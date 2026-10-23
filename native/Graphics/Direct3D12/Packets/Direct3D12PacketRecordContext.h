#pragma once
#include "CommandLease.h"
#include "ResourceStateTransaction.h"
struct Direct3D12PacketRecordContext
{
    Celeste::Graphics::Direct3D12::CommandLease& lease;
    Celeste::Graphics::Direct3D12::ResourceStateTransaction& states;
};
