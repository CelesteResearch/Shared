using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Celeste.Core.Scheduling;
using Celeste.Core.Text;
using Celeste.Everest.Content.Metadata;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Text;
using Celeste.Game.Menus.Chapters;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Menus.Chapters
{
    public class EverestChapterSelectIconPresentation : ChapterSelectIconPresentation
    {
        public bool IsHidden => hidden;

        private class AnimatedMapIconMeta
        {
            public float? FrontFPS { get; set; }

            public float? BackFPS { get; set; }


#nullable enable annotations
            public string? FrontFrames { get; set; }

            public string? BackFrames { get; set; }
#nullable restore annotations
        }

        private readonly bool isAnimated;

        private readonly List<AtlasEntry> FrontTextures;

        private readonly List<AtlasEntry> BackTextures;

        private readonly int[] FrontOrder;

        private readonly int[] BackOrder;

        private readonly float FrontFPS;

        private readonly float BackFPS;

        private int FrontFrame;

        private int BackFrame;

        private float FrontFrameTimer;

        private float BackFrameTimer;

        public EverestChapterSelectIconPresentation(ISourceEngineContext engine, int area, AtlasEntry front,
            AtlasEntry back) : base(engine, area, front, back)
        {
            var text = Regex.Replace(front.Name, "\\d+$", string.Empty);
            var text2 = text + "_back";
            var flag = Graphics.GuiAtlas.HasAtlasSubtextures(text);
            var flag2 = Graphics.GuiAtlas.HasAtlasSubtextures(text2);
            if (!(flag || flag2)) return;

            isAnimated = true;
            if (flag)
                FrontTextures = Graphics.GuiAtlas.GetAtlasSubtextures(text);
            else
                FrontTextures = [front];

            if (flag2)
                BackTextures = Graphics.GuiAtlas.GetAtlasSubtextures(text2);
            else if (Graphics.GuiAtlas.Has(text2))
                BackTextures = [Graphics.GuiAtlas[text2]];
            else
                BackTextures = FrontTextures;

            FrontOrder = [.. Enumerable.Range(0, FrontTextures.Count)];
            BackOrder = [.. Enumerable.Range(0, BackTextures.Count)];
            this.front = FrontTextures[0];
            this.back = BackTextures[0];
            FrontFPS = 12f;
            BackFPS = 12f;
            var modAsset =
                ((IEverestContentRegistryEnvironment)engine).SourceContentRegistry.Get<AssetTypeYaml>(
                    "Graphics/Atlases/Gui/" + text + ".meta");
            if (modAsset != null &&
                ((IEverestAssetMetadataEnvironment)engine).AssetMetadata.TryDeserialize<AnimatedMapIconMeta>(modAsset,
                    out var result))
            {
                FrontFPS = result.FrontFPS ?? FrontFPS;
                BackFPS = result.BackFPS ?? FrontFPS;
                if (result.FrontFrames != null) FrontOrder = SourceCsvIntegerFrames.Read(result.FrontFrames);

                if (result.BackFrames != null)
                    BackOrder = SourceCsvIntegerFrames.Read(result.BackFrames);
                else if (result.FrontFrames != null && BackTextures.Count == FrontTextures.Count)
                    BackOrder = FrontOrder;
            }
        }

        public override void Update()
        {
            base.Update();
            if (!hidden && Process.SaveContext.CurrentSave != null && isAnimated)
            {
                FrontFrameTimer -= engine.DeltaTime;
                while (FrontFrameTimer < 0f)
                {
                    FrontFrameTimer += 1f / FrontFPS;
                    FrontFrame++;
                    FrontFrame %= FrontOrder.Length;
                    front = FrontTextures[FrontOrder[FrontFrame]];
                }

                BackFrameTimer -= engine.DeltaTime;
                while (BackFrameTimer < 0f)
                {
                    BackFrameTimer += 1f / BackFPS;
                    BackFrame++;
                    BackFrame %= BackOrder.Length;
                    back = BackTextures[BackOrder[BackFrame]];
                }
            }
        }
    }
}
