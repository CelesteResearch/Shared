using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Hud.Tutorials.Birds
{
    public sealed class BirdTutorialText
    {
        public string FontFace { get; private set; }
        public float FontSize { get; private set; }
        public string Carry { get; private set; } = "XXX";
        public string Hold { get; private set; } = "XXX";

        public static global::Celeste.Simulation.Presentation.Hud.Tutorials.Birds.BirdTutorialText ReadDialogExport(
            string path)
        {
            var result = new global::Celeste.Simulation.Presentation.Hud.Tutorials.Birds.BirdTutorialText();
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
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string key = reader.ReadString();
                    reader.ReadString();
                    string cleaned = reader.ReadString();
                    if (key.Equals("tutorial_carry", StringComparison.OrdinalIgnoreCase)) result.Carry = cleaned;
                    else if (key.Equals("tutorial_hold", StringComparison.OrdinalIgnoreCase)) result.Hold = cleaned;
                }
            }

            return result;
        }
    }
}
