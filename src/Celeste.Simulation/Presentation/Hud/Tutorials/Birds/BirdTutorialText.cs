using System;
using System.IO;

namespace Celeste.Simulation.Presentation.Hud.Tutorials.Birds
{
    public sealed class BirdTutorialText
    {
        public string FontFace { get; private set; }
        public float FontSize { get; private set; }
        public string Carry { get; private set; } = "XXX";
        public string Hold { get; private set; } = "XXX";

        public static BirdTutorialText ReadDialogExport(
            string path)
        {
            var result = new BirdTutorialText();
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                reader.ReadString();
                reader.ReadString();
                reader.ReadString();
                reader.ReadInt32();
                result.FontFace = reader.ReadString();
                result.FontSize = reader.ReadSingle();
                reader.ReadString();
                reader.ReadString();
                reader.ReadString();
                reader.ReadInt32();
                reader.ReadInt32();
                var count = reader.ReadInt32();
                for (var i = 0; i < count; i++)
                {
                    var key = reader.ReadString();
                    reader.ReadString();
                    var cleaned = reader.ReadString();
                    if (key.Equals("tutorial_carry", StringComparison.OrdinalIgnoreCase)) result.Carry = cleaned;
                    else if (key.Equals("tutorial_hold", StringComparison.OrdinalIgnoreCase)) result.Hold = cleaned;
                }
            }

            return result;
        }
    }
}
