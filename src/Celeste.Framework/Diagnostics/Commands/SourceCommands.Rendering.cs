using Celeste.Core.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        public virtual void Render()
        {
            var viewWidth = process.ViewWidth;
            var viewHeight = process.ViewHeight;
            process.Draw.SpriteBatch.Begin();
            SourcePrimitiveDrawing.Rect(process, 10f, viewHeight - 50, viewWidth - 20, 40f, PackedColor.Black * 0.8f);
            if (underscore)
                process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, ">" + currentText + "_",
                    new(20f, viewHeight - 42), PackedColor.White.PackedValue);
            else
                process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, ">" + currentText,
                    new(20f, viewHeight - 42), PackedColor.White.PackedValue);

            if (drawCommands.Count > 0)
            {
                var num = 10 + 30 * drawCommands.Count;
                SourcePrimitiveDrawing.Rect(process, 10f, viewHeight - num - 60, viewWidth - 20, num,
                    PackedColor.Black * 0.8f);
                for (var i = 0; i < drawCommands.Count; i++)
                    process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, drawCommands[i].Text,
                        new(20f, viewHeight - 92 - 30 * i), drawCommands[i].Color.PackedValue);
            }

            process.Draw.SpriteBatch.End();
        }
    }
}
