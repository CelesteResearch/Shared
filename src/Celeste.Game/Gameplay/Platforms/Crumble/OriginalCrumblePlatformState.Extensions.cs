using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Gameplay.Platforms.Crumble
{
    public partial class OriginalCrumblePlatformState
    {
        protected IReadOnlyList<SpriteImage> CrumbleImages => images;
        protected IReadOnlyList<SimulationCoroutine> CrumbleFalls => falls;
        protected IReadOnlyList<int> CrumbleFallOrder => fallOrder;
        protected ShakerListComponent CrumbleShaker => shaker;
        protected LightOccludeState CrumbleOccluder => occluder;
        protected SimulationCoroutine CrumbleOutlineFader => outlineFader;

        protected IEnumerator RunCrumbleOutlineFade(float target) => OutlineFade(target);
        protected IEnumerator RunCrumbleTileOut(SpriteImage image, float delay) => TileOut(image, delay);

        protected IEnumerator RunCrumbleTileIn(int index, SpriteImage image, float delay) =>
            TileIn(index, image, delay);

        protected IEnumerator RunCrumbleTileInWithoutSound(int index, SpriteImage image, float delay)
            => CrumbleTileReturn(index, image, delay, false);

        private IEnumerator CrumbleTileReturn(int index, SpriteImage img, float delay, bool playSound)
        {
            yield return delay;
            if (playSound)
                process.AudioSession.Play("event:/game/general/platform_return", base.Center, process.SaveContext);
            img.Visible = true;
            img.Color = PackedColor.White;
            img.Position = new Vector2(index * 8 + 4, 4f);
            for (float time = 0f; time < 1f; time += process.DeltaTime / 0.25f)
            {
                yield return null;
                img.Scale = Vector2.One * (1f + process.EasingArithmetic.BounceOut(1f - time) * 0.2f);
            }

            img.Scale = Vector2.One;
        }
    }
}
