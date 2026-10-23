using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Scene.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Display.Colors;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Presentation.Hud.Statistics
{
    public class GameplayStatsState : SceneEntityState
    {
        public const int DisplayDepth = -101;
        public float DrawLerp;
        private readonly ISourceEngineContext engine;

        public GameplayStatsState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Depth = DisplayDepth;
            Tags = new SceneTagSet(((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                                   ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value |
                                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value |
                                   ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value);
        }

        public override void Update()
        {
            base.Update();
            var level = Scene as OriginalLevelSceneRoot;
            DrawLerp = global::Celeste.Core.Mathematics.ScalarMath.Approach(DrawLerp,
                level.Paused && level.PauseMainMenuOpen && level.Wipe == null ? 1f : 0f, engine.DeltaTime * 8f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }

        public override void Render(ISourceRenderContext context)
        {
            if (DrawLerp <= 0f) return;
            float ease = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(DrawLerp);
            var level = Scene as OriginalLevelSceneRoot;
            var area = ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session);
            var modeProgress = ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave)[area.ID].Modes[area.Mode];
            if (!modeProgress.Completed && !((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.CheatMode &&
                !((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.DebugMode) return;
            var sourceMode = ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetArea(area).GetOriginalMode(area.Mode);
            int total = sourceMode.TotalStrawberries;
            int dotsWidth = (total - 1) * 32;
            int separatorsWidth = total > 0 && sourceMode.Checkpoints != null ? sourceMode.Checkpoints.Length * 32 : 0;
            Vector2 position = new Vector2((1920 - dotsWidth - separatorsWidth) / 2, 1016f + (1f - ease) * 80f);
            if (total <= 0) return;
            int groups = sourceMode.Checkpoints == null ? 1 : sourceMode.Checkpoints.Length + 1;
            for (int i = 0; i < groups; i++)
            {
                int count = i == 0 ? sourceMode.StartStrawberries : sourceMode.Checkpoints[i - 1].Strawberries;
                for (int j = 0; j < count; j++)
                {
                    var id = sourceMode.StrawberriesByCheckpoint[i, j];
                    if (id == null) continue;
                    bool collected = false;
                    foreach (global::Celeste.Core.Maps.MapEntityId strawberry in level.Session.Strawberries)
                        if (id.ID == strawberry.ID && id.Level.Name == strawberry.Level)
                            collected = true;
                    var dot = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                        .GuiAtlas.Entries["dot"];
                    if (collected)
                        Outline(context, dot, position,
                            area.Mode == 2 ? SourceHexColor.HexToColor("f2ff30") : SourceHexColor.HexToColor("ff3040"),
                            1.5f);
                    else
                    {
                        bool saved = false;
                        foreach (global::Celeste.Core.Maps.MapEntityId strawberry in modeProgress.Strawberries)
                            if (id.ID == strawberry.ID && id.Level.Name == strawberry.Level)
                                saved = true;
                        if (saved) Outline(context, dot, position, SourceHexColor.HexToColor("4193ff"), 1f);
                        else
                            SourcePrimitiveDrawing.Rect(context, this, position.X - dot.ClipRect.Width * .5f,
                                position.Y - 4f, dot.ClipRect.Width, 8f, PackedColor.DarkGray);
                    }

                    position.X += 32;
                }

                if (sourceMode.Checkpoints != null && i < sourceMode.Checkpoints.Length)
                {
                    SourcePrimitiveDrawing.Rect(context, this, position.X - 3f, position.Y - 16f, 6f, 32f,
                        PackedColor.DarkGray);
                    position.X += 32;
                }
            }
        }

        private void Outline(ISourceRenderContext context, AtlasEntry texture, Vector2 position, PackedColor color,
            float scale)
            => SourceAtlasDrawing.DrawOutline(context, this, texture, position, texture.Center, color, scale);
    }
}
