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

namespace Celeste.Everest.Gameplay.Triggers.Height
{
    [CustomEntity(new string[] { "everest/CustomHeightDisplayTrigger" })]
    public class CustomHeightDisplayTriggerState : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private bool isVanilla;

        private int target;

        private int from;

        private string text;

        private bool progressAudio;

        private bool displayOnTransition;

        public CustomHeightDisplayTriggerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            isVanilla = EntityAttributeReader.Bool(data.Values, "vanilla");
            target = EntityAttributeReader.Int(data.Values, "target");
            from = EntityAttributeReader.Int(data.Values, "from");
            text = EntityAttributeReader.Attr(data.Values, "text", "{X}m");
            progressAudio = EntityAttributeReader.Bool(data.Values, "progressAudio");
            displayOnTransition = EntityAttributeReader.Bool(data.Values, "displayOnTransition");
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            if (isVanilla)
            {
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new OriginalHeightDisplayState(engine, target));
            }
            else
            {
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                    new CustomHeightDisplayState(engine, text, target, from, progressAudio, displayOnTransition));
            }

            RemoveSelf();
        }
    }
}
