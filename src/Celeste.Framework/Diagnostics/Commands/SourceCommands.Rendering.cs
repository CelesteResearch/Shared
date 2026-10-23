using Celeste.Core.Display;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Display;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        public virtual void Render()
        {
            int viewWidth = process.ViewWidth;
            int viewHeight = process.ViewHeight;
            process.Draw.SpriteBatch.Begin();
            SourcePrimitiveDrawing.Rect(process, 10f, viewHeight - 50, viewWidth - 20, 40f, PackedColor.Black * 0.8f);
            if (underscore)
            {
                process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, ">" + currentText + "_",
                    new Vector2(20f, viewHeight - 42), PackedColor.White.PackedValue);
            }
            else
            {
                process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, ">" + currentText,
                    new Vector2(20f, viewHeight - 42), PackedColor.White.PackedValue);
            }

            if (drawCommands.Count > 0)
            {
                int num = 10 + 30 * drawCommands.Count;
                SourcePrimitiveDrawing.Rect(process, 10f, viewHeight - num - 60, viewWidth - 20, num,
                    PackedColor.Black * 0.8f);
                for (int i = 0; i < drawCommands.Count; i++)
                {
                    process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, drawCommands[i].Text,
                        new Vector2(20f, viewHeight - 92 - 30 * i), drawCommands[i].Color.PackedValue);
                }
            }

            process.Draw.SpriteBatch.End();
        }
    }
}
