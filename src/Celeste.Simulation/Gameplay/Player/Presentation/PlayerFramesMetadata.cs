using System;
using System.Collections.Generic;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.Gameplay.Player.Presentation
{
    public sealed class PlayerFramesMetadata
    {
        private readonly Dictionary<string, PlayerAnimMetadata> frames =
            new Dictionary<string, PlayerAnimMetadata>(StringComparer.OrdinalIgnoreCase);

        public PlayerAnimMetadata Get(AtlasEntry texture) =>
            texture != null && frames.TryGetValue(texture.Name, out var frame) ? frame : null;

        public void Set(string name, PlayerAnimMetadata metadata) => frames[name] = metadata;

        public void Clear() => frames.Clear();

        public void CopyFrom(PlayerFramesMetadata metadata)
        {
            if (metadata == null) throw new ArgumentNullException(nameof(metadata));
            if (ReferenceEquals(this, metadata)) return;
            frames.Clear();
            foreach (var pair in metadata.frames) frames[pair.Key] = pair.Value;
        }
    }
}
