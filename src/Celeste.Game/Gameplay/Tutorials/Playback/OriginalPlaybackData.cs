using System.Collections.Generic;
using System.IO;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;

namespace Celeste.Game.Gameplay.Tutorials.Playback
{
    public static class OriginalPlaybackData
    {
        public static void Export(List<ChaserState> list, string path)
        {
            var timeStamp = list[0].TimeStamp;
            var position = list[0].Position;
            using var binaryWriter = new BinaryWriter(File.OpenWrite(path));
            binaryWriter.Write("TIMELINE");
            binaryWriter.Write(2);
            binaryWriter.Write(list.Count);
            foreach (var item in list)
            {
                binaryWriter.Write(item.Position.X - position.X);
                binaryWriter.Write(item.Position.Y - position.Y);
                binaryWriter.Write(item.TimeStamp - timeStamp);
                binaryWriter.Write(item.Animation);
                binaryWriter.Write(item.Facing);
                binaryWriter.Write(item.OnGround);
                var hairColor = item.HairColor;
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
