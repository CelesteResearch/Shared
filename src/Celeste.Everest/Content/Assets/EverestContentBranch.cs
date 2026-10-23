using System;
using System.IO;

namespace Celeste.Everest.Content.Assets
{
    public sealed class EverestContentBranch : EverestContentAsset
    {
        public EverestContentBranch(global::Celeste.Everest.Content.Registry.EverestContentRegistry registry) : base(
            registry, null)
        {
        }

        protected override void Open(out Stream stream, out bool isSection) => throw new InvalidOperationException();
    }
}
