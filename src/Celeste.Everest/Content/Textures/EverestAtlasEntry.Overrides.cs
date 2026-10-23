using System.Collections.Generic;
using System.Numerics;
using Celeste.Everest.Content.Assets;

namespace Celeste.Everest.Content.Textures
{
    public partial class EverestAtlasEntry
    {
        public EverestContentAsset Metadata;
        private List<EverestContentAsset> modAssets;

        public void SetOverride(EverestContentAsset asset, EverestVirtualContent content)
        {
            if (!hasOriginal && ((EverestVirtualTexture)Texture).Metadata == asset)
            {
                Metadata = asset;
                asset.Targets.Add(this);
                return;
            }

            if (modAssets == null)
                modAssets = new List<EverestContentAsset>();
            if ((modAssets.Count == 0 ? null : modAssets[modAssets.Count - 1]) != asset)
            {
                modAssets.Add(asset);
                asset.Targets.Add(this);
            }

            var texture = content.CreateTexture(asset);
            var meta = asset.GetMeta<EverestTextureMetadata>();
            if (meta != null)
            {
                if (meta.Width == 0)
                    meta.Width = texture.Width;
                if (meta.Height == 0)
                    meta.Height = texture.Height;
                SetOverride(texture, new Vector2(meta.X, meta.Y), meta.Width, meta.Height);
            }
            else if (texture.Width == ClipRect.Width && texture.Height == ClipRect.Height)
                SetOverride(texture, DrawOffset, FrameWidth, FrameHeight);
            else
                SetOverride(texture, Vector2.Zero, texture.Width, texture.Height);
        }

        public void UndoOverride(EverestVirtualContent content)
        {
            if (modAssets != null && modAssets.Count > 0)
            {
                modAssets.RemoveAt(modAssets.Count - 1);
                if (modAssets.Count > 0)
                {
                    SetOverride(modAssets[modAssets.Count - 1], content);
                    return;
                }
            }

            RestoreOriginalTexture();
        }

        public void UndoOverride(EverestContentAsset asset, EverestVirtualContent content)
        {
            if (asset == Metadata)
                Atlas?.Entries.ContainsValue(this);
            else
            {
                if (modAssets == null)
                    return;
                int index = modAssets.IndexOf(asset);
                if (index != -1)
                {
                    if (index == modAssets.Count - 1)
                        UndoOverride(content);
                    else
                        modAssets.Remove(asset);
                }
            }
        }
    }
}
