#include "SpritePipeline.h"
#include <stdexcept>
#include <string>

namespace Celeste::Graphics::Vulkan
{
    static void Check(VkResult result, const char* operation)
    {
        if (result != VK_SUCCESS)
            throw std::runtime_error(std::string(operation) + ": " + std::to_string(result));
    }
    template <class T> static T& Required(const std::shared_ptr<T>& owner)
    {
        if (!owner)
            throw std::invalid_argument("Missing pipeline resource owner");
        return *owner;
    }
    SpritePipeline::SpritePipeline(std::shared_ptr<ResourceContext> owner, std::shared_ptr<TextureImage> output,
                                   const SpritePipelineInfo& info, std::shared_ptr<SpritePipelineObjects> cachedObjects)
        : objects(std::move(cachedObjects)), contextOwner(std::move(owner)), targetOwner(std::move(output)),
          context(Required(contextOwner)), target(Required(targetOwner)), targetLevel(info.targetLevel),
          targetLayer(info.targetLayer), depthAttachment(info.depthAttachment), images(info.sampledImages)
    {
        if (context.native.apiVersion < VK_API_VERSION_1_1)
            throw std::invalid_argument("Sprite pipeline requires enabled Vulkan 1.1 for negative viewport height");
        if (info.polygonMode != VK_POLYGON_MODE_FILL && !context.native.enabledFeatures.fillModeNonSolid)
            throw std::invalid_argument("Non-solid rasterization was not enabled on this device");
        const uint32_t portability = context.native.portabilityFeatures;
        if ((portability & CelesteVulkanPortabilitySubset) &&
            !(portability & CelesteVulkanPortabilitySeparateStencilMaskReference) &&
            info.depthState.stencilTestEnable && info.cullMode == VK_CULL_MODE_NONE &&
            (info.depthState.front.compareMask != info.depthState.back.compareMask ||
             info.depthState.front.writeMask != info.depthState.back.writeMask ||
             info.depthState.front.reference != info.depthState.back.reference))
            throw std::invalid_argument(
                "Separate stencil masks and references were not enabled on this portability device");
        auto requireColorBlend = [&](const VkPipelineColorBlendAttachmentState& blend) {
            if ((portability & CelesteVulkanPortabilitySubset) &&
                !(portability & CelesteVulkanPortabilityConstantAlphaColorBlendFactors) && blend.blendEnable &&
                (blend.srcColorBlendFactor == VK_BLEND_FACTOR_CONSTANT_ALPHA ||
                 blend.srcColorBlendFactor == VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_ALPHA ||
                 blend.dstColorBlendFactor == VK_BLEND_FACTOR_CONSTANT_ALPHA ||
                 blend.dstColorBlendFactor == VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_ALPHA))
                throw std::invalid_argument("Constant-alpha color blending was not enabled on this portability device");
        };
        requireColorBlend(info.blend);
        colorTargetCount = info.colorTargetCount;
        additionalTargets = info.additionalTargets;
        if (colorTargetCount < 1 || colorTargetCount > 4)
            throw std::invalid_argument("Invalid color attachment count");
        const auto mipExtent = target.MipExtent(targetLevel);
        targetExtent = {mipExtent.width, mipExtent.height};
        const auto targetView = target.attachments.at(target.StateIndex(targetLevel, targetLayer));
        if (!targetView)
            throw std::invalid_argument("Texture lacks a renderable attachment view");
        if (depthAttachment &&
            (&depthAttachment->context != &context || depthAttachment->extent.width != targetExtent.width ||
             depthAttachment->extent.height != targetExtent.height || depthAttachment->samples != target.samples))
            throw std::invalid_argument("Depth attachment does not match color target");
        if (&target.context != &context)
            throw std::invalid_argument("Target device mismatch");
        for (uint32_t i = 0; i + 1 < colorTargetCount; ++i)
        {
            const auto& color = additionalTargets[i];
            if (!color.image || &color.image->context != &context)
                throw std::invalid_argument("Color attachment device mismatch");
            const auto extent = color.image->MipExtent(color.level);
            if (extent.width != targetExtent.width || extent.height != targetExtent.height ||
                color.image->samples != target.samples)
                throw std::invalid_argument("Color attachment extent or samples differ");
            if (!color.image->attachments.at(color.image->StateIndex(color.level, color.layer)))
                throw std::invalid_argument("Color attachment has no renderable view");
            const auto& a = info.additionalBlends[i];
            requireColorBlend(a);
            const auto& b = info.blend;
            const bool different = a.blendEnable != b.blendEnable || a.srcColorBlendFactor != b.srcColorBlendFactor ||
                                   a.dstColorBlendFactor != b.dstColorBlendFactor || a.colorBlendOp != b.colorBlendOp ||
                                   a.srcAlphaBlendFactor != b.srcAlphaBlendFactor ||
                                   a.dstAlphaBlendFactor != b.dstAlphaBlendFactor || a.alphaBlendOp != b.alphaBlendOp ||
                                   a.colorWriteMask != b.colorWriteMask;
            if (!context.native.enabledFeatures.independentBlend && different)
                throw std::invalid_argument("Different color blend states require enabled independentBlend");
            if (color.image.get() == &target && color.level == targetLevel && color.layer == targetLayer)
                throw std::invalid_argument("Duplicate color attachment subresource");
            for (uint32_t j = 0; j < i; ++j)
                if (color.image == additionalTargets[j].image && color.level == additionalTargets[j].level &&
                    color.layer == additionalTargets[j].layer)
                    throw std::invalid_argument("Duplicate color attachment subresource");
        }
        for (const auto& stage : images)
            for (const auto& binding : stage)
            {
                if (!binding.image || &binding.image->context != &context || binding.image.get() == &target ||
                    binding.image->samples != VK_SAMPLE_COUNT_1_BIT)
                    throw std::invalid_argument("Sampled image mismatch or attachment feedback");
                for (uint32_t i = 0; i + 1 < colorTargetCount; ++i)
                    if (binding.image == additionalTargets[i].image)
                        throw std::invalid_argument("Sampled image is also a color attachment");
                const bool linear = binding.sampler.minFilter == VK_FILTER_LINEAR ||
                                    binding.sampler.magFilter == VK_FILTER_LINEAR ||
                                    binding.sampler.mipmapMode == VK_SAMPLER_MIPMAP_MODE_LINEAR;
                if (linear && !(binding.image->formatFeatures & VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_LINEAR_BIT))
                    throw std::invalid_argument("Sampled format does not support requested linear filtering");
            }
#define LOAD(name) name = reinterpret_cast<PFN_vk##name>(context.native.getDeviceProcAddr(context.native.device, "vk" #name)); if (!name) throw std::runtime_error("Missing vk" #name);
        LOAD(CreateShaderModule)
        LOAD(DestroyShaderModule)
        LOAD(CreateDescriptorSetLayout)
        LOAD(DestroyDescriptorSetLayout)
        LOAD(CreateDescriptorPool)
        LOAD(DestroyDescriptorPool)
        LOAD(AllocateDescriptorSets)
        LOAD(UpdateDescriptorSets)
        LOAD(CreateSampler)
        LOAD(DestroySampler)
        LOAD(CreatePipelineLayout)
        LOAD(DestroyPipelineLayout)
        LOAD(CreateRenderPass)
        LOAD(DestroyRenderPass)
        LOAD(CreateFramebuffer)
        LOAD(DestroyFramebuffer)
        LOAD(CreateGraphicsPipelines)
        LOAD(DestroyPipeline)
        LOAD(CmdBeginRenderPass)
        LOAD(CmdEndRenderPass)
        LOAD(CmdBindPipeline)
        LOAD(CmdBindDescriptorSets)
        LOAD(CmdBindVertexBuffers)
        LOAD(CmdBindIndexBuffer)
        LOAD(CmdDrawIndexed)
        LOAD(CmdSetViewport)
        LOAD(CmdSetScissor)
        LOAD(CmdSetBlendConstants)
        LOAD(CmdDraw)
        LOAD(CmdSetStencilReference)
        LOAD(CmdSetDepthBias)
#undef LOAD
        if (!objects)
        {
            const auto query = reinterpret_cast<PFN_vkGetPhysicalDeviceFormatProperties>(
                context.native.getInstanceProcAddr(context.native.instance, "vkGetPhysicalDeviceFormatProperties"));
            if (!query)
                throw std::runtime_error("Missing vkGetPhysicalDeviceFormatProperties");
            for (const auto& attribute : info.attributes)
            {
                VkFormatProperties properties{};
                query(context.native.physicalDevice, attribute.format, &properties);
                if (!(properties.bufferFeatures & VK_FORMAT_FEATURE_VERTEX_BUFFER_BIT))
                    throw std::invalid_argument("Vertex layout requires an unsupported physical format");
            }
        }
        const auto device = context.native.device;
        if (objects)
        {
            if (objects->context.get() != &context)
                throw std::invalid_argument("Cached pipeline device mismatch");
            shaders = objects->shaders;
            setLayouts = objects->setLayouts;
            layout = objects->layout;
            renderPass = objects->renderPass;
            pipeline = objects->pipeline;
        }
        const auto uniformType =
            info.dynamicConstants ? VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC : VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER;
        try
        {
            const ShaderBinary binaries[] = {info.vertex, info.pixel};
            VkPipelineShaderStageCreateInfo stages[2]{};
            if (!objects)
                for (uint32_t stage = 0; stage < 2; ++stage)
                {
                    if (!binaries[stage].words || !binaries[stage].byteCount || binaries[stage].byteCount % 4 ||
                        !binaries[stage].entryPoint)
                        throw std::invalid_argument("Invalid linked SPIRV binary");
                    VkShaderModuleCreateInfo module{VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO};
                    module.codeSize = binaries[stage].byteCount;
                    module.pCode = binaries[stage].words;
                    Check(CreateShaderModule(device, &module, nullptr, &shaders[stage]), "CreateShaderModule");
                    stages[stage].sType = VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO;
                    stages[stage].stage = stage == 0 ? VK_SHADER_STAGE_VERTEX_BIT : VK_SHADER_STAGE_FRAGMENT_BIT;
                    stages[stage].module = shaders[stage];
                    stages[stage].pName = binaries[stage].entryPoint;
                    std::vector<VkDescriptorSetLayoutBinding> bindings;
                    for (const auto& image : images[stage])
                    {
                        for (const auto& previous : bindings)
                            if (previous.binding == image.slot)
                                throw std::invalid_argument("Duplicate sampler binding");
                        bindings.push_back({image.slot, VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, 1,
                                            static_cast<VkShaderStageFlags>(stages[stage].stage), nullptr});
                    }
                    VkDescriptorSetLayoutCreateInfo set{VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO};
                    set.bindingCount = static_cast<uint32_t>(bindings.size());
                    set.pBindings = bindings.data();
                    Check(CreateDescriptorSetLayout(device, &set, nullptr, &setLayouts[stage * 2]),
                          "CreateSamplerLayout");
                    VkDescriptorSetLayoutBinding uniform{0, uniformType, 1,
                                                         static_cast<VkShaderStageFlags>(stages[stage].stage), nullptr};
                    set.bindingCount = info.constants[stage].buffer ? 1 : 0;
                    set.pBindings = &uniform;
                    Check(CreateDescriptorSetLayout(device, &set, nullptr, &setLayouts[stage * 2 + 1]),
                          "CreateUniformLayout");
                }
            VkPipelineLayoutCreateInfo pipelineLayout{VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO};
            pipelineLayout.setLayoutCount = 4;
            pipelineLayout.pSetLayouts = setLayouts.data();
            if (!objects)
                Check(CreatePipelineLayout(device, &pipelineLayout, nullptr, &layout), "CreatePipelineLayout");
            uint32_t imageCount = static_cast<uint32_t>(images[0].size() + images[1].size());
            std::vector<VkDescriptorPoolSize> poolSizes;
            if (imageCount)
                poolSizes.push_back({VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, imageCount});
            const uint32_t uniformCount = (info.constants[0].buffer ? 1 : 0) + (info.constants[1].buffer ? 1 : 0);
            if (uniformCount)
                poolSizes.push_back({uniformType, uniformCount});
            VkDescriptorPoolCreateInfo descriptorPool{VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO};
            descriptorPool.maxSets = 4;
            descriptorPool.poolSizeCount = static_cast<uint32_t>(poolSizes.size());
            descriptorPool.pPoolSizes = poolSizes.data();
            Check(CreateDescriptorPool(device, &descriptorPool, nullptr, &pool), "CreateDescriptorPool");
            VkDescriptorSetAllocateInfo allocation{VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO};
            allocation.descriptorPool = pool;
            allocation.descriptorSetCount = 4;
            allocation.pSetLayouts = setLayouts.data();
            Check(AllocateDescriptorSets(device, &allocation, sets.data()), "AllocateDescriptorSets");
            samplers.reserve(imageCount);
            for (uint32_t stage = 0; stage < 2; ++stage)
            {
                for (const auto& image : images[stage])
                {
                    VkSampler sampler = VK_NULL_HANDLE;
                    Check(CreateSampler(device, &image.sampler, nullptr, &sampler), "CreateSampler");
                    samplers.push_back(sampler);
                    VkDescriptorImageInfo descriptor{sampler, image.image->view,
                                                     VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL};
                    VkWriteDescriptorSet write{VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET};
                    write.dstSet = sets[stage * 2];
                    write.dstBinding = image.slot;
                    write.descriptorCount = 1;
                    write.descriptorType = VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER;
                    write.pImageInfo = &descriptor;
                    UpdateDescriptorSets(device, 1, &write, 0, nullptr);
                }
                if (info.constants[stage].buffer)
                {
                    VkWriteDescriptorSet write{VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET};
                    write.dstSet = sets[stage * 2 + 1];
                    write.descriptorCount = 1;
                    write.descriptorType = uniformType;
                    write.pBufferInfo = &info.constants[stage];
                    UpdateDescriptorSets(device, 1, &write, 0, nullptr);
                }
            }
            VkAttachmentDescription attachments[5]{};
            VkAttachmentReference references[4]{};
            VkImageView attachmentViews[5]{};
            VkPipelineColorBlendAttachmentState colorBlends[4]{};
            for (uint32_t i = 0; i < colorTargetCount; ++i)
            {
                const auto& image = i ? *additionalTargets[i - 1].image : target;
                const auto level = i ? additionalTargets[i - 1].level : targetLevel;
                const auto layer = i ? additionalTargets[i - 1].layer : targetLayer;
                auto& attachment = attachments[i];
                attachment.format = image.format.native;
                attachment.samples = image.samples;
                attachment.loadOp = VK_ATTACHMENT_LOAD_OP_LOAD;
                attachment.storeOp = VK_ATTACHMENT_STORE_OP_STORE;
                attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
                attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
                attachment.initialLayout = attachment.finalLayout = VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;
                references[i] = {i, VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL};
                attachmentViews[i] = image.attachments[image.StateIndex(level, layer)];
                colorBlends[i] = i ? info.additionalBlends[i - 1] : info.blend;
            }
            VkSubpassDescription subpass{};
            subpass.pipelineBindPoint = VK_PIPELINE_BIND_POINT_GRAPHICS;
            subpass.colorAttachmentCount = colorTargetCount;
            subpass.pColorAttachments = references;
            VkAttachmentReference depthReference{colorTargetCount, VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL};
            if (depthAttachment)
            {
                auto& depth = attachments[colorTargetCount];
                depth.format = depthAttachment->format;
                depth.samples = depthAttachment->samples;
                depth.loadOp = depth.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_LOAD;
                depth.storeOp = depth.stencilStoreOp = VK_ATTACHMENT_STORE_OP_STORE;
                depth.initialLayout = depth.finalLayout = VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL;
                subpass.pDepthStencilAttachment = &depthReference;
                attachmentViews[colorTargetCount] = depthAttachment->view;
            }
            const auto attachmentCount = colorTargetCount + (depthAttachment ? 1u : 0u);
            VkRenderPassCreateInfo pass{VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO};
            pass.attachmentCount = attachmentCount;
            pass.pAttachments = attachments;
            pass.subpassCount = 1;
            pass.pSubpasses = &subpass;
            if (!objects)
                Check(CreateRenderPass(device, &pass, nullptr, &renderPass), "CreateRenderPass");
            VkFramebufferCreateInfo frame{VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO};
            frame.renderPass = renderPass;
            frame.attachmentCount = attachmentCount;
            frame.pAttachments = attachmentViews;
            frame.width = targetExtent.width;
            frame.height = targetExtent.height;
            frame.layers = 1;
            Check(CreateFramebuffer(device, &frame, nullptr, &framebuffer), "CreateFramebuffer");
            VkVertexInputBindingDescription binding{0, info.vertexStride, VK_VERTEX_INPUT_RATE_VERTEX};
            VkPipelineVertexInputStateCreateInfo vertex{VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO};
            vertex.vertexBindingDescriptionCount =
                info.vertexBindings.empty() ? 1 : static_cast<uint32_t>(info.vertexBindings.size());
            vertex.pVertexBindingDescriptions = info.vertexBindings.empty() ? &binding : info.vertexBindings.data();
            vertex.vertexAttributeDescriptionCount = static_cast<uint32_t>(info.attributes.size());
            vertex.pVertexAttributeDescriptions = info.attributes.data();
            VkPipelineInputAssemblyStateCreateInfo assembly{
                VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO};
            assembly.topology = info.topology;
            VkPipelineViewportStateCreateInfo view{VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO};
            view.viewportCount = view.scissorCount = 1;
            const VkDynamicState dynamicStates[] = {VK_DYNAMIC_STATE_VIEWPORT, VK_DYNAMIC_STATE_SCISSOR,
                                                    VK_DYNAMIC_STATE_BLEND_CONSTANTS,
                                                    VK_DYNAMIC_STATE_STENCIL_REFERENCE, VK_DYNAMIC_STATE_DEPTH_BIAS};
            VkPipelineDynamicStateCreateInfo dynamic{VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO};
            dynamic.dynamicStateCount = 5;
            dynamic.pDynamicStates = dynamicStates;
            VkPipelineRasterizationStateCreateInfo raster{VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO};
            raster.polygonMode = info.polygonMode;
            raster.depthBiasEnable = VK_TRUE;
            raster.cullMode = info.cullMode;
            raster.frontFace = VK_FRONT_FACE_COUNTER_CLOCKWISE;
            raster.lineWidth = 1;
            VkPipelineMultisampleStateCreateInfo multisample{VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO};
            multisample.rasterizationSamples = target.samples;
            const VkSampleMask sampleMasks[] = {info.sampleMask, UINT32_MAX};
            multisample.pSampleMask = sampleMasks;
            VkPipelineColorBlendStateCreateInfo blend{VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO};
            blend.attachmentCount = colorTargetCount;
            blend.pAttachments = colorBlends;
            VkGraphicsPipelineCreateInfo graphics{VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO};
            graphics.pDepthStencilState = &info.depthState;
            graphics.pDynamicState = &dynamic;
            graphics.stageCount = 2;
            graphics.pStages = stages;
            graphics.pVertexInputState = &vertex;
            graphics.pInputAssemblyState = &assembly;
            graphics.pViewportState = &view;
            graphics.pRasterizationState = &raster;
            graphics.pMultisampleState = &multisample;
            graphics.pColorBlendState = &blend;
            graphics.layout = layout;
            graphics.renderPass = renderPass;
            if (!objects)
            {
                Check(CreateGraphicsPipelines(device, VK_NULL_HANDLE, 1, &graphics, nullptr, &pipeline),
                      "CreateGraphicsPipelines");
                objects = std::make_shared<SpritePipelineObjects>(contextOwner);
                objects->shaders = shaders;
                objects->setLayouts = setLayouts;
                objects->layout = layout;
                objects->renderPass = renderPass;
                objects->pipeline = pipeline;
            }
        }
        catch (...)
        {
            Release();
            throw;
        }
    }
    SpritePipeline::~SpritePipeline()
    {
        Release();
    }
    void SpritePipeline::Release() noexcept
    {
        const auto device = context.native.device;
        if (!objects && pipeline)
            DestroyPipeline(device, pipeline, nullptr);
        if (framebuffer)
            DestroyFramebuffer(device, framebuffer, nullptr);
        if (!objects && renderPass)
            DestroyRenderPass(device, renderPass, nullptr);
        if (pool)
            DestroyDescriptorPool(device, pool, nullptr);
        for (auto sampler : samplers)
            DestroySampler(device, sampler, nullptr);
        if (!objects && layout)
            DestroyPipelineLayout(device, layout, nullptr);
        for (auto set : setLayouts)
            if (!objects && set)
                DestroyDescriptorSetLayout(device, set, nullptr);
        for (auto shader : shaders)
            if (!objects && shader)
                DestroyShaderModule(device, shader, nullptr);
    }
    void SpritePipeline::PrepareRecording(const ImageRecording& recording, const DepthStencilRecording* depth) const
    {
        recording.Validate(target);
        for (uint32_t i = 0; i + 1 < colorTargetCount; ++i)
            recording.Validate(*additionalTargets[i].image);
        for (const auto& stage : images)
            for (const auto& image : stage)
                recording.Validate(*image.image);
        if (depthAttachment)
        {
            if (!depth)
                throw std::invalid_argument("Depth attachment needs a prepared recording transaction");
            depth->Validate(*depthAttachment);
        }
    }
    void SpritePipeline::Record(ImageRecording& recording, VkBuffer vertices, VkBuffer indices, uint32_t indexCount,
                                VkIndexType indexType, const uint32_t* dynamicOffsets, uint32_t dynamicOffsetCount,
                                DepthStencilRecording* depth) noexcept
    {
        SpriteDrawArguments arguments;
        arguments.vertices = vertices;
        arguments.indices = indices;
        arguments.count = indexCount;
        arguments.indexType = indexType;
        arguments.viewport = {0,
                              static_cast<float>(targetExtent.height),
                              static_cast<float>(targetExtent.width),
                              -static_cast<float>(targetExtent.height),
                              0,
                              1};
        arguments.scissor = {{0, 0}, targetExtent};
        arguments.dynamicOffsets = dynamicOffsets;
        arguments.dynamicOffsetCount = dynamicOffsetCount;
        arguments.depthRecording = depth;
        Record(recording, arguments);
    }
    void SpritePipeline::Record(ImageRecording& recording, const SpriteDrawArguments& arguments) noexcept
    {
        const auto commands = recording.Commands();
        for (uint32_t stage = 0; stage < 2; ++stage)
            for (const auto& image : images[stage])
                recording.Transition(*image.image, VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                                     VK_PIPELINE_STAGE_VERTEX_SHADER_BIT | VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT,
                                     VK_ACCESS_SHADER_READ_BIT);
        recording.Transition(target, targetLevel, targetLayer, VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                             VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT,
                             VK_ACCESS_COLOR_ATTACHMENT_READ_BIT | VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT);
        for (uint32_t i = 0; i + 1 < colorTargetCount; ++i)
        {
            const auto& color = additionalTargets[i];
            recording.Transition(*color.image, color.level, color.layer, VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                                 VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT,
                                 VK_ACCESS_COLOR_ATTACHMENT_READ_BIT | VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT);
        }
        if (depthAttachment)
            arguments.depthRecording->Transition(
                *depthAttachment, VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL,
                VK_PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT | VK_PIPELINE_STAGE_LATE_FRAGMENT_TESTS_BIT,
                VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_READ_BIT | VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT);
        VkRenderPassBeginInfo begin{VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO};
        begin.renderPass = renderPass;
        begin.framebuffer = framebuffer;
        begin.renderArea.extent = targetExtent;
        CmdBeginRenderPass(commands, &begin, VK_SUBPASS_CONTENTS_INLINE);
        CmdBindPipeline(commands, VK_PIPELINE_BIND_POINT_GRAPHICS, pipeline);
        CmdSetViewport(commands, 0, 1, &arguments.viewport);
        CmdSetScissor(commands, 0, 1, &arguments.scissor);
        CmdSetBlendConstants(commands, arguments.blendConstants);
        CmdSetDepthBias(commands, arguments.depthBiasConstant, 0, arguments.depthBiasSlope);
        CmdSetStencilReference(commands, VK_STENCIL_FACE_FRONT_AND_BACK, arguments.stencilReference);
        CmdBindDescriptorSets(commands, VK_PIPELINE_BIND_POINT_GRAPHICS, layout, 0, 4, sets.data(),
                              arguments.dynamicOffsetCount, arguments.dynamicOffsets);
        CmdBindVertexBuffers(commands, 0, arguments.vertexBindingCount ? arguments.vertexBindingCount : 1,
                             arguments.vertexBindingCount ? arguments.vertexBuffers : &arguments.vertices,
                             arguments.vertexBindingCount ? arguments.vertexOffsets : &arguments.vertexOffset);
        if (arguments.indices)
        {
            CmdBindIndexBuffer(commands, arguments.indices, 0, arguments.indexType);
            CmdDrawIndexed(commands, arguments.count, arguments.instances, arguments.first, arguments.baseVertex, 0);
        }
        else
            CmdDraw(commands, arguments.count, arguments.instances, arguments.first, 0);
        CmdEndRenderPass(commands);
    }
}
