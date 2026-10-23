using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.IO;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Text;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Editor
{
    public class LevelTemplateState
    {
        protected readonly ISourceEngineContext EngineContext;
        protected virtual bool IsTrackableStrawberry(string name) => name.Equals("strawberry");
        protected ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;

        protected ISourceVectorArithmetic VectorArithmetic =>
            ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;

        public string Name;

        public LevelTemplateType Type;

        public int X;

        public int Y;

        public int Width;

        public int Height;

        public int ActualWidth;

        public int ActualHeight;

        public GridColliderGeometry Grid;

        public GridColliderGeometry Back;

        public List<Vector2> Spawns;

        public List<Vector2> Strawberries;

        public List<string> StrawberryMetadata;

        public List<Vector2> Checkpoints;

        public List<IntRect> Jumpthrus;

        public bool Dummy;

        public int EditorColorIndex;

        protected Vector2 moveAnchor;

        protected Vector2 resizeAnchor;

        protected List<IntRect> solids = new List<IntRect>();

        protected List<IntRect> backs = new List<IntRect>();

        protected PackedColor bgTilesColor =>
            ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess.TemplateColors.BgTilesColor;

        protected PackedColor[] fgTilesColor =>
            ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess.TemplateColors.FgTilesColor;

        protected PackedColor inactiveBorderColor => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess
            .TemplateColors.InactiveBorderColor;

        protected PackedColor selectedBorderColor => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess
            .TemplateColors.SelectedBorderColor;

        protected PackedColor hoveredBorderColor => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess
            .TemplateColors.HoveredBorderColor;

        protected PackedColor dummyBgTilesColor => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess
            .TemplateColors.DummyBgTilesColor;

        protected PackedColor dummyFgTilesColor => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess
            .TemplateColors.DummyFgTilesColor;

        protected PackedColor dummyInactiveBorderColor => ((IOriginalMapEditorEnvironment)EngineContext)
            .MapEditorProcess
            .TemplateColors.DummyInactiveBorderColor;

        protected PackedColor firstBorderColor => ((IOriginalMapEditorEnvironment)EngineContext).MapEditorProcess
            .TemplateColors.FirstBorderColor;

        protected Vector2 resizeHoldSize => new Vector2(Math.Min(Width, 4), Math.Min(Height, 4));

        public IntRect Rect => new IntRect(X, Y, Width, Height);

        public int Left
        {
            get { return X; }
            set { X = value; }
        }

        public int Top
        {
            get { return Y; }
            set { Y = value; }
        }

        public int Right
        {
            get { return X + Width; }
            set { X = value - Width; }
        }

        public int Bottom
        {
            get { return Y + Height; }
            set { Y = value - Height; }
        }

        public LevelTemplateState(ISourceEngineContext engine, OriginalLevelRoomData data)
        {
            EngineContext = engine;
            _ = ((IOriginalMapEditorEnvironment)engine).MapEditorProcess.TemplateColors;
            Name = data.Name;
            EditorColorIndex = data.EditorColorIndex;
            X = data.Bounds.X / 8;
            Y = data.Bounds.Y / 8;
            ActualWidth = data.Bounds.Width;
            ActualHeight = data.Bounds.Height;
            Width = (int)Math.Ceiling((float)ActualWidth / 8f);
            Height = (int)Math.Ceiling((float)ActualHeight / 8f);
            Grid = new GridColliderGeometry(8f, 8f, data.Solids);
            Back = new GridColliderGeometry(8f, 8f, data.Bg);
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int k;
                    for (k = 0; j + k < Width && Back[j + k, i] && !Grid[j + k, i]; k++)
                    {
                    }

                    if (k > 0)
                    {
                        backs.Add(new IntRect(j, i, k, 1));
                        j += k - 1;
                    }
                }

                for (int l = 0; l < Width; l++)
                {
                    int m;
                    for (m = 0; l + m < Width && Grid[l + m, i]; m++)
                    {
                    }

                    if (m > 0)
                    {
                        solids.Add(new IntRect(l, i, m, 1));
                        l += m - 1;
                    }
                }
            }

            Spawns = new List<Vector2>();
            foreach (Vector2 spawn in data.Spawns)
            {
                Spawns.Add(spawn / 8f - new Vector2(X, Y));
            }

            Strawberries = new List<Vector2>();
            StrawberryMetadata = new List<string>();
            Checkpoints = new List<Vector2>();
            Jumpthrus = new List<IntRect>();
            foreach (OriginalLevelEntityData entity in data.Entities)
            {
                if (IsTrackableStrawberry(entity.Name) || entity.Name.Equals("snowberry"))
                {
                    Strawberries.Add(entity.Position / 8f);
                    StrawberryMetadata.Add(EntityAttributeReader.Int(entity.Values, "checkpointID") + ":" +
                                           EntityAttributeReader.Int(entity.Values, "order"));
                }
                else if (entity.Name.Equals("checkpoint"))
                {
                    Checkpoints.Add(entity.Position / 8f);
                }
                else if (entity.Name.Equals("jumpThru"))
                {
                    Jumpthrus.Add(new IntRect((int)(entity.Position.X / 8f), (int)(entity.Position.Y / 8f),
                        entity.Width / 8, 1));
                }
            }

            Dummy = data.Dummy;
            Type = LevelTemplateType.Level;
        }

        public LevelTemplateState(ISourceEngineContext engine, int x, int y, int w, int h)
        {
            EngineContext = engine;
            _ = ((IOriginalMapEditorEnvironment)engine).MapEditorProcess.TemplateColors;
            Name = "FILLER";
            X = x;
            Y = y;
            Width = w;
            Height = h;
            ActualWidth = w * 8;
            ActualHeight = h * 8;
            Type = LevelTemplateType.Filler;
        }

        public virtual void RenderContents(ISourceRenderContext context, CameraState camera,
            List<LevelTemplateState> allLevels)
        {
            if (Type == LevelTemplateType.Level)
            {
                bool flag = false;
                if (((SourceSceneState)EngineContext.Frame.Scenes.CurrentScene).BetweenInterval(0.1f))
                {
                    foreach (LevelTemplateState allLevel in allLevels)
                    {
                        if (allLevel != this && allLevel.Rect.Intersects(Rect))
                        {
                            flag = true;
                            break;
                        }
                    }
                }

                SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X, Y, Width, Height,
                    (flag ? PackedColor.Red : PackedColor.Black) * 0.5f);
                foreach (IntRect back in backs)
                {
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X + back.X, Y + back.Y, back.Width,
                        back.Height,
                        Dummy ? dummyBgTilesColor : bgTilesColor);
                }

                foreach (IntRect solid in solids)
                {
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X + solid.X, Y + solid.Y, solid.Width,
                        solid.Height, Dummy ? dummyFgTilesColor : fgTilesColor[EditorColorIndex]);
                }

                foreach (Vector2 spawn in Spawns)
                {
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, (float)X + spawn.X, (float)Y + spawn.Y - 1f,
                        1f,
                        1f, PackedColor.Red);
                }

                foreach (Vector2 strawberry in Strawberries)
                {
                    SourcePrimitiveDrawing.HollowRect((ISourceDrawScope)context, (float)X + strawberry.X - 1f,
                        (float)Y + strawberry.Y - 2f, 3f, 3f, PackedColor.LightPink);
                }

                foreach (Vector2 checkpoint in Checkpoints)
                {
                    SourcePrimitiveDrawing.HollowRect((ISourceDrawScope)context, (float)X + checkpoint.X - 1f,
                        (float)Y + checkpoint.Y - 2f, 3f, 3f, PackedColor.Lime);
                }

                {
                    foreach (IntRect jumpthru in Jumpthrus)
                    {
                        SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X + jumpthru.X, Y + jumpthru.Y,
                            jumpthru.Width, 1f, PackedColor.Yellow);
                    }

                    return;
                }
            }

            SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X, Y, Width, Height, dummyFgTilesColor);
            SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, (float)(X + Width) - resizeHoldSize.X,
                (float)(Y + Height) - resizeHoldSize.Y, resizeHoldSize.X, resizeHoldSize.Y, PackedColor.Orange);
        }

        public virtual void RenderOutline(ISourceRenderContext context, CameraState camera)
        {
            float t = 1f / camera.Zoom * 2f;
            if (Check(Vector2.Zero))
            {
                Outline(context, X + 1, Y + 1, Width - 2, Height - 2, t, firstBorderColor);
            }

            Outline(context, X, Y, Width, Height, t, Dummy ? dummyInactiveBorderColor : inactiveBorderColor);
        }

        public virtual void RenderHighlight(ISourceRenderContext context, CameraState camera, bool hovered,
            bool selected)
        {
            if (selected || hovered)
            {
                float t = 1f / camera.Zoom * 2f;
                Outline(context, X, Y, Width, Height, t, hovered ? hoveredBorderColor : selectedBorderColor);
            }
        }

        protected void Outline(ISourceRenderContext context, float x, float y, float w, float h, float t,
            PackedColor color)
        {
            SourcePrimitiveDrawing.Line((ISourceDrawScope)context, new Vector2(x, y), new Vector2(x + w, y), color, t,
                VectorArithmetic);
            SourcePrimitiveDrawing.Line((ISourceDrawScope)context, new Vector2(x + w, y), new Vector2(x + w, y + h),
                color,
                t, VectorArithmetic);
            SourcePrimitiveDrawing.Line((ISourceDrawScope)context, new Vector2(x, y + h), new Vector2(x + w, y + h),
                color,
                t, VectorArithmetic);
            SourcePrimitiveDrawing.Line((ISourceDrawScope)context, new Vector2(x, y), new Vector2(x, y + h), color, t,
                VectorArithmetic);
        }

        public bool Check(Vector2 point)
        {
            if (point.X >= (float)Left && point.Y >= (float)Top && point.X < (float)Right)
            {
                return point.Y < (float)Bottom;
            }

            return false;
        }

        public bool Check(IntRect rect)
        {
            return Rect.Intersects(rect);
        }

        public void StartMoving()
        {
            moveAnchor = new Vector2(X, Y);
        }

        public void Move(Vector2 relativeMove, List<LevelTemplateState> allLevels, bool snap)
        {
            X = (int)(moveAnchor.X + relativeMove.X);
            Y = (int)(moveAnchor.Y + relativeMove.Y);
            if (!snap)
            {
                return;
            }

            foreach (LevelTemplateState allLevel in allLevels)
            {
                if (allLevel == this)
                {
                    continue;
                }

                if (Bottom >= allLevel.Top && Top <= allLevel.Bottom)
                {
                    bool num = Math.Abs(Left - allLevel.Right) < 3;
                    bool flag = Math.Abs(Right - allLevel.Left) < 3;
                    if (num)
                    {
                        Left = allLevel.Right;
                    }
                    else if (flag)
                    {
                        Right = allLevel.Left;
                    }

                    if (num || flag)
                    {
                        if (Math.Abs(Top - allLevel.Top) < 3)
                        {
                            Top = allLevel.Top;
                        }
                        else if (Math.Abs(Bottom - allLevel.Bottom) < 3)
                        {
                            Bottom = allLevel.Bottom;
                        }
                    }
                }

                if (Right < allLevel.Left || Left > allLevel.Right)
                {
                    continue;
                }

                bool num2 = Math.Abs(Top - allLevel.Bottom) < 5;
                bool flag2 = Math.Abs(Bottom - allLevel.Top) < 5;
                if (num2)
                {
                    Top = allLevel.Bottom;
                }
                else if (flag2)
                {
                    Bottom = allLevel.Top;
                }

                if (num2 || flag2)
                {
                    if (Math.Abs(Left - allLevel.Left) < 3)
                    {
                        Left = allLevel.Left;
                    }
                    else if (Math.Abs(Right - allLevel.Right) < 3)
                    {
                        Right = allLevel.Right;
                    }
                }
            }
        }

        public void StartResizing()
        {
            resizeAnchor = new Vector2(Width, Height);
        }

        public void Resize(Vector2 relativeMove)
        {
            Width = Math.Max(1, (int)(resizeAnchor.X + relativeMove.X));
            Height = Math.Max(1, (int)(resizeAnchor.Y + relativeMove.Y));
            ActualWidth = Width * 8;
            ActualHeight = Height * 8;
        }

        public bool ResizePosition(Vector2 mouse)
        {
            if (mouse.X > (float)(X + Width) - resizeHoldSize.X && mouse.Y > (float)(Y + Height) - resizeHoldSize.Y &&
                mouse.X < (float)(X + Width))
            {
                return mouse.Y < (float)(Y + Height);
            }

            return false;
        }
    }
}
