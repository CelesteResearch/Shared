#pragma once
#include "Direct3D12DrawArena.h"
struct Direct3D12DrawArenaPool
{
    std::vector<std::shared_ptr<Direct3D12DrawArena>> arenas;
    std::shared_ptr<Direct3D12DrawArena> Acquire();
};
