#pragma once
#include "CelesteGraphicsPacket.h"
namespace Celeste::Graphics::Direct3D12
{
    struct PresentCommand
    {
        uint32_t source, output, prepared = UINT32_MAX;
        CelesteGraphicsRect from, to;
        bool copy = false;
        static void Prepare(CelesteGraphicsPacket&, void*);
        static void Record(CelesteGraphicsPacket&, const void*, Direct3D12PacketRecordContext&) noexcept;
    };
}
