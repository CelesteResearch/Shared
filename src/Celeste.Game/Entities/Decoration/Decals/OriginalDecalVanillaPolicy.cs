using Celeste.Core.Randomness;
using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Simulation.Presentation.Particles.Emission;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Graphics.Content;

namespace Celeste.Game.Entities.Decoration.Decals
{
    public sealed class OriginalDecalVanillaPolicy : IOriginalDecalRegistrationPolicy
    {
        private readonly ISourceEngineContext engine;
        private ISourceGameGraphicsEnvironment graphics => (ISourceGameGraphicsEnvironment)engine;
        private ISourceRenderEnvironment renderEnvironment => (ISourceRenderEnvironment)engine;

        private OriginalParticleCatalog particleTypes
            => ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine).ParticleTypes;

        private ISourceSoundSourceFactory sounds => ((ISourceSoundSourceEnvironment)engine).SoundSources;

        private ISourceRandom random
            => ((ISourceRandomEnvironment)engine).Random;

        public OriginalDecalVanillaPolicy(ISourceEngineContext engine)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public void AfterAwake(OriginalDecalEntity decal)
        {
        }

        public void Apply(OriginalDecalEntity decal, int depthBeforeAdded)
        {
            string text = decal.Name.ToLower().Replace("decals/", "");
            switch (text)
            {
                case "generic/grass_a":
                case "generic/grass_b":
                case "generic/grass_c":
                case "generic/grass_d":
                    decal.MakeBanner(random, 2f, 2f, 1, 0.05f, easeDown: false, -2f);
                    break;
                case "0-prologue/house":
                    CreateSmoke(decal, new Vector2(36f, -28f), inbg: true);
                    break;
                case "1-forsakencity/rags":
                case "1-forsakencity/ragsb":
                case "3-resort/curtain_side_a":
                case "3-resort/curtain_side_d":
                    decal.MakeBanner(random, 2f, 3.5f, 2, 0.05f, easeDown: true);
                    break;
                case "3-resort/roofcenter":
                case "3-resort/roofcenter_b":
                case "3-resort/roofcenter_c":
                case "3-resort/roofcenter_d":
                    decal.MakeSolid(-8f, -4f, 16f, 8f, 14);
                    break;
                case "3-resort/roofedge":
                case "3-resort/roofedge_b":
                case "3-resort/roofedge_c":
                case "3-resort/roofedge_d":
                    decal.MakeSolid((!(decal.Scale.X < 0f)) ? (-8) : 0, -4f, 8f, 8f, 14);
                    break;
                case "3-resort/bridgecolumntop":
                    decal.MakeSolid(-8f, -8f, 16f, 8f, 8);
                    decal.MakeSolid(-5f, 0f, 10f, 8f, 8);
                    break;
                case "3-resort/bridgecolumn":
                    decal.MakeSolid(-5f, -8f, 10f, 16f, 8);
                    break;
                case "3-resort/vent":
                    CreateSmoke(decal, Vector2.Zero, inbg: false);
                    break;
                case "3-resort/brokenelevator":
                    decal.MakeSolid(-16f, -20f, 32f, 48f, 22);
                    break;
                case "4-cliffside/bridge_a":
                    decal.MakeSolid(-24f, 0f, 48f, 8f, 8, decal.Depth != 9000);
                    break;
                case "4-cliffside/flower_a":
                case "4-cliffside/flower_b":
                case "4-cliffside/flower_c":
                case "4-cliffside/flower_d":
                    decal.MakeBanner(random, 2f, 2f, 1, 0.05f, easeDown: false, 2f, onlyIfWindy: true);
                    break;
                case "5-temple/bg_mirror_a":
                case "5-temple/bg_mirror_b":
                case "5-temple/bg_mirror_shard_a":
                case "5-temple/bg_mirror_shard_b":
                case "5-temple/bg_mirror_shard_c":
                case "5-temple/bg_mirror_shard_d":
                case "5-temple/bg_mirror_shard_e":
                case "5-temple/bg_mirror_shard_f":
                case "5-temple/bg_mirror_shard_g":
                case "5-temple/bg_mirror_shard_h":
                case "5-temple/bg_mirror_shard_i":
                case "5-temple/bg_mirror_shard_j":
                case "5-temple/bg_mirror_shard_k":
                case "5-temple/bg_mirror_shard_group_a":
                case "5-temple/bg_mirror_shard_group_a_b":
                case "5-temple/bg_mirror_shard_group_a_c":
                case "5-temple/bg_mirror_shard_group_b":
                case "5-temple/bg_mirror_shard_group_c":
                case "5-temple/bg_mirror_shard_group_d":
                case "5-temple/bg_mirror_shard_group_e":
                    decal.Scale.Y = 1f;
                    MakeMirror(decal, text, keepOffsetsClose: false);
                    break;
                case "5-temple/bg_mirror_c":
                case "5-temple/statue_d":
                    MakeMirror(decal, text, keepOffsetsClose: true);
                    break;
                case "5-temple-dark/mosaic_b":
                    decal.OwnedComponents.Add(new BloomPointState(new Vector2(0f, 5f), .75f, 16f));
                    break;
                case "6-reflection/crystal_reflection":
                    MakeMirrorSpecialCase(decal, text, new Vector2(-12f, 2f));
                    break;
                case "7-summit/cloud_a":
                case "7-summit/cloud_b":
                case "7-summit/cloud_bb":
                case "7-summit/cloud_bc":
                case "7-summit/cloud_bd":
                case "7-summit/cloud_c":
                case "7-summit/cloud_cb":
                case "7-summit/cloud_cc":
                case "7-summit/cloud_cd":
                case "7-summit/cloud_ce":
                case "7-summit/cloud_d":
                case "7-summit/cloud_db":
                case "7-summit/cloud_dc":
                case "7-summit/cloud_dd":
                case "7-summit/cloud_e":
                case "7-summit/cloud_f":
                case "7-summit/cloud_g":
                case "7-summit/cloud_h":
                case "7-summit/cloud_j":
                case "7-summit/cloud_i":
                    decal.Depth = -13001;
                    decal.MakeParallax(0.1f);
                    decal.Scale *= 1.15f;
                    break;
                case "7-summit/summitflag":
                    var sound = sounds.Create();
                    sound.Play("event:/env/local/07_summit/flag_flap");
                    decal.OwnedComponents.Add(sound);
                    break;
                case "9-core/ball_a":
                    decal.AddImage(new SourceDecalCoreSwapComponent(decal.Textures[0],
                        graphics.GameGraphics.GameAtlas["decals/9-core/ball_a_ice"]));
                    break;
                case "9-core/ball_a_ice":
                    decal.AddImage(new SourceDecalCoreSwapComponent(
                        graphics.GameGraphics.GameAtlas["decals/9-core/ball_a"],
                        decal.Textures[0]));
                    break;
                case "9-core/rock_e":
                    decal.AddImage(new SourceDecalCoreSwapComponent(decal.Textures[0],
                        graphics.GameGraphics.GameAtlas["decals/9-core/rock_e_ice"]));
                    break;
                case "9-core/rock_e_ice":
                    decal.AddImage(new SourceDecalCoreSwapComponent(
                        graphics.GameGraphics.GameAtlas["decals/9-core/rock_e"],
                        decal.Textures[0]));
                    break;
                case "9-core/heart_bevel_a":
                case "9-core/heart_bevel_b":
                case "9-core/heart_bevel_c":
                case "9-core/heart_bevel_d":
                    decal.Scale.Y = 1f;
                    decal.Scale.X = 1f;
                    break;
                case "10-farewell/creature_a":
                case "10-farewell/creature_b":
                case "10-farewell/creature_c":
                case "10-farewell/creature_d":
                case "10-farewell/creature_e":
                case "10-farewell/creature_f":
                    decal.Depth = 10001;
                    decal.MakeParallax(-0.1f);
                    decal.MakeFloaty(random);
                    break;
                case "10-farewell/coral_":
                case "10-farewell/coral_a":
                case "10-farewell/coral_b":
                case "10-farewell/coral_c":
                case "10-farewell/coral_d":
                    decal.MakeScaredAnimation(random);
                    break;
                case "10-farewell/clouds/cloud_a":
                case "10-farewell/clouds/cloud_b":
                case "10-farewell/clouds/cloud_bb":
                case "10-farewell/clouds/cloud_bc":
                case "10-farewell/clouds/cloud_bd":
                case "10-farewell/clouds/cloud_c":
                case "10-farewell/clouds/cloud_cb":
                case "10-farewell/clouds/cloud_cc":
                case "10-farewell/clouds/cloud_cd":
                case "10-farewell/clouds/cloud_ce":
                case "10-farewell/clouds/cloud_d":
                case "10-farewell/clouds/cloud_db":
                case "10-farewell/clouds/cloud_dc":
                case "10-farewell/clouds/cloud_dd":
                case "10-farewell/clouds/cloud_e":
                case "10-farewell/clouds/cloud_f":
                case "10-farewell/clouds/cloud_g":
                case "10-farewell/clouds/cloud_h":
                case "10-farewell/clouds/cloud_j":
                case "10-farewell/clouds/cloud_i":
                    decal.Depth = -13001;
                    decal.MakeParallax(0.1f);
                    decal.Scale *= 1.15f;
                    break;
                case "10-farewell/glitch_a_":
                case "10-farewell/glitch_b_":
                case "10-farewell/glitch_c":
                    decal.Frame = (float)random.NextDouble() * decal.Textures.Count;
                    break;
                case "10-farewell/cliffside":
                case "10-farewell/car":
                case "10-farewell/bed":
                case "10-farewell/floating house":
                case "10-farewell/heart_a":
                case "10-farewell/heart_b":
                case "10-farewell/reflection":
                case "10-farewell/tower":
                case "10-farewell/temple":
                case "10-farewell/giantcassete":
                    decal.Depth = 10001;
                    decal.MakeParallax(-0.15f);
                    decal.MakeFloaty(random);
                    break;
                case "10-farewell/finalflag":
                    decal.AnimationSpeed = 6f;
                    decal.AddImage(new SourceDecalFinalFlagComponent());
                    break;
            }

            if (decal.Name.Contains("crack")) decal.IsCrack = true;
            decal.EnsureDefaultImage();
        }

