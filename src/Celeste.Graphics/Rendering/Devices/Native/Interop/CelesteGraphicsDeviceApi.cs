using System;
using System.Runtime.InteropServices;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Devices.Native.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CelesteGraphicsDeviceApi
    {
        public uint abiVersion;
        public delegate* unmanaged[Cdecl]<byte*> GetLastError;
        public delegate* unmanaged[Cdecl]<IntPtr, int> DestroyDevice;
        public delegate* unmanaged[Cdecl]<IntPtr, CelesteGraphicsTextureInfo*, IntPtr*, int> CreateTexture;
        public delegate* unmanaged[Cdecl]<IntPtr, void> ReleaseTexture;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr*, int> BeginPacket;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, CelesteGraphicsTextureRegion*, void*, uint, int> WriteTexture;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, int> CopyTexture;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, IntRect*, IntRect*, int> Present;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr*, int> Submit;
        public delegate* unmanaged[Cdecl]<IntPtr, void> ReleasePacket;
        public delegate* unmanaged[Cdecl]<IntPtr, int> GetCompletion;
        public delegate* unmanaged[Cdecl]<IntPtr, int> Wait;
        public delegate* unmanaged[Cdecl]<IntPtr, void> ReleaseSubmission;
        public delegate* unmanaged[Cdecl]<IntPtr, void> ReleaseOutput;
        public delegate* unmanaged[Cdecl]<IntPtr, CelesteGraphicsCapabilities*, int> GetCapabilities;
        public delegate* unmanaged[Cdecl]<IntPtr, SourceSurfaceFormat, int, int*, int> GetMaxMultiSampleCount;
        public delegate* unmanaged[Cdecl]<IntPtr, SourceNativePresentationParameters*, int> ConfigureBackbuffer;
        public delegate* unmanaged[Cdecl]<IntPtr, CelesteGraphicsBackbufferInfo*, int> GetBackbufferInfo;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntRect*, IntRect*, int> PresentBackbuffer;
        public delegate* unmanaged[Cdecl]<IntPtr, CameraViewport*, int> SetViewport;
        public delegate* unmanaged[Cdecl]<IntPtr, IntRect*, int> SetScissorRect;
        public delegate* unmanaged[Cdecl]<IntPtr, SourceClearOptions, float*, float, int, int> Clear;
        public delegate* unmanaged[Cdecl]<IntPtr, SourceNativeBlendState*, int> SetBlendState;
        public delegate* unmanaged[Cdecl]<IntPtr, SourceNativeDepthStencilState*, int> SetDepthStencilState;
        public delegate* unmanaged[Cdecl]<IntPtr, SourceNativeRasterizerState*, int> SetRasterizerState;
        public delegate* unmanaged[Cdecl]<IntPtr, uint, byte, IntPtr, SourceNativeSamplerState*, int> SetSampler;
        public delegate* unmanaged[Cdecl]<IntPtr, uint*, int> GetBlendFactor;
        public delegate* unmanaged[Cdecl]<IntPtr, uint, int> SetBlendFactor;
        public delegate* unmanaged[Cdecl]<IntPtr, int*, int> GetSampleMask;
        public delegate* unmanaged[Cdecl]<IntPtr, int, int> SetSampleMask;
        public delegate* unmanaged[Cdecl]<IntPtr, int*, int> GetStencilReference;
        public delegate* unmanaged[Cdecl]<IntPtr, int, int> SetStencilReference;

        public delegate* unmanaged[Cdecl]<IntPtr, SourceNativeRenderTargetBinding*, int, IntPtr, SourceDepthFormat, byte
            , int> SetRenderTargets;

        public delegate* unmanaged[Cdecl]<IntPtr, SourceNativeRenderTargetBinding*, int> ResolveTarget;

        public delegate* unmanaged[Cdecl]<IntPtr, int, int, SourceSurfaceFormat, int, IntPtr, IntPtr*, int>
            CreateColorRenderbuffer;

        public delegate* unmanaged[Cdecl]<IntPtr, int, int, SourceDepthFormat, int, IntPtr*, int>
            CreateDepthRenderbuffer;

        public delegate* unmanaged[Cdecl]<IntPtr, void> ReleaseRenderbuffer;
        public delegate* unmanaged[Cdecl]<IntPtr, byte*, uint, int> SetTextureName;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, CelesteGraphicsTextureRegion*, IntPtr*, int> ReadTexture;
        public delegate* unmanaged[Cdecl]<IntPtr, IntRect*, IntPtr*, int> ReadBackbuffer;
        public delegate* unmanaged[Cdecl]<IntPtr, byte, byte, SourceBufferUsage, int, IntPtr*, int> CreateBuffer;
        public delegate* unmanaged[Cdecl]<IntPtr, void> ReleaseBuffer;

        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int, void*, int, int, int, SourceSetDataOptions, int>
            WriteBuffer;

        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int, int, int, int, IntPtr*, int> ReadBuffer;

        public delegate* unmanaged[Cdecl]<IntPtr, SourceNativeVertexBufferBinding*, int, byte, int, int>
            SetVertexBindings;

        public delegate* unmanaged[Cdecl]<IntPtr, SourcePrimitiveType, int, int, int> Draw;

        public delegate* unmanaged[Cdecl]<IntPtr, SourcePrimitiveType, int, int, int, int, int, int, IntPtr,
            SourceIndexElementSize, int> DrawIndexed;

        public delegate* unmanaged[Cdecl]<IntPtr, void*, uint, void*, int> ApplyEffect;
        public delegate* unmanaged[Cdecl]<IntPtr, int> GetReadbackStatus;
        public delegate* unmanaged[Cdecl]<IntPtr, void**, uint*, int> GetReadbackBytes;
        public delegate* unmanaged[Cdecl]<IntPtr, void> ReleaseReadback;
        public delegate* unmanaged[Cdecl]<uint, void**, int> Allocate;
        public delegate* unmanaged[Cdecl]<void*, void> Free;
    }
}
