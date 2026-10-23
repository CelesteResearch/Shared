using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Simulation.Gameplay.Environment.Wind;

namespace Celeste.Game.Content.Maps.Levels
{
    public sealed class OriginalLevelRoomData : global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionLevelData
    {
        public string Name;
        string global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionLevelData.Name => Name;
        public bool Dummy;
        public int Strawberries;
        public bool HasGem, HasHeartGem, HasCheckpoint, DisableDownTransition;
        public IntRect Bounds;
        public List<OriginalLevelEntityData> Entities;
        public List<OriginalLevelEntityData> Triggers;
        public List<Vector2> Spawns;
        List<Vector2> global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionLevelData.Spawns => Spawns;
        public Vector2? DefaultSpawn;
        public global::Celeste.Core.Display.PackedColor? CustomEditorColor;
        public List<OriginalDecalPlacement> FgDecals;
        public List<OriginalDecalPlacement> BgDecals;
        public string Solids = "", Bg = "", FgTiles = "", BgTiles = "", ObjTiles = "";
        public RoomWindPattern WindPattern;
        public Vector2 CameraOffset;
        public bool Dark, Underwater, Space;
        public string Music = "", AltMusic = "", Ambience = "";
        public float[] MusicLayers = new float[4];
        public int MusicProgress = -1, AmbienceProgress = -1;
        public bool MusicWhispers, DelayAltMusic;
        public int EnforceDashNumber, EditorColorIndex;

        internal OriginalLevelRoomData(BinaryPackerElement source)
        {
        }

        public bool Check(Vector2 at)
        {
            if (at.X >= (float)Bounds.Left && at.Y >= (float)Bounds.Top && at.X < (float)Bounds.Right)
                return at.Y < (float)Bounds.Bottom;
            return false;
        }

        public IntRect TileBounds => new(Bounds.X / 8, Bounds.Y / 8,
            (int)Math.Ceiling((float)Bounds.Width / 8f), (int)Math.Ceiling((float)Bounds.Height / 8f));

        public Vector2 Position
        {
            get => new(Bounds.X, Bounds.Y);
            set
            {
                for (int i = 0; i < Spawns.Count; i++)
                    Spawns[i] -= Position;
                Bounds.X = (int)value.X;
                Bounds.Y = (int)value.Y;
                for (int i = 0; i < Spawns.Count; i++)
                    Spawns[i] += Position;
            }
        }

        public int LoadSeed
        {
            get
            {
                int value = 0;
                foreach (char character in Name)
                    value += character;
                return value;
            }
        }
    }
}
