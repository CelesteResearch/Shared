using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Extensions.Collectibles;
using Celeste.Everest.Content.Maps.Processing;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;

namespace Celeste.Everest.Gameplay.Collectibles.Hearts
{
    public sealed class EverestHeartGemRuntimePolicy : IOriginalHeartGemRuntimePolicy
    {
        public bool InstalledDialogs => true;
        public bool InstalledFakeHeartColor => true;

        public void BeforeCollectRoutine(OriginalLevelSceneRoot level, RoomPlayerSession player, bool isFake)
        {
            bool flag = false;
            var meta = level != null
                ? ((IEverestChapterMapProcessingEnvironment)level.EngineContext).MapProcessing.GetModeMeta(
                    (global::Celeste.Game.Content.Maps.OriginalChapterMapData)level.Session.MapData)
                : null;
            if (meta != null && meta.HeartIsEnd.HasValue) flag = meta.HeartIsEnd.Value;
            if (flag & !isFake)
            {
                var list = new List<ISourceStrawberryCollectible>();
                var berryTypes = ((ISourceInstalledStrawberryRegistryEnvironment)level.EngineContext).StrawberryRegistry
                    .GetBerryTypes();
                foreach (var follower in player.Leader.Followers)
                    if (berryTypes.Contains(follower.Entity.GetType()) &&
                        follower.Entity is ISourceStrawberryCollectible)
                        list.Add(follower.Entity as ISourceStrawberryCollectible);
                foreach (var item in list) item.OnCollect();
            }
        }

        public bool IsCompleteArea(OriginalLevelSceneRoot level, bool isFake, bool originalValue)
        {
            var meta = ((IEverestChapterMapProcessingEnvironment)level.EngineContext).MapProcessing.GetModeMeta(
                (global::Celeste.Game.Content.Maps.OriginalChapterMapData)level.Session.MapData);
            if (meta != null && meta.HeartIsEnd.HasValue)
            {
                if (meta.HeartIsEnd.Value) return !isFake;
                return false;
            }

            return originalValue;
        }

        public int TotalHeartsForAchievement(ISourceEngineContext engine, OriginalSaveDataState save)
            => ((IOriginalSaveCounterEnvironment)engine).SaveCounters.TotalHeartGemsInVanilla(save);
    }
}