        private void MakeMirror(SourceDecalEntityState decal, string path, bool keepOffsetsClose)
        {
            decal.Depth = 9500;
            if (keepOffsetsClose)
            {
                MakeMirror(decal, path, SourceDecalEntityState.GetMirrorOffset(random));
                return;
            }

            decal.AddMirrorMasks(graphics.GameGraphics.GameAtlas.GetAtlasSubtextures("mirrormasks/" + path),
                false, random, renderEnvironment);
        }

        private void MakeMirror(SourceDecalEntityState decal, string path, Vector2 offset)
        {
            decal.Depth = 9500;
            decal.AddMirrorMasks(graphics.GameGraphics.GameAtlas.GetAtlasSubtextures("mirrormasks/" + path),
                offset, random, renderEnvironment);
        }

        private void MakeMirrorSpecialCase(SourceDecalEntityState decal, string path, Vector2 offset)
        {
            decal.Depth = 9500;
            decal.AddSpecialMirrorMasks(graphics.GameGraphics.GameAtlas.GetAtlasSubtextures("mirrormasks/" + path),
                offset, random, renderEnvironment);
        }

        private void CreateSmoke(SourceDecalEntityState decal, Vector2 offset, bool inbg)
        {
            var level = (OriginalLevelSceneRoot)decal.Scene;
            var emitter = new ParticleEmitterState(inbg ? level.ParticlesBG : level.ParticlesFG,
                particleTypes.Chimney, offset, new Vector2(4f, 1f), -(float)Math.PI / 2f, 1, .2f, engine);
            decal.OwnedComponents.Add(emitter);
            emitter.SimulateCycle();
        }
    }
}
