cmake_minimum_required(VERSION 3.24)
project(CelesteGraphicsVulkan LANGUAGES CXX)

add_library(
    CelesteGraphicsVulkan SHARED
    CelesteVulkanDeviceApi.cpp
    Device/CelesteGraphicsDevice.cpp
    Device/VulkanDeviceApiTable.cpp
    Device/VulkanDevicePackets.cpp
    Draw/Buffers/UniformBufferPool.cpp
    Draw/Commands/ClearCommand.cpp
    Draw/Commands/DrawCommand.cpp
    Draw/Commands/InitializeNullTextureCommand.cpp
    Draw/Effects/EffectConstantStorage.cpp
    Draw/Effects/EffectProgram.cpp
    Draw/Effects/EffectProgramCache.cpp
    Draw/Effects/EffectShaderLease.cpp
    Draw/Effects/EffectSnapshotCache.cpp
    Draw/Pipelines/DrawPipelineCache.cpp
    Draw/Pipelines/SpritePipeline.cpp
    Draw/Pipelines/SpritePipelineObjects.cpp
    Draw/State/DrawLogicalState.cpp
    Draw/State/NullTextureCache.cpp
    Draw/State/SourceVulkanConversions.cpp
    Draw/State/SourceVulkanDepthStencil.cpp
    Draw/State/VulkanDrawContext.cpp
    Draw/State/VulkanDrawState.cpp
    Draw/VulkanDrawApi.cpp
    Packets/CelesteGraphicsPacket.cpp
    Packets/VulkanPacketApi.cpp
    Packets/VulkanPacketCompletion.cpp
    Presentation/VulkanPresentationApi.cpp
    Resources/Abi/VulkanBufferApi.cpp
    Resources/Abi/VulkanReadbackApi.cpp
    Resources/Abi/VulkanTextureApi.cpp
    Resources/Depth/DepthStencilAttachment.cpp
    Resources/Depth/DepthStencilRecording.cpp
    Resources/Depth/VulkanColorRenderbufferApi.cpp
    Resources/Depth/VulkanDepthApi.cpp
    Resources/ImageRecording.cpp
    Resources/ResourceContext.cpp
    Resources/TextureBytes.cpp
    Resources/TextureFormat.cpp
    Resources/TextureImage.cpp
    Resources/TransferBuffer.cpp
    Resources/TransferBufferPool.cpp
    VulkanApiErrors.cpp
    VulkanLibrary.cpp
    VulkanOutputApi.cpp
    VulkanSubmissionQueue.cpp)
target_compile_features(CelesteGraphicsVulkan PRIVATE cxx_std_17)
target_compile_definitions(CelesteGraphicsVulkan PRIVATE VK_NO_PROTOTYPES VK_ENABLE_BETA_EXTENSIONS
                                                         MOJOSHADER_EFFECT_SUPPORT)
target_include_directories(
    CelesteGraphicsVulkan
    PRIVATE "${CMAKE_CURRENT_SOURCE_DIR}/."
            "${CMAKE_CURRENT_SOURCE_DIR}/Device"
            "${CMAKE_CURRENT_SOURCE_DIR}/Packets"
            "${CMAKE_CURRENT_SOURCE_DIR}/Presentation"
            "${CMAKE_CURRENT_SOURCE_DIR}/Resources"
            "${CMAKE_CURRENT_SOURCE_DIR}/Resources/Abi"
            "${CMAKE_CURRENT_SOURCE_DIR}/Resources/Depth"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/Buffers"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/Commands"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/Effects"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/Pipelines"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/State"
            "${CMAKE_CURRENT_SOURCE_DIR}/../../Effects"
            "${CMAKE_CURRENT_SOURCE_DIR}/../../../vendor/mojoshader-ad5dff84830c2863c841f4b1f4e3df78c705b383"
            "${CMAKE_CURRENT_SOURCE_DIR}/../Include"
            "${CMAKE_CURRENT_SOURCE_DIR}/../../../vendor/Vulkan-Headers-1.3.239")
target_link_libraries(CelesteGraphicsVulkan PRIVATE CelesteGraphicsEffects)
target_sources(
    CelesteGraphicsVulkan PRIVATE Window/CelesteVulkanWindow.Device.cpp Window/CelesteVulkanWindow.Presentation.cpp
                                  Window/CelesteVulkanWindow.Api.cpp Window/CelesteVulkanWindow.Surface.cpp)
if(APPLE)
    enable_language(OBJCXX)
    target_sources(CelesteGraphicsVulkan PRIVATE Window/CelesteVulkanWindow.Metal.mm)
    target_link_libraries(CelesteGraphicsVulkan PRIVATE "-framework Cocoa" "-framework QuartzCore")
endif()
if(WIN32)
    target_sources(CelesteGraphicsVulkan PRIVATE CelesteGraphicsVulkan.def)
    target_link_libraries(CelesteGraphicsVulkan PRIVATE user32)
    target_compile_options(CelesteGraphicsVulkan PRIVATE /utf-8)
elseif(UNIX AND NOT APPLE)
    target_link_libraries(CelesteGraphicsVulkan PRIVATE dl)
endif()
