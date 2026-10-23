using System.IO;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Metadata.Completion;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Presentation.Completion.SceneFactories;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Chapters.Flow.Completions
{
    public sealed class EverestLevelExitCompletionPolicy : IOriginalLevelExitCompletionPolicy
    {
        private readonly IOriginalAreaDataResolver areas;
        private readonly OriginalLevelExitCompletionPolicy original;
        private readonly ISourceAtlasLoaderEnvironment atlasEnvironment;
        private readonly IInstalledAreaCompleteFactory areaCompletes;

        public EverestLevelExitCompletionPolicy(IOriginalAreaDataResolver areas,
            OriginalLevelExitCompletionPolicy original, ISourceAtlasLoaderEnvironment atlasEnvironment,
            IInstalledAreaCompleteFactory areaCompletes)
        {
            this.areas = areas;
            this.original = original;
            this.atlasEnvironment = atlasEnvironment;
            this.areaCompletes = areaCompletes;
        }

        public void PlayMusic(LevelExitSequence exit)
        {
            var session = exit.Session;
            var music = ((EverestArea)areas.Get(session.AreaID))?.Metadata?.CompleteScreen?.MusicBySide;
            if (music != null && music.Length > session.Mode)
                ((IOriginalGameplayProcess)exit.EngineContext).AudioSession.ChannelOutput.SetMusic(music[session.Mode]);
            else
                original.PlayMusic(exit);
        }

        public void Load(LevelExitSequence exit)
        {
            var area = (EverestArea)areas.Get(exit.Session.AreaID);
            var metadata = area.Metadata?.CompleteScreen;
            exit.CompleteMetadata = metadata;
            if (metadata != null && metadata.Atlas != null)
                exit.CompleteAtlas = SourceAtlasLoader.FromAtlas(
                    Path.Combine("Graphics", "Atlases", metadata.Atlas), AtlasDataFormat.PackerNoAtlas,
                    atlasEnvironment);
            else
                original.LoadXml(exit, area);
        }

        public ISourceSceneExecution CreateAreaComplete(LevelExitSequence exit)
            => areaCompletes.CreateAreaComplete(exit.Session, exit.CompleteXml, exit.CompleteAtlas,
                exit.Snow, (MapMetaCompleteScreen)exit.CompleteMetadata);
    }
}
