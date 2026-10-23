using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Celeste.Graphics.Animation.Replay;

namespace Celeste.Formats.Replay.Timelines
{
    public static class PlaybackTimelineCodec
    {
        public const string Header = "TIMELINE";

        public static void Export(List<CharacterReplayFrame> list, string path)
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
                var hairColor = item.HairColour;
                binaryWriter.Write(hairColor.R);
                hairColor = item.HairColour;
                binaryWriter.Write(hairColor.G);
                hairColor = item.HairColour;
                binaryWriter.Write(hairColor.B);
                binaryWriter.Write(item.Depth);
                binaryWriter.Write(item.Scale.X);
                binaryWriter.Write(item.Scale.Y);
                binaryWriter.Write(item.DashDirection.X);
                binaryWriter.Write(item.DashDirection.Y);
            }
        }


        public static List<CharacterReplayFrame> Import(byte[] buffer)
        {
            // PlaybackData.Import (:53-99).
            var frames = new List<CharacterReplayFrame>();
            using (var reader = new BinaryReader(new MemoryStream(buffer)))
            {
                var version = 1;
                if (reader.ReadString() == Header) version = reader.ReadInt32();
                else reader.BaseStream.Seek(0L, SeekOrigin.Begin);
                var count = reader.ReadInt32();
                for (var i = 0; i < count; i++)
                {
                    var frame = new CharacterReplayFrame
                    {
                        Position = new(reader.ReadSingle(), reader.ReadSingle()),
                        TimeStamp = reader.ReadSingle(),
                        Animation = reader.ReadString(),
                        Facing = reader.ReadInt32(),
                        OnGround = reader.ReadBoolean(),
                        HairColour = new(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(),
                            255),
                        Depth = reader.ReadInt32(),
                    };
                    if (version == 1)
                    {
                        frame.Scale = new(frame.Facing, 1f);
                        frame.DashDirection = Vector2.Zero;
                    }
                    else
                    {
                        frame.Scale = new(reader.ReadSingle(), reader.ReadSingle());
                        frame.DashDirection = new(reader.ReadSingle(), reader.ReadSingle());
                    }

                    frames.Add(frame);
                }
            }

            return frames;
        }
    }
}
