using Celeste.Input.Runtime;
using Celeste.Core.Framework.Graphics;
using System;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice : ISourceTextureDevice, IDisposable, ISourceScreenGraphicsDevice
    {
        ISourceScreenGraphicsAdapter ISourceScreenGraphicsDevice.Adapter => Adapter;

        private readonly ISourceGraphicsDeviceIO deviceIO;
        private readonly ISourceGraphicsDeviceInputMetrics inputMetrics;
        private readonly IntPtr nativeDeviceHandle;
        private IntPtr effectStateChangesPtr;
        private IntPtr userVertexBuffer;
        private IntPtr userIndexBuffer;

        public SourceGraphicsAdapter Adapter { get; private set; }
        public SourceGraphicsProfile GraphicsProfile { get; private set; }
        public bool IsDisposed { get; private set; }
        public SourceGraphicsResourceReferences ResourceReferences { get; } = new();
        public SourcePipelineCache PipelineCache { get; }
        public IntPtr EffectStateChangesPointer => effectStateChangesPtr;
        public IntPtr NativeDeviceHandle => nativeDeviceHandle;
        public ISourceTextureIO TextureIO => deviceIO.TextureIO;
        internal ISourceGraphicsDeviceIO PhysicalIO => deviceIO;
        public event EventHandler<EventArgs> Disposing;

        public unsafe SourceGraphicsDevice(SourceGraphicsAdapter adapter, SourceGraphicsProfile graphicsProfile,
            SourcePresentationParameters presentationParameters, ISourceGraphicsDeviceIO physicalIO,
            ISourceGraphicsDeviceInputMetrics inputMetrics)
        {
            this.inputMetrics = inputMetrics;
            deviceIO = physicalIO;
            sourceIO = physicalIO;
            targetIO = physicalIO;
            if (presentationParameters == null)
            {
                throw new ArgumentNullException("presentationParameters");
            }

            Adapter = adapter;
            PresentationParameters = presentationParameters;
            GraphicsProfile = graphicsProfile;
            PresentationParameters.MultiSampleCount =
                SourceMultisampleMath.ClosestMSAAPower(PresentationParameters.MultiSampleCount);
            try
            {
                nativeDeviceHandle = deviceIO.CreateDevice(ref PresentationParameters.parameters, 0);
            }
            catch (Exception ex)
            {
                throw new SourceNoSuitableGraphicsDeviceException(ex.Message);
            }

            inputMetrics.MouseBackBufferWidth = PresentationParameters.BackBufferWidth;
            inputMetrics.MouseBackBufferHeight = PresentationParameters.BackBufferHeight;
            inputMetrics.TouchDisplayWidth = PresentationParameters.BackBufferWidth;
            inputMetrics.TouchDisplayHeight = PresentationParameters.BackBufferHeight;
            BlendState = SourceBlendState.Opaque;
            DepthStencilState = SourceDepthStencilState.Default;
            RasterizerState = SourceRasterizerState.CullCounterClockwise;
            deviceIO.GetMaxTextureSlots(out var textures, out var vertexTextures);
            Textures = new SourceTextureCollection(textures, modifiedSamplers);
            SamplerStates = new SourceSamplerStateCollection(textures, modifiedSamplers);
            VertexTextures = new SourceTextureCollection(vertexTextures, modifiedVertexSamplers);
            VertexSamplerStates = new SourceSamplerStateCollection(vertexTextures, modifiedVertexSamplers);
            var bounds = PresentationParameters.Bounds;
            Viewport = new CameraViewport(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            var viewport = Viewport;
            ScissorRectangle =
                new Celeste.Core.Geometry.IntRect(viewport.X, viewport.Y, viewport.Width, viewport.Height);
            PipelineCache = new SourcePipelineCache(this);
            effectStateChangesPtr = deviceIO.Allocate(sizeof(SourceEffect.MOJOSHADER_effectStateChanges));
            SourceEffect.MOJOSHADER_effectStateChanges* ptr =
                (SourceEffect.MOJOSHADER_effectStateChanges*)(void*)effectStateChangesPtr;
            ptr->render_state_change_count = 0u;
            ptr->sampler_state_change_count = 0u;
            ptr->vertex_sampler_state_change_count = 0u;
        }

        ~SourceGraphicsDevice()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (Disposing != null)
                {
                    Disposing(this, EventArgs.Empty);
                }

                ResourceReferences.DisposeTrackedResources();
                if (userVertexBuffer != IntPtr.Zero)
                {
                    deviceIO.AddDisposeVertexBuffer(userVertexBuffer);
                }

                if (userIndexBuffer != IntPtr.Zero)
                {
                    deviceIO.AddDisposeIndexBuffer(userIndexBuffer);
                }

                deviceIO.Free(effectStateChangesPtr);
                deviceIO.DestroyDevice();
            }

            IsDisposed = true;
        }

        public void CreateEffect(byte[] effectCode, int effectCodeLength, out IntPtr effect, out IntPtr effectData)
            => deviceIO.CreateEffect(effectCode, effectCodeLength, out effect, out effectData);

        public void CloneEffect(IntPtr originalEffect, out IntPtr effect, out IntPtr effectData)
            => deviceIO.CloneEffect(originalEffect, out effect, out effectData);

        public void SetEffectTechnique(IntPtr effect, IntPtr technique) =>
            deviceIO.SetEffectTechnique(effect, technique);

        public void AddDisposeEffect(IntPtr effect) => deviceIO.AddDisposeEffect(effect);

        public void ApplyEffect(IntPtr effect, uint pass, IntPtr stateChanges) =>
            deviceIO.ApplyEffect(effect, pass, stateChanges);
    }
}
