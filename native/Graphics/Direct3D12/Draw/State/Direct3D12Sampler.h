#pragma once
#include "CelesteGraphicsBackend.h"
#include <d3d12.h>
D3D12_SAMPLER_DESC ConvertSampler(const SourceNativeSamplerState&);
