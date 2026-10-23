using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Rendering.States;
using Celeste.Audio.Fmod.Events;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Effects.Liquids;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication :
        global::Celeste.Game.Gameplay.Environment.Lava.IOriginalLavaProcess,
        global::Celeste.Game.Gameplay.Doors.HeartGems.IOriginalHeartGemDoorProcess,
        ISourceSpatialAudio, ISourcePrimitiveGraphicsDevice
    {
        void global::Celeste.Core.Scheduling.ISourceFreezeEnvironment.Freeze(float duration)
            => global::Celeste.Game.Execution.Engine.Actions.OriginalCelesteFreeze.Freeze(this, duration);

        ILiquidWavePresentationPolicy ISourceLavaRectangleEnvironment.LiquidWavePolicy =>
            SourceLiquidWavePresentationPolicy.Shared;

        ISourceLavaRectangleSizeArithmetic ISourceLavaRectangleEnvironment.LavaRectangleSizeArithmetic
            => SourceProfile == global::Celeste.Game.Profiles.GameProfile.Original
                ? (ISourceLavaRectangleSizeArithmetic)OriginalLavaRectangleSizeArithmetic.Shared
                : InstalledLavaRectangleSizeArithmetic.Shared;

        AtlasData ISourceLavaRectangleEnvironment.LiquidAtlas => GraphicsResources.GameAtlas;
        ISourcePrimitiveGraphicsDevice ISourceLavaRectangleEnvironment.PrimitiveGraphics => this;
        ISourceSpatialAudio ISourceSpatialAudioEnvironment.SpatialAudio => this;
        SourceEffect ISourcePrimitiveGraphicsDevice.FxPrimitive => GraphicsResources.FxPrimitive;

        int ISourcePrimitiveGraphicsDevice.ViewportWidth =>
            ((ISourceGraphicsDeviceEnvironment)this).GraphicsDevice.Viewport.Width;

        int ISourcePrimitiveGraphicsDevice.ViewportHeight =>
            ((ISourceGraphicsDeviceEnvironment)this).GraphicsDevice.Viewport.Height;

        void ISourcePrimitiveGraphicsDevice.SetRasterizerState(SourceRasterizerState state)
            => ((ISourceGraphicsDeviceEnvironment)this).GraphicsDevice.RasterizerState = state;

        void ISourcePrimitiveGraphicsDevice.SetBlendState(SourceBlendState state)
            => ((ISourceGraphicsDeviceEnvironment)this).GraphicsDevice.BlendState = state;

        void ISourcePrimitiveGraphicsDevice.DrawUserTriangleList<T>(T[] vertices, int vertexOffset, int primitiveCount)
            => ((ISourceGraphicsDeviceEnvironment)this).GraphicsDevice.DrawUserPrimitives(
                SourcePrimitiveType.TriangleList,
                vertices, vertexOffset, primitiveCount);

        void ISourcePrimitiveGraphicsDevice.DrawUserIndexedTriangleList<T>(T[] vertices, int vertexOffset,
            int vertexCount,
            int[] indices, int indexOffset, int primitiveCount)
            => ((ISourceGraphicsDeviceEnvironment)this).GraphicsDevice.DrawUserIndexedPrimitives(
                SourcePrimitiveType.TriangleList, vertices, vertexOffset, vertexCount, indices, indexOffset,
                primitiveCount);

        ISourceAudioEventReference ISourceSpatialAudio.Play(string path, Vector2 position, string parameter,
            float value)
        {
            var process = (IOriginalGameplayProcess)this;
            return process.AudioSession.Play(path, position, process.SaveContext, parameter, value);
        }

        ISourceAudioEventReference ISourceSpatialAudio.Play(string path, Vector2 position, string parameter,
            float value,
            string parameter2, float value2)
        {
            var process = (IOriginalGameplayProcess)this;
            return process.AudioSession.Play(path, position, process.SaveContext, parameter, value, parameter2, value2);
        }

        void ISourceSpatialAudio.Position(ISourceAudioEventReference instance, Vector2 position)
        {
            var process = (IOriginalGameplayProcess)this;
            process.AudioSession.Position((FmodEventReference)instance, position, process.SaveContext);
        }

        void ISourceSpatialAudio.Stop(ISourceAudioEventReference instance, bool allowFadeOut)
            => ((IOriginalGameplayProcess)this).AudioSession.Stop((FmodEventReference)instance, allowFadeOut);
    }
}
