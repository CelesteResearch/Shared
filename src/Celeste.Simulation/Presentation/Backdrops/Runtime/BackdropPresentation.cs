using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Rendering;

namespace Celeste.Simulation.Presentation.Backdrops.Runtime
{
    public abstract class BackdropPresentation
    {
        public class Fader
        {
            private struct Segment
            {
                public float PositionFrom;
                public float PositionTo;
                public float From;
                public float To;
            }

            private readonly List<Segment> Segments = [];

            public Fader Add(float posFrom, float posTo, float fadeFrom, float fadeTo)
            {
                Segments.Add(new()
                {
                    PositionFrom = posFrom,
                    PositionTo = posTo,
                    From = fadeFrom,
                    To = fadeTo,
                });
                return this;
            }

            public float Value(float position)
            {
                var value = 1f;
                foreach (var segment in Segments)
                    value *= ScalarMath.ClampedMap(position,
                        segment.PositionFrom, segment.PositionTo, segment.From, segment.To);
                return value;
            }
        }

        public bool UseSpritebatch = true;
        public string Name;
        public HashSet<string> Tags = [];
        public Vector2 Position, Scroll = Vector2.One, Speed;

        public PackedColor Color = PackedColor
            .White;

        public bool LoopX = true, LoopY = true, FlipX, FlipY;
        public Fader FadeX, FadeY;
        public float FadeAlphaMultiplier = 1, WindMultiplier;
        public HashSet<string> ExcludeFrom, OnlyIn;
        public string OnlyIfFlag, OnlyIfNotFlag, AlsoIfFlag;
        public bool? Dreaming;
        public bool Visible, InstantIn = true, InstantOut, ForceVisible;

        public BackdropPresentation()
        {
            Visible = true;
        }

        public BackdropRendererPresentation Renderer;

        public bool IsVisible(ISourceBackdropScene scene)
        {
            if (ForceVisible) return true;
            if (!string.IsNullOrEmpty(OnlyIfNotFlag) && scene.GetFlag(OnlyIfNotFlag)) return false;
            if (!string.IsNullOrEmpty(AlsoIfFlag) && scene.GetFlag(AlsoIfFlag)) return true;
            if (Dreaming.HasValue && Dreaming.Value != scene.Dreaming) return false;
            if (!string.IsNullOrEmpty(OnlyIfFlag) && !scene.GetFlag(OnlyIfFlag)) return false;
            if (ExcludeFrom != null && ExcludeFrom.Contains(scene.Level)) return false;
            if (OnlyIn != null && !OnlyIn.Contains(scene.Level)) return false;
            return true;
        }

        public virtual void Update(ISourceBackdropScene scene)
        {
            if (scene.Transitioning)
            {
                if (InstantIn && IsVisible(scene)) Visible = true;
                if (InstantOut && !IsVisible(scene)) Visible = false;
            }
            else
            {
                Visible = IsVisible(scene);
            }
        }

        public virtual void BeforeRender(
            ISourceBackdropScene scene)
        {
        }

        public virtual void Render(ISourceRenderContext context,
            ISourceBackdropScene scene)
        {
        }

        public virtual void Ended(ISourceBackdropScene scene)
        {
        }
    }
}
