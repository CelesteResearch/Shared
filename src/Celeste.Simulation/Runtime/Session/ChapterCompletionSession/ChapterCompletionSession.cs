using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Inventory;
using Celeste.Simulation.Runtime.Session.Maps;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation.Runtime.Session
{
    public sealed partial class ChapterCompletionSession
    {
        [DataContract]
        public sealed class Counter
        {
            [DataMember] public string Key;
            [DataMember] public int Value;
        }

        [DataMember] public Vector2? RespawnPoint;
        [DataMember] public RoomAudioState Audio = new();
        [DataMember] public RoomPlayerInventory Inventory;
        [DataMember] public HashSet<string> Flags = [];
        [DataMember] public HashSet<string> LevelFlags = [];

        [DataMember] public HashSet<MapEntityId> DoNotLoad = [];

        [DataMember] public HashSet<MapEntityId> Keys = [];

        [DataMember] public List<Counter> Counters = [];
        [DataMember] public string FurthestSeenLevel, Level, ColorGrade;
        [DataMember] public int DeathsInCurrentLevel;
        [DataMember] public bool Dreaming;
        [DataMember] public float LightingAlphaAdd, BloomBaseAdd;
        [DataMember] public float DarkRoomAlpha = .75f;
        [DataMember] public RoomCoreMode CoreMode;
        public bool JustStarted = true;

        public IChapterSessionMapData MapData =>
            sourceSessionMaps
                .GetMap(AreaID, Mode);

        public IChapterSessionLevelData LevelData =>
            MapData.GetLevel(Level);

        public int DetectedStrawberries
        {
            get => MapData.DetectedStrawberries;
            set => MapData.DetectedStrawberries = value;
        }

        private ChapterCompletionSession()
        {
        }

        [OnDeserializing]
        private void Deserializing(StreamingContext context)
        {
            JustStarted = true;
        }

        public ChapterCompletionSession Restart(string intoLevel = null)
        {
            var session = sourceSessionFactory.Restart(this, StartCheckpoint, OldStats);
            session.UnlockedCSide = UnlockedCSide;
            if (intoLevel != null)
            {
                session.Level = intoLevel;
                if (intoLevel != MapData.StartLevel().Name)
                    session.StartedFromBeginning = false;
            }

            return session;
        }

        public void UpdateLevelStartDashes()
        {
            DashesAtLevelStart = Dashes;
        }

        public Vector2 GetSpawnPoint(Vector2 from)
        {
            return Vector2Selection.ClosestTo(
                LevelData.Spawns, from, sourceVectorEnvironment.VectorArithmetic);
        }

        public bool GetFlag(string flag)
        {
            return Flags.Contains(flag);
        }

        public void SetFlag(string flag, bool setTo = true)
        {
            if (!sourceSessionFactory.AllowFlagChange(this, flag, setTo)) return;
            if (setTo) Flags.Add(flag);
            else Flags.Remove(flag);
        }

        public int GetCounter(string counter)
        {
            for (var i = 0; i < Counters.Count; i++)
                if (Counters[i].Key.Equals(counter))
                    return Counters[i].Value;
            return 0;
        }

        public void SetCounter(string counter, int value)
        {
            for (var i = 0; i < Counters.Count; i++)
                if (Counters[i].Key.Equals(counter))
                {
                    Counters[i].Value = value;
                    return;
                }

            Counters.Add(new() { Key = counter, Value = value });
        }

        public void IncrementCounter(string counter)
        {
            for (var i = 0; i < Counters.Count; i++)
                if (Counters[i].Key.Equals(counter))
                {
                    Counters[i].Value++;
                    return;
                }

            Counters.Add(new() { Key = counter, Value = 1 });
        }

        public bool GetLevelFlag(string level)
        {
            return LevelFlags.Contains(level);
        }
    }
}
