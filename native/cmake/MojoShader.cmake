# Include with MOJO_ROOT pointing at the single pinned vendor directory.
# Do not execute vendor CMake: it rewrites the pinned version header.
if(NOT TARGET mojoshader)
    add_library(
        mojoshader STATIC
        "${MOJO_ROOT}/mojoshader.c"
        "${MOJO_ROOT}/mojoshader_common.c"
        "${MOJO_ROOT}/mojoshader_effects.c"
        "${MOJO_ROOT}/profiles/mojoshader_profile_bytecode.c"
        "${MOJO_ROOT}/profiles/mojoshader_profile_common.c"
        "${MOJO_ROOT}/profiles/mojoshader_profile_d3d.c"
        "${MOJO_ROOT}/profiles/mojoshader_profile_hlsl.c"
        "${MOJO_ROOT}/profiles/mojoshader_profile_glsl.c"
        "${MOJO_ROOT}/profiles/mojoshader_profile_spirv.c")
    if(WIN32)
        target_sources(mojoshader PRIVATE "${MOJO_ROOT}/mojoshader_d3d11.c")
    endif()
    target_include_directories(mojoshader PUBLIC "${MOJO_ROOT}")
    target_compile_definitions(
        mojoshader PRIVATE MOJOSHADER_EFFECT_SUPPORT SUPPORT_PROFILE_ARB1=0 SUPPORT_PROFILE_ARB1_NV=0
                           SUPPORT_PROFILE_METAL=0 SUPPORT_PROFILE_GLSPIRV=0)
    if(MSVC)
        target_compile_options(mojoshader PRIVATE /TP /utf-8)
        target_compile_definitions(mojoshader PRIVATE _CRT_SECURE_NO_WARNINGS)
    else()
        set_target_properties(mojoshader PROPERTIES POSITION_INDEPENDENT_CODE ON)
    endif()
endif()
