using System;
using Celeste.Everest.Content.Graphics;
using Celeste.Game.Execution.Areas;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Runtime.Threading;
using Celeste.Localization.Lookup;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Formats.Save.Xml;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Runtime.LevelLoading
{
    public sealed class EverestLevelLoaderConstructorPrefix
    {
        private readonly OriginalLevelLoaderProcessState process;
        private readonly IOriginalAreaKeyPolicy areaKeys;
        private readonly ISourceDialogEnvironment dialogEnvironment;
        private readonly EverestLoggerProcess logger;
        private readonly global::Celeste.Everest.Modules.Runtime.IEverestCoreSettingsEnvironment settings;
        private readonly EverestMainThreadProcess mainThread;
        private readonly EverestVirtualContent virtualContent;
        private readonly EverestLevelLoaderGraphicsBoundary graphics;

        public EverestLevelLoaderConstructorPrefix(OriginalLevelLoaderProcessState process,
            IOriginalAreaKeyPolicy areaKeys, ISourceDialogEnvironment dialogEnvironment, EverestLoggerProcess logger,
            global::Celeste.Everest.Modules.Runtime.IEverestCoreSettingsEnvironment settings,
            EverestMainThreadProcess mainThread,
            EverestVirtualContent virtualContent, EverestLevelLoaderGraphicsBoundary graphics)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            this.areaKeys = areaKeys ?? throw new ArgumentNullException(nameof(areaKeys));
            this.dialogEnvironment = dialogEnvironment ?? throw new ArgumentNullException(nameof(dialogEnvironment));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.mainThread = mainThread ?? throw new ArgumentNullException(nameof(mainThread));
            this.virtualContent = virtualContent ?? throw new ArgumentNullException(nameof(virtualContent));
            this.graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
        }

        public void BeforeOriginalConstructor(ChapterCompletionSession session)
        {
            var dialogs = dialogEnvironment.Dialog
                          ?? throw new InvalidOperationException("The actual Dialog catalog has not been loaded.");
            string sid = session != null ? areaKeys.GetSID(areaKeys.GetSessionArea(session)) : null;
            sid ??= "NULL";
            string name = session != null ? areaKeys.GetArea(areaKeys.GetSessionArea(session)).Name : null;
            string suffix = session != null && dialogs.Has(name)
                ? " [" + dialogs.Clean(name, dialogs.Languages["english"]) + "]"
                : null;
            if (session != null && session.Mode > 0)
                suffix += " [" + (AreaMode)session.Mode + "]";
            logger.InfoLevelLoaderLoading(sid, suffix);
            if (process.LastLoadingThread != null &&
                process.LastLoadingThread.TryGetTarget(out var thread) && thread != null && thread.IsAlive)
                thread.Interrupt();
            if (settings.CurrentCoreSettings.LazyLoading)
                mainThread.Schedule(virtualContent.UnloadOverworld, false);
            graphics.Apply(session, sid, suffix);
        }
    }
}
