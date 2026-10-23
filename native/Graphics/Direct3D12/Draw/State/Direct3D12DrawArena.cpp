#include "Direct3D12DrawArenaPool.h"
#include "CelesteGraphicsPacket.h"
#include <stdexcept>
uint32_t Direct3D12DrawArena::AddDraw()
{
    if (drawCount == UINT32_MAX)
        throw std::length_error("Draw arena index overflow");
    if (drawCount == draws.size())
        draws.emplace_back();
    return drawCount++;
}
uint32_t Direct3D12DrawArena::AddClear()
{
    if (clearCount == UINT32_MAX)
        throw std::length_error("Clear arena index overflow");
    if (clearCount == clears.size())
        clears.emplace_back();
    return clearCount++;
}
void Direct3D12DrawArena::Reset() noexcept
{
    for (uint32_t i = 0; i < drawCount; ++i)
        draws[i] = Direct3D12PreparedDraw{};
    for (uint32_t i = 0; i < clearCount; ++i)
        clears[i] = Direct3D12PreparedTargets{};
    drawCount = clearCount = 0;
}
std::shared_ptr<Direct3D12DrawArena> Direct3D12DrawArenaPool::Acquire()
{
    for (auto& arena : arenas)
        if (arena.use_count() == 1)
        {
            arena->Reset();
            return arena;
        }
    auto arena = std::make_shared<Direct3D12DrawArena>();
    arenas.push_back(arena);
    return arena;
}
Direct3D12DrawArena& GetDrawArena(CelesteGraphicsPacket& packet)
{
    if (!packet.drawArena)
    {
        auto& pool = packet.Owner().drawArenas;
        if (!pool)
            pool = std::make_shared<Direct3D12DrawArenaPool>();
        packet.drawArena = pool->Acquire();
        packet.Retain(packet.drawArena);
    }
    return *packet.drawArena;
}
