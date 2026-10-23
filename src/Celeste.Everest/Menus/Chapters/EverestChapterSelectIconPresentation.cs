using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Journal;
using Celeste.Game.Menus.Title;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.Data;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using System.Linq;
using System.Text.RegularExpressions;
using Celeste.Game.Menus.Chapters;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Types.Text;
using Celeste.Everest.Content.Metadata;
using Celeste.Core.Text;

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

        private bool isAnimated;

        private List<AtlasEntry> FrontTextures;

        private List<AtlasEntry> BackTextures;

        private int[] FrontOrder;

        private int[] BackOrder;

        private float FrontFPS;

        private float BackFPS;

        private int FrontFrame;

        private int BackFrame;

        private float FrontFrameTimer;

        private float BackFrameTimer;

        public EverestChapterSelectIconPresentation(ISourceEngineContext engine, int area, AtlasEntry front,
            AtlasEntry back) : base(engine, area, front, back)
        {
            string text = Regex.Replace(front.Name, "\\d+$", string.Empty);
            string text2 = text + "_back";
            bool flag = Graphics.GuiAtlas.HasAtlasSubtextures(text);
            bool flag2 = Graphics.GuiAtlas.HasAtlasSubtextures(text2);
            if (!(flag || flag2))
            {
                return;
            }

            isAnimated = true;
            if (flag)
            {
                FrontTextures = Graphics.GuiAtlas.GetAtlasSubtextures(text);
            }
            else
            {
                FrontTextures = new List<AtlasEntry> { front };
            }

            if (flag2)
            {
                BackTextures = Graphics.GuiAtlas.GetAtlasSubtextures(text2);
            }
            else if (Graphics.GuiAtlas.Has(text2))
            {
                BackTextures = new List<AtlasEntry> { Graphics.GuiAtlas[text2] };
            }
            else
            {
                BackTextures = FrontTextures;
            }

            FrontOrder = Enumerable.Range(0, FrontTextures.Count).ToArray();
            BackOrder = Enumerable.Range(0, BackTextures.Count).ToArray();
            this.front = FrontTextures[0];
            this.back = BackTextures[0];
            FrontFPS = 12f;
            BackFPS = 12f;
            EverestContentAsset modAsset =
                ((IEverestContentRegistryEnvironment)engine).SourceContentRegistry.Get<AssetTypeYaml>(
                    "Graphics/Atlases/Gui/" + text + ".meta");
            if (modAsset != null &&
                ((IEverestAssetMetadataEnvironment)engine).AssetMetadata.TryDeserialize<AnimatedMapIconMeta>(modAsset,
                    out var result))
            {
                FrontFPS = result.FrontFPS ?? FrontFPS;
                BackFPS = result.BackFPS ?? FrontFPS;
                if (result.FrontFrames != null)
                {
                    FrontOrder = SourceCsvIntegerFrames.Read(result.FrontFrames);
                }

                if (result.BackFrames != null)
                {
                    BackOrder = SourceCsvIntegerFrames.Read(result.BackFrames);
                }
                else if (result.FrontFrames != null && BackTextures.Count == FrontTextures.Count)
                {
                    BackOrder = FrontOrder;
                }
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
