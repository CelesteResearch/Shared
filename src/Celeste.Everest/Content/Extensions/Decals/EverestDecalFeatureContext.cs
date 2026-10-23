using Celeste.Core.Display;
using Celeste.Graphics.Display;
using Celeste.Core.Randomness;
using System;
using Celeste.Everest.Diagnostics.Logging;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Geometry;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Presentation.Particles;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Particles.Emission;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed class EverestDecalFeatureContext
    {
        private readonly ISourceEngineContext engine;
        private ISourceGameGraphicsEnvironment graphics => (ISourceGameGraphicsEnvironment)engine;
        private ISourceRenderEnvironment renderEnvironment => (ISourceRenderEnvironment)engine;
        private ISourceSoundSourceFactory sounds => ((ISourceSoundSourceEnvironment)engine).SoundSources;

        private OriginalParticleCatalog particleTypes
            => ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine).ParticleTypes;

        private ISourceRandom random
            => ((global::Celeste.Core.Randomness.ISourceRandomProxyEnvironment)engine).RandomProxy;

        public EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;

        public EverestDecalFeatureContext(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public void MakeFloaty(SourceDecalEntityState decal) => decal.MakeFloaty(random);

        public void RandomizeStartingFrame(SourceDecalEntityState decal)
            => decal.Frame = (float)random.NextDouble() * decal.Textures.Count;

        public void MakeScaredAnimation(SourceDecalEntityState decal, int hideRange, int showRange,
            int[] idle, int[] hidden, int[] show, int[] hide)
            => decal.MakeScaredAnimation(random, hideRange, showRange, idle, hidden, show, hide);

        public void MakeBanner(SourceDecalEntityState decal, float speed, float amplitude, int sliceSize,
            float sliceSinIncrement, bool easeDown, float offset = 0f, bool onlyIfWindy = false)
            => decal.MakeBanner(random, speed, amplitude, sliceSize, sliceSinIncrement, easeDown, offset, onlyIfWindy);

        public void MakeStaticMover(SourceDecalEntityState decal, int x, int y, int width, int height)
            => decal.MakeStaticMover(x, y, width, height, platform =>
                ((ISourceDecalAttachmentScene)decal.Scene).DecalAttachmentHistory.Record(decal.Name, decal.Position));

        public void CreateSmoke(SourceDecalEntityState decal, Vector2 offset, bool inbg)
        {
            var level = (OriginalLevelSceneRoot)decal.Scene;
            var emitter = new ParticleEmitterState(inbg ? level.ParticlesBG : level.ParticlesFG,
                particleTypes.Chimney, offset, new Vector2(4f, 1f), -(float)Math.PI / 2f, 1, .2f, engine);
            decal.OwnedComponents.Add(emitter);
            emitter.SimulateCycle();
        }

        public void MakeMirror(SourceDecalEntityState decal, string path, bool keepOffsetsClose)
        {
            decal.Depth = 9500;
            if (keepOffsetsClose)
            {
                Vector2 offset = SourceDecalEntityState.GetMirrorOffset(random);
                decal.AddMirrorMasks(graphics.GameGraphics.GameAtlas.GetAtlasSubtextures("mirrormasks/" + path),
                    offset, random, renderEnvironment);
            }
            else
                decal.AddMirrorMasks(graphics.GameGraphics.GameAtlas.GetAtlasSubtextures("mirrormasks/" + path),
                    false, random, renderEnvironment);
        }

        public void MakeFlagSwap(SourceDecalEntityState decal, string flag, string offPath, string onPath)
            => decal.MakeFlagSwap(flag,
                offPath != null ? graphics.GameGraphics.GameAtlas.GetAtlasSubtextures(offPath) : new List<AtlasEntry>(),
                onPath != null ? graphics.GameGraphics.GameAtlas.GetAtlasSubtextures(onPath) : new List<AtlasEntry>());

        public void AddBloom(SourceDecalEntityState decal, Vector2 at, float alpha, float radius)
            => decal.OwnedComponents.Add(new BloomPointState(at, alpha, radius));

        public void AddLight(SourceDecalEntityState decal, Vector2 at, PackedColor color, float alpha, int startFade,
            int endFade)
            => decal.OwnedComponents.Add(new VertexLightState(engine, at, color, alpha, startFade, endFade));

        public void AddLightOcclude(SourceDecalEntityState decal, int x, int y, int width, int height, float alpha)
            => decal.OwnedComponents.Add(new LightOccludeState(new IntRect(x, y, width, height), alpha));

        public void AddSound(SourceDecalEntityState decal, string eventName)
        {
            var sound = sounds.Create();
            sound.Play(eventName);
            decal.OwnedComponents.Add(sound);
        }
    }
}
