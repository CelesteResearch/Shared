#pragma once
#include "Direct3D12PacketCompletion.h"
#include "BufferResource.h"
#include "TransferFootprint.h"
#include <optional>
struct CelesteGraphicsReadback
{
    std::shared_ptr<Direct3D12PacketCompletion> completion;
    std::shared_ptr<Celeste::Graphics::Direct3D12::BufferResource> staging;
    std::optional<Celeste::Graphics::Direct3D12::TransferFootprint> footprint;
    std::vector<uint8_t> bytes;
    bool unchanged = false, copied = false;
};
