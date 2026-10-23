using W = Celeste.Formats.Save.Xml;

namespace Celeste.Game.Save.Formats.Original
{
    public static partial class FileSaveCodec
    {
        private static W.SaveData CopyValues(global::Celeste.Game.Save.Data.OriginalSaveDataState source,
            W.SaveData target)
        {
            if (source == null) return target;
            target.Name = source.Name;
            target.TotalDeaths = source.TotalDeaths;
            target.TotalStrawberries = source.TotalStrawberries;
            target.TotalGoldenStrawberries = source.TotalGoldenStrawberries;
            target.LastSave = source.LastSave;
            target.TotalJumps = source.TotalJumps;
            target.TotalWallJumps = source.TotalWallJumps;
            target.TotalDashes = source.TotalDashes;
            target.Version = source.Version;
            target.TheoSisterName = source.TheoSisterName;
            target.HasModdedSaveData = source.HasModdedSaveData;
            target.UnlockedAreas = source.UnlockedAreas;
            target.Time = source.Time;
            target.CheatMode = source.CheatMode;
            target.AssistMode = source.AssistMode;
            target.VariantMode = source.VariantMode;
            target.RevealedChapter9 = source.RevealedChapter9;
            return target;
        }

        private static global::Celeste.Game.Save.Data.OriginalSaveDataState CopyValues(W.SaveData source,
            global::Celeste.Game.Save.Data.OriginalSaveDataState target)
        {
            if (source == null) return target;
            target.Version = source.Version;
            target.Name = source.Name;
            target.Time = source.Time;
            target.LastSave = source.LastSave;
            target.CheatMode = source.CheatMode;
            target.AssistMode = source.AssistMode;
            target.VariantMode = source.VariantMode;
            target.TheoSisterName = source.TheoSisterName;
            target.UnlockedAreas = source.UnlockedAreas;
            target.TotalDeaths = source.TotalDeaths;
            target.TotalStrawberries = source.TotalStrawberries;
            target.TotalGoldenStrawberries = source.TotalGoldenStrawberries;
            target.TotalJumps = source.TotalJumps;
            target.TotalWallJumps = source.TotalWallJumps;
            target.TotalDashes = source.TotalDashes;
            target.RevealedChapter9 = source.RevealedChapter9;
            target.HasModdedSaveData = source.HasModdedSaveData;
            return target;
        }

        private static W.Assists CopyValues(global::Celeste.Game.Save.Data.FileAssists source, W.Assists target)
        {
            target.GameSpeed = source.GameSpeed;
            target.Invincible = source.Invincible;
            target.DashAssist = source.DashAssist;
            target.InfiniteStamina = source.InfiniteStamina;
            target.MirrorMode = source.MirrorMode;
            target.ThreeSixtyDashing = source.ThreeSixtyDashing;
            target.InvisibleMotion = source.InvisibleMotion;
            target.NoGrabbing = source.NoGrabbing;
            target.LowFriction = source.LowFriction;
            target.SuperDashing = source.SuperDashing;
            target.Hiccups = source.Hiccups;
            target.PlayAsBadeline = source.PlayAsBadeline;
            return target;
        }

        private static global::Celeste.Game.Save.Data.FileAssists CopyValues(W.Assists source,
            global::Celeste.Game.Save.Data.FileAssists target)
        {
            if (source == null) return target;
            target.GameSpeed = source.GameSpeed;
            target.Invincible = source.Invincible;
            target.DashAssist = source.DashAssist;
            target.InfiniteStamina = source.InfiniteStamina;
            target.MirrorMode = source.MirrorMode;
            target.ThreeSixtyDashing = source.ThreeSixtyDashing;
            target.InvisibleMotion = source.InvisibleMotion;
            target.NoGrabbing = source.NoGrabbing;
            target.LowFriction = source.LowFriction;
            target.SuperDashing = source.SuperDashing;
            target.Hiccups = source.Hiccups;
            target.PlayAsBadeline = source.PlayAsBadeline;
            return target;
        }

        private static W.AreaModeStats CopyValues(global::Celeste.Simulation.Save.Progress.ChapterModeProgress source,
            W.AreaModeStats target)
        {
            if (source == null) return target;
            target.TotalStrawberries = source.TotalStrawberries;
            target.Deaths = source.Deaths;
            target.BestDashes = source.BestDashes;
            target.BestDeaths = source.BestDeaths;
            target.Completed = source.Completed;
            target.SingleRunCompleted = source.SingleRunCompleted;
            target.FullClear = source.FullClear;
            target.HeartGem = source.HeartGem;
            target.TimePlayed = source.TimePlayed;
            target.BestTime = source.BestTime;
            target.BestFullClearTime = source.BestFullClearTime;
            return target;
        }

