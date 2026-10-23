using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Content.Dialogs;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Startup;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Scene;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text;
using Celeste.Physics.Collision.Shapes;
using Image = Celeste.Graphics.Animation.SpriteImage;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;

namespace Celeste.Game.Entities.Memorials
{
    public class MemorialTextState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private ActiveBitmapFont ActiveFont => ((IOriginalGameTextEnvironment)engine).Text.ActiveFont;
        public bool Show;

        public bool Dreamy;

        public MemorialState Memorial;

        private float index;

        private string message;

        private float alpha;

        private float timer;

        private float widestCharacter;

        private int firstLineLength;

        private SoundSource textSfx;

        private bool textSfxPlaying;

        public MemorialTextState(MemorialState memorial, bool dreamy, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags |= ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            Tags |= ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            OwnedComponents.Add(textSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            Dreamy = dreamy;
            Memorial = memorial;
            message = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("memorial");
            firstLineLength = CountToNewline(0);
            for (int i = 0; i < message.Length; i++)
            {
                float x = ActiveFont.Measure(message[i]).X;
                if (x > widestCharacter)
                {
                    widestCharacter = x;
                }
            }

            widestCharacter *= 0.9f;
        }

        public override void Update()
        {
            base.Update();
            if ((base.Scene as OriginalLevelSceneRoot).Paused)
            {
                textSfx.Pause();
                return;
            }

            timer += engine.DeltaTime;
            if (!Show)
            {
                alpha = ScalarMath.Approach(alpha, 0f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (alpha <= 0f)
                {
                    index = firstLineLength;
                }
            }
            else
            {
                alpha = ScalarMath.Approach(alpha, 1f, engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (alpha >= 1f)
                {
                    index = ScalarMath.Approach(index, message.Length, 32f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                }
            }

            if (Show && alpha >= 1f && index < (float)message.Length)
            {
                if (!textSfxPlaying)
                {
                    textSfxPlaying = true;
                    textSfx.Play(Dreamy
                        ? "event:/ui/game/memorial_dream_text_loop"
                        : "event:/ui/game/memorial_text_loop");
                    textSfx.Param("end", 0f);
                }
            }
            else if (textSfxPlaying)
            {
                textSfxPlaying = false;
                textSfx.Stop();
                textSfx.Param("end", 1f);
            }

            textSfx.Resume();
        }

        private int CountToNewline(int start)
        {
            int i;
            for (i = start; i < message.Length && message[i] != '\n'; i++)
            {
            }

            return i - start;
        }

        public override void Render(ISourceRenderContext context)
        {
            if ((base.Scene as OriginalLevelSceneRoot).FrozenOrPaused ||
                (base.Scene as OriginalLevelSceneRoot).Completed ||
                !(index > 0f) || !(alpha > 0f))
            {
                return;
            }

            var camera = ((OriginalLevelSceneRoot)Scene).Camera;
            Vector2 vector = new Vector2((Memorial.Position.X - camera.Position.X) * 6f,
                (Memorial.Position.Y - camera.Position.Y) * 6f - 350f - ActiveFont.LineHeight * 3.3f);
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode)
            {
                vector.X = 1920f - vector.X;
            }

            float num = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(alpha);
            int num2 = (int)((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(message.Length, index);
            int num3 = 0;
            float num4 = 64f * (1f - num);
            int num5 = CountToNewline(0);
            for (int i = 0; i < num2; i++)
            {
                char c = message[i];
                if (c == '\n')
                {
                    num3 = 0;
                    num5 = CountToNewline(i + 1);
                    num4 += ActiveFont.LineHeight * 1.1f;
                    continue;
                }

                float x = 1f;
                float x2 = (float)(-num5) * widestCharacter / 2f + ((float)num3 + 0.5f) * widestCharacter;
                float num6 = 0f;
                if (Dreamy && c != ' ' && c != '-' && c != '\n')
                {
                    c = message[
                        (i + (int)(Math.Sin(timer * 2f + (float)i / 8f) * 4.0) + message.Length) % message.Length];
                    num6 = (float)Math.Sin(timer * 2f + (float)i / 8f) * 8f;
                    x = ((!(Math.Sin(timer * 4f + (float)i / 16f) < 0.0)) ? 1 : (-1));
                }

                ActiveFont.Draw(context, this, c, vector + new Vector2(x2, num4 + num6), new Vector2(0.5f, 1f),
                    new Vector2(x, 1f), PackedColor.White * num);
                num3++;
            }
        }
    }
}
