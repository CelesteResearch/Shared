using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

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

            private List<Segment> Segments = new List<Segment>();

            public Fader Add(float posFrom, float posTo, float fadeFrom, float fadeTo)
            {
                Segments.Add(new Segment
                {
                    PositionFrom = posFrom,
                    PositionTo = posTo,
                    From = fadeFrom,
                    To = fadeTo
                });
                return this;
            }

            public float Value(float position)
            {
                float value = 1f;
                foreach (Segment segment in Segments)
                    value *= global::Celeste.Core.Mathematics.ScalarMath.ClampedMap(position,
                        segment.PositionFrom, segment.PositionTo, segment.From, segment.To);
                return value;
            }
        }

        public bool UseSpritebatch = true;
        public string Name;
        public HashSet<string> Tags = new HashSet<string>();
        public Vector2 Position, Scroll = Vector2.One, Speed;

        public global::Celeste.Core.Display.PackedColor Color = global::Celeste.Core.Display.PackedColor
            .White;

        public bool LoopX = true, LoopY = true, FlipX, FlipY;
        public Fader FadeX, FadeY;
        public float FadeAlphaMultiplier = 1, WindMultiplier;
        public HashSet<string> ExcludeFrom, OnlyIn;
        public string OnlyIfFlag, OnlyIfNotFlag, AlsoIfFlag;
        public bool? Dreaming;
        public bool Visible, InstantIn = true, InstantOut, ForceVisible;

        public BackdropPresentation() => Visible = true;
        public global::Celeste.Simulation.Presentation.Backdrops.Rendering.BackdropRendererPresentation Renderer;

        public bool IsVisible(global::Celeste.Simulation.Presentation.Backdrops.Runtime.ISourceBackdropScene scene)
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

        public virtual void Update(global::Celeste.Simulation.Presentation.Backdrops.Runtime.ISourceBackdropScene scene)
        {
            if (scene.Transitioning)
            {
                if (InstantIn && IsVisible(scene)) Visible = true;
                if (InstantOut && !IsVisible(scene)) Visible = false;
            }
            else Visible = IsVisible(scene);
        }

        public virtual void BeforeRender(
            global::Celeste.Simulation.Presentation.Backdrops.Runtime.ISourceBackdropScene scene)
        {
        }

        public virtual void Render(global::Celeste.Core.Rendering.ISourceRenderContext context,
            ISourceBackdropScene scene)
        {
        }

        public virtual void Ended(global::Celeste.Simulation.Presentation.Backdrops.Runtime.ISourceBackdropScene scene)
        {
        }
    }
}
