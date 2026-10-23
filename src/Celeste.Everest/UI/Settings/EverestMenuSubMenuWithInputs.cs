using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Bindings;
using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Framework;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuSubMenuWithInputs : TextMenuPresentation.Item, IEverestMenuItemExt
    {
        private OriginalGameInputProcess Input =>
            ((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource;

        private readonly object[] Items;

        public PackedColor TextColor { get; set; } = PackedColor.Gray;

        public PackedColor ButtonColor { get; set; } = PackedColor.White;

        public PackedColor StrokeColor { get; set; } = PackedColor.White;

        public float Alpha { get; set; } = 1f;

        public float Scale { get; set; } = 0.6f;

        public string Icon { get; set; }

        public float? IconWidth { get; set; }

        public bool IconOutline { get; set; }

        public Vector2 Offset { get; set; }

        public EverestMenuSubMenuWithInputs(TextMenuResources resources, string text, char separator,
            SourceVirtualButton[] buttons)
        {
            Resources = resources;
            string[] array = text.Split(separator);
            Items = new object[array.Length * 2 - 1];
            for (int i = 0; i < Items.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Items[i] = array[i / 2];
                }
                else
                {
                    Items[i] = buttons[i / 2];
                }
            }
        }

        public override float Height()
        {
            return ActiveFont.LineHeight;
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            Vector2 position2 = position;
            Vector2 justify = new Vector2(0f, 0.5f);
            float num = Alpha * Alpha * Alpha;
            object[] items = Items;
            foreach (object obj in items)
            {
                if (obj is string)
                {
                    ActiveFont.DrawOutline(context, Container, obj as string, position2, justify, Vector2.One * Scale,
                        TextColor * Alpha, 2f, PackedColor.Black * num);
                    position2.X += ActiveFont.Measure(obj as string).X * Scale;
                }
                else if (obj is SourceVirtualButton)
                {
                    SourceVirtualButton virtualButton = obj as SourceVirtualButton;
                    AtlasEntry mTexture = (Input.GuiInputController(OriginalGameInputProcess.PrefixMode.Latest)
                        ? Input.GuiButton(virtualButton, OriginalGameInputProcess.PrefixMode.Attached)
                        : ((virtualButton.Binding.Keyboard.Count <= 0)
                            ? Input.GuiKey(SourceKeys.None)
                            : Input.GuiKey(virtualButton.Binding.Keyboard[0])));
                    SourceAtlasDrawing.DrawJustified(context, Container, mTexture, position2, justify,
                        ButtonColor * num,
                        Scale);
                    position2.X += (float)mTexture.Width * Scale;
                }
            }
        }
    }
}
