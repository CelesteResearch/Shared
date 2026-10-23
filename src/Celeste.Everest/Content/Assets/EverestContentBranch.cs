using System;
using System.IO;
using Celeste.Everest.Content.Registry;

namespace Celeste.Everest.Content.Assets
{
    public sealed class EverestContentBranch : EverestContentAsset
    {
        public EverestContentBranch(EverestContentRegistry registry) : base(
            registry, null)
        {
        }

        protected override void Open(out Stream stream, out bool isSection)
        {
            throw new InvalidOperationException();
        }
    }
}
