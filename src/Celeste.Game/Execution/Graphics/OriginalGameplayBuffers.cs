using System.Collections.Generic;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Game.Execution.Graphics
{
    public sealed class OriginalGameplayBuffers
    {
        public VirtualRenderTarget Gameplay;
        public VirtualRenderTarget Level;
        public VirtualRenderTarget ResortDust;
        public VirtualRenderTarget LightBuffer;
        public VirtualRenderTarget Light;
        public VirtualRenderTarget Displacement;
        public VirtualRenderTarget MirrorSources;
        public VirtualRenderTarget MirrorMasks;
        public VirtualRenderTarget SpeedRings;
        public VirtualRenderTarget Lightning;
        public VirtualRenderTarget TempA;
        public VirtualRenderTarget TempB;

        private readonly List<VirtualRenderTarget> all = [];
        private VirtualContent content;

        public void Create(VirtualContent sourceContent)
        {
            Unload();
            content = sourceContent;
            Gameplay = Create(320, 180);
            Level = Create(320, 180);
            ResortDust = Create(320, 180);
            Light = Create(320, 180);
            Displacement = Create(320, 180);
            LightBuffer = Create(1024, 1024);
            MirrorSources = Create(384, 244);
            MirrorMasks = Create(384, 244);
            SpeedRings = Create(512, 512);
            Lightning = Create(160, 160);
            TempA = Create(320, 180);
            TempB = Create(320, 180);
        }

        private VirtualRenderTarget Create(int width, int height)
        {
            var target = content.CreateRenderTarget("gameplay-buffer-" + all.Count, width, height);
            all.Add(target);
            return target;
        }

        public void Unload()
        {
            foreach (var target in all)
                target.Dispose();
            all.Clear();
        }
    }
}
