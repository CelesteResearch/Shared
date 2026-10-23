using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Bindings;
using Celeste.Core.Display;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Game.Controls.Source;
using Celeste.Simulation.UI.Menus.Text;
using Color = Celeste.Core.Display.PackedColor;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;

namespace Celeste.Game.Menus.Controls
{
    public class InputMappingInfoPresentation : TextMenuPresentation.Item
    {
        private readonly ISourceEngineContext engine;
        private OriginalGameInputProcess SourceInput => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private ActiveBitmapFont Font => ((ISourceActiveFontScope)engine).ActiveFont;
        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        private global::Celeste.Game.Content.Dialogs.OriginalGameTextProcess Text =>
            ((global::Celeste.Game.Content.Dialogs.IOriginalGameTextEnvironment)engine).Text;

        private List<object> info = new List<object>();

        private bool controllerMode;

        private float borderEase;

        private bool fixedPosition;

        public InputMappingInfoPresentation(ISourceEngineContext engine, bool controllerMode)
        {
            this.engine = engine;
            string[] array = Text.CleanDialog("BTN_CONFIG_INFO").Split('|');
            if (array.Length == 3)
            {
                info.Add(array[0]);
                info.Add(SourceInput.MenuConfirm);
                info.Add(array[1]);
                info.Add(SourceInput.MenuJournal);
                info.Add(array[2]);
            }

            this.controllerMode = controllerMode;
            AboveAll = true;
        }

        public override float LeftWidth()
        {
            return 100f;
        }

        public override float Height()
        {
            return Font.LineHeight * 2f;
        }

        public override void Update()
        {
            borderEase = ScalarMath.Approach(borderEase, fixedPosition ? 1f : 0f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            fixedPosition = false;
            if (position.Y < 100f)
            {
                fixedPosition = true;
                position.Y = 100f;
            }

            Color color = Color.Gray * Ease.CubeOut(Container.Alpha);
            Color strokeColor = Color.Black * Ease.CubeOut(Container.Alpha);
            Color color2 = Color.White * Ease.CubeOut(Container.Alpha);
            float num = 0f;
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i] is string)
                {
                    string text = info[i] as string;
                    num += Font.Measure(text).X * 0.6f;
                }
                else if (info[i] is SourceVirtualButton)
                {
                    SourceVirtualButton virtualButton = info[i] as SourceVirtualButton;
                    if (controllerMode)
                    {
                        AtlasEntry mTexture =
                            SourceInput.GuiButton(virtualButton, OriginalGameInputProcess.PrefixMode.Attached);
                        num += (float)mTexture.FrameWidth * 0.6f;
                    }
                    else if (virtualButton.Binding.Keyboard.Count > 0)
                    {
                        AtlasEntry mTexture2 = SourceInput.GuiKey(virtualButton.Binding.Keyboard[0]);
                        num += (float)mTexture2.FrameWidth * 0.6f;
                    }
                    else
                    {
                        AtlasEntry mTexture3 = SourceInput.GuiKey(Keys.None);
                        num += (float)mTexture3.FrameWidth * 0.6f;
                    }
                }
            }

            Vector2 position2 = position + new Vector2(Container.Width - num, 0f) / 2f;
            if (borderEase > 0f)
            {
                SourcePrimitiveDrawing.HollowRect(context, Container, position2.X - 22f, position2.Y - 42f, num + 44f,
                    84f,
                    Color.White * Ease.CubeOut(Container.Alpha) * borderEase);
                SourcePrimitiveDrawing.HollowRect(context, Container, position2.X - 21f, position2.Y - 41f, num + 42f,
                    82f,
                    Color.White * Ease.CubeOut(Container.Alpha) * borderEase);
                SourcePrimitiveDrawing.Rect(context, Container, position2.X - 20f, position2.Y - 40f, num + 40f, 80f,
                    Color.Black * Ease.CubeOut(Container.Alpha));
            }

            for (int j = 0; j < info.Count; j++)
            {
                if (info[j] is string)
                {
                    string text2 = info[j] as string;
                    Font.DrawOutline(context, Container, text2, position2, new Vector2(0f, 0.5f), Vector2.One * 0.6f,
                        color,
                        2f, strokeColor);
                    position2.X += Font.Measure(text2).X * 0.6f;
                }
                else if (info[j] is SourceVirtualButton)
                {
                    SourceVirtualButton virtualButton2 = info[j] as SourceVirtualButton;
                    if (controllerMode)
                    {
                        AtlasEntry mTexture4 =
                            SourceInput.GuiButton(virtualButton2, OriginalGameInputProcess.PrefixMode.Attached);
                        SourceAtlasDrawing.DrawJustified(context, Container, mTexture4, position2,
                            new Vector2(0f, 0.5f),
                            color2, 0.6f);
                        position2.X += (float)mTexture4.FrameWidth * 0.6f;
                    }
                    else if (virtualButton2.Binding.Keyboard.Count > 0)
                    {
                        AtlasEntry mTexture5 = SourceInput.GuiKey(virtualButton2.Binding.Keyboard[0]);
                        SourceAtlasDrawing.DrawJustified(context, Container, mTexture5, position2,
                            new Vector2(0f, 0.5f),
                            color2, 0.6f);
                        position2.X += (float)mTexture5.FrameWidth * 0.6f;
                    }
                    else
                    {
                        AtlasEntry mTexture6 = SourceInput.GuiKey(Keys.None);
                        SourceAtlasDrawing.DrawJustified(context, Container, mTexture6, position2,
                            new Vector2(0f, 0.5f),
                            color2, 0.6f);
                        position2.X += (float)mTexture6.FrameWidth * 0.6f;
                    }
                }
            }
        }
    }
}
