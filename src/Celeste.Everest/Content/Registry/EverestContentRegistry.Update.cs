using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Celeste.Core.IO;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Content.Types.Maps;
using Celeste.Everest.Content.Types.Text;
using Celeste.Everest.Content.Types.Graphics;
using Celeste.Everest.Content.Types.Playback;
using Celeste.Everest.Content.Types.Dialogs;
using Celeste.Everest.Content.Extensions.Decals;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Modules.Runtime;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        private ISourceEngineContext EngineContext => processing.AssetReload.EngineContext;

        public void Update(EverestContentAsset prev, EverestContentAsset next)
        {
            if (prev != null)
            {
                foreach (object target2 in prev.Targets)
                {
                    EverestAtlasEntry mtex = target2 as EverestAtlasEntry;
                    if (mtex != null)
                    {
                        processing.AssetReload.Do(
                            processing.Text.Dialog.Clean("ASSETRELOADHELPER_UNLOADINGTEXTURE") + " " +
                            Path.GetFileName(prev.PathVirtual),
                            delegate { mtex.UndoOverride(prev, processing.VirtualContent); });
                    }
                }

                if (next == null || prev.PathVirtual != next.PathVirtual)
                {
                    Add(prev.PathVirtual, null);
                }
            }

            if (next != null && TryAdd(next.PathVirtual, next))
            {
                string path = next.PathVirtual;
                string fileName = Path.GetFileName(path);
                OriginalLevelSceneRoot levelPrev =
                    (EngineContext.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot) ??
                    (processing.AssetReload.ReturnToScene as OriginalLevelSceneRoot);
                if (next.Type == typeof(AssetTypeMap))
                {
                    string mapName = path.Substring(5);
                    OriginalAreaModeData mode = ((IOriginalAreaSourceTable)EngineContext).Areas
                        .SelectMany(area => ((EverestArea)area).Mode).FirstOrDefault((OriginalAreaModeData modeSel) =>
                            modeSel?.MapData?.Filename == mapName);
                    if (mode != null)
                    {
                        processing.AssetReload.Do(
                            processing.Text.Dialog.Clean("ASSETRELOADHELPER_RELOADINGMAPNAME") + " " + fileName,
                            delegate(bool silent)
                            {
                                mode.MapData.Reload();
                                return Task.CompletedTask;
                            }).ContinueWith((Task _) => processing.MainThread.Schedule(delegate
                        {
                            if (levelPrev?.Session.MapData == mode.MapData)
                            {
                                processing.AssetReload.ReloadLevel();
                            }
                        }));
                    }
                    else
                    {
                        processing.AssetReload.Do(processing.Text.Dialog.Clean("ASSETRELOADHELPER_RELOADINGALLMAPS"),
                            delegate(bool silent)
                            {
                                processing.AssetReload.ReloadAllMaps();
                                return Task.CompletedTask;
                            }).ContinueWith(delegate { processing.AssetReload.ReloadLevel(); });
                    }
                }
                else if (next.Type == typeof(AssetTypeXml) || next.Type == typeof(AssetTypeSpriteBank))
                {
                    processing.AssetReload.ReloadLevel();
                }
                else if (next.Type == typeof(AssetTypeTutorial))
                {
                    ((IEverestContentUpdateEnvironment)EngineContext).PlaybackData.Load(
                        ((ISourceContentDirectoryEnvironment)EngineContext).ContentDirectory,
                        ((global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment)EngineContext)
                        .ContentFiles);
                    processing.AssetReload.ReloadLevel();
                }
                else if (next.Type == typeof(AssetTypeDecalRegistry))
                {
                    ((IEverestDecalRegistryEnvironment)EngineContext).DecalRegistry.LoadModRegistry(next);
                    processing.AssetReload.ReloadLevel();
                }
                else if (next.Type == typeof(AssetTypeDialog) || next.Type == typeof(AssetTypeDialogExport))
                {
                    processing.AssetReload.Do(
                        processing.Text.Dialog.Clean("ASSETRELOADHELPER_RELOADINGDIALOG") + " " + fileName, delegate
                        {
                            string text = path + ".txt";
                            foreach (string vanillaLanguageFile in processing.Text.GetVanillaLanguageFileList(
                                         Path.Combine(
                                             ((ISourceContentDirectoryEnvironment)EngineContext).ContentDirectory,
                                             "Dialog"), "*.txt", SearchOption.AllDirectories))
                            {
                                if (vanillaLanguageFile.Equals(text, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    text = vanillaLanguageFile;
                                    break;
                                }
                            }

                            processing.Text.LoadLanguage(Path.Combine(PathContentOrig, text));
                            processing.Text.RefreshLanguages();
                        });
                }
                else if (next.Type == typeof(AssetTypeObjModel) || next.Type == typeof(AssetTypeObjModelExport))
                {
                    if (next.Type == typeof(AssetTypeObjModel))
                    {
                        processing.MountainExtension.ObjModelCache.Remove(next.PathVirtual + ".obj");
                    }
                    else
                    {
                        processing.MountainExtension.ObjModelCache.Remove(next.PathVirtual + ".export");
                    }

                    processing.MainThread.Schedule(delegate { processing.MountainExtension.ReloadModData(); });
                }
                else if (next.Type == typeof(AssetTypeFont))
                {
                    processing.MainThread.Schedule(delegate { processing.Text.Fonts.Reload(); });
                }

                HashSet<WeakReference> hashSet = new HashSet<WeakReference>();
                EverestContentAsset modAsset = next;
                while (modAsset != null && !string.IsNullOrEmpty(modAsset.PathVirtual))
                {
                    int num = LoadedAssetPaths.IndexOf(modAsset.PathVirtual);
                    if (num != -1)
                    {
                        WeakReference weakReference = LoadedAssets[num];
                        if (hashSet.Add(weakReference))
                        {
                            object target = weakReference.Target;
                            if (weakReference.IsAlive)
                            {
                                ProcessUpdate(target, next, load: false);
                            }
                        }
                    }

                    modAsset = Get(Path.GetDirectoryName(modAsset.PathVirtual).Replace('\\', '/'));
                }
            }

            OnUpdate?.Invoke(prev, next);
            ((ISourceEverestModulesProcessEnvironment)EngineContext).ModulesProcess.InvalidateInstallationHash();
        }
    }
}
