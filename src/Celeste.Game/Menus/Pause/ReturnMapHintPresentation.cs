using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Menus.Pause
{
    public class ReturnMapHintPresentation : SceneEntityState
    {
        protected AtlasEntry checkpoint;
        protected readonly ISourceEngineContext engine;
        protected IOriginalAreaKeyPolicy AreaKeys => ((IOriginalAreaKeyEnvironment)engine).AreaKeys;

        protected OriginalMountainResources MountainResources =>
            ((IOriginalMountainEnvironment)engine).MountainResources;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected IOriginalGameTextEnvironment TextProcess => (IOriginalGameTextEnvironment)engine;

        public ReturnMapHintPresentation(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var session = (Scene as OriginalLevelSceneRoot).Session;
            var area = AreaKeys.GetSessionArea(session);
            var checkpoints =
                ((IOriginalSaveCheckpointEnvironment)engine).SaveCheckpoints.GetCheckpoints(
                    ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave, area);
            OriginalCheckpointData checkpointData = null;
            var modeProperties =
                ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[area.ID].Mode[area.Mode];
            if (modeProperties.Checkpoints != null)
            {
                var checkpoints2 = modeProperties.Checkpoints;
                foreach (var checkpointData2 in checkpoints2)
                    if (session.LevelFlags.Contains(checkpointData2.Level) &&
                        checkpoints.Contains(checkpointData2.Level))
                        checkpointData = checkpointData2;
            }

            var text = AreaKeys.Format(area);
            if (checkpointData != null) text = text + "_" + checkpointData.Level;

            if (MountainResources.Checkpoints.Has(text)) checkpoint = MountainResources.Checkpoints[text];
        }

        public virtual string GetCheckpointPreviewName(OriginalAreaKey area, string level)
        {
            if (level == null) return AreaKeys.Format(area);

            return AreaKeys.Format(area) + "_" + level;
        }

        private AtlasEntry GetCheckpointPreview(OriginalAreaKey area, string level)
        {
            var checkpointPreviewName = GetCheckpointPreviewName(area, level);
            return MountainResources.Checkpoints.Has(checkpointPreviewName)
                ? MountainResources.Checkpoints[checkpointPreviewName]
                : null;
        }

        public override void Render(ISourceRenderContext context)
        {
            var mTexture = Graphics.GuiAtlas["checkpoint"];
            var text = TextProcess.Text.Dialog.Clean("MENU_RETURN_INFO");
            var mTexture2 = MountainResources.Checkpoints["polaroid"];
            var num = TextProcess.Text.ActiveFont.Measure(text).X * 0.75f;
            if (checkpoint != null)
            {
                var num2 = mTexture2.FrameWidth * 0.25f;
                var vector = new Vector2((1920f - num - num2 - 64f) / 2f, 730f);
                var num3 = 720f / checkpoint.ClipRect.Width;
                TextProcess.Text.ActiveFont.DrawOutline(context, this, text, vector + new Vector2(num / 2f, 0f),
                    new(0.5f, 0.5f), Vector2.One * 0.75f, PackedColor.LightGray, 2f, PackedColor.Black);
                vector.X += num + 64f;
                SourceAtlasDrawing.DrawCentered(context, this, mTexture2, vector + new Vector2(num2 / 2f, 0f),
                    PackedColor.White, 0.25f, 0.1f);
                SourceAtlasDrawing.DrawCentered(context, this, checkpoint, vector + new Vector2(num2 / 2f, 0f),
                    PackedColor.White, 0.25f * num3, 0.1f);
                SourceAtlasDrawing.DrawCentered(context, this, mTexture,
                    vector + new Vector2(num2 * 0.8f, mTexture2.FrameHeight * 0.25f * 0.5f * 0.8f),
                    PackedColor.White, 0.75f);
            }
            else
            {
                var num4 = mTexture.FrameWidth * 0.75f;
                var vector2 = new Vector2((1920f - num - num4 - 64f) / 2f, 730f);
                TextProcess.Text.ActiveFont.DrawOutline(context, this, text, vector2 + new Vector2(num / 2f, 0f),
                    new(0.5f, 0.5f), Vector2.One * 0.75f, PackedColor.LightGray, 2f, PackedColor.Black);
                vector2.X += num + 64f;
                SourceAtlasDrawing.DrawCentered(context, this, mTexture, vector2 + new Vector2(num4 * 0.5f, 0f),
                    PackedColor.White, 0.75f);
            }
        }
    }
}
