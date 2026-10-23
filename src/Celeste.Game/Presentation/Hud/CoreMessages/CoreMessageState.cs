using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;
using Celeste.Graphics.Display;

namespace Celeste.Game.Presentation.Hud.CoreMessages
{
    public class CoreMessageState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private string text;
        private float alpha;

        public CoreMessageState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            string[] array = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("app_ending")
                .Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            text = array[EntityAttributeReader.Int(data.Values, "line", 0)];
        }

        public override void Update()
        {
            RoomPlayerSession player = ((OriginalLevelSceneRoot)Scene).SourceScene.Entities
                .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (player != null)
                alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(
                    ScalarMath.ClampedMap(Math.Abs(X - player.X), 0f, 128f, 1f, 0f));
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 camera = ((OriginalLevelSceneRoot)Scene).Camera.Position;
            Vector2 position = CoreMessageLayout.UnlockedPosition(Position, camera);
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode)
                position.X = 1920f - position.X;
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, this,
                text, position, new Vector2(.5f), Vector2.One * 1.25f, PackedColor.White * alpha);
        }
    }
}
