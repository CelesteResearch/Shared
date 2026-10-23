using Celeste.Core.Display;
using Celeste.Simulation.Runtime.Session;
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

namespace Celeste.Everest.Presentation.Hud.Height
{
    public class CustomHeightDisplayState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private ActiveBitmapFont ActiveFont => ((IOriginalGameTextEnvironment)engine).Text.ActiveFont;

        private global::Celeste.Localization.Lookup.DialogCatalog Dialog =>
            ((IOriginalGameTextEnvironment)engine).Text.Dialog;

        private global::Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        private string leftText;

        private string rightText;

        private float leftSize;

        private float numberSize;

        private Vector2 size;

        private bool hasCount;

        private float ease;

        private float pulse;

        private bool displayOnTransition;

        private string spawnedLevel;

        private bool audioProgressed;

        private bool easingCamera;

        private string displaySound;

        private bool drawText
        {
            get
            {
                if (ease > 0f)
                {
                    return !string.IsNullOrEmpty(Text);
                }

                return false;
            }
        }

        public string Text { get; }

        public int Target { get; }

        public float Approach { get; private set; }

        /// <summary />
        /// <param name="dialog">Dialog ID, replaces first occurence of "{X}" with the counter.</param>
        /// <param name="target">Target for the counter.</param>
        /// <param name="from">Counter start.</param>
        /// <param name="progressAudio">Whether to increment audio progression.</param>
        /// <param name="displayOnTransition" />
        public CustomHeightDisplayState(ISourceEngineContext engine, string dialog, int target, int from = 0,
            bool progressAudio = false, bool displayOnTransition = false)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Text = dialog;
            leftText = "";
            rightText = "";
            this.displayOnTransition = displayOnTransition;
            easingCamera = true;
            audioProgressed = !progressAudio;
            if (target > from)
            {
                if (Dialog.Has(dialog))
                {
                    Text = Dialog.Get(dialog).ToUpper();
                }

                Target = target;
                Approach = from;
                int num = Text.IndexOf("{x}", StringComparison.InvariantCultureIgnoreCase);
                if (num != -1)
                {
                    hasCount = true;
                    displaySound = "event:/game/07_summit/altitude_count";
                    leftText = Text.Substring(0, num);
                    if (num + 3 < Text.Length)
                    {
                        rightText = Text.Substring(num + 3);
                    }

                    leftSize = ActiveFont.Measure(leftText).X;
                    numberSize = ActiveFont.Measure(Target.ToString()).X;
                    size = ActiveFont.Measure(leftText + Target + rightText);
                }
                else
                {
                    displaySound = "event:/game/07_summit/checkpoint_confetti";
                    leftText = Text;
                    size = ActiveFont.Measure(leftText);
                }
            }

            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            spawnedLevel = ((OriginalLevelSceneRoot)Scene).Session.Level;
        }

        private IEnumerator Routine()
        {
            RoomPlayerSession player;
            while (true)
            {
                RoomPlayerSession entity;
                player = (entity =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName));

                if (entity != null &&
                    (!displayOnTransition || !(((OriginalLevelSceneRoot)Scene).Session.Level == spawnedLevel)))
                {
                    break;
                }

                yield return null;
            }

            StepAudioProgression();
            easingCamera = !displayOnTransition;
            yield return 0.1f;
            if (displayOnTransition)
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, CameraUp()));
            }

            if (!string.IsNullOrEmpty(Text))
            {
                Audio.Play(displaySound);
            }

            while ((ease += engine.DeltaTime / 0.15f) < 1f)
            {
                yield return null;
            }

            float displayTimer = 0f;
            while (Approach < (float)Target && player.Scene != null && (!player.OnGround() || displayTimer < 0.5f) &&
                   !(displayTimer > 3f))
            {
                displayTimer += engine.DeltaTime;
                yield return null;
            }

            Approach = Target;
            if (hasCount)
            {
                pulse = 1f;
                while ((pulse -= engine.DeltaTime * 4f) > 0f)
                {
                    yield return null;
                }

                pulse = 0f;
            }

            yield return 1f;
            while ((ease -= engine.DeltaTime / 0.15f) > 0f)
            {
                yield return null;
            }

            RemoveSelf();
        }

        private IEnumerator CameraUp()
        {
            easingCamera = true;
            OriginalLevelSceneRoot level = ((OriginalLevelSceneRoot)Scene);
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 1.5f)
            {
                level.Camera.Y = (float)(level.Bounds.Bottom - 180) +
                                 64f * (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p));
                yield return null;
            }
        }

        private void StepAudioProgression()
        {
            if (!audioProgressed)
            {
                ChapterCompletionSession session = ((OriginalLevelSceneRoot)Scene).Session;
                audioProgressed = true;
                session.Audio.Music.Progress++;
                OriginalAudioSession.Apply(session.Audio, ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                    ((IOriginalGameplayProcess)engine).AudioApplyPolicy, false);
            }
        }

        public override void Update()
        {
            if (ease > 0f && hasCount)
            {
                if ((float)Target - Approach > 100f)
                {
                    Approach += 1000f * engine.DeltaTime;
                }
                else if ((float)Target - Approach > 25f)
                {
                    Approach += 200f * engine.DeltaTime;
                }
                else if ((float)Target - Approach > 5f)
                {
                    Approach += 50f * engine.DeltaTime;
                }
                else if ((float)Target - Approach > 0f)
                {
                    Approach += 10f * engine.DeltaTime;
                }
                else
                {
                    Approach = Target;
                }
            }

            if (!easingCamera)
            {
                OriginalLevelSceneRoot level = ((OriginalLevelSceneRoot)Scene);
                level.Camera.Y = level.Bounds.Bottom - 180 + 64;
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!((OriginalLevelSceneRoot)Scene).Paused && drawText)
            {
                Vector2 vector = new Vector2(1920f, 1080f) / 2f;
                float num = 1.2f + pulse * 0.2f;
                Vector2 vector2 = size * num;
                float num2 = ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut(ease);
                SourcePrimitiveDrawing.Rect(context, this, vector.X - (vector2.X + 64f) * 0.5f,
                    vector.Y - (vector2.Y + 32f) * 0.5f * num2, vector2.X + 64f, (vector2.Y + 32f) * num2,
                    PackedColor.Black);
                Vector2 vector3 = vector + new Vector2((0f - vector2.X) * 0.5f, 0f);
                Vector2 scale = new Vector2(1f, num2) * num;
                PackedColor color = PackedColor.White * num2;
                ActiveFont.Draw(context, this, leftText, vector3, new Vector2(0f, 0.5f), scale, color);
                ActiveFont.Draw(context, this, rightText, vector3 + Vector2.UnitX * (leftSize + numberSize) * num,
                    new Vector2(0f, 0.5f), scale, color);
                if (hasCount)
                {
                    ActiveFont.Draw(context, this, ((int)Approach).ToString(),
                        vector3 + Vector2.UnitX * (leftSize + numberSize * 0.5f) * num, new Vector2(0.5f, 0.5f), scale,
                        color);
                }
            }
        }

        public override void Removed(object scene)
        {
            StepAudioProgression();
            base.Removed(scene);
        }
    }
}
