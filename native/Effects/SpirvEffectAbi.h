#pragma once
#include "EffectFrontendAbi.h"
#ifdef __cplusplus
extern "C"
{
#endif
    typedef struct CelesteSpirvVertexAttribute
    {
        int32_t usage, format, usageIndex;
    } CelesteSpirvVertexAttribute;
    typedef struct CelesteSpirvBinaryView
    {
        const uint32_t* words;
        uint32_t byteCount;
        const char* entryPoint;
    } CelesteSpirvBinaryView;
    // Desktop-only optional ABI. Shader handles are from the same CPU frontend module.
    // Program owns both binaries and entry point strings; input leases may be released after Create.
    CE_EXPORT const char* CE_CALL CelesteSpirvGetError(void);
    CE_EXPORT int CE_CALL CelesteSpirvCreateProgram(void* vertexShader, void* pixelShader,
                                                    const CelesteSpirvVertexAttribute* attributes, int32_t count,
                                                    void** program);
    CE_EXPORT int CE_CALL CelesteSpirvGetBinary(void* program, int vertex, CelesteSpirvBinaryView* view);
    CE_EXPORT void CE_CALL CelesteSpirvDestroyProgram(void* program);
    // Shader input location by semantic; missing/unused inputs return -1 with success.
    // Query at pipeline construction; the result is independent of declaration order.
    CE_EXPORT int CE_CALL CelesteSpirvGetVertexLocation(void* program, int32_t usage, int32_t usageIndex,
                                                        int32_t* location);
    // Reads the current bound stage's registers; owner-thread synchronous copy.
    CE_EXPORT int CE_CALL CelesteSpirvCopyConstants(void* effect, int vertex, void* destination,
                                                    uint32_t capacityBytes);
#ifdef __cplusplus
}
#endif
