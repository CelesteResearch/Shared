using System;
using System.Linq;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Reflection;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands
    {
        public override void Log(object obj, PackedColor color)
        {
            var text = obj.ToString();
            if (debugRClog != null)
            {
                debugRClog.AppendLine(text);
                return;
            }

            if (text.Contains("\n"))
            {
                var array = text.Split('\n');
                foreach (var obj2 in array) Log(obj2, color);

                return;
            }

            var num = process.ViewWidth - 40;
            while (process.Draw.DefaultFont.MeasureString(text).X > num)
            {
                var num2 = -1;
                for (var j = 0; j < text.Length; j++)
                    if (text[j] == ' ')
                    {
                        if (process.Draw.DefaultFont.MeasureString(text.Substring(0, j)).X > num) break;

                        num2 = j;
                    }

                if (num2 == -1) break;

                drawCommands.Insert(0, new(text.Substring(0, num2), color));
                text = text.Substring(num2 + 1);
            }

            drawCommands.Insert(0, new(text, color));
            var num3 = Math.Max(installed.Settings.ExtraCommandHistoryLines + (process.ViewHeight - 100) / 30, 0);
            firstLineIndexToDraw = ScalarMath.Clamp(firstLineIndexToDraw, 0, Math.Max(drawCommands.Count - 1, 0));
            while (drawCommands.Count > num3) drawCommands.RemoveAt(drawCommands.Count - 1);
        }

        public override void Log(object obj)
        {
            Log(obj, PackedColor.White);
        }

        protected override void InvokeMethod(ISourceCommandMethodMetadata method,
            object[] param = null)
        {
            try
            {
                method.Invoke(null, param);
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                process.Commands.Log(innerException.Message, PackedColor.Yellow);
                LogStackTrace(innerException.StackTrace);
                if (ContainCantDrawChar(innerException.Message + innerException.StackTrace))
                {
                    process.Commands.Log(
                        "Please check log.txt for full exception log, because it contains characters that can't be displayed.",
                        PackedColor.Yellow);
                    installed.Logger.LogDetailed(innerException, "Commands");
                }
            }
        }

        private bool ContainCantDrawChar(string text)
        {
            return text.ToCharArray()
                .Any(c => !process.Draw.DefaultFont.Characters.Contains(c) && !char.IsControl(c));
        }
    }
}
