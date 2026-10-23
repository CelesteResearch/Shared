using Celeste.Simulation.Audio;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using Celeste.Simulation;

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
        [DataMember] public RoomAudioState Audio = new RoomAudioState();
        [DataMember] public global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory Inventory;
        [DataMember] public HashSet<string> Flags = new HashSet<string>();
        [DataMember] public HashSet<string> LevelFlags = new HashSet<string>();

        [DataMember] public HashSet<global::Celeste.Core.Maps.MapEntityId> DoNotLoad =
            new HashSet<global::Celeste.Core.Maps.MapEntityId>();

        [DataMember] public HashSet<global::Celeste.Core.Maps.MapEntityId> Keys =
            new HashSet<global::Celeste.Core.Maps.MapEntityId>();

        [DataMember] public List<Counter> Counters = new List<Counter>();
        [DataMember] public string FurthestSeenLevel, Level, ColorGrade;
        [DataMember] public int DeathsInCurrentLevel;
        [DataMember] public bool Dreaming;
        [DataMember] public float LightingAlphaAdd, BloomBaseAdd;
        [DataMember] public float DarkRoomAlpha = .75f;
        [DataMember] public global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode CoreMode;
        public bool JustStarted = true;

        public global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionMapData MapData =>
            sourceSessionMaps
                .GetMap(AreaID, Mode);

        public global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionLevelData LevelData =>
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

        public global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession Restart(string intoLevel = null)
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

        public void UpdateLevelStartDashes() => DashesAtLevelStart = Dashes;

        public Vector2 GetSpawnPoint(Vector2 from)
            => global::Celeste.Core.Mathematics.Vector2Selection.ClosestTo(
                LevelData.Spawns, from, sourceVectorEnvironment.VectorArithmetic);

        public bool GetFlag(string flag) => Flags.Contains(flag);

        public void SetFlag(string flag, bool setTo = true)
        {
            if (!sourceSessionFactory.AllowFlagChange(this, flag, setTo)) return;
            if (setTo) Flags.Add(flag);
            else Flags.Remove(flag);
        }

        public int GetCounter(string counter)
        {
            for (int i = 0; i < Counters.Count; i++)
                if (Counters[i].Key.Equals(counter))
                    return Counters[i].Value;
            return 0;
        }

        public void SetCounter(string counter, int value)
        {
            for (int i = 0; i < Counters.Count; i++)
                if (Counters[i].Key.Equals(counter))
                {
                    Counters[i].Value = value;
                    return;
                }

            Counters.Add(new Counter { Key = counter, Value = value });
        }

        public void IncrementCounter(string counter)
        {
            for (int i = 0; i < Counters.Count; i++)
                if (Counters[i].Key.Equals(counter))
                {
                    Counters[i].Value++;
                    return;
                }

            Counters.Add(new Counter { Key = counter, Value = 1 });
        }

        public bool GetLevelFlag(string level) => LevelFlags.Contains(level);
    }
}
