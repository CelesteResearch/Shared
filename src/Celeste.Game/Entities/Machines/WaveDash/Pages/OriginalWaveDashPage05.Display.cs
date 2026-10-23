using Celeste.Core.Display;
using System;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Input.Gameplay;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Simulation.UI.Menus.Completion;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Threading;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Audio.Fmod.Events;
using Celeste.Game.Entities.Machines.WaveDash.Playback;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public partial class OriginalWaveDashPage05
    {
        private class Display
        {
            public Vector2 Position;

            public RichTextLayout Info;

            public OriginalWaveDashPlaybackTutorial Tutorial;

            private SimulationCoroutine routine;

            private float xEase;

            private float time;
            private readonly ISourceEngineContext engine;

            public Display(ISourceEngineContext engine, Vector2 position, string text, string tutorial,
                Vector2 tutorialOffset)
            {
                this.engine = engine;
                Position = position;
                Info = OriginalFancyTextParser.Parse(text, 896, 8, 1f, PackedColor.Black * 0.6f,
                    OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
                Tutorial = new OriginalWaveDashPlaybackTutorial(engine, tutorial, tutorialOffset, new Vector2(1f, 1f),
                    new Vector2(1f, 1f));
                Tutorial.OnRender = delegate(ISourceRenderContext context)
                {
                    SourcePrimitiveDrawing.Line((ISourceDrawScope)context, -64f, 20f, 64f, 20f, PackedColor.Black,
                        ((ISourceVectorEnvironment)engine).VectorArithmetic);
                };
                routine = new SimulationCoroutine(engine, Routine());
            }

            private IEnumerator Routine()
            {
                Celeste.Simulation.Gameplay.Tutorial.Replay.PlayerPlaybackState playback = Tutorial.Playback;
                int step = 0;
                while (true)
                {
                    int frameIndex = playback.FrameIndex;
                    if (step % 2 == 0)
                    {
                        Tutorial.Update();
                    }

                    if (frameIndex != playback.FrameIndex && playback.FrameIndex == playback.FrameCount - 1)
                    {
                        while (time < 3f)
                        {
                            yield return null;
                        }

                        yield return 0.1f;
                        while (xEase < 1f)
                        {
                            xEase = ScalarMath.Approach(xEase, 1f, engine.DeltaTime * 4f,
                                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                            yield return null;
                        }

                        xEase = 1f;
                        yield return 0.5f;
                        xEase = 0f;
                        time = 0f;
                    }

                    step++;
                    yield return null;
                }
            }

            public void Update()
            {
                time += engine.DeltaTime;
                routine.Update();
            }

            public void Render(ISourceRenderContext context)
            {
                Tutorial.Render(context, Position, 4f);
                Info.DrawJustifyPerLine(context, null, (ISourceRichTextDrawProcess)engine,
                    Position + Vector2.UnitY * 200f,
                    new Vector2(0.5f, 0f), Vector2.One * 0.8f, 1f);
                if (xEase > 0f)
                {
                    Vector2 vector = Vector2Geometry.AngleToVector((1f - xEase) * 0.1f + (float)Math.PI / 4f, 1f);
                    Vector2 vector2 = new Vector2(-vector.Y, vector.X);
                    float num = 0.5f + (1f - xEase) * 0.5f;
                    float thickness = 64f * num;
                    float num2 = 300f * num;
                    Vector2 position = Position;
                    SourcePrimitiveDrawing.Line((ISourceDrawScope)context, position - vector * num2,
                        position + vector * num2, PackedColor.Red, thickness,
                        ((ISourceVectorEnvironment)engine).VectorArithmetic);
                    SourcePrimitiveDrawing.Line((ISourceDrawScope)context, position - vector2 * num2,
                        position + vector2 * num2, PackedColor.Red, thickness,
                        ((ISourceVectorEnvironment)engine).VectorArithmetic);
                }
            }
        }
    }
}
