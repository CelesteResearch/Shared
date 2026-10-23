using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Content.Maps
{
    public partial class OriginalChapterMapData : global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionMapData
    {
        public global::Celeste.Game.Execution.Areas.OriginalAreaKey Area;
        public global::Celeste.Game.Execution.Areas.IOriginalAreaData Data;
        public global::Celeste.Game.Execution.Areas.OriginalAreaModeData ModeData;

        global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionAreaData
            global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionMapData.Data
            => (global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionAreaData)Data;

        global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionModeData
            global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionMapData.ModeData => ModeData;

        int global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionMapData.DetectedStrawberries
        {
            get => DetectedStrawberries;
            set => DetectedStrawberries = value;
        }

        private readonly IOriginalChapterMapStartPolicy startPolicy;
        public List<OriginalLevelRoomData> Levels = new List<OriginalLevelRoomData>();

        private readonly IOriginalChapterMapLoadPolicy loadPolicy;

        public OriginalChapterMapData(
            global::Celeste.Game.Execution.Areas.OriginalAreaKey area,
            global::Celeste.Game.Execution.Areas.IOriginalAreaSourceTable areas,
            IOriginalChapterMapStartPolicy startPolicy, IOriginalChapterMapLoadPolicy loadPolicy)
        {
            this.startPolicy = startPolicy;
            this.loadPolicy = loadPolicy;
            Area = area;
            Data = areas.Areas[Area.ID];
            ModeData = Data.GetOriginalMode(Area.Mode);
            loadPolicy.Load(this);
        }

        public void Reload() => loadPolicy.Load(this);

        public OriginalLevelRoomData Get(string levelName) => loadPolicy.Get(this, levelName);

        global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionLevelData
            global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionMapData.GetLevel(string name) => Get(name);

        public OriginalLevelRoomData StartLevel() => startPolicy.StartLevel(this);

        global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionLevelData
            global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionMapData.StartLevel() => StartLevel();

        public OriginalLevelRoomData GetTransitionTarget(OriginalLevelSceneRoot level, Vector2 position)
            => GetAt(position);

        public bool CanTransitionTo(OriginalLevelSceneRoot level, Vector2 position)
        {
            var target = GetTransitionTarget(level, position);
            if (target != null) return !target.Dummy;
            return false;
        }

        public OriginalLevelRoomData GetAt(Vector2 at)
        {
            foreach (var level in Levels)
            {
                if (level.Check(at)) return level;
            }

            return null;
        }
    }
}
