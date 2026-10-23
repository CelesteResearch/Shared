using Celeste.Core.Display;
using Celeste.Graphics.Display;
using System.Collections.Generic;
using System.IO;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Gameplay.Tutorials.Playback
{
    public static class OriginalPlaybackData
    {
        public static void Export(List<ChaserState> list, string path)
        {
            float timeStamp = list[0].TimeStamp;
            System.Numerics.Vector2 position = list[0].Position;
            using BinaryWriter binaryWriter = new BinaryWriter(File.OpenWrite(path));
            binaryWriter.Write("TIMELINE");
            binaryWriter.Write(2);
            binaryWriter.Write(list.Count);
            foreach (ChaserState item in list)
            {
                binaryWriter.Write(item.Position.X - position.X);
                binaryWriter.Write(item.Position.Y - position.Y);
                binaryWriter.Write(item.TimeStamp - timeStamp);
                binaryWriter.Write(item.Animation);
                binaryWriter.Write((int)item.Facing);
                binaryWriter.Write(item.OnGround);
                PackedColor hairColor = item.HairColor;
                binaryWriter.Write(hairColor.R);
                hairColor = item.HairColor;
                binaryWriter.Write(hairColor.G);
                hairColor = item.HairColor;
                binaryWriter.Write(hairColor.B);
                binaryWriter.Write(item.Depth);
                binaryWriter.Write(item.Scale.X);
                binaryWriter.Write(item.Scale.Y);
                binaryWriter.Write(item.DashDirection.X);
                binaryWriter.Write(item.DashDirection.Y);
            }
        }
    }
}
