#pragma once
#include "Direct3D12PacketCommand.h"
#include "Direct3D12PacketCompletion.h"
#include "CelesteGraphicsDirect3D12.h"
#include "GpuResource.h"
#include "ResourceStateTransaction.h"
#include <memory>
#include <vector>
struct Direct3D12PacketStorage
{
    std::shared_ptr<Direct3D12PacketCompletion> completion = std::make_shared<Direct3D12PacketCompletion>();
    std::vector<unsigned char> bytes;
    std::vector<std::shared_ptr<void>> resources;
    std::vector<std::shared_ptr<Celeste::Graphics::Direct3D12::GpuResource>> tracked;
    std::vector<Direct3D12PacketCommand> commands;
    std::vector<CelesteDirect3D12HostResourceState> outputStates;
    std::shared_ptr<Celeste::Graphics::Direct3D12::ResourceStateTransaction> states;
};
