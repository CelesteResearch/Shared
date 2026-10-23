#pragma once
#include <stdint.h>
#ifdef _WIN32
#define CE_EXPORT __declspec(dllexport)
#define CE_CALL __cdecl
#else
#define CE_EXPORT __attribute__((visibility("default")))
#define CE_CALL
#endif
#ifdef __cplusplus
extern "C"
{
#endif
    typedef struct CelesteEffectShaderDescription
    {
        const char* profile;
        const char* entryPoint;
        const unsigned char* tokens;
        uint32_t tokenLength;
        const void* swizzles;
        uint32_t swizzleCount;
        const void* samplerMap;
        uint32_t samplerCount;
        const void* parsed;
        int32_t floatCount, intCount, boolCount;
        int32_t stage;
        const void* output;
        int32_t outputLength;
        const char* outputEntryPoint;
        const void* uniforms;
        int32_t uniformCount;
        const void* samplers;
        int32_t samplerCountParsed;
        const void* attributes;
        int32_t attributeCount;
        const void* outputs;
        int32_t outputCount;
        const void* identity;
        const void* packing;
        int32_t packingCount;
        int32_t constantBufferBytes;
    } CelesteEffectShaderDescription;

    typedef struct CelesteEffectRegisterView
    {
        const void* vertexIdentity;
        const void* pixelIdentity;
        const float* vertexFloat;
        uint32_t vertexFloatCount;
        const float* pixelFloat;
        uint32_t pixelFloatCount;
        const int32_t* vertexInt;
        uint32_t vertexIntCount;
        const int32_t* pixelInt;
        uint32_t pixelIntCount;
        const unsigned char* vertexBool;
        uint32_t vertexBoolCount;
        const unsigned char* pixelBool;
        uint32_t pixelBoolCount;
    } CelesteEffectRegisterView;

    // Every operation is sequential on the owning context thread. Pointers are borrowed
    // unless returned as an explicit handle; zero-length buffers may be null.
    CE_EXPORT const char* CE_CALL CelesteEffectGetError(void);
    CE_EXPORT int CE_CALL CelesteEffectFrontendCreate(const char* profile, void** frontend);
    CE_EXPORT void CE_CALL CelesteEffectFrontendDestroy(void* frontend);
    CE_EXPORT int CE_CALL CelesteEffectCreate(void* frontend, const unsigned char* code, uint32_t length, void** effect,
                                              void** metadata);
    CE_EXPORT int CE_CALL CelesteEffectClone(void* source, void** effect, void** metadata);
    // Synchronous owner-thread destruction; callers must enqueue non-owner releases.
    CE_EXPORT void CE_CALL CelesteEffectDestroy(void* effect);
    CE_EXPORT int CE_CALL CelesteEffectSetTechnique(void* effect, const void* technique);
    CE_EXPORT int CE_CALL CelesteEffectApply(void* effect, uint32_t pass, void* stateChanges);
    CE_EXPORT int CE_CALL CelesteEffectGetShaderCount(void* effect, uint32_t* count);
    CE_EXPORT int CE_CALL CelesteEffectGetTechniqueCount(void* effect, uint32_t* count);
    CE_EXPORT int CE_CALL CelesteEffectGetTechnique(void* effect, uint32_t index, const void** technique,
                                                    uint32_t* passCount);
    // Assignment bits 1/2, selector bits 4/8, potentially retained stage bits 16/32.
    // Selector choices are read from their original object array; no parameter evaluation is performed.
    CE_EXPORT int CE_CALL CelesteEffectGetPassStageFlags(void* effect, uint32_t technique, uint32_t pass,
                                                         uint32_t* flags);
    CE_EXPORT int CE_CALL CelesteEffectGetPassShaderCount(void* effect, uint32_t technique, uint32_t pass, int vertex,
                                                          uint32_t* count);
    CE_EXPORT int CE_CALL CelesteEffectAcquirePassShader(void* effect, uint32_t technique, uint32_t pass, int vertex,
                                                         uint32_t index, void** shader);
    CE_EXPORT int CE_CALL CelesteEffectAcquireShader(void* effect, uint32_t index, void** shader);
    CE_EXPORT int CE_CALL CelesteEffectAcquireBoundShader(void* effect, int vertex, void** shader);
    CE_EXPORT int CE_CALL CelesteEffectGetShaderDescription(void* shader, CelesteEffectShaderDescription* description);
    CE_EXPORT void CE_CALL CelesteEffectReleaseShader(void* shader);
    CE_EXPORT int CE_CALL CelesteEffectBorrowRegisters(void* effect, CelesteEffectRegisterView* view);
    // First validate all six capacities; failure writes none. Target pointer fields
    // supply caller-owned writable memory. Count fields are capacities in elements.
    CE_EXPORT int CE_CALL CelesteEffectCopyRegisters(void* effect, const CelesteEffectRegisterView* target);
    CE_EXPORT int CE_CALL CelesteEffectCopyHlslConstants(void* effect, int vertex, void* target,
                                                         uint32_t capacityBytes);
#ifdef __cplusplus
}
#endif
