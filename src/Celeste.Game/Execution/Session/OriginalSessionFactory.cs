using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Profiles;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Inventory;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Execution.Session
{
    public sealed class OriginalSessionFactory : IChapterSessionFactory
    {
        private readonly IOriginalSessionConstructionProcess process;

        public bool AllowFlagChange(ChapterCompletionSession session, string flag, bool setTo)
        {
            return SourceRuntimeExtensions
                .Get<ISourceSessionFlagInterceptionEnvironment>(process)
                ?.AllowSourceSessionFlagChange(session, flag, setTo) ?? true;
        }

        public OriginalSessionFactory(IOriginalSessionConstructionProcess process)
        {
            this.process = process;
        }

        // XML deserialization executes the private Session allocation/default phase,
        // not its public gameplay constructor. Bind the actual process providers
        // without querying MapData, restoring area metadata, or cloning Audio.
        public ChapterCompletionSession CreateDeserializedSession()
        {
            return new(process.SessionMaps, this, process);
        }

        public ChapterCompletionSession CreateSession(OriginalAreaKey area, string checkpoint = null,
            ChapterAreaProgress oldStats = null)
        {
            if (process.SourceProfile == GameProfile.InstalledEverest)
            {
                var self = (IOriginalSessionAreaMetadata)process.AreaKeys.GetArea(area);
                if (area.Mode == 0) self.RestoreASideAreaData();
                else self.OverrideASideMeta(area.Mode);
            }

            var session = new ChapterCompletionSession(process.SessionMaps, this, process);
            session.AreaID = area.ID;
            session.Mode = area.Mode;
            session.AreaSID = area.SID;
            session.AreaSIDID = area.SIDID;
            session.StartCheckpoint = checkpoint;
            session.ColorGrade = session.MapData.Data.ColorGrade;
            session.Dreaming = process.AreaTable.Areas[area.ID].Dreaming;
            session.Inventory = GetCheckpointInventory(area, checkpoint);
            session.CoreMode = process.AreaTable.Areas[area.ID].CoreMode;
            session.FirstLevel = true;
            session.Audio = session.MapData.ModeData.AudioState.Clone();
            if (session.StartCheckpoint == null)
            {
                var map = session.MapData;
                session.Level = map.StartLevel().Name;
                session.StartedFromBeginning = true;
            }
            else
            {
                session.Level = session.StartCheckpoint;
                session.StartedFromBeginning = false;
                session.Dreaming = GetCheckpointDreaming(area, checkpoint);
                session.CoreMode = GetCheckpointCoreMode(area, checkpoint);
                var audio = GetCheckpointAudioState(area, checkpoint);
                if (audio != null)
                {
                    if (audio.Music != null) session.Audio.Music = audio.Music.Clone();
                    if (audio.Ambience != null) session.Audio.Ambience = audio.Ambience.Clone();
                }

                var color = GetCheckpointColorGrade(area, checkpoint);
                if (color != null) session.ColorGrade = color;
                var checkpointData = GetCheckpoint(area, checkpoint);
                if (checkpointData != null && checkpointData.Flags != null)
                    foreach (var flag in checkpointData.Flags)
                        session.SetFlag(flag);
            }

            if (oldStats != null) session.OldStats = oldStats;
            else
                session.OldStats = process.AreaStats.CloneAreaStats(
                    process.SaveCounters.GetAreasSafe(process.SaveContext.CurrentSave)[session.AreaID]);
            return session;
        }

        public int GetMaxArea()
        {
            return ((IOriginalSaveProgressionEnvironment)process)
                .SaveProgression.GetMaxArea(process.SaveContext.CurrentSave);
        }

        public ChapterCompletionSession Restart(ChapterCompletionSession actualSession, string checkpoint,
            ChapterAreaProgress oldStats)
        {
            return CreateSession(process.AreaKeys.GetSessionArea(actualSession), checkpoint, oldStats);
        }

        public OriginalCheckpointData GetCheckpoint(OriginalAreaKey area, string level)
        {
            var checkpoints = process.AreaTable.Areas[area.ID].GetOriginalMode(area.Mode).Checkpoints;
            if (level != null && checkpoints != null)
                foreach (var checkpoint in checkpoints)
                    if (checkpoint.Level.Equals(level))
                        return checkpoint;
            return null;
        }

        private RoomPlayerInventory GetCheckpointInventory(
            OriginalAreaKey area, string level)
        {
            var checkpoint = GetCheckpoint(area, level);
            if (checkpoint != null && checkpoint.Inventory.HasValue) return checkpoint.Inventory.Value;
            return process.AreaTable.Areas[area.ID].GetOriginalMode(area.Mode).Inventory;
        }

        private bool GetCheckpointDreaming(OriginalAreaKey area, string level)
        {
            return GetCheckpoint(area, level)?.Dreaming ?? process.AreaTable.Areas[area.ID].Dreaming;
        }

        private RoomCoreMode GetCheckpointCoreMode(OriginalAreaKey area,
            string level)
        {
            var checkpoint = GetCheckpoint(area, level);
            if (checkpoint != null && checkpoint.CoreMode.HasValue) return checkpoint.CoreMode.Value;
            return process.AreaTable.Areas[area.ID].CoreMode;
        }

        private RoomAudioState GetCheckpointAudioState(OriginalAreaKey area, string level)
        {
            return GetCheckpoint(area, level)?.AudioState;
        }

        private string GetCheckpointColorGrade(OriginalAreaKey area, string level)
        {
            return GetCheckpoint(area, level)?.ColorGrade;
        }
    }
}
