using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Presentation.Effects.Mirrors
{
    public sealed class MirrorSurfaceState : SourceComponentState
    {
        private readonly ISourceExtremaArithmetic arithmetic;
        public Action OnRender;
        private Vector2 reflectionOffset;

        public Vector2 ReflectionOffset
        {
            get => reflectionOffset;
            set
            {
                reflectionOffset = value;
                ReflectionColor = new PackedColor(
                    0.5f + arithmetic.Min(arithmetic.Max(reflectionOffset.X / 32f, -1f), 1f) * 0.5f,
                    0.5f + arithmetic.Min(arithmetic.Max(reflectionOffset.Y / 32f, -1f), 1f) * 0.5f,
                    0f, 1f);
            }
        }

        public PackedColor ReflectionColor { get; private set; }

        public MirrorSurfaceState(ISourceExtremaArithmetic arithmetic, Action onRender = null) : base(false, true)
        {
            this.arithmetic = arithmetic;
            OnRender = onRender;
        }
    }
}
