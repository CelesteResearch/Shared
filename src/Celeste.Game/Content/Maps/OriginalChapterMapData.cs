using System.Collections.Generic;
using System.Numerics;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Runtime.Session.Maps;

namespace Celeste.Game.Content.Maps
{
    public partial class OriginalChapterMapData : IChapterSessionMapData
    {
        public OriginalAreaKey Area;
        public IOriginalAreaData Data;
        public OriginalAreaModeData ModeData;

        IChapterSessionAreaData
            IChapterSessionMapData.Data
            => (IChapterSessionAreaData)Data;

        IChapterSessionModeData
            IChapterSessionMapData.ModeData => ModeData;

        int IChapterSessionMapData.DetectedStrawberries
        {
            get => DetectedStrawberries;
            set => DetectedStrawberries = value;
        }

        private readonly IOriginalChapterMapStartPolicy startPolicy;
        public List<OriginalLevelRoomData> Levels = [];

        private readonly IOriginalChapterMapLoadPolicy loadPolicy;

        public OriginalChapterMapData(
            OriginalAreaKey area,
            IOriginalAreaSourceTable areas,
            IOriginalChapterMapStartPolicy startPolicy, IOriginalChapterMapLoadPolicy loadPolicy)
        {
            this.startPolicy = startPolicy;
            this.loadPolicy = loadPolicy;
            Area = area;
            Data = areas.Areas[Area.ID];
            ModeData = Data.GetOriginalMode(Area.Mode);
            loadPolicy.Load(this);
        }

        public void Reload()
        {
            loadPolicy.Load(this);
        }

        public OriginalLevelRoomData Get(string levelName)
        {
            return loadPolicy.Get(this, levelName);
        }

        IChapterSessionLevelData
            IChapterSessionMapData.GetLevel(string name)
        {
            return Get(name);
        }

        public OriginalLevelRoomData StartLevel()
        {
            return startPolicy.StartLevel(this);
        }

        IChapterSessionLevelData
            IChapterSessionMapData.StartLevel()
        {
            return StartLevel();
        }

        public OriginalLevelRoomData GetTransitionTarget(OriginalLevelSceneRoot level, Vector2 position)
        {
            return GetAt(position);
        }

        public bool CanTransitionTo(OriginalLevelSceneRoot level, Vector2 position)
        {
            var target = GetTransitionTarget(level, position);
            if (target != null) return !target.Dummy;
            return false;
        }

        public OriginalLevelRoomData GetAt(Vector2 at)
        {
            foreach (var level in Levels)
                if (level.Check(at))
                    return level;

            return null;
        }
    }
}
