using Celeste.Core.Display;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        public virtual void Log(object obj, PackedColor color)
        {
            string text = obj.ToString();
            if (text.Contains("\n"))
            {
                string[] array = text.Split(new char[1] { '\n' });
                foreach (string obj2 in array)
                {
                    Log(obj2, color);
                }

                return;
            }

            int num = process.WindowClientBounds.Width - 40;
            while (process.Draw.DefaultFont.MeasureString(text).X > (float)num)
            {
                int num2 = -1;
                for (int j = 0; j < text.Length; j++)
                {
                    if (text[j] == ' ')
                    {
                        if (!(process.Draw.DefaultFont.MeasureString(text.Substring(0, j)).X <= (float)num))
                        {
                            break;
                        }

                        num2 = j;
                    }
                }

                if (num2 == -1)
                {
                    break;
                }

                drawCommands.Insert(0, new SourceCommandLine(text.Substring(0, num2), color));
                text = text.Substring(num2 + 1);
            }

            drawCommands.Insert(0, new SourceCommandLine(text, color));
            int num3 = (process.WindowClientBounds.Height - 100) / 30;
            while (drawCommands.Count > num3)
            {
                drawCommands.RemoveAt(drawCommands.Count - 1);
            }
        }

        public virtual void Log(object obj)
        {
            Log(obj, PackedColor.White);
        }

        public void LogStackTrace(string stackTrace)
        {
            string[] array = stackTrace.Split(new char[1] { '\n' });
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                int num = text.LastIndexOf(" in ") + 4;
                int num2 = text.LastIndexOf('\\') + 1;
                if (num != -1 && num2 != -1)
                {
                    text = text.Substring(0, num) + text.Substring(num2);
                }

                int num3 = text.IndexOf('(') + 1;
                int num4 = text.IndexOf(')');
                if (num3 != -1 && num4 != -1)
                {
                    text = text.Substring(0, num3) + text.Substring(num4);
                }

                int num5 = text.LastIndexOf(':');
                if (num5 != -1)
                {
                    text = text.Insert(num5 + 1, " ").Insert(num5, " ");
                }

                text = text.TrimStart(new char[0]);
                text = "-> " + text;
                process.Commands.Log(text, PackedColor.White);
            }
        }
    }
}
