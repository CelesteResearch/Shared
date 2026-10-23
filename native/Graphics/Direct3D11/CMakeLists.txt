cmake_minimum_required(VERSION 3.24)
project(CelesteGraphicsD3D11 LANGUAGES C CXX)
if(NOT WIN32 OR NOT CMAKE_SIZEOF_VOID_P EQUAL 8)
    message(FATAL_ERROR "Direct3D11 requires Windows x64")
endif()
set(MOJO_ROOT "${CMAKE_CURRENT_SOURCE_DIR}/../../../vendor/mojoshader-ad5dff84830c2863c841f4b1f4e3df78c705b383")
include("${CMAKE_CURRENT_SOURCE_DIR}/../../cmake/MojoShader.cmake")
add_library(
    CelesteGraphicsD3D11 SHARED
    Direct3D11Device.cpp
    Direct3D11Effect.cpp
    Direct3D11Transport.cpp
    Direct3D11Commands.cpp
    Direct3D11PhysicalStateScope.cpp
    Direct3D11Resources.cpp
    Direct3D11WindowOutput.cpp
    Direct3D11Backbuffer.cpp)
target_compile_features(CelesteGraphicsD3D11 PRIVATE cxx_std_17)
target_include_directories(CelesteGraphicsD3D11 PUBLIC "${CMAKE_CURRENT_SOURCE_DIR}" "${MOJO_ROOT}")
target_compile_definitions(CelesteGraphicsD3D11 PRIVATE CELESTE_D3D11_BUILD WIN32_LEAN_AND_MEAN NOMINMAX
                                                        MOJOSHADER_EFFECT_SUPPORT)
target_compile_options(CelesteGraphicsD3D11 PRIVATE /utf-8)
target_link_libraries(CelesteGraphicsD3D11 PRIVATE mojoshader d3d11 d3dcompiler dxguid)
