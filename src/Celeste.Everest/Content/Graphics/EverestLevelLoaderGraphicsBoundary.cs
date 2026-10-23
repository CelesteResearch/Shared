using System;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Everest.Audio.Surfaces;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Audio.Surfaces;
using Celeste.Game.Execution.Graphics;
using Celeste.Localization.Lookup;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Content.Graphics
{
    public sealed class EverestLevelLoaderGraphicsBoundary
    {
        private readonly IOriginalAreaSourceTable areas;
        private readonly OriginalGameGraphicsResources graphics;
        private readonly ISourceEngineContext engine;
        private readonly EverestGraphicsXmlReader content;
        private readonly LevelEnterStaticState errors;
        private readonly ISourceDialogEnvironment dialogEnvironment;
        private readonly EverestLoggerProcess logger;

        public EverestLevelLoaderGraphicsBoundary(IOriginalAreaSourceTable areas,
            OriginalGameGraphicsResources graphics, ISourceEngineContext engine,
            EverestGraphicsXmlReader content,
            LevelEnterStaticState errors, ISourceDialogEnvironment dialogEnvironment,
            EverestLoggerProcess logger)
        {
            this.areas = areas ?? throw new ArgumentNullException(nameof(areas));
            this.graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.content = content ?? throw new ArgumentNullException(nameof(content));
            this.errors = errors ?? throw new ArgumentNullException(nameof(errors));
            this.dialogEnvironment = dialogEnvironment ?? throw new ArgumentNullException(nameof(dialogEnvironment));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Apply(ChapterCompletionSession session, string sid, string areaNameSuffix)
        {
            var dialogs = dialogEnvironment.Dialog
                          ?? throw new InvalidOperationException("The actual Dialog catalog has not been loaded.");
            ((EverestSurfaceIndex)((IOriginalSurfaceIndexEnvironment)engine).SurfaceIndex).ResetForLevelLoader();
            var currentPath = "";
            var failureDomain = EverestGraphicsFailureDomain.General;
            try
            {
                EverestLevelLoaderGraphicsPolicy.Apply(session, areas, graphics, engine,
                    content, errors, dialogs, ref currentPath, ref failureDomain);
            }
            catch (Exception exception)
            {
                if (errors.ErrorMessage == null)
                {
                    if (exception is XmlException)
                    {
                        errors.ErrorMessage = dialogs.Get("postcard_xmlerror").Replace("((path))", currentPath);
                        if (logger.GetLogLevel("LevelLoader") <= EverestLogLevel.Warn)
                            logger.Log(EverestLogLevel.Warn, "LevelLoader", "Failed parsing " + currentPath);
                    }
                    else if (failureDomain == EverestGraphicsFailureDomain.Autotiler)
                    {
                        errors.ErrorMessage = dialogs.Get("postcard_tilexmlerror").Replace("((path))", currentPath);
                        if (logger.GetLogLevel("LevelLoader") <= EverestLogLevel.Warn)
                            logger.Log(EverestLogLevel.Warn, "LevelLoader",
                                "Failed parsing tileset tag in " + currentPath);
                    }
                    else
                    {
                        errors.ErrorMessage = dialogs.Get("postcard_levelloadfailed").Replace("((sid))", sid);
                    }
                }

                if (logger.GetLogLevel("LevelLoader") <= EverestLogLevel.Warn)
                    logger.Log(EverestLogLevel.Warn, "LevelLoader", "Failed loading " + sid + areaNameSuffix);
                logger.LogDetailed(exception);
            }
        }
    }
}
