using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Gameplay;
using Celeste.Input.Runtime;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Editor
{
    public class MapEditorState : SourceSceneState
    {
        protected ISourceVectorArithmetic VectorArithmetic =>
            ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;

        protected ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;

        protected virtual LevelTemplateState CreateTemplate(OriginalLevelRoomData data)
        {
            return new(EngineContext, data);
        }

        protected virtual LevelTemplateState CreateTemplate(int x, int y, int w, int h)
        {
            return new(EngineContext, x, y, w, h);
        }

        protected enum MouseModes
        {
            Hover,
            Pan,
            Select,
            Move,
            Resize,
        }

        protected PackedColor gridColor => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess.GridColor;

        protected CameraState Camera
        {
            get => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess.Camera;
            set => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess.Camera = value;
        }

        protected OriginalAreaKey area
        {
            get => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess.Area;
            set => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess.Area = value;
        }

        protected float saveFlash
        {
            get => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess.SaveFlash;
            set => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess.SaveFlash = value;
        }

        protected OriginalChapterMapData mapData;

        protected List<LevelTemplateState> levels = [];

        protected Vector2 mousePosition;

        protected MouseModes mouseMode;

        protected Vector2 lastMouseScreenPosition;

        protected Vector2 mouseDragStart;

        protected HashSet<LevelTemplateState> selection = [];

        protected HashSet<LevelTemplateState> hovered = [];

        protected float fade;

        protected List<Vector2[]> undoStack = [];

        protected List<Vector2[]> redoStack = [];

        public MapEditorState(ISourceEngineContext engine, OriginalAreaKey area, bool reloadMapData = true)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            area.ID = Math.Min(Math.Max(area.ID, 0),
                ((IOriginalSessionConstructionProcess)EngineContext).AreaTable.Areas.Count - 1);
            mapData = ((IOriginalSessionConstructionProcess)EngineContext).AreaTable.Areas[area.ID].Mode[area.Mode]
                .MapData;
            if (reloadMapData) mapData.Reload();

            foreach (var level in mapData.Levels) levels.Add(CreateTemplate(level));

            foreach (var item in mapData.Filler) levels.Add(CreateTemplate(item.X, item.Y, item.Width, item.Height));

            if (area != this.area)
            {
                this.area = area;
                Camera = new(((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.Width,
                    ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.Height, VectorArithmetic);
                Camera.Zoom = 6f;
                Camera.CenterOrigin();
            }

            if (((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave == null)
                ((IOriginalSaveDebugEnvironment)EngineContext).SaveDebug.InitializeDebugMode(
                    ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage,
                    (IOriginalSaveInitializationServices)EngineContext);
        }

        public override void GainFocus()
        {
            base.GainFocus();
            SaveAndReload();
        }

        protected void SelectAll()
        {
            selection.Clear();
            foreach (var level in levels) selection.Add(level);
        }

        public void Rename(string oldName, string newName)
        {
            LevelTemplateState levelTemplate = null;
            LevelTemplateState levelTemplate2 = null;
            foreach (var level in levels)
                if (levelTemplate == null && level.Name == oldName)
                {
                    levelTemplate = level;
                    if (levelTemplate2 != null) break;
                }
                else if (levelTemplate2 == null && level.Name == newName)
                {
                    levelTemplate2 = level;
                    if (levelTemplate != null) break;
                }

            var path = Path.Combine("..", "..", "..", "Content", "Levels", mapData.Filename);
            if (levelTemplate2 == null)
            {
                File.Move(Path.Combine(path, levelTemplate.Name + ".xml"), Path.Combine(path, newName + ".xml"));
                levelTemplate.Name = newName;
            }
            else
            {
                var text = Path.Combine(path, "TEMP.xml");
                File.Move(Path.Combine(path, levelTemplate.Name + ".xml"), text);
                File.Move(Path.Combine(path, levelTemplate2.Name + ".xml"), Path.Combine(path, oldName + ".xml"));
                File.Move(text, Path.Combine(path, newName + ".xml"));
                levelTemplate.Name = newName;
                levelTemplate2.Name = oldName;
            }

            Save();
        }

        protected void Save()
        {
        }

        protected void SaveAndReload()
        {
        }

        protected void UpdateMouse()
        {
            mousePosition = SourceVector2Math.Transform(((ISourceMInputEnvironment)EngineContext).MInput.Mouse.Position,
                SourceMatrixMath.Invert(Camera.Matrix));
        }

        public override void Update()
        {
            var vector = default(Vector2);
            vector.X = (lastMouseScreenPosition.X - ((ISourceMInputEnvironment)EngineContext).MInput.Mouse.Position.X) /
                       Camera.Zoom;
            vector.Y = (lastMouseScreenPosition.Y - ((ISourceMInputEnvironment)EngineContext).MInput.Mouse.Position.Y) /
                       Camera.Zoom;
            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.Space) &&
                ((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.LeftControl))
            {
                Camera.Zoom = 6f;
                Camera.Position = Vector2.Zero;
            }

            var num = Math.Sign(((ISourceMInputEnvironment)EngineContext).MInput.Mouse.WheelDelta);
            if ((num > 0 && Camera.Zoom >= 1f) || Camera.Zoom > 1f)
                Camera.Zoom += num;
            else
                Camera.Zoom += num * 0.25f;

            Camera.Zoom = Extrema.Max(0.25f, Extrema.Min(24f, Camera.Zoom));
            Camera.Position +=
                new Vector2(((ISourceGameInputEnvironment)EngineContext).Input.MoveX.Value,
                    ((ISourceGameInputEnvironment)EngineContext).Input.MoveY.Value) * 300f * EngineContext.DeltaTime;
            UpdateMouse();
            hovered.Clear();
            if (mouseMode == MouseModes.Hover)
            {
                mouseDragStart = mousePosition;
                if (((ISourceMInputEnvironment)EngineContext).MInput.Mouse.PressedLeftButton)
                {
                    var flag = LevelCheck(mousePosition);
                    if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.Space))
                    {
                        mouseMode = MouseModes.Pan;
                    }
                    else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.LeftControl))
                    {
                        if (flag)
                            ToggleSelection(mousePosition);
                        else
                            mouseMode = MouseModes.Select;
                    }
                    else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.F))
                    {
                        levels.Add(CreateTemplate((int)mousePosition.X, (int)mousePosition.Y, 32, 32));
                    }
                    else if (flag)
                    {
                        if (!SelectionCheck(mousePosition)) SetSelection(mousePosition);

                        var flag2 = false;
                        if (selection.Count == 1)
                            foreach (var item in selection)
                                if (item.ResizePosition(mousePosition) && item.Type == LevelTemplateType.Filler)
                                    flag2 = true;

                        if (flag2)
                        {
                            foreach (var item2 in selection) item2.StartResizing();

                            mouseMode = MouseModes.Resize;
                        }
                        else
                        {
                            StoreUndo();
                            foreach (var item3 in selection) item3.StartMoving();

                            mouseMode = MouseModes.Move;
                        }
                    }
                    else
                    {
                        mouseMode = MouseModes.Select;
                    }
                }
                else if (((ISourceMInputEnvironment)EngineContext).MInput.Mouse.PressedRightButton)
                {
                    var levelTemplate = TestCheck(mousePosition);
                    if (levelTemplate != null)
                    {
                        if (levelTemplate.Type == LevelTemplateType.Filler)
                        {
                            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.F))
                                levels.Remove(levelTemplate);
                        }
                        else
                        {
                            LoadLevel(levelTemplate, mousePosition * 8f);
                        }

                        return;
                    }
                }
                else if (((ISourceMInputEnvironment)EngineContext).MInput.Mouse.PressedMiddleButton)
                {
                    mouseMode = MouseModes.Pan;
                }
                else if (!((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.Space))
                {
                    foreach (var level in levels)
                        if (level.Check(mousePosition))
                            hovered.Add(level);

                    if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.LeftControl))
                    {
                        if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.Z))
                            Undo();
                        else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.Y))
                            Redo();
                        else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.A))
                            SelectAll();
                    }
                }
            }
            else if (mouseMode == MouseModes.Pan)
            {
                Camera.Position += vector;
                if (!((ISourceMInputEnvironment)EngineContext).MInput.Mouse.CheckLeftButton &&
                    !((ISourceMInputEnvironment)EngineContext).MInput.Mouse.CheckMiddleButton)
                    mouseMode = MouseModes.Hover;
            }
            else if (mouseMode == MouseModes.Select)
            {
                var mouseRect = GetMouseRect(mouseDragStart, mousePosition);
                foreach (var level2 in levels)
                    if (level2.Check(mouseRect))
                        hovered.Add(level2);

                if (!((ISourceMInputEnvironment)EngineContext).MInput.Mouse.CheckLeftButton)
                {
                    if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.LeftControl))
                        ToggleSelection(mouseRect);
                    else
                        SetSelection(mouseRect);

                    mouseMode = MouseModes.Hover;
                }
            }
            else if (mouseMode == MouseModes.Move)
            {
                var relativeMove = Vector2Math.Round(mousePosition - mouseDragStart);
                var snap = selection.Count == 1 &&
                           !((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.LeftAlt);
                foreach (var item4 in selection) item4.Move(relativeMove, levels, snap);

                if (!((ISourceMInputEnvironment)EngineContext).MInput.Mouse.CheckLeftButton)
                    mouseMode = MouseModes.Hover;
            }
            else if (mouseMode == MouseModes.Resize)
            {
                var relativeMove2 = Vector2Math.Round(mousePosition - mouseDragStart);
                foreach (var item5 in selection) item5.Resize(relativeMove2);

                if (!((ISourceMInputEnvironment)EngineContext).MInput.Mouse.CheckLeftButton)
                    mouseMode = MouseModes.Hover;
            }

            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.D1))
                SetEditorColor(0);
            else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.D2))
                SetEditorColor(1);
            else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.D3))
                SetEditorColor(2);
            else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.D4))
                SetEditorColor(3);
            else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.D5))
                SetEditorColor(4);
            else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.D6))
                SetEditorColor(5);
            else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.D7))
                SetEditorColor(6);

            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.F1) ||
                (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.LeftControl) &&
                 ((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.S)))
            {
                SaveAndReload();
                return;
            }

            if (saveFlash > 0f) saveFlash -= EngineContext.DeltaTime * 4f;

            lastMouseScreenPosition = ((ISourceMInputEnvironment)EngineContext).MInput.Mouse.Position;
            base.Update();
        }

        protected void SetEditorColor(int index)
        {
            foreach (var item in selection) item.EditorColorIndex = index;
        }

        public override void Render()
        {
            var context = SourceRenderContext;
            UpdateMouse();
            ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(new(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp, SourceDepthStencilState.None,
                SourceRasterizerState.CullNone, null,
                SourceMatrixMath.Multiply(Camera.Matrix,
                    ((ISourceMInputEnvironment)EngineContext).MInput.Engine.ScreenMatrix)));
            var num = 1920f / Camera.Zoom;
            var num2 = 1080f / Camera.Zoom;
            var num3 = 5;
            var num4 = (float)Math.Floor(Camera.Left / num3 - 1f) * num3;
            var num5 = (float)Math.Floor(Camera.Top / num3 - 1f) * num3;
            for (var num6 = num4; num6 <= num4 + num + 10f; num6 += 5f)
                SourcePrimitiveDrawing.Line((ISourceDrawScope)context, new(num6, Camera.Top),
                    new(num6, Camera.Top + num2), gridColor, VectorArithmetic);

            for (var num7 = num5; num7 <= num5 + num2 + 10f; num7 += 5f)
                SourcePrimitiveDrawing.Line((ISourceDrawScope)context, new(Camera.Left, num7),
                    new(Camera.Left + num, num7), gridColor, VectorArithmetic);

            SourcePrimitiveDrawing.Line((ISourceDrawScope)context, new(0f, Camera.Top),
                new(0f, Camera.Top + num2), PackedColor.DarkSlateBlue, 1f / Camera.Zoom, VectorArithmetic);
            SourcePrimitiveDrawing.Line((ISourceDrawScope)context, new(Camera.Left, 0f),
                new(Camera.Left + num, 0f), PackedColor.DarkSlateBlue, 1f / Camera.Zoom, VectorArithmetic);
            foreach (var level in levels) level.RenderContents(context, Camera, levels);

            foreach (var level2 in levels) level2.RenderOutline(context, Camera);

            foreach (var level3 in levels)
                level3.RenderHighlight(context, Camera, selection.Contains(level3), hovered.Contains(level3));

            if (mouseMode == MouseModes.Hover)
            {
                SourcePrimitiveDrawing.Line((ISourceDrawScope)context,
                    new(mousePosition.X - 12f / Camera.Zoom, mousePosition.Y),
                    new(mousePosition.X + 12f / Camera.Zoom, mousePosition.Y), PackedColor.Yellow,
                    3f / Camera.Zoom,
                    VectorArithmetic);
                SourcePrimitiveDrawing.Line((ISourceDrawScope)context,
                    new(mousePosition.X, mousePosition.Y - 12f / Camera.Zoom),
                    new(mousePosition.X, mousePosition.Y + 12f / Camera.Zoom), PackedColor.Yellow,
                    3f / Camera.Zoom,
                    VectorArithmetic);
            }
            else if (mouseMode == MouseModes.Select)
            {
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, GetMouseRect(mouseDragStart, mousePosition),
                    PackedColor.Lime * 0.25f);
            }

            if (saveFlash > 0f)
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, Camera.Left, Camera.Top, num, num2,
                    PackedColor.White *
                    ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.CubeInOut(saveFlash));

            if (fade > 0f)
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, 0f, 0f, 320f, 180f, PackedColor.Black * fade);

            ((ISourceDrawScope)context).Draw.SpriteBatch.End();
            ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(new(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, SourceDepthStencilState.None,
                SourceRasterizerState.CullNone, null,
                ((ISourceMInputEnvironment)EngineContext).MInput.Engine.ScreenMatrix));
            SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, 0f, 0f, 1920f, 72f, PackedColor.Black);
            var position = new Vector2(16f, 4f);
            var position2 = new Vector2(1904f, 4f);
            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.Q))
            {
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, -10f, -10f, 1940f, 1100f,
                    PackedColor.Black * 0.25f);
                foreach (var level4 in levels)
                {
                    var num8 = 0;
                    while (level4.Strawberries != null && num8 < level4.Strawberries.Count)
                    {
                        var vector = level4.Strawberries[num8];
                        ((IActiveBitmapFontEnvironment)EngineContext).Font.DrawOutline(context, this,
                            ((IActiveBitmapFontEnvironment)EngineContext).BaseSize, level4.StrawberryMetadata[num8],
                            (new Vector2(level4.X + vector.X, level4.Y + vector.Y) - Camera.Position) *
                            Camera.Zoom + new Vector2(960f, 532f), new(0.5f, 1f), Vector2.One * 1f,
                            PackedColor.Red,
                            2f, PackedColor.Black);
                        num8++;
                    }
                }
            }

            if (hovered.Count == 0)
            {
                if (selection.Count > 0)
                {
                    ((IActiveBitmapFontEnvironment)EngineContext).Font.Draw(context, this,
                        ((IActiveBitmapFontEnvironment)EngineContext).BaseSize, selection.Count + " levels selected",
                        position, Vector2.Zero, Vector2.One, PackedColor.Red);
                }
                else
                {
                    ((IActiveBitmapFontEnvironment)EngineContext).Font.Draw(context, this,
                        ((IActiveBitmapFontEnvironment)EngineContext).BaseSize,
                        ((IOriginalGameTextEnvironment)EngineContext).Text.Dialog.Clean(mapData.Data.Name), position,
                        Vector2.Zero, Vector2.One, PackedColor.Aqua);
                    ((IActiveBitmapFontEnvironment)EngineContext).Font.Draw(context, this,
                        ((IActiveBitmapFontEnvironment)EngineContext).BaseSize,
                        string.Concat(mapData.Area.Mode, " MODE"),
                        position2, Vector2.UnitX, Vector2.One, PackedColor.Red);
                }
            }
            else if (hovered.Count == 1)
            {
                LevelTemplateState levelTemplate = null;
                using (var enumerator2 = hovered.GetEnumerator())
                {
                    if (enumerator2.MoveNext()) levelTemplate = enumerator2.Current;
                }

                var text = levelTemplate.ActualWidth + "x" + levelTemplate.ActualHeight +
                           "   " +
                           levelTemplate.X + "," + levelTemplate.Y + "   " + levelTemplate.X * 8 + "," +
                           levelTemplate.Y * 8;
                ((IActiveBitmapFontEnvironment)EngineContext).Font.Draw(context, this,
                    ((IActiveBitmapFontEnvironment)EngineContext).BaseSize, levelTemplate.Name, position, Vector2.Zero,
                    Vector2.One, PackedColor.Yellow);
                ((IActiveBitmapFontEnvironment)EngineContext).Font.Draw(context, this,
                    ((IActiveBitmapFontEnvironment)EngineContext).BaseSize, text, position2, Vector2.UnitX, Vector2.One,
                    PackedColor.Green);
            }
            else
            {
                ((IActiveBitmapFontEnvironment)EngineContext).Font.Draw(context, this,
                    ((IActiveBitmapFontEnvironment)EngineContext).BaseSize, hovered.Count + " levels", position,
                    Vector2.Zero, Vector2.One, PackedColor.Yellow);
            }

            ((ISourceDrawScope)context).Draw.SpriteBatch.End();
        }

        protected virtual void LoadLevel(LevelTemplateState level, Vector2 at)
        {
            Save();
            var session = ((IOriginalSessionEnvironment)EngineContext).Sessions.CreateSession(area);
            session.FirstLevel = false;
            session.Level = level.Name;
            session.StartedFromBeginning = false;
            EngineContext.Frame.Scenes.NextScene =
                ((IOriginalLevelLoaderEnvironment)EngineContext).LevelLoaders.CreateLevelLoader(session, at);
        }

        protected void StoreUndo()
        {
            var array = new Vector2[levels.Count];
            for (var i = 0; i < levels.Count; i++) array[i] = new(levels[i].X, levels[i].Y);

            undoStack.Add(array);
            while (undoStack.Count > 30) undoStack.RemoveAt(0);

            redoStack.Clear();
        }

        protected void Undo()
        {
            if (undoStack.Count > 0)
            {
                var array = new Vector2[levels.Count];
                for (var i = 0; i < levels.Count; i++) array[i] = new(levels[i].X, levels[i].Y);

                redoStack.Add(array);
                var array2 = undoStack[undoStack.Count - 1];
                undoStack.RemoveAt(undoStack.Count - 1);
                for (var j = 0; j < array2.Length; j++)
                {
                    levels[j].X = (int)array2[j].X;
                    levels[j].Y = (int)array2[j].Y;
                }
            }
        }

        protected void Redo()
        {
            if (redoStack.Count > 0)
            {
                var array = new Vector2[levels.Count];
                for (var i = 0; i < levels.Count; i++) array[i] = new(levels[i].X, levels[i].Y);

                undoStack.Add(array);
                var array2 = redoStack[undoStack.Count - 1];
                redoStack.RemoveAt(undoStack.Count - 1);
                for (var j = 0; j < array2.Length; j++)
                {
                    levels[j].X = (int)array2[j].X;
                    levels[j].Y = (int)array2[j].Y;
                }
            }
        }

        protected IntRect GetMouseRect(Vector2 a, Vector2 b)
        {
            var vector = new Vector2(Extrema.Min(a.X, b.X), Extrema.Min(a.Y, b.Y));
            var vector2 = new Vector2(Extrema.Max(a.X, b.X), Extrema.Max(a.Y, b.Y));
            return new((int)vector.X, (int)vector.Y, (int)(vector2.X - vector.X), (int)(vector2.Y - vector.Y));
        }

        protected LevelTemplateState TestCheck(Vector2 point)
        {
            foreach (var level in levels)
                if (!level.Dummy && level.Check(point))
                    return level;

            return null;
        }

        protected bool LevelCheck(Vector2 point)
        {
            foreach (var level in levels)
                if (level.Check(point))
                    return true;

            return false;
        }

        protected bool SelectionCheck(Vector2 point)
        {
            foreach (var item in selection)
                if (item.Check(point))
                    return true;

            return false;
        }

        protected bool SetSelection(Vector2 point)
        {
            selection.Clear();
            foreach (var level in levels)
                if (level.Check(point))
                    selection.Add(level);

            return selection.Count > 0;
        }

        protected bool ToggleSelection(Vector2 point)
        {
            var result = false;
            foreach (var level in levels)
                if (level.Check(point))
                {
                    result = true;
                    if (selection.Contains(level))
                        selection.Remove(level);
                    else
                        selection.Add(level);
                }

            return result;
        }

        protected void SetSelection(IntRect rect)
        {
            selection.Clear();
            foreach (var level in levels)
                if (level.Check(rect))
                    selection.Add(level);
        }

        protected void ToggleSelection(IntRect rect)
        {
            foreach (var level in levels)
                if (level.Check(rect))
                {
                    if (selection.Contains(level))
                        selection.Remove(level);
                    else
                        selection.Add(level);
                }
        }
    }
}
