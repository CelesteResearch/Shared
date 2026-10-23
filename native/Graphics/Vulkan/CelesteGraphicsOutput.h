#pragma once
#include "VulkanOutputState.h"
#include <memory>
struct CelesteGraphicsOutput final
{
    std::shared_ptr<VulkanOutputState> state;
};
