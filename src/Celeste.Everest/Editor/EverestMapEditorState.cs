using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Settings;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Editor;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Gameplay;
using Celeste.Input.Runtime;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Editor
{
    public class EverestMapEditorState : MapEditorState
    {
        private readonly ChapterCompletionSession CurrentSession;
        private int zoomWaitFrames;
        private List<Vector2> keys;
        private static readonly int ZoomIntervalFrames = 6;

        public EverestMapEditorState(ISourceEngineContext engine, OriginalAreaKey area, bool reloadMapData = true)
            : this(engine, area, reloadMapData, ((IOriginalMapEditorEnvironment)engine).MapEditorProcess.Area)
        {
        }

        private EverestMapEditorState(ISourceEngineContext engine, OriginalAreaKey area, bool reloadMapData,
            OriginalAreaKey previous)
            : base(engine, area, reloadMapData)
        {
            CurrentSession = (engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot)?.Session ?? ReadSaveSession();
            if (CurrentSession == null ||
                ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSessionArea(CurrentSession) != area)
                CurrentSession = null;
            else if (previous != area) CenterViewOnCurrentRespawn();
        }

        private ChapterCompletionSession ReadSaveSession()
        {
            var save = ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave;
            return save == null
                ? null
                : ((IOriginalSaveSessionSelectionEnvironment)EngineContext).SaveSessionSelection
                .GetCurrentSessionSafe(save);
        }

        private ChapterCompletionSession CreateCheckpointSession(OriginalAreaKey area, string room)
        {
            var session = ((IOriginalSessionEnvironment)EngineContext).Sessions.CreateSession(area, room);
            session.StartCheckpoint = null;
            return session;
        }

        protected override LevelTemplateState CreateTemplate(OriginalLevelRoomData data)
        {
            return new EverestLevelTemplateState(EngineContext, data);
        }

        protected override LevelTemplateState CreateTemplate(int x, int y, int w, int h)
        {
            return new EverestLevelTemplateState(EngineContext, x, y, w, h);
        }

        public override void Update()
        {
            MakeMapEditorBetter();
            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.F2))
                CenterViewOnCurrentRespawn();

            base.Update();
        }

        public override void Render()
        {
            var context = SourceRenderContext;
            base.Render();
            RenderManualText();
            RenderKeys();
            RenderHighlightCurrentRoom();
        }

        protected override void LoadLevel(LevelTemplateState level, Vector2 at)
        {
            Save();
            var state = ((ISourceFnaKeyboardStateEnvironment)EngineContext).KeyboardState.GetState();
            var num = state.IsKeyDown(SourceKeys.LeftControl) || state.IsKeyDown(SourceKeys.RightControl);
            var flag = state.IsKeyDown(SourceKeys.LeftShift) || state.IsKeyDown(SourceKeys.RightShift);
            var session = !num && CurrentSession != null
                ? CurrentSession
                : ((IOriginalSessionEnvironment)EngineContext).Sessions.GetCheckpoint(area, level.Name) == null
                    ? ((IOriginalSessionEnvironment)EngineContext).Sessions.CreateSession(area)
                    : CreateCheckpointSession(area, level.Name);
            session.Level = level.Name;
            session.RespawnPoint = flag ? at : null;
            session.FirstLevel = false;
            session.StartedFromBeginning = false;
            if (num && !flag && (session.FirstLevel = level.Name == session.MapData.StartLevel().Name))
            {
                Vector2 vector;
                if (((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetLevelSet(
                        ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSessionArea(session)) == "Celeste")
                {
                    var bounds = ((OriginalLevelRoomData)session.LevelData).Bounds;
                    vector = session.GetSpawnPoint(new(bounds.Left, bounds.Bottom));
                }
                else
                {
                    vector = session.LevelData.Spawns[0];
                }

                session.StartedFromBeginning = session.GetSpawnPoint(at) == vector;
            }

            EngineContext.Frame.Scenes.NextScene =
                ((IOriginalLevelLoaderEnvironment)EngineContext).LevelLoaders.CreateLevelLoader(session, at);
        }

        private void MakeMapEditorBetter()
        {
            if ((((ISourceGameInputEnvironment)EngineContext).Input.ESC.Pressed ||
                 ((ISourceGameInputEnvironment)EngineContext).Input.MenuCancel.Pressed) && CurrentSession != null)
            {
                ((ISourceGameInputEnvironment)EngineContext).Input.ESC.ConsumePress();
                ((ISourceGameInputEnvironment)EngineContext).Input.MenuCancel.ConsumePress();
                EngineContext.Frame.Scenes.NextScene =
                    ((IOriginalLevelLoaderEnvironment)EngineContext).LevelLoaders.CreateLevelLoader(CurrentSession);
            }

            if (((ISourceGameInputEnvironment)EngineContext).Input.MenuConfirm.Pressed)
            {
                ((ISourceGameInputEnvironment)EngineContext).Input.MenuConfirm.ConsumePress();
                var levelTemplate = TestCheck(mousePosition);
                if (levelTemplate != null)
                {
                    if (levelTemplate.Type == LevelTemplateType.Filler) return;

                    LoadLevel(levelTemplate, mousePosition * 8f);
                }
            }

            if (Camera != null)
            {
                var vector =
                    new Vector2(((ISourceGameInputEnvironment)EngineContext).Input.MoveX.Value,
                        ((ISourceGameInputEnvironment)EngineContext).Input.MoveY.Value) * 300f *
                    EngineContext.DeltaTime;
                Camera.Position -= vector;
                var num = !((ISourceGameInputEnvironment)EngineContext).Input.MoveX.Inverted ? 1 : -1;
                var num2 = !((ISourceGameInputEnvironment)EngineContext).Input.MoveY.Inverted ? 1 : -1;
                var vector2 = new Vector2(vector.X * num, vector.Y * num2);
                if (Camera.Zoom < 6f)
                    Camera.Position += vector2 * (float)Math.Pow(1.3, 6f - Camera.Zoom);
                else
                    Camera.Position += vector2;
            }

            var currentState = ((ISourceMInputEnvironment)EngineContext).MInput
                .GamePads[((ISourceGameInputEnvironment)EngineContext).Input.Gamepad].CurrentState;
            if (zoomWaitFrames <= 0 && Camera != null)
            {
                var num3 = 0f;
                if (Math.Abs(currentState.ThumbSticks.Right.X) >= 0.5f)
                    num3 = Camera.Zoom + Math.Sign(currentState.ThumbSticks.Right.X) * 1f;
                else if (Math.Abs(currentState.ThumbSticks.Right.Y) >= 0.5f)
                    num3 = Camera.Zoom + Math.Sign(currentState.ThumbSticks.Right.Y) * 1f;

                if (num3 >= 1f)
                {
                    Camera.Zoom = num3;
                    zoomWaitFrames = ZoomIntervalFrames;
                }
            }
        }

        private void RenderManualText()
        {
            var context = SourceRenderContext;
            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.F5))
                ((IEverestCurrentCoreSettingsEnvironment)EngineContext)
                    .CurrentCoreSettings
                    .ShowManualTextOnDebugMap =
                    !((IEverestCurrentCoreSettingsEnvironment)EngineContext)
                        .CurrentCoreSettings.ShowManualTextOnDebugMap;

            ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(new(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, SourceDepthStencilState.None,
                SourceRasterizerState.CullCounterClockwise, null, Matrix4x4.Identity));
            var text = "F5: Show/Hide instructions";
            if (((IEverestCurrentCoreSettingsEnvironment)EngineContext)
                .CurrentCoreSettings
                .ShowManualTextOnDebugMap)
                text =
                    "Right Click:  Teleport to the room\nConfirm:      Teleport to the room\nHold Control: Restart Chapter before teleporting\nHold Shift:   Teleport to the mouse position\nCancel:       Exit debug map\nQ:            Show red berries\nF1:           Show keys\nF2:           Center on current respawn point\nF5:           Show/Hide instructions";

            var vector = ((ISourceDrawScope)context).Draw.DefaultFont.MeasureString(text);
            SourcePrimitiveDrawing.Rect((ISourceDrawScope)context,
                ((ISourceEngineViewEnvironment)EngineContext).ViewWidth - vector.X - 20f,
                ((ISourceEngineViewEnvironment)EngineContext).ViewHeight - vector.Y - 20f, vector.X + 20f,
                vector.Y + 20f, PackedColor.Black * 0.8f);
            ((ISourceDrawScope)context).Draw.SpriteBatch.DrawString(((ISourceDrawScope)context).Draw.DefaultFont, text,
                new(((ISourceEngineViewEnvironment)EngineContext).ViewWidth - vector.X - 10f,
                    ((ISourceEngineViewEnvironment)EngineContext).ViewHeight - vector.Y - 10f),
                PackedColor.White.PackedValue);
            ((ISourceDrawScope)context).Draw.SpriteBatch.End();
        }

        private void RenderKeys()
        {
            var context = SourceRenderContext;
            if (keys == null && mapData?.Levels != null)
            {
                keys = [];
                foreach (var level in mapData.Levels)
                {
                    var bounds = level.Bounds;
                    var vector = new Vector2(bounds.X, bounds.Y);
                    foreach (var item in
                             level.Entities.Where(entityData =>
                                 entityData.Name == "key"))
                        keys.Add((vector + item.Position) / 8f);
                }
            }

            ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(new(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp, SourceDepthStencilState.None,
                SourceRasterizerState.CullNone, null,
                SourceMatrixMath.Multiply(Camera.Matrix,
                    ((ISourceMInputEnvironment)EngineContext).MInput.Engine.ScreenMatrix)));
            if (keys != null && keys.Count > 0)
                for (var num = 0; num < keys.Count; num++)
                    SourcePrimitiveDrawing.HollowRect((ISourceDrawScope)context, keys[num].X - 1f, keys[num].Y - 2f, 3f,
                        3f,
                        PackedColor.Gold);

            ((ISourceDrawScope)context).Draw.SpriteBatch.End();
            ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(new(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, SourceDepthStencilState.None,
                SourceRasterizerState.CullNone, null,
                ((ISourceMInputEnvironment)EngineContext).MInput.Engine.ScreenMatrix));
            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.F1))
            {
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, -10f, -10f, 1940f, 1100f,
                    PackedColor.Black * 0.25f);
                if (keys != null && keys.Count > 0)
                    for (var num2 = 0; num2 < keys.Count; num2++)
                        ((IActiveBitmapFontEnvironment)EngineContext).Font.DrawOutline(context, this,
                            ((IActiveBitmapFontEnvironment)EngineContext).BaseSize, (num2 + 1).ToString(),
                            (keys[num2] - Camera.Position + Vector2.UnitX) * Camera.Zoom + new Vector2(960f, 540f),
                            new(0.5f, 0.5f), Vector2.One * 1f, PackedColor.Gold, 2f, PackedColor.Black);
            }

            ((ISourceDrawScope)context).Draw.SpriteBatch.End();
        }

        private void RenderHighlightCurrentRoom()
        {
            var context = SourceRenderContext;
            ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(new(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp, SourceDepthStencilState.None,
                SourceRasterizerState.CullNone, null,
                SourceMatrixMath.Multiply(Camera.Matrix,
                    ((ISourceMInputEnvironment)EngineContext).MInput.Engine.ScreenMatrix)));
            if (CurrentSession != null)
                levels.Find(template => template.Name == CurrentSession.Level)
                    ?.RenderHighlight(context, Camera, false, true);

            ((ISourceDrawScope)context).Draw.SpriteBatch.End();
        }

        private void CenterViewOnCurrentRespawn()
        {
            var currentSession = CurrentSession;
            if (currentSession != null && currentSession.RespawnPoint.HasValue)
                Camera.Position = CurrentSession.RespawnPoint.Value / 8f;
        }
    }
}
