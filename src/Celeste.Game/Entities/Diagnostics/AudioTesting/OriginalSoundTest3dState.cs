using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Entities.Diagnostics.AudioTesting
{
    public class OriginalSoundTest3dState : SceneEntityState
    {
        public SoundSourceComponentState sfx;

        public OriginalSoundTest3dState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            OwnedComponents.Add(sfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            sfx.Play("event:/3d_testing");
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, Position.X - 8f, Position.Y - 8f, 16f, 16f, PackedColor.Yellow);
            var camera = (Scene as OriginalLevelSceneRoot).Camera;
            SourcePrimitiveDrawing.HollowRect(context, this, Position.X - 320f, camera.Y, 640f, 180f, PackedColor.Red);
            SourcePrimitiveDrawing.HollowRect(context, this, Position.X - 160f, camera.Y, 320f, 180f,
                PackedColor.Yellow);
            SourcePrimitiveDrawing.HollowRect(context, this, Position.X - 160f - 320f, camera.Y, 960f, 180f,
                PackedColor.Yellow);
        }
    }
}
