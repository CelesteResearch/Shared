#pragma once
#include "Direct3D12PreparedDraw.h"
#include <vector>
struct Direct3D12DrawArena
{
    std::vector<Direct3D12PreparedDraw> draws;
    std::vector<Direct3D12PreparedTargets> clears;
    uint32_t drawCount = 0, clearCount = 0;
    uint32_t AddDraw();
    uint32_t AddClear();
    void Reset() noexcept;
};
struct CelesteGraphicsPacket;
Direct3D12DrawArena& GetDrawArena(CelesteGraphicsPacket&);
