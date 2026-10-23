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
using Celeste.Game.Editor;

namespace Celeste.Everest.Editor
{
    public class EverestLevelTemplateState : LevelTemplateState
    {
        public PackedColor? CustomEditorColor;
        public PackedColor EditorColor => CustomEditorColor ?? fgTilesColor[EditorColorIndex];

        public EverestLevelTemplateState(ISourceEngineContext engine, OriginalLevelRoomData data) : base(engine, data)
        {
            CustomEditorColor = data.CustomEditorColor;
        }

        public EverestLevelTemplateState(ISourceEngineContext engine, int x, int y, int w, int h) : base(engine, x, y,
            w, h)
        {
        }

        protected override bool IsTrackableStrawberry(string name) =>
            ((Celeste.Everest.Content.Extensions.Collectibles.ISourceInstalledStrawberryRegistryEnvironment)
                EngineContext)
            .StrawberryRegistry.TrackableContains(name);

        public override void RenderContents(ISourceRenderContext context, CameraState camera,
            List<LevelTemplateState> allLevels)
        {
            if (!IsVisible(camera))
            {
                return;
            }

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
                        solid.Height, Dummy ? dummyFgTilesColor : EditorColor);
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

        public override void RenderOutline(ISourceRenderContext context, CameraState camera)
        {
            if (IsVisible(camera))
            {
                float t = 1f / camera.Zoom * 2f;
                if (Check(Vector2.Zero))
                {
                    Outline(context, X + 1, Y + 1, Width - 2, Height - 2, t, firstBorderColor);
                }

                Outline(context, X, Y, Width, Height, t, Dummy ? dummyInactiveBorderColor : inactiveBorderColor);
            }
        }

        public override void RenderHighlight(ISourceRenderContext context, CameraState camera, bool hovered,
            bool selected)
        {
            if (IsVisible(camera) && (selected || hovered))
            {
                float t = 1f / camera.Zoom * 2f;
                Outline(context, X, Y, Width, Height, t, hovered ? hoveredBorderColor : selectedBorderColor);
            }
        }

        private bool IsVisible(CameraState camera)
        {
            return Celeste.Everest.Gameplay.Visibility.EverestCullHelper.IsRectangleVisible(EngineContext, X, Y, Width,
                Height, 4f, camera);
        }
    }
}
