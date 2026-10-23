cmake_minimum_required(VERSION 3.24)
project(CelesteGraphicsDirect3D12 LANGUAGES CXX)
if(NOT WIN32 OR NOT CMAKE_SIZEOF_VOID_P EQUAL 8)
    message(FATAL_ERROR "Direct3D12 requires Windows x64")
endif()
if(NOT TARGET CelesteGraphicsEffects)
    message(FATAL_ERROR "Direct3D12 requires the shared effect frontend")
endif()
add_library(
    CelesteGraphicsDirect3D12 SHARED
    CelesteGraphicsDirect3D12.def
    Device/DeviceContext.cpp
    Device/Direct3D12DeviceExports.cpp
    Draw/Binding/BindingBatch.cpp
    Draw/Binding/BindingPool.cpp
    Draw/Commands/Direct3D12Clear.cpp
    Draw/Commands/Direct3D12DrawApi.cpp
    Draw/Commands/Direct3D12PreparedTargets.cpp
    Draw/Effects/Direct3D12EffectCache.cpp
    Draw/Effects/Direct3D12Effects.cpp
    Draw/Effects/Direct3D12EffectShaderLease.cpp
    Draw/Pipelines/PipelineCache.cpp
    Draw/Pipelines/PipelineKey.cpp
    Draw/Pipelines/SourceInputLayout.cpp
    Draw/Pipelines/SourcePipelineState.cpp
    Draw/Pipelines/SourceRootSignature.cpp
    Draw/Shaders/Direct3D12Shaders.cpp
    Draw/State/Direct3D12Backbuffer.cpp
    Draw/State/Direct3D12DrawArena.cpp
    Draw/State/Direct3D12DrawState.cpp
    Draw/State/Direct3D12Sampler.cpp
    Draw/State/Direct3D12StateApi.cpp
    Packets/CelesteGraphicsPacket.cpp
    Packets/Direct3D12PacketExports.cpp
    Presentation/Direct3D12PresentationApi.cpp
    Presentation/PresentationBinding.cpp
    Presentation/PresentationContext.cpp
    Presentation/PresentCommand.cpp
    Resources/Abi/Direct3D12BufferApi.cpp
    Resources/Abi/Direct3D12Capabilities.cpp
    Resources/Abi/Direct3D12ReadbackApi.cpp
    Resources/Abi/Direct3D12RenderbufferApi.cpp
    Resources/Abi/Direct3D12TextureApi.cpp
    Resources/Abi/MipGenerationApi.cpp
    Resources/BufferResource.cpp
    Resources/DepthResource.cpp
    Resources/GpuResource.cpp
    Resources/ResourceFormat.cpp
    Resources/TextureResource.cpp
    Submission/CommandLease.cpp
    Submission/DirectQueueExecutor.cpp
    Submission/FenceTicket.cpp
    Submission/SubmissionQueue.cpp
    Transfers/BufferTransfer.cpp
    Transfers/ResourceStateTransaction.cpp
    Transfers/TextureCopy.cpp
    Transfers/TextureTransfer.cpp
    Transfers/TransferBufferPool.cpp
    Transfers/TransferFootprint.cpp
    Window/CelesteDirect3D12Window.cpp
    Window/Direct3D12WindowExports.cpp)
set_target_properties(CelesteGraphicsDirect3D12 PROPERTIES WINDOWS_EXPORT_ALL_SYMBOLS OFF)
target_compile_features(CelesteGraphicsDirect3D12 PRIVATE cxx_std_17)
target_compile_definitions(CelesteGraphicsDirect3D12 PRIVATE NOMINMAX WIN32_LEAN_AND_MEAN MOJOSHADER_EFFECT_SUPPORT)
target_compile_options(CelesteGraphicsDirect3D12 PRIVATE /W4 /utf-8)
target_include_directories(
    CelesteGraphicsDirect3D12
    PRIVATE "${CMAKE_CURRENT_SOURCE_DIR}"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw"
            "${CMAKE_CURRENT_SOURCE_DIR}/../Include"
            "${CMAKE_CURRENT_SOURCE_DIR}/../../Effects"
            "${CMAKE_CURRENT_SOURCE_DIR}/../../../vendor/mojoshader-ad5dff84830c2863c841f4b1f4e3df78c705b383"
            "${CMAKE_CURRENT_SOURCE_DIR}/Device"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/Binding"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/Commands"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/Effects"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/Pipelines"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/Shaders"
            "${CMAKE_CURRENT_SOURCE_DIR}/Draw/State"
            "${CMAKE_CURRENT_SOURCE_DIR}/Packets"
            "${CMAKE_CURRENT_SOURCE_DIR}/Presentation"
            "${CMAKE_CURRENT_SOURCE_DIR}/Resources"
            "${CMAKE_CURRENT_SOURCE_DIR}/Resources/Abi"
            "${CMAKE_CURRENT_SOURCE_DIR}/Submission"
            "${CMAKE_CURRENT_SOURCE_DIR}/Transfers"
            "${CMAKE_CURRENT_SOURCE_DIR}/Window")
target_link_libraries(CelesteGraphicsDirect3D12 PRIVATE CelesteGraphicsEffects d3d12 dxgi d3dcompiler)
