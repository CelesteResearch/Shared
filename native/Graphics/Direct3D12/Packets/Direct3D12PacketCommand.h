#pragma once
#include <cstddef>
struct CelesteGraphicsPacket;
struct Direct3D12PacketRecordContext;
using Direct3D12PacketPrepare = void (*)(CelesteGraphicsPacket&, void*);
using Direct3D12PacketRecord = void (*)(CelesteGraphicsPacket&, const void*, Direct3D12PacketRecordContext&) noexcept;
using Direct3D12PacketCommit = void (*)(CelesteGraphicsPacket&, const void*) noexcept;
struct Direct3D12PacketCommand
{
    size_t offset;
    Direct3D12PacketPrepare prepare;
    Direct3D12PacketRecord record;
    Direct3D12PacketCommit commit;
};
