using System;
using System.Collections.Generic;
using Celeste.Core.Audio;
using Celeste.Simulation.Audio;

namespace Celeste.Game.Audio
{
    // AreaData.Mode[].AudioState and CheckpointData.AudioState for the installed vanilla maps.
    internal static class RoomAudioDefaults
    {
        private static readonly Dictionary<string, RoomAudioState> Maps = BuildMaps();
        private static readonly Dictionary<string, RoomAudioState> Checkpoints = BuildCheckpoints();

        internal static RoomAudioState CreateCheckpoint(string map, string checkpoint)
        {
            return Checkpoints.TryGetValue(map + "/" + checkpoint, out var state) ? state.Clone() : null;
        }

        internal static RoomAudioState Create(string map, string checkpoint)
        {
            if (!Maps.TryGetValue(map, out var state))
                throw new ArgumentException("Unknown original map package: " + map, nameof(map));
            if (checkpoint != null && Checkpoints.TryGetValue(map + "/" + checkpoint, out var checkpointState))
                state = checkpointState;
            return state.Clone();
        }

        private static Dictionary<string, RoomAudioState> BuildMaps()
        {
            var result = new Dictionary<string, RoomAudioState>(StringComparer.Ordinal)
            {
                { "0-Intro", new("event:/music/lvl0/intro", "event:/env/amb/00_prologue") },
                { "8-Epilogue", new("event:/music/lvl8/main", "event:/env/amb/00_prologue") },
                {
                    "LostLevels",
                    new(new EventTrackState("event:/new_content/music/lvl10/part01").SetProgress(1),
                        new("event:/env/amb/00_prologue"))
                },
            };
            AddChapter(result, 1, "ForsakenCity", "lvl1/main", "01_forsaken_city", "01_main");
            AddChapter(result, 2, "OldSite", "lvl2/beginning", "02_old_site", "02_dream");
            AddChapter(result, 3, "CelestialResort", "lvl3/intro", "03_resort", "03_exterior");
            AddChapter(result, 4, "GoldenRidge", "lvl4/main", "04_cliffside", "04_main");
            AddChapter(result, 5, "MirrorTemple", "lvl5/normal", "05_mirror_temple", "05_interior_main");
            AddChapter(result, 6, "Reflection", "lvl6/main", "06_reflection", "06_main");
            AddChapter(result, 7, "Summit", "lvl7/main", "07_summit", null);
            AddChapter(result, 9, "Core", "lvl9/main", "09_core", "09_main");
            return result;
        }

        private static void AddChapter(Dictionary<string, RoomAudioState> maps, int chapter, string name, string music,
            string remix, string ambience)
        {
            var amb = ambience == null ? null : "event:/env/amb/" + ambience;
            maps.Add(chapter + "-" + name, new("event:/music/" + music, amb));
            maps.Add(chapter + "H-" + name, new("event:/music/remix/" + remix, amb));
            maps.Add(chapter + "X-" + name, new("event:/music/remix/" + remix, amb));
        }

        private static Dictionary<string, RoomAudioState> BuildCheckpoints()
        {
            var result = new Dictionary<string, RoomAudioState>(StringComparer.Ordinal)
            {
                {
                    "3-CelestialResort/08-a",
                    new(new EventTrackState("event:/music/lvl3/explore").SetProgress(3),
                        new("event:/env/amb/03_interior"))
                },
                {
                    "3-CelestialResort/09-d",
                    new(new EventTrackState("event:/music/lvl3/clean").SetProgress(3),
                        new("event:/env/amb/03_interior"))
                },
                {
                    "5-MirrorTemple/c-00",
                    new("event:/music/lvl5/middle_temple", "event:/env/amb/05_interior_dark")
                },
                {
                    "5-MirrorTemple/d-00",
                    new("event:/music/lvl5/middle_temple", "event:/env/amb/05_interior_dark")
                },
                {
                    "5-MirrorTemple/e-00",
                    new("event:/music/lvl5/mirror", "event:/env/amb/05_interior_dark")
                },
                {
                    "6-Reflection/after-00",
                    new(
                        new EventTrackState("event:/music/lvl6/badeline_acoustic").Param("levelup", 2f),
                        new("event:/env/amb/06_main"))
                },
                { "7-Summit/g-00", new("event:/music/lvl7/final_ascent", null) },
                {
                    "LostLevels/a-00",
                    new(new EventTrackState("event:/new_content/music/lvl10/part01").SetProgress(1),
                        null)
                },
                {
                    "LostLevels/c-00",
                    new(new EventTrackState("event:/new_content/music/lvl10/part01").SetProgress(1),
                        null)
                },
                { "LostLevels/e-00z", new("event:/new_content/music/lvl10/part02", null) },
                {
                    "LostLevels/f-door",
                    new("event:/new_content/music/lvl10/intermission_heartgroove", null)
                },
                { "LostLevels/h-00b", new("event:/new_content/music/lvl10/part03", null) },
                {
                    "LostLevels/i-00",
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/cassette_rooms").Param("sixteenth_note",
                            7f), null)
                },
                {
                    "LostLevels/j-00",
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/cassette_rooms")
                            .Param("sixteenth_note", 7f).SetProgress(3), null)
                },
                {
                    "LostLevels/j-16",
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/final_run").SetProgress(3), null)
                },
            };
            string[] summit = ["b-00", "c-00", "d-00", "e-00b", "f-00"];
            for (var i = 0; i < summit.Length; i++)
                result.Add("7-Summit/" + summit[i],
                    new(new EventTrackState("event:/music/lvl7/main").SetProgress(i + 1), null));
            return result;
        }
    }
}
