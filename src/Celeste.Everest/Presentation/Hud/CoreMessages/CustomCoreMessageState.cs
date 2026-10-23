using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Presentation.Hud.CoreMessages;
using Celeste.Graphics.Text;
using Celeste.Localization.Lookup;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Everest.Presentation.Hud.CoreMessages
{
    /// <summary>
    ///     Based on CoreMessage, to be used by custom maps.
    ///     Checks for the following new attributes:
    ///     - `string dialog` (default: `app_ending`)
    ///     - `bool outline` (default: `false`)
    /// </summary>
    [CustomEntity("everest/coreMessage")]
    public class CustomCoreMessageState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private ActiveBitmapFont ActiveFont => ((IOriginalGameTextEnvironment)engine).Text.ActiveFont;

        private DialogCatalog Dialog =>
            ((IOriginalGameTextEnvironment)engine).Text.Dialog;

        private OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        private readonly string text;

        private float alpha;

        private readonly bool outline;

        public CustomCoreMessageState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            text = Dialog.Clean(EntityAttributeReader.Attr(data.Values, "dialog", "app_ending"))
                .Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries)[
                    EntityAttributeReader.Int(data.Values, "line")];
            outline = EntityAttributeReader.Bool(data.Values, "outline");
        }

        public override void Update()
        {
            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null)
                alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(
                    ScalarMath.ClampedMap(Math.Abs(X - entity.X), 0f, 128f, 1f, 0f));

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = ((OriginalLevelSceneRoot)Scene).Camera.Position;
            var position2 =
                CoreMessageLayout.UnlockedPosition(Position,
                    position);
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode)
                position2.X = 1920f - position2.X;

            if (outline)
                ActiveFont.DrawOutline(context, this, text, position2, new(0.5f, 0.5f), Vector2.One * 1.25f,
                    PackedColor.White * alpha, 2f, PackedColor.Black * alpha);
            else
                ActiveFont.Draw(context, this, text, position2, new(0.5f, 0.5f), Vector2.One * 1.25f,
                    PackedColor.White * alpha);
        }
    }
}
