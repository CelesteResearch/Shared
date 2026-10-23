#pragma once
#include "Direct3D12EffectSnapshot.h"
#include "Direct3D12EffectProgram.h"
#include <d3d12.h>
#include <unordered_map>
struct Direct3D12EffectCache : std::enable_shared_from_this<Direct3D12EffectCache>
{
    std::shared_ptr<Direct3D12EffectSnapshot> Apply(void* effect, uint32_t pass, void* changes);
    std::shared_ptr<const Direct3D12EffectProgram> Prepare(const Direct3D12EffectSnapshot& snapshot,
                                                           const D3D12_INPUT_ELEMENT_DESC* elements, size_t count);

  private:
    std::vector<std::shared_ptr<Direct3D12EffectSnapshot>> snapshots;
    size_t nextSnapshot = 0;
    std::string programLookup;
    std::shared_ptr<Direct3D12EffectSnapshot> AcquireSnapshot();
    std::unordered_map<const void*, std::shared_ptr<Direct3D12EffectShaderLease>> shaders;
    std::unordered_map<std::string, std::shared_ptr<const Direct3D12EffectProgram>> programs;
};
