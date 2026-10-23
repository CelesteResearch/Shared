using System;
using System.Collections.Generic;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Directories;
using Celeste.Everest.Content.Types.Playback;
using Celeste.Formats.Replay.Timelines;
using Celeste.Graphics.Animation.Replay;

namespace Celeste.Everest.Content.Playback
{
    public static class EverestTutorialTimelineLoader
    {
        public static void LoadVanilla(IDictionary<string, List<CharacterReplayFrame>> tutorials,
            string name, byte[] bytes, IEverestContentDiagnostics diagnostics)
        {
            diagnostics.Verbose("PlaybackData", "Loading vanilla tutorial: " + name);
            var timeline = Import(bytes, diagnostics);
            if (timeline != null) tutorials.Add(name, timeline);
        }

        private static List<CharacterReplayFrame> Import(byte[] bytes, IEverestContentDiagnostics diagnostics)
        {
            try
            {
                return PlaybackTimelineCodec.Import(bytes);
            }
            catch (Exception exception)
            {
                diagnostics.Detailed(exception);
                return null;
            }
        }

        public static void Load(EverestContentRegistry content,
            IDictionary<string, List<CharacterReplayFrame>> tutorials, IEverestContentDiagnostics diagnostics)
        {
            if (content.TryGet<AssetTypeDirectory>("Tutorials", out var directory, true))
                LoadDirectory(directory, tutorials, diagnostics);
        }

        private static void LoadDirectory(EverestContentAsset directory,
            IDictionary<string, List<CharacterReplayFrame>> tutorials, IEverestContentDiagnostics diagnostics)
        {
            foreach (var child in directory.Children)
                if (child.Type == typeof(AssetTypeDirectory))
                {
                    LoadDirectory(child, tutorials, diagnostics);
                }
                else if (child.Type == typeof(AssetTypeTutorial))
                {
                    var path = child.PathVirtual;
                    if (path.StartsWith("Tutorials/")) path = path.Substring("Tutorials/".Length);
                    diagnostics.Verbose("PlaybackData", "Loading tutorial: " + path);
                    var timeline = Import(child.Data, diagnostics);
                    if (timeline != null) tutorials[path] = timeline;
                }
        }
    }
}
