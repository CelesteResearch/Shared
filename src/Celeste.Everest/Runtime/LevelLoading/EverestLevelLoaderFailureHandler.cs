using System;
using Celeste.Game.Execution.Areas;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Localization.Lookup;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Formats.Save.Xml;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Content.Tiles.Autotiling;

namespace Celeste.Everest.Runtime.LevelLoading
{
    public sealed class EverestLevelLoaderFailureHandler
    {
        private readonly IOriginalAreaKeyPolicy areaKeys;
        private readonly OriginalGameGraphicsResources graphics;
        private readonly LevelEnterStaticState errors;
        private readonly ISourceDialogEnvironment dialogEnvironment;
        private readonly EverestLoggerProcess logger;

        public EverestLevelLoaderFailureHandler(IOriginalAreaKeyPolicy areaKeys, OriginalGameGraphicsResources graphics,
            LevelEnterStaticState errors, ISourceDialogEnvironment dialogEnvironment, EverestLoggerProcess logger)
        {
            this.areaKeys = areaKeys ?? throw new ArgumentNullException(nameof(areaKeys));
            this.graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            this.errors = errors ?? throw new ArgumentNullException(nameof(errors));
            this.dialogEnvironment = dialogEnvironment ?? throw new ArgumentNullException(nameof(dialogEnvironment));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Handle(ChapterCompletionSession session, Exception exception)
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
            if (errors.ErrorMessage == null)
            {
                if (exception is AutotilerException tile && exception.Source == "TileHandler")
                {
                    string room = "???";
                    for (int i = 0; i < graphics.ForegroundAutotiler.LevelBounds.Count; i++)
                    {
                        if (graphics.ForegroundAutotiler.LevelBounds[i].Contains(tile.X, tile.Y))
                        {
                            tile.X -= graphics.ForegroundAutotiler.LevelBounds[i].X;
                            tile.Y -= graphics.ForegroundAutotiler.LevelBounds[i].Y;
                            room = ((OriginalChapterMapData)session.MapData).Levels[i].Name;
                            break;
                        }
                    }

                    string type = "";
                    if (EverestExceptionStackTrace.TypeInStacktrace(exception,
                            typeof(global::Celeste.Game.Execution.LevelLoader.Terrain.OriginalSolidTiles)))
                        type = "fg";
                    else if (EverestExceptionStackTrace.TypeInStacktrace(exception,
                                 typeof(global::Celeste.Game.Execution.LevelLoader.Terrain.OriginalBackgroundTiles)))
                        type = "bg";
                    errors.ErrorMessage = dialogs.Get("postcard_badtileid")
                        .Replace("((type))", type).Replace("((id))", tile.ID.ToString())
                        .Replace("((x))", tile.X.ToString()).Replace("((y))", tile.Y.ToString())
                        .Replace("((room))", room).Replace("((sid))", sid);
                    logger.WarnLevelLoaderTile(tile, room);
                }
                else
                    errors.ErrorMessage = dialogs.Get("postcard_levelloadfailed").Replace("((sid))", sid);
            }

            logger.WarnLevelLoaderLoading(sid, suffix);
            logger.LogDetailed(exception, null);
        }
    }
}
