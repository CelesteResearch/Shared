using System;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Maps.Metadata.Completion;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Menus.Overworld;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Runtime.Chapters.Flow
{
    public sealed partial class EverestLevelEnterPolicy
    {
        public void Go(ChapterCompletionSession session, bool fromSaveData, IOriginalLevelEnterProcess actualProcess)
        {
            var sourceScenes = ((IOriginalLevelEntryEnvironment)actualProcess).LevelEntries;
            if (actualProcess.LevelEnterStatics.ErrorMessage != null)
            {
                actualProcess.Frame.Scenes.NextScene = sourceScenes.CreateLevelEnter(session, fromSaveData);
                return;
            }

            try
            {
                if (!PlayCustomVignette(session, fromSaveData, actualProcess))
                    OriginalLevelEntryRouting.Go(session, fromSaveData, actualProcess.Frame.Scenes, sourceScenes);
                ((IEverestLevelEnterEventsEnvironment)actualProcess).LevelEnterEvents.Enter(session, fromSaveData);
            }
            catch (Exception error)
            {
                var sid = session == null
                    ? "???"
                    : actualProcess.AreaKeys.GetSID(actualProcess.AreaKeys.GetSessionArea(session));
                sid ??= "???";
                string name = null;
                if (session != null)
                {
                    var areaName = actualProcess.AreaKeys.GetArea(actualProcess.AreaKeys.GetSessionArea(session))
                        .Name;
                    if (actualProcess.Text.Dialog.Has(areaName))
                        name = " [" +
                               actualProcess.Text.Dialog.Clean(areaName,
                                   actualProcess.Text.Dialog.Languages["english"]) +
                               "]";
                }

                if (session is { Mode: > 0 })
                    name += $" [{(SourceAreaMode)session.Mode}]";
                var logger = ((IEverestLoggerProcessEnvironment)actualProcess).Logger;
                logger.LevelEnterFailed(sid, name);
                logger.LogDetailed(error);
                actualProcess.LevelEnterStatics.ErrorMessage =
                    actualProcess.Text.Dialog.Get("postcard_levelloadfailed").Replace("((sid))", sid);
                actualProcess.Frame.Scenes.NextScene = sourceScenes.CreateLevelEnter(session, fromSaveData);
            }
        }

        private bool PlayCustomVignette(ChapterCompletionSession session, bool fromSaveData,
            IOriginalLevelEnterProcess actualProcess)
        {
            var custom =
                ((IEverestLevelEnterEventsEnvironment)actualProcess).LevelEnterEvents.PlayVignette(session,
                    fromSaveData);
            if (custom != null)
            {
                actualProcess.Frame.Scenes.NextScene = custom;
                return true;
            }

            var start = !fromSaveData && session.StartedFromBeginning;
            var area = (EverestArea)actualProcess.AreaKeys.GetArea(actualProcess.AreaKeys.GetSessionArea(session));
            MapMetaCompleteScreen screen;
            if (start && (screen = area.Metadata?.LoadingVignetteScreen) != null && screen.Atlas != null)
            {
                actualProcess.Frame.Scenes.NextScene =
                    new CustomScreenVignetteScene(session, null, screen, actualProcess);
                return true;
            }

            MapMetaTextVignette text;
            if (start && (text = area.Metadata?.LoadingVignetteText) != null && text.Dialog != null)
            {
                var snow = actualProcess.Frame.Scenes.CurrentScene is OverworldSequence overworld
                    ? overworld.Snow
                    : null;
                actualProcess.Frame.Scenes.NextScene = new CustomTextVignetteScene(session, text, snow, actualProcess);
                return true;
            }

            return false;
        }

        // Original AreaMode enumeration's ToString is used solely for the source error label.
        private enum SourceAreaMode
        {
            Normal,
            BSide,
            CSide,
        }
    }
}
