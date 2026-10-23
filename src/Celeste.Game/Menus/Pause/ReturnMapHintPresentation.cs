using Celeste.Core.Display;
using Celeste.Graphics.Content;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

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
            OriginalAreaKey area = AreaKeys.GetSessionArea(session);
            HashSet<string> checkpoints =
                ((IOriginalSaveCheckpointEnvironment)engine).SaveCheckpoints.GetCheckpoints(
                    ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave, area);
            OriginalCheckpointData checkpointData = null;
            OriginalAreaModeData modeProperties =
                ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[area.ID].Mode[(int)area.Mode];
            if (modeProperties.Checkpoints != null)
            {
                OriginalCheckpointData[] checkpoints2 = modeProperties.Checkpoints;
                foreach (OriginalCheckpointData checkpointData2 in checkpoints2)
                {
                    if (session.LevelFlags.Contains(checkpointData2.Level) &&
                        checkpoints.Contains(checkpointData2.Level))
                    {
                        checkpointData = checkpointData2;
                    }
                }
            }

            string text = AreaKeys.Format(area);
            if (checkpointData != null)
            {
                text = text + "_" + checkpointData.Level;
            }

            if (MountainResources.Checkpoints.Has(text))
            {
                checkpoint = MountainResources.Checkpoints[text];
            }
        }

        public virtual string GetCheckpointPreviewName(OriginalAreaKey area, string level)
        {
            if (level == null)
            {
                return AreaKeys.Format(area);
            }

            return AreaKeys.Format(area) + "_" + level;
        }

        private AtlasEntry GetCheckpointPreview(OriginalAreaKey area, string level)
        {
            string checkpointPreviewName = GetCheckpointPreviewName(area, level);
            if (MountainResources.Checkpoints.Has(checkpointPreviewName))
            {
                return MountainResources.Checkpoints[checkpointPreviewName];
            }

            return null;
        }

        public override void Render(ISourceRenderContext context)
        {
            AtlasEntry mTexture = Graphics.GuiAtlas["checkpoint"];
            string text = TextProcess.Text.Dialog.Clean("MENU_RETURN_INFO");
            AtlasEntry mTexture2 = MountainResources.Checkpoints["polaroid"];
            float num = TextProcess.Text.ActiveFont.Measure(text).X * 0.75f;
            if (checkpoint != null)
            {
                float num2 = (float)mTexture2.FrameWidth * 0.25f;
                Vector2 vector = new Vector2((1920f - num - num2 - 64f) / 2f, 730f);
                float num3 = 720f / (float)checkpoint.ClipRect.Width;
                TextProcess.Text.ActiveFont.DrawOutline(context, this, text, vector + new Vector2(num / 2f, 0f),
                    new Vector2(0.5f, 0.5f), Vector2.One * 0.75f, PackedColor.LightGray, 2f, PackedColor.Black);
                vector.X += num + 64f;
                SourceAtlasDrawing.DrawCentered(context, this, mTexture2, vector + new Vector2(num2 / 2f, 0f),
                    PackedColor.White, 0.25f, 0.1f);
                SourceAtlasDrawing.DrawCentered(context, this, checkpoint, vector + new Vector2(num2 / 2f, 0f),
                    PackedColor.White, 0.25f * num3, 0.1f);
                SourceAtlasDrawing.DrawCentered(context, this, mTexture,
                    vector + new Vector2(num2 * 0.8f, (float)mTexture2.FrameHeight * 0.25f * 0.5f * 0.8f),
                    PackedColor.White, 0.75f);
            }
            else
            {
                float num4 = (float)mTexture.FrameWidth * 0.75f;
                Vector2 vector2 = new Vector2((1920f - num - num4 - 64f) / 2f, 730f);
                TextProcess.Text.ActiveFont.DrawOutline(context, this, text, vector2 + new Vector2(num / 2f, 0f),
                    new Vector2(0.5f, 0.5f), Vector2.One * 0.75f, PackedColor.LightGray, 2f, PackedColor.Black);
                vector2.X += num + 64f;
                SourceAtlasDrawing.DrawCentered(context, this, mTexture, vector2 + new Vector2(num4 * 0.5f, 0f),
                    PackedColor.White, 0.75f);
            }
        }
    }
}
