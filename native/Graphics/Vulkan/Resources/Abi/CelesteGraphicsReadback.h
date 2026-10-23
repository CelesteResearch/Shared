#pragma once
#include "VulkanReadbackState.h"
struct CelesteGraphicsReadback final
{
    std::shared_ptr<VulkanReadbackState> state;
};
