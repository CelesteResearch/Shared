using System;
using System.IO;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Atlases;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Content.Types.Directories;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Everest.Runtime.Threading;
using Celeste.Everest.Text.BitmapFonts;
using Celeste.Game.Content.Dialogs;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        private readonly IEverestContentProcessingEnvironment processing;
        internal global::Celeste.Everest.Modules.Updating.EverestLoaderProcess AssetLoader => processing.Loader;
        internal global::Celeste.Everest.Content.Serialization.EverestYamlProcess AssetYaml => processing.Yaml;

        public EverestContentRegistry(IEverestContentDiagnostics diagnostics,
            IEverestContentProcessingEnvironment processing)
        {
            Diagnostics = diagnostics ?? throw new ArgumentNullException(nameof(diagnostics));
            this.processing = processing ?? throw new ArgumentNullException(nameof(processing));
        }

        public void ProcessUpdate(object asset, EverestContentAsset mapping, bool load)
        {
            if (asset == null || mapping == null)
                return;
            AtlasData atlas = asset as AtlasData;
            if (atlas != null)
            {
                string text = processing.Text.Dialog?.Language == null
                    ? ""
                    : processing.Text.CleanDialog(mapping.Children.Count == 0
                        ? "ASSETRELOADHELPER_RELOADINGTEXTURE"
                        : "ASSETRELOADHELPER_RELOADINGTEXTURES");
                processing.AssetReload.Do(load, text + " " + Path.GetFileName(mapping.PathVirtual), () =>
                {
                    atlas.ResetCaches();
                    ((EverestAtlasData)atlas).Ingest(mapping, processing.VirtualContent,
                        processing.AtlasIngestDiagnostics);
                });
                if (processing.Emoji.IsInitialized() && RefreshEmojis(mapping))
                    processing.MainThread.Schedule(() =>
                    {
                        processing.Logger.Log(EverestLogLevel.Verbose, "content",
                            "Reloading fonts after late emoji registration");
                        processing.Text.Fonts.Reload();
                    });
                if ((processing.MountainExtension.ModsLoaded || processing.MountainExtension.ModsDataLoaded) &&
                    PotentiallyContainsMountainTextures(mapping))
                    processing.AssetReload.Do(load, processing.Text.CleanDialog("ASSETRELOADHELPER_RELOADINGMOUNTAIN"),
                        () =>
                        {
                            processing.MountainExtension.ReloadMod();
                            processing.MainThread.Schedule(() => processing.MountainExtension.ReloadModData());
                        });
            }

            OnProcessUpdate?.Invoke(asset, mapping, load);
        }

        private bool RefreshEmojis(EverestContentAsset mapping)
        {
            if (mapping.Type == typeof(AssetTypeDirectory))
                lock (mapping.Children)
                {
                    bool found = false;
                    foreach (EverestContentAsset child in mapping.Children)
                        found = RefreshEmojis(child) || found;
                    return found;
                }

            if (mapping.PathVirtual.StartsWith("Graphics/Atlases/Gui/emoji/"))
            {
                string name = mapping.PathVirtual.Substring(27);
                var message = processing.Logger.BeginEnabledMessage("content", EverestLogLevel.Verbose);
                if (message.ShouldLog)
                    message.Write("Late registering emoji: " + name);
                processing.Emoji.Register(name, (EverestAtlasEntry)processing.GuiAtlas["emoji/" + name]);
                return true;
            }

            return false;
        }

        private static bool PotentiallyContainsMountainTextures(EverestContentAsset mapping)
        {
            if (mapping.Type == typeof(AssetTypeDirectory))
                lock (mapping.Children)
                {
                    foreach (EverestContentAsset child in mapping.Children)
                        if (PotentiallyContainsMountainTextures(child))
                            return true;
                    return false;
                }

            return mapping.PathVirtual.StartsWith("Graphics/Atlases/Mountain/");
        }
    }
}
