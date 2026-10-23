#include "Direct3D12EffectCache.h"
#include "Direct3D12Shaders.h"
#include <stdexcept>
#include <cstring>
static void CheckEffect(int result)
{
    if (!result)
        throw std::runtime_error(CelesteEffectGetError());
}
std::shared_ptr<Direct3D12EffectSnapshot> Direct3D12EffectCache::AcquireSnapshot()
{
    // Owner-thread pool. A slot is reusable only when no state/packet/fence loan remains.
    // Its shared control block and both vector capacities survive every reuse.
    for (size_t scanned = 0; scanned < snapshots.size(); scanned++)
    {
        auto index = nextSnapshot;
        nextSnapshot = (nextSnapshot + 1) % snapshots.size();
        if (snapshots[index].use_count() == 1)
            return snapshots[index];
    }
    auto snapshot = std::make_shared<Direct3D12EffectSnapshot>();
    snapshot->cache = shared_from_this();
    snapshots.push_back(snapshot);
    return snapshot;
}
std::shared_ptr<Direct3D12EffectSnapshot> Direct3D12EffectCache::Apply(void* effect, uint32_t pass, void* changes)
{
    // Source-visible Apply remains synchronous, before parameter writes can change it.
    CheckEffect(CelesteEffectApply(effect, pass, changes));
    CelesteEffectRegisterView registers{};
    CheckEffect(CelesteEffectBorrowRegisters(effect, &registers));
    const void* identities[] = {registers.vertexIdentity, registers.pixelIdentity};
    auto snapshot = AcquireSnapshot();
    for (int stage = 0; stage < 2; stage++)
    {
        if (!identities[stage])
            throw std::runtime_error("D3D12 draw requires both applied shader stages");
        auto found = shaders.find(identities[stage]);
        if (found == shaders.end())
            found =
                shaders.emplace(identities[stage], std::make_shared<Direct3D12EffectShaderLease>(effect, stage == 0))
                    .first;
        snapshot->shaders[stage] = found->second;
        auto& constants = snapshot->constants[stage];
        constants.resize(found->second->description.constantBufferBytes);
        CheckEffect(CelesteEffectCopyHlslConstants(effect, stage == 0, constants.data(),
                                                   static_cast<uint32_t>(constants.size())));
    }
    return snapshot;
}
std::shared_ptr<const Direct3D12EffectProgram> Direct3D12EffectCache::Prepare(const Direct3D12EffectSnapshot& snapshot,
                                                                              const D3D12_INPUT_ELEMENT_DESC* elements,
                                                                              size_t count)
{
    // Device-owned cache keeps shader leases alive: pointer identities cannot be recycled.
    // Fast lookup uses only shader identities and consumed signature interpretation.
    auto& key = programLookup;
    key.clear();
    key.reserve(2 * sizeof(void*) + count * 20);
    for (auto& shader : snapshot.shaders)
    {
        auto identity = shader->description.identity;
        key.append(reinterpret_cast<const char*>(&identity), sizeof(identity));
    }
    for (size_t i = 0; i < count; i++)
    {
        auto& element = elements[i];
        key += element.SemanticName;
        key += '\0';
        key.append(reinterpret_cast<const char*>(&element.SemanticIndex), sizeof(element.SemanticIndex));
        key.append(reinterpret_cast<const char*>(&element.Format), sizeof(element.Format));
    }
    auto found = programs.find(key);
    if (found != programs.end())
        return found->second;
    auto prepared = Celeste::Graphics::Direct3D12::PrepareShaders(snapshot.shaders[0]->description,
                                                                  snapshot.shaders[1]->description, elements, count);
    auto result = std::make_shared<Direct3D12EffectProgram>();
    result->shaders = Celeste::Graphics::Direct3D12::CompileShaders(prepared);
    result->cacheKey = std::move(prepared.cacheKey);
    programs.emplace(key, result);
    return result;
}
