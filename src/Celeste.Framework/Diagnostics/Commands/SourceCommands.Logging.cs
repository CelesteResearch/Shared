using Celeste.Core.Display;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        public virtual void Log(object obj, PackedColor color)
        {
            var text = obj.ToString();
            if (text.Contains("\n"))
            {
                var array = text.Split(['\n']);
                foreach (var obj2 in array) Log(obj2, color);

                return;
            }

            var num = process.WindowClientBounds.Width - 40;
            while (process.Draw.DefaultFont.MeasureString(text).X > num)
            {
                var num2 = -1;
                for (var j = 0; j < text.Length; j++)
                    if (text[j] == ' ')
                    {
                        if (!(process.Draw.DefaultFont.MeasureString(text.Substring(0, j)).X <= num)) break;

                        num2 = j;
                    }

                if (num2 == -1) break;

                drawCommands.Insert(0, new(text.Substring(0, num2), color));
                text = text.Substring(num2 + 1);
            }

            drawCommands.Insert(0, new(text, color));
            var num3 = (process.WindowClientBounds.Height - 100) / 30;
            while (drawCommands.Count > num3) drawCommands.RemoveAt(drawCommands.Count - 1);
        }

        public virtual void Log(object obj)
        {
            Log(obj, PackedColor.White);
        }

        public void LogStackTrace(string stackTrace)
        {
            var array = stackTrace.Split(['\n']);
            for (var i = 0; i < array.Length; i++)
            {
                var text = array[i];
                var num = text.LastIndexOf(" in ") + 4;
                var num2 = text.LastIndexOf('\\') + 1;
                if (num != -1 && num2 != -1) text = text.Substring(0, num) + text.Substring(num2);

                var num3 = text.IndexOf('(') + 1;
                var num4 = text.IndexOf(')');
                if (num3 != -1 && num4 != -1) text = text.Substring(0, num3) + text.Substring(num4);

                var num5 = text.LastIndexOf(':');
                if (num5 != -1) text = text.Insert(num5 + 1, " ").Insert(num5, " ");

                text = text.TrimStart( /* ReSharper disable once UseCollectionExpression */ new char[0]);
                text = "-> " + text;
                process.Commands.Log(text, PackedColor.White);
            }
        }
    }
}
