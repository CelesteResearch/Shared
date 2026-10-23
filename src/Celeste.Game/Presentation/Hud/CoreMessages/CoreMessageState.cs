using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Entities;
using Celeste.Simulation;

namespace Celeste.Game.Presentation.Hud.CoreMessages
{
    public class CoreMessageState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly string text;
        private float alpha;

        public CoreMessageState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            var array = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("app_ending")
                .Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
            text = array[EntityAttributeReader.Int(data.Values, "line")];
        }

        public override void Update()
        {
            var player = ((OriginalLevelSceneRoot)Scene).SourceScene.Entities
                .GetTrackedEntity<RoomPlayerSession>(typeof(RoomPlayerSession).FullName);
            if (player != null)
                alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(
                    ScalarMath.ClampedMap(Math.Abs(X - player.X), 0f, 128f, 1f, 0f));
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var camera = ((OriginalLevelSceneRoot)Scene).Camera.Position;
            var position = CoreMessageLayout.UnlockedPosition(Position, camera);
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode)
                position.X = 1920f - position.X;
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, this,
                text, position, new(.5f), Vector2.One * 1.25f, PackedColor.White * alpha);
        }
    }
}
