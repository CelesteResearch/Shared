using Celeste.Core.Display;
using Celeste.Scene.Scheduling;
using Celeste.Simulation.Runtime.Session;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Ascension;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Simulation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Presentation.Hud.Height
{
    public class OriginalHeightDisplayState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private int index;

        private string text = "";

        private string leftText = "";

        private string rightText = "";

        private float leftSize;

        private float rightSize;

        private float numberSize;

        private Vector2 size;

        private int height;

        private float approach;

        private float ease;

        private float pulse;

        private string spawnedLevel;

        private bool setAudioProgression;

        private bool easingCamera = true;

        private bool drawText
        {
            get
            {
                if (index >= 0 && ease > 0f)
                {
                    return !string.IsNullOrEmpty(text);
                }

                return false;
            }
        }

        public OriginalHeightDisplayState(ISourceEngineContext engine, int index)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = new SceneTagSet(((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                                   ((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value);
            this.index = index;
            string name = "CH7_HEIGHT_" + ((index < 0) ? "START" : index.ToString());
            if (index >= 0 && ((IOriginalGameTextEnvironment)engine).Text.Dialog.Has(name))
            {
                text = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get(name);
                text = text.ToUpper();
                height = (index + 1) * 500;
                approach = index * 500;
                int num = text.IndexOf("{X}");
                leftText = text.Substring(0, num);
                leftSize = ((ISourceActiveFontScope)engine).ActiveFont.Measure(leftText).X;
                rightText = text.Substring(num + 3);
                numberSize = ((ISourceActiveFontScope)engine).ActiveFont.Measure(height.ToString()).X;
                rightSize = ((ISourceActiveFontScope)engine).ActiveFont.Measure(rightText).X;
                size = ((ISourceActiveFontScope)engine).ActiveFont.Measure(leftText + height + rightText);
            }

            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            spawnedLevel = (scene as OriginalLevelSceneRoot).Session.Level;
        }

        private IEnumerator Routine()
        {
            RoomPlayerSession player;
            while (true)
            {
                player =
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                if (player != null && (base.Scene as OriginalLevelSceneRoot).Session.Level != spawnedLevel)
                {
                    break;
                }

                yield return null;
            }

            StepAudioProgression();
            easingCamera = false;
            yield return 0.1f;
            OwnedComponents.Add(new SimulationCoroutine(engine, CameraUp()));
            if (!string.IsNullOrEmpty(text) && index >= 0)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/07_summit/altitude_count");
            }

            while ((ease += engine.Frame.DeltaTime / 0.15f) < 1f)
            {
                yield return null;
            }

            while (approach < (float)height &&
                   ((IOriginalAscendPolicyEnvironment)engine).AscendPolicy.HeightDisplayPlayerAirborne(player))
            {
                yield return null;
            }

            approach = height;
            pulse = 1f;
            while ((pulse -= engine.Frame.DeltaTime * 4f) > 0f)
            {
                yield return null;
            }

            pulse = 0f;
            yield return 1f;
            while ((ease -= engine.Frame.DeltaTime / 0.15f) > 0f)
            {
                yield return null;
            }

            RemoveSelf();
        }

        private IEnumerator CameraUp()
        {
            easingCamera = true;
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            for (float p = 0f; p < 1f; p += engine.Frame.DeltaTime * 1.5f)
            {
                level.Camera.Y = (float)(level.Bounds.Bottom - 180) +
                                 64f * (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p));
                yield return null;
            }
        }

        private void StepAudioProgression()
        {
            ChapterCompletionSession session = (base.Scene as OriginalLevelSceneRoot).Session;
            if (!setAudioProgression && index >= 0 &&
                ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(session).Mode == 0)
            {
                setAudioProgression = true;
                int num = index + 1;
                if (num <= 5)
                {
                    session.Audio.Music.Progress = num;
                }
                else
                {
                    session.Audio.Music.Event = "event:/music/lvl7/final_ascent";
                }

                OriginalAudioSession.Apply(session.Audio, ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                    ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            }
        }

        public override void Update()
        {
            if (index >= 0 && ease > 0f)
            {
                if ((float)height - approach > 100f)
                {
                    approach += 1000f * engine.Frame.DeltaTime;
                }
                else if ((float)height - approach > 25f)
                {
                    approach += 200f * engine.Frame.DeltaTime;
                }
                else if ((float)height - approach > 5f)
                {
                    approach += 50f * engine.Frame.DeltaTime;
                }
                else if ((float)height - approach > 0f)
                {
                    approach += 10f * engine.Frame.DeltaTime;
                }
                else
                {
                    approach = height;
                }
            }

            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            if (!easingCamera)
            {
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
                Vector2 vector3 = new Vector2(1f, num2);
                SourcePrimitiveDrawing.Rect(context, this, vector.X - (vector2.X + 64f) * 0.5f * vector3.X,
                    vector.Y - (vector2.Y + 32f) * 0.5f * vector3.Y, (vector2.X + 64f) * vector3.X,
                    (vector2.Y + 32f) * vector3.Y, PackedColor.Black);
                Vector2 vector4 = vector + new Vector2((0f - vector2.X) * 0.5f, 0f);
                Vector2 scale = vector3 * num;
                PackedColor color = PackedColor.White * num2;
                ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this, leftText, vector4,
                    new Vector2(0f, 0.5f),
                    scale, color);
                ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this, rightText,
                    vector4 + Vector2.UnitX * (leftSize + numberSize) * num, new Vector2(0f, 0.5f), scale, color);
                ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, this, ((int)approach).ToString(),
                    vector4 + Vector2.UnitX * (leftSize + numberSize * 0.5f) * num, new Vector2(0.5f, 0.5f), scale,
                    color);
            }
        }

        public override void Removed(object scene)
        {
            StepAudioProgression();
            base.Removed(scene);
        }
    }
}
