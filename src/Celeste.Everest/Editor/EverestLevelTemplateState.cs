using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Extensions.Collectibles;
using Celeste.Everest.Gameplay.Visibility;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Editor;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Scenes;

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

        protected override bool IsTrackableStrawberry(string name)
        {
            return ((ISourceInstalledStrawberryRegistryEnvironment)
                    EngineContext)
                .StrawberryRegistry.TrackableContains(name);
        }

        public override void RenderContents(ISourceRenderContext context, CameraState camera,
            List<LevelTemplateState> allLevels)
        {
            if (!IsVisible(camera)) return;

            if (Type == LevelTemplateType.Level)
            {
                var flag = false;
                if (((SourceSceneState)EngineContext.Frame.Scenes.CurrentScene).BetweenInterval(0.1f))
                    foreach (var allLevel in allLevels)
                        if (allLevel != this && allLevel.Rect.Intersects(Rect))
                        {
                            flag = true;
                            break;
                        }

                SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X, Y, Width, Height,
                    (flag ? PackedColor.Red : PackedColor.Black) * 0.5f);
                foreach (var back in backs)
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X + back.X, Y + back.Y, back.Width,
                        back.Height,
                        Dummy ? dummyBgTilesColor : bgTilesColor);

                foreach (var solid in solids)
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X + solid.X, Y + solid.Y, solid.Width,
                        solid.Height, Dummy ? dummyFgTilesColor : EditorColor);

                foreach (var spawn in Spawns)
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X + spawn.X, Y + spawn.Y - 1f,
                        1f,
                        1f, PackedColor.Red);

                foreach (var strawberry in Strawberries)
                    SourcePrimitiveDrawing.HollowRect((ISourceDrawScope)context, X + strawberry.X - 1f,
                        Y + strawberry.Y - 2f, 3f, 3f, PackedColor.LightPink);

                foreach (var checkpoint in Checkpoints)
                    SourcePrimitiveDrawing.HollowRect((ISourceDrawScope)context, X + checkpoint.X - 1f,
                        Y + checkpoint.Y - 2f, 3f, 3f, PackedColor.Lime);

                {
                    foreach (var jumpthru in Jumpthrus)
                        SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X + jumpthru.X, Y + jumpthru.Y,
                            jumpthru.Width, 1f, PackedColor.Yellow);

                    return;
                }
            }

            SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X, Y, Width, Height, dummyFgTilesColor);
            SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, X + Width - resizeHoldSize.X,
                Y + Height - resizeHoldSize.Y, resizeHoldSize.X, resizeHoldSize.Y, PackedColor.Orange);
        }

        public override void RenderOutline(ISourceRenderContext context, CameraState camera)
        {
            if (!IsVisible(camera))
                return;
            var t = 1f / camera.Zoom * 2f;
            if (Check(Vector2.Zero)) Outline(context, X + 1, Y + 1, Width - 2, Height - 2, t, firstBorderColor);

            Outline(context, X, Y, Width, Height, t, Dummy ? dummyInactiveBorderColor : inactiveBorderColor);
        }

        public override void RenderHighlight(ISourceRenderContext context, CameraState camera, bool hovered,
            bool selected)
        {
            if (!(IsVisible(camera) && (selected || hovered)))
                return;
            var t = 1f / camera.Zoom * 2f;
            Outline(context, X, Y, Width, Height, t, hovered ? hoveredBorderColor : selectedBorderColor);
        }

        private bool IsVisible(CameraState camera)
        {
            return EverestCullHelper.IsRectangleVisible(EngineContext, X, Y, Width,
                Height, 4f, camera);
        }
    }
}
