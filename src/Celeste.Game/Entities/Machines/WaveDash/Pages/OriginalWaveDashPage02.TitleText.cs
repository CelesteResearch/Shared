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

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public partial class OriginalWaveDashPage02
    {
        private class TitleText
        {
            public const float Scale = 1.5f;

            public string Text;

            public Vector2 Position;

            public float Width;

            private float ease;
            private readonly ISourceEngineContext engine;

            public TitleText(ISourceEngineContext engine, Vector2 pos, string text)
            {
                this.engine = engine;
                Position = pos;
                Text = text;
                Width = ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Measure(text).X * 1.5f;
            }

            public IEnumerator Stamp()
            {
                while (ease < 1f)
                {
                    ease = ScalarMath.Approach(ease, 1f, engine.DeltaTime * 4f,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    yield return null;
                }

                yield return 0.2f;
            }

            public void Render(ISourceRenderContext context)
            {
                if (!(ease <= 0f))
                {
                    Vector2 scale = Vector2.One *
                                    (1f + (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(ease))) *
                                    1.5f;
                    ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.DrawOutline(context, null, Text,
                        Position + new Vector2(Width / 2f,
                            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.LineHeight * 0.5f * 1.5f),
                        new Vector2(0.5f, 0.5f), scale, PackedColor.White, 2f, PackedColor.Black);
                }
            }
        }
    }
}
