using System.IO;
using Celeste.Core.Scheduling;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Audio;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Chapters.Flow
{
    public sealed class OriginalLevelExitCompletionPolicy : IOriginalLevelExitCompletionPolicy
    {
        private readonly IOriginalAreaDataResolver areas;
        private readonly OriginalGameGraphicsResources graphics;
        private readonly ISourceAtlasLoaderEnvironment atlasEnvironment;
        private readonly IOriginalAreaCompleteFactory areaCompletes;

        public OriginalLevelExitCompletionPolicy(IOriginalAreaDataResolver areas,
            OriginalGameGraphicsResources graphics, ISourceAtlasLoaderEnvironment atlasEnvironment,
            IOriginalAreaCompleteFactory areaCompletes)
        {
            this.areas = areas;
            this.graphics = graphics;
            this.atlasEnvironment = atlasEnvironment;
            this.areaCompletes = areaCompletes;
        }

        public void PlayMusic(LevelExitSequence exit)
        {
            var session = exit.Session;
            ((IOriginalGameplayProcess)exit.EngineContext).AudioSession.ChannelOutput.SetMusic(
                OriginalCompletionMusicPolicy.SelectEvent(session.Mode, session.Mode == 0 ? session.AreaID : 0));
        }

        public void Load(LevelExitSequence exit)
        {
            LoadXml(exit, areas.Get(exit.Session.AreaID));
        }

        public void LoadXml(LevelExitSequence exit, IOriginalAreaData actualArea)
        {
            exit.CompleteXml = graphics.CompleteScreensXml["Screens"][actualArea.CompleteScreenName];
            if (exit.CompleteXml != null && exit.CompleteXml.HasAttribute("atlas"))
                exit.CompleteAtlas = SourceAtlasLoader.FromAtlas(
                    Path.Combine("Graphics", "Atlases", exit.CompleteXml.GetAttribute("atlas")),
                    AtlasDataFormat.PackerNoAtlas, atlasEnvironment);
        }

        public ISourceSceneExecution CreateAreaComplete(LevelExitSequence exit)
        {
            return areaCompletes.CreateAreaComplete(exit.Session, exit.CompleteXml, exit.CompleteAtlas, exit.Snow);
        }
    }
}