        private static global::Celeste.Simulation.Save.Progress.ChapterModeProgress CopyValues(W.AreaModeStats source,
            global::Celeste.Simulation.Save.Progress.ChapterModeProgress target)
        {
            if (source == null) return target;
            target.TotalStrawberries = source.TotalStrawberries;
            target.Completed = source.Completed;
            target.SingleRunCompleted = source.SingleRunCompleted;
            target.FullClear = source.FullClear;
            target.Deaths = source.Deaths;
            target.TimePlayed = source.TimePlayed;
            target.BestTime = source.BestTime;
            target.BestFullClearTime = source.BestFullClearTime;
            target.BestDashes = source.BestDashes;
            target.BestDeaths = source.BestDeaths;
            target.HeartGem = source.HeartGem;
            return target;
        }

        private static W.Session CopyValues(global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession source,
            W.Session target)
        {
            if (source == null) return target;
            target.FurthestSeenLevel = source.FurthestSeenLevel;
            target.Level = source.Level;
            target.ColorGrade = source.ColorGrade;
            target.DeathsInCurrentLevel = source.DeathsInCurrentLevel;
            target.Dreaming = source.Dreaming;
            target.LightingAlphaAdd = source.LightingAlphaAdd;
            target.BloomBaseAdd = source.BloomBaseAdd;
            target.DarkRoomAlpha = source.DarkRoomAlpha;
            target.Time = source.Time;
            target.Deaths = source.Deaths;
            target.Dashes = source.Dashes;
            target.DashesAtLevelStart = source.DashesAtLevelStart;
            target.StartedFromBeginning = source.StartedFromBeginning;
            target.RestartedFromGolden = source.RestartedFromGolden;
            target.Cassette = source.Cassette;
            target.HeartGem = source.HeartGem;
            target.GrabbedGolden = source.GrabbedGolden;
            target.BeatBestTime = source.BeatBestTime;
            target.InArea = source.InArea;
            target.FirstLevel = source.FirstLevel;
            target.UnlockedCSide = source.UnlockedCSide;
            target.HitCheckpoint = source.HitCheckpoint;
            target.StartCheckpoint = source.StartCheckpoint;
            return target;
        }

        private static global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession CopyValues(W.Session source,
            global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession target)
        {
            if (source == null) return target;
            target.UnlockedCSide = source.UnlockedCSide;
            target.FurthestSeenLevel = source.FurthestSeenLevel;
            target.BeatBestTime = source.BeatBestTime;
            target.Level = source.Level;
            target.Time = source.Time;
            target.StartedFromBeginning = source.StartedFromBeginning;
            target.Deaths = source.Deaths;
            target.Dashes = source.Dashes;
            target.DashesAtLevelStart = source.DashesAtLevelStart;
            target.DeathsInCurrentLevel = source.DeathsInCurrentLevel;
            target.InArea = source.InArea;
            target.StartCheckpoint = source.StartCheckpoint;
            target.FirstLevel = source.FirstLevel;
            target.Cassette = source.Cassette;
            target.HeartGem = source.HeartGem;
            target.Dreaming = source.Dreaming;
            target.ColorGrade = source.ColorGrade;
            target.LightingAlphaAdd = source.LightingAlphaAdd;
            target.BloomBaseAdd = source.BloomBaseAdd;
            target.DarkRoomAlpha = source.DarkRoomAlpha;
            target.GrabbedGolden = source.GrabbedGolden;
            target.HitCheckpoint = source.HitCheckpoint;
            target.RestartedFromGolden = source.RestartedFromGolden;
            return target;
        }

        private static W.PlayerInventory CopyValues(
            global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory source, W.PlayerInventory target)
        {
            target.Dashes = source.Dashes;
            target.DreamDash = source.DreamDash;
            target.Backpack = source.Backpack;
            target.NoRefills = source.NoRefills;
            return target;
        }

        private static global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory CopyValues(
            W.PlayerInventory source, global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory target)
        {
            if (source == null) return target;
            target.Dashes = source.Dashes;
            target.DreamDash = source.DreamDash;
            target.Backpack = source.Backpack;
            target.NoRefills = source.NoRefills;
            return target;
        }
    }
}
