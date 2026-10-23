using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Text;
using Celeste.Scene.Entities;
using Celeste.Simulation.Audio.Sources;
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

        private readonly string message;

        private float alpha;

        private float timer;

        private readonly float widestCharacter;

        private readonly int firstLineLength;

        private readonly SoundSource textSfx;

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
            for (var i = 0; i < message.Length; i++)
            {
                var x = ActiveFont.Measure(message[i]).X;
                if (x > widestCharacter) widestCharacter = x;
            }

            widestCharacter *= 0.9f;
        }

        public override void Update()
        {
            base.Update();
            if ((Scene as OriginalLevelSceneRoot).Paused)
            {
                textSfx.Pause();
                return;
            }

            timer += engine.DeltaTime;
            if (!Show)
            {
                alpha = ScalarMath.Approach(alpha, 0f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (alpha <= 0f) index = firstLineLength;
            }
            else
            {
                alpha = ScalarMath.Approach(alpha, 1f, engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (alpha >= 1f)
                    index = ScalarMath.Approach(index, message.Length, 32f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            if (Show && alpha >= 1f && index < message.Length)
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
            if ((Scene as OriginalLevelSceneRoot).FrozenOrPaused ||
                (Scene as OriginalLevelSceneRoot).Completed ||
                !(index > 0f) || !(alpha > 0f))
                return;

            var camera = ((OriginalLevelSceneRoot)Scene).Camera;
            var vector = new Vector2((Memorial.Position.X - camera.Position.X) * 6f,
                (Memorial.Position.Y - camera.Position.Y) * 6f - 350f - ActiveFont.LineHeight * 3.3f);
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode)
                vector.X = 1920f - vector.X;

            var num = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(alpha);
            var num2 = (int)((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(message.Length, index);
            var num3 = 0;
            var num4 = 64f * (1f - num);
            var num5 = CountToNewline(0);
            for (var i = 0; i < num2; i++)
            {
                var c = message[i];
                if (c == '\n')
                {
                    num3 = 0;
                    num5 = CountToNewline(i + 1);
                    num4 += ActiveFont.LineHeight * 1.1f;
                    continue;
                }

                var x = 1f;
                var x2 = -num5 * widestCharacter / 2f + (num3 + 0.5f) * widestCharacter;
                var num6 = 0f;
                if (Dreamy && c != ' ' && c != '-' && c != '\n')
                {
                    c = message[
                        (i + (int)(Math.Sin(timer * 2f + i / 8f) * 4.0) + message.Length) % message.Length];
                    num6 = (float)Math.Sin(timer * 2f + i / 8f) * 8f;
                    x = !(Math.Sin(timer * 4f + i / 16f) < 0.0) ? 1 : -1;
                }

                ActiveFont.Draw(context, this, c, vector + new Vector2(x2, num4 + num6), new(0.5f, 1f),
                    new(x, 1f), PackedColor.White * num);
                num3++;
            }
        }
    }
}
