#pragma once
#include <memory>
struct VulkanPacketCompletion;
struct CelesteGraphicsSubmission final
{
    std::shared_ptr<VulkanPacketCompletion> completion;
};
