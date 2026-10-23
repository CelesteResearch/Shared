using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Localization.Lookup;
using Celeste.Scene.Entities;
using Celeste.Simulation.Audio.Sources;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;

namespace Celeste.Everest.Entities.Memorials
{
    /// <summary>
    ///     Based on MemorialText, spawned by CustomMemorial.
    /// </summary>
    public class CustomMemorialTextState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private ActiveBitmapFont ActiveFont => ((IOriginalGameTextEnvironment)engine).Text.ActiveFont;

        private DialogCatalog Dialog =>
            ((IOriginalGameTextEnvironment)engine).Text.Dialog;

        private OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        public CustomMemorialState Memorial;

        public bool Show;

        public bool Dreamy;

        public string Message;

        public float Spacing;

        private float index;

        private float alpha;

        private float timer;

        private readonly float[] lineWidths;

        private readonly int firstLineLength;

        private readonly SoundSource textSfx;

        private bool textSfxPlaying;

        private readonly Dictionary<int, SourcePixelFontCharacter> charChars;

        public CustomMemorialTextState(CustomMemorialState memorial, bool dreamy, string text, float spacing,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            OwnedComponents.Add(textSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            Dreamy = dreamy;
            Memorial = memorial;
            Message = text;
            Spacing = spacing;
            firstLineLength = CountToNewline(0);
            var array = text.Split('\n');
            lineWidths = new float[array.Length];
            for (var i = 0; i < array.Length; i++)
                lineWidths[i] = ActiveFont.Measure(array[i]).X + spacing * array[i].Length;

            charChars = ActiveFont.Font.Get(ActiveFont.BaseSize).Characters;
        }

        public override void Update()
        {
            base.Update();
            if (((OriginalLevelSceneRoot)Scene).Paused)
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
                    index = ScalarMath.Approach(index, Message.Length, 32f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            if (Show && alpha >= 1f && index < Message.Length)
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
            for (i = start; i < Message.Length && Message[i] != '\n'; i++)
            {
            }

            return i - start;
        }

        public override void Render(ISourceRenderContext context)
        {
            var level = (OriginalLevelSceneRoot)Scene;
            if (level.FrozenOrPaused || level.Completed || index <= 0f || alpha <= 0f) return;

            var camera = level.Camera;
            var vector = new Vector2((Memorial.X - camera.X) * (6f * level.Zoom),
                (Memorial.Y - camera.Y) * (6f * level.Zoom) - 350f - ActiveFont.LineHeight * 3.3f);
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode)
                vector.X = 1920f - vector.X;

            var num = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(alpha);
            var num2 = (int)Math.Min(Message.Length, index);
            for (var i = 0; i < 2; i++)
            {
                var num3 = 64f * (1f - num);
                CountToNewline(0);
                var num4 = 0;
                var num5 = 0;
                var num6 = 0f;
                for (var j = 0; j < num2; j++)
                {
                    var c = Message[j];
                    SourcePixelFontCharacter value;
                    if (c == '\n')
                    {
                        num4 = 0;
                        num5++;
                        CountToNewline(j + 1);
                        num3 += ActiveFont.LineHeight * 1.1f;
                        num6 = 0f;
                    }
                    else if (charChars.TryGetValue(c, out value))
                    {
                        var x = num6 - lineWidths[num5] * 0.5f;
                        num6 += value.XAdvance;
                        if (j < Message.Length - 1 && value.Kerning.TryGetValue(Message[j + 1], out var value2))
                            num6 += value2;

                        num6 += Spacing;
                        var x2 = 1f;
                        var num7 = 0f;
                        if (Dreamy && c != ' ' && c != '-' && c != '\n')
                        {
                            c = Message[
                                (j + (int)(Math.Sin(timer * 2f + j / 8f) * 4.0) + Message.Length) %
                                Message.Length];
                            num7 = (float)Math.Sin(timer * 2f + j / 8f) * 8f;
                            x2 = Math.Sin(timer * 4f + j / 16f) < 0.0 ? -1f : 1f;
                        }

                        if (i == 0)
                            ActiveFont.DrawOutline(context, this, c.ToString(), vector + new Vector2(x, num3 + num7),
                                new(0f, 1f), new(x2, 1f), PackedColor.Transparent, 2f,
                                PackedColor.Black * num * num * num);
                        else
                            ActiveFont.DrawOutline(context, this, c.ToString(), vector + new Vector2(x, num3 + num7),
                                new(0f, 1f), new(x2, 1f), PackedColor.White * num, 2f,
                                PackedColor.Transparent);

                        num4++;
                    }
                }
            }
        }
    }
}
