using System;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Launch;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Runtime.Launch
{
// Optional development entry. All gameplay and UI construction remains in the
// actual source process. Normal startup creates no request or extra frame hook.
    public sealed class SourceApplicationLaunchRequest : IDisposable
    {
        private readonly GameApplication process;
        private readonly GameLaunchOptions options;
        private bool subscribed;
        public bool Completed { get; private set; }
        public Exception? Failure { get; private set; }

        public SourceApplicationLaunchRequest(GameApplication process, GameLaunchOptions options)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            this.options = options?.Clone() ?? throw new ArgumentNullException(nameof(options));
            this.options.Validate();
            if (process.ActualGame.SourceHostRunOpen)
                throw new InvalidOperationException(
                    "A source launch selection must be supplied before the source game starts.");
            if (this.options.Language != null)
                process.Settings.LanguageId = this.options.Language;
            process.EngineUpdateEnded += OnEngineUpdateEnded;
            subscribed = true;
        }

        private void OnEngineUpdateEnded()
        {
            try
            {
                var scene = process.Frame.Scenes.CurrentScene;
                if (scene is GameLoaderScene loader)
                {
                    if (options.View != GameLaunchView.Normal) loader.SkipIntro();
                    return;
                }

                // Never replace the loader: its coroutine owns opening-atlas
                // disposal, worker priority restoration, and the real scene handoff.
                if (scene is not OverworldSequence overworld) return;
                Apply(overworld);
                Completed = true;
                Dispose();
            }
            catch (Exception error)
            {
                Failure = error;
                Dispose();
            }
        }

        private void Apply(OverworldSequence overworld)
        {
            switch (options.View)
            {
                case GameLaunchView.Normal:
                    return;
                case GameLaunchView.Level:
                    LoadLevel();
                    return;
                case GameLaunchView.Overworld:
                    var save = InitializeDebugSave();
                    var area = ResolveArea();
                    save.LastArea = area;
                    save.CurrentSession = process.Sessions.CreateSession(area);
                    if (overworld.Goto<ChapterSelectSequence>() == null)
                        throw new InvalidOperationException("The source overworld has no chapter selection page.");
                    return;
                case GameLaunchView.Postcard:
                    EngineRuntime.Instance.Commands.ExecuteCommand(
                        options.ResolvedPostcard == "variants" ? "postcard_variants" : "postcard_cside",
                        []);
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(options.View));
            }
        }

        private OriginalSaveDataState InitializeDebugSave()
        {
            return process.SaveDebug.InitializeDebugMode(
                process.UserIOStorage,
                process);
        }

        private OriginalAreaKey ResolveArea()
        {
            var keys = process.AreaKeys;
            if (options.Map == null) return keys.Create(options.ResolvedArea);
            foreach (var area in process.AreaTable.Areas)
            {
                for (var mode = 0; mode < area.ModeCount; mode++)
                    if (area.HasMode(mode) && string.Equals(area.GetOriginalMode(mode).Path,
                            options.ResolvedMap, StringComparison.Ordinal))
                        return keys.ToKey(area, mode);
                if (string.Equals(area.SID, options.Map, StringComparison.Ordinal))
                    return keys.ToKey(area);
            }

            throw new ArgumentException("The loaded source area table has no map '" + options.Map + "'.");
        }

        private void LoadLevel()
        {
            var area = ResolveArea();
            var save = InitializeDebugSave();
            save.LastArea = area;
            var session = process.Sessions.CreateSession(area,
                GameLaunchOptions.RuntimeRoomName(options.Checkpoint));
            if (options.Checkpoint != null && session.MapData.GetLevel(session.Level) == null)
                throw new ArgumentException("Unknown source checkpoint room '" + options.Checkpoint + "'.");
            if (options.Room != null)
            {
                var room = GameLaunchOptions.RuntimeRoomName(options.Room);
                if (session.MapData.GetLevel(room) == null)
                    throw new ArgumentException("Unknown source room '" + options.Room + "'.");
                session.Level = room;
                session.FirstLevel = false;
            }

            process.Frame.Scenes.NextScene = process
                .LevelLoaders.CreateLevelLoader(session);
        }

        public void Dispose()
        {
            if (!subscribed) return;
            process.EngineUpdateEnded -= OnEngineUpdateEnded;
            subscribed = false;
        }
    }
}
