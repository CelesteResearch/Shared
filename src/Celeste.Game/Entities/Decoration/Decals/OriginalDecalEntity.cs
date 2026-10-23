using Celeste.Core.Display;
using Celeste.Graphics.Display;
using Celeste.Core.Randomness;
using System;
using System.IO;
using System.Numerics;
using Celeste.Scene.Components.Oscillation;
using Celeste.Core.Components;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Entities.Decoration.Decals
{
    public class OriginalDecalEntity : SourceDecalEntityState
    {
        public const string Root = "decals";
        public const string MirrorMaskRoot = "mirrormasks";
        private readonly IOriginalDecalRegistrationPolicy registration;
        public bool DepthSetByPlacement;
        public bool ParallaxSetByPlacement;
        private readonly WigglerComponentPool wigglers;
        private readonly ISourceRandom random;
        private readonly ISourceGameGraphicsEnvironment graphics;

        private static PackedColor[] confettiColors =
        {
            new PackedColor(254, 32, 116),
            new PackedColor(32, 94, 254),
            new PackedColor(206, 254, 32)
        };

        public OriginalDecalEntity(Celeste.Core.Scheduling.ISourceEngineContext engine, string texture,
            Vector2 position,
            Vector2 scale, int depth,
            AtlasData atlas, IOriginalDecalRegistrationPolicy registration, WigglerComponentPool wigglers,
            ISourceRandom random, ISourceGameGraphicsEnvironment graphics)
            : base(engine, NormalizeName(texture), position, scale, depth, atlas)
        {
            this.registration = registration;
            this.wigglers = wigglers;
            this.random = random;
            this.graphics = graphics;
        }

        protected override Vector2 ParallaxCenter
            => ((Celeste.Graphics.Geometry.TwoD.Camera.ISourceCameraScene)Scene).Camera.Position +
               new Vector2(160f, 90f);

        public override void Added(object scene)
        {
            int depthBeforeAdded = Depth;
            base.Added(scene);
            registration.Apply(this, depthBeforeAdded);
        }

        private static string NormalizeName(string texture)
        {
            if (string.IsNullOrEmpty(Path.GetExtension(texture))) texture += ".png";
            string extension = Path.GetExtension(texture);
            string input = Path.Combine("decals", texture.Replace(extension, "")).Replace('\\', '/');
            // Match the original regex's Unicode digits and its anchor before a final LF.
            int end = input.Length;
            bool finalLineFeed = end > 0 && input[end - 1] == '\n';
            if (finalLineFeed) end--;
            int start = end;
            while (start > 0 && char.IsDigit(input[start - 1])) start--;
            if (start == end) return input;
            return finalLineFeed ? input.Remove(start, end - start) : input.Substring(0, start);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            registration.AfterAwake(this);
        }

        public void FinalFlagTrigger()
        {
            var wiggler = wigglers.Create(1f, 4f,
                value => (Image as SourceDecalFinalFlagComponent).Rotation = (float)Math.PI / 15f * value,
                start: true);
            Vector2 position = Position;
            position.X = (float)Math.Round(position.X / 8f) * 8f - 8f;
            position.Y += 6f;
            var confetti =
                new global::Celeste.Game.Gameplay.Checkpoints.Summit.OriginalSummitCheckpointState.ConfettiRenderer(
                    EngineContext, position);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(confetti);
            OwnedComponents.Add(wiggler);
        }
    }
}
