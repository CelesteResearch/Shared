using System;
using System.IO;
using System.Text;
using Celeste.Game.Execution.Diagnostics;

namespace Celeste.Game.Execution.Threading
{
    public static class OriginalGameErrorLog
    {
        public const string Filename = "error_log.txt";
        public const string Marker = "==========================================";

        public static void Write(Exception exception, IOriginalGameErrorIdentity engine)
            => Write(exception.ToString(), engine);

        public static void Write(string message, IOriginalGameErrorIdentity engine)
            => Write(message, engine, PhysicalIo, Filename,
                () => engine.Version.ToString());

        private static readonly IOriginalErrorLogIo PhysicalIo = new FileOriginalErrorLogIo();

        public static void Write(string message, IOriginalGameErrorIdentity engine,
            IOriginalErrorLogIo io, string filename, Func<string> getVersionText)
        {
            var builder = new StringBuilder();
            string previous = "";
            if (Path.IsPathRooted(filename))
            {
                string directory = Path.GetDirectoryName(filename);
                if (!io.DirectoryExists(directory))
                    io.CreateDirectory(directory);
            }

            if (io.FileExists(filename))
            {
                var reader = io.OpenReader(filename);
                previous = reader.ReadToEnd();
                reader.Close();
                if (!previous.Contains(Marker))
                    previous = "";
            }

            builder.Append(engine != null ? engine.Title : "Monocle Engine");
            builder.AppendLine(" Error Log");
            builder.AppendLine(Marker);
            builder.AppendLine();
            if (engine != null && engine.Version != null)
            {
                builder.Append("Ver ");
                builder.AppendLine(getVersionText());
            }

            builder.AppendLine(DateTime.Now.ToString());
            builder.AppendLine(message);
            if (previous != "")
            {
                int start = previous.IndexOf(Marker) + Marker.Length;
                builder.AppendLine(previous.Substring(start));
            }

            var writer = io.OpenWriter(filename, false);
            writer.Write(builder.ToString());
            writer.Close();
        }
    }
}
