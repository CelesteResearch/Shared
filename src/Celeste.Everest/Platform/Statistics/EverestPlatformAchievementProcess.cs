using System;
using System.Runtime.CompilerServices;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Text;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Platform.Statistics
{
    public sealed class EverestPlatformAchievementProcess : OriginalPlatformAchievementProcess
    {
        private readonly ISourceEngineContext engine;

        internal EverestPlatformAchievementProcess(IOriginalPlatformStatisticsOutput output,
            OriginalPlatformStatisticsProcess statistics, ISourceEngineContext engine)
            : base(output, statistics)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Register(OriginalAchievement achievement)
        {
            bool flag;
            switch (achievement)
            {
                case OriginalAchievement.STRB1:
                case OriginalAchievement.STRB2:
                case OriginalAchievement.STRB3:
                case OriginalAchievement.CASS:
                    var save = ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave;
                    flag = save != null && ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSet(save) ==
                        "Celeste";
                    break;
                case OriginalAchievement.ONEUP:
                case OriginalAchievement.CSIDES:
                case OriginalAchievement.FAREWELL:
                case OriginalAchievement.WOW:
                    var level = engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot
                                ?? (engine.Frame.Scenes.CurrentScene as OriginalLevelLoaderScene)?.Level;
                    if (level == null)
                    {
                        flag = false;
                    }
                    else
                    {
                        var area = ((IOriginalAreaKeyEnvironment)engine).AreaKeys;
                        flag = area.GetLevelSet(area.GetSessionArea(level.Session)) == "Celeste";
                    }

                    break;
                case OriginalAchievement.PICO8:
                    flag = !((IEverestContentRegistryEnvironment)engine).SourceContentRegistry.TryGet<AssetTypeText>(
                        "Pico8Tilemap", out _);
                    break;
                default:
                    flag = true;
                    break;
            }

            if (flag) base.Register(achievement);
        }
    }
}
