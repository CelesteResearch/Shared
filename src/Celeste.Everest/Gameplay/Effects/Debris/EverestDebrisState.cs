using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Tiles.Autotiling;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles.Autotiling;

namespace Celeste.Everest.Gameplay.Effects.Debris
{
    public class EverestDebrisState : DebrisState
    {
        public EverestDebrisState(ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy) : base(engine, targetMotionPolicy)
        {
        }

        private ISourceGameGraphicsResources Graphics
            => ((ISourceGameGraphicsEnvironment)SourceEngine).GameGraphics;

        private EverestAutotiler ForegroundAutotiler
            => (EverestAutotiler)((ISourceAutotilingResources)Graphics).ForegroundAutotiler;

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public override DebrisState Init(Vector2 position, char tileset, bool playSound = true)
        {
            // The base physical method is the complete source orig_Init, with the
            // same actor fields and random draws. The wrapper is a distinct method.
            DebrisState debris = base.Init(position, tileset, playSound);
            if (ForegroundAutotiler.TryGetCustomDebris(out string path, tileset))
            {
                List<AtlasEntry> textures = Graphics.GameAtlas.GetAtlasSubtextures("debris/" + path);
                SourceImage.Texture = textures[((ISourceRandomEnvironment)SourceEngine).Random.Next(textures.Count)];
            }

            return debris;
        }

        public DebrisState Init(Vector2 position, char tileset)
        {
            return Init(position, tileset, true);
        }

        protected override void ImpactSfx(float velocity)
        {
            if (!SourcePlaySound) return;
            char tileset = SourceTileset;
            if (!ForegroundAutotiler.TryGetCustomDebrisImpactSfx(out string soundEvent, tileset))
            {
                soundEvent = "event:/game/general/debris_dirt";
                if (tileset == '4' || tileset == '5' || tileset == '6' || tileset == '7' || tileset == 'a'
                    || tileset == 'c' || tileset == 'd' || tileset == 'e' || tileset == 'f' || tileset == 'd' ||
                    tileset == 'g')
                    soundEvent = "event:/game/general/debris_stone";
                else if (tileset == '9') soundEvent = "event:/game/general/debris_wood";
            }

            ((ISourceSpatialAudioEnvironment)SourceEngine).SpatialAudio.Play(soundEvent, Position,
                "debris_velocity", ScalarMath.ClampedMap(velocity, 0f, 150f));
        }
    }
}
