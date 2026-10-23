using Celeste.Core.Display;
using Celeste.Graphics.Animation.Replay;
using Celeste.Graphics.Display;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Formats.Replay.Timelines
{
    public static class PlaybackTimelineCodec
    {
        public const string Header = "TIMELINE";

        public static void Export(List<CharacterReplayFrame> list, string path)
        {
            float timeStamp = list[0].TimeStamp;
            Vector2 position = list[0].Position;
            using System.IO.BinaryWriter binaryWriter = new System.IO.BinaryWriter(System.IO.File.OpenWrite(path));
            binaryWriter.Write("TIMELINE");
            binaryWriter.Write(2);
            binaryWriter.Write(list.Count);
            foreach (CharacterReplayFrame item in list)
            {
                binaryWriter.Write(item.Position.X - position.X);
                binaryWriter.Write(item.Position.Y - position.Y);
                binaryWriter.Write(item.TimeStamp - timeStamp);
                binaryWriter.Write(item.Animation);
                binaryWriter.Write((int)item.Facing);
                binaryWriter.Write(item.OnGround);
                PackedColor hairColor = item.HairColour;
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
            using (var reader = new System.IO.BinaryReader(new System.IO.MemoryStream(buffer)))
            {
                int version = 1;
                if (reader.ReadString() == Header) version = reader.ReadInt32();
                else reader.BaseStream.Seek(0L, System.IO.SeekOrigin.Begin);
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    var frame = new CharacterReplayFrame
                    {
                        Position = new Vector2(reader.ReadSingle(), reader.ReadSingle()),
                        TimeStamp = reader.ReadSingle(),
                        Animation = reader.ReadString(),
                        Facing = reader.ReadInt32(),
                        OnGround = reader.ReadBoolean(),
                        HairColour = new PackedColor(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(),
                            255),
                        Depth = reader.ReadInt32()
                    };
                    if (version == 1)
                    {
                        frame.Scale = new Vector2(frame.Facing, 1f);
                        frame.DashDirection = Vector2.Zero;
                    }
                    else
                    {
                        frame.Scale = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                        frame.DashDirection = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                    }

                    frames.Add(frame);
                }
            }

            return frames;
        }
    }
}
