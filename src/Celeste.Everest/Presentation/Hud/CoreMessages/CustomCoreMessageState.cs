using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Audio;
using Celeste.Game.Presentation.Hud.Height;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Everest.Presentation.Hud.Height;
using Celeste.Everest.Entities.Memorials;
using Image = Celeste.Graphics.Animation.SpriteImage;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;

namespace Celeste.Everest.Presentation.Hud.CoreMessages
{
    /// <summary>
    ///       Based on CoreMessage, to be used by custom maps.
    ///
    ///       Checks for the following new attributes:
    ///       - `string dialog` (default: `app_ending`)
    ///       - `bool outline` (default: `false`)
    ///       </summary>
    [CustomEntity(new string[] { "everest/coreMessage" })]
    public class CustomCoreMessageState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private ActiveBitmapFont ActiveFont => ((IOriginalGameTextEnvironment)engine).Text.ActiveFont;

        private global::Celeste.Localization.Lookup.DialogCatalog Dialog =>
            ((IOriginalGameTextEnvironment)engine).Text.Dialog;

        private global::Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        private string text;

        private float alpha;

        private bool outline;

        public CustomCoreMessageState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            text = Dialog.Clean(EntityAttributeReader.Attr(data.Values, "dialog", "app_ending"))
                .Split(new char[2] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)[
                    EntityAttributeReader.Int(data.Values, "line")];
            outline = EntityAttributeReader.Bool(data.Values, "outline");
        }

        public override void Update()
        {
            RoomPlayerSession entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity != null)
            {
                alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(
                    ScalarMath.ClampedMap(Math.Abs(base.X - entity.X), 0f, 128f, 1f, 0f));
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 position = ((OriginalLevelSceneRoot)base.Scene).Camera.Position;
            Vector2 position2 =
                global::Celeste.Game.Presentation.Hud.CoreMessages.CoreMessageLayout.UnlockedPosition(Position,
                    position);
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode)
            {
                position2.X = 1920f - position2.X;
            }

            if (outline)
            {
                ActiveFont.DrawOutline(context, this, text, position2, new Vector2(0.5f, 0.5f), Vector2.One * 1.25f,
                    PackedColor.White * alpha, 2f, PackedColor.Black * alpha);
            }
            else
            {
                ActiveFont.Draw(context, this, text, position2, new Vector2(0.5f, 0.5f), Vector2.One * 1.25f,
                    PackedColor.White * alpha);
            }
        }
    }
}
