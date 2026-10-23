using System.Collections.Generic;
using System.Text.RegularExpressions;
using Celeste.Core.Components;
using Celeste.Game.Audio.State.Globals;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Entities;
using Celeste.Simulation;

namespace Celeste.Game.Audio.Entities
{
    public sealed class OriginalTempleEndingMusicHandler : SceneEntityState
    {
        public const string StartLevel = "e-01";
        public const string EndLevel = "e-09";
        public const string ApplyIn = "e-*";
        private readonly ISourceEngineContext engine;
        private readonly HashSet<string> levels = new();
        private float startX, endX;

        public OriginalTempleEndingMusicHandler(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            var tags = ((IOriginalGameTagsEnvironment)engine).Tags;
            Tags = tags.TransitionUpdate.Value | tags.Global.Value;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var expression = new Regex(Regex.Escape("e-*").Replace("\\*", ".*") + "$");
            var level = (OriginalLevelSceneRoot)scene;
            foreach (var room in ((OriginalChapterMapData)level.Session.MapData).Levels)
            {
                if (room.Name.Equals("e-01")) startX = room.Bounds.Left;
                else if (room.Name.Equals("e-09")) endX = room.Bounds.Right;
                if (expression.IsMatch(room.Name)) levels.Add(room.Name);
            }
        }

        public override void Update()
        {
            base.Update();
            var level = (OriginalLevelSceneRoot)Scene;
            var player =
                level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            var process = (IOriginalGameplayProcess)engine;
            if (player != null && levels.Contains(level.Session.Level) &&
                process.AudioSession.Device.CurrentMusicName == "event:/music/lvl5/mirror")
            {
                float progress = ScalarMath.Clamp((player.Position.X - startX) / (endX - startX), 0f, 1f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                level.Session.Audio.Music.Layer(1, 1f - progress,
                    ((IOriginalAudioStateGlobalsEnvironment)engine).AudioStateGlobals.LayerParameters);
                level.Session.Audio.Music.Layer(5, progress,
                    ((IOriginalAudioStateGlobalsEnvironment)engine).AudioStateGlobals.LayerParameters);
                OriginalAudioSession.Apply(level.Session.Audio, process.AudioSession.ChannelOutput,
                    process.AudioApplyPolicy);
            }
        }
    }
}
