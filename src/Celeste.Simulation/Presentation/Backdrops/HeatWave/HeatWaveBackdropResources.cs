using System;
using System.Numerics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.Presentation.Backdrops.HeatWave
{
    public sealed class HeatWaveBackdropResources
    {
        public Func<AtlasEntry> ResolveMist { get; }
        public Vector4[] HotColors { get; }
        public Vector4[] ColdColors { get; }
        public Vector4 FirstMistCold { get; }
        public Vector4 FirstMistHot { get; }
        public Vector4 SecondMistCold { get; }
        public Vector4 SecondMistHot { get; }
        public Vector4 DisplacementColor { get; }
        public int Width { get; }
        public int Height { get; }
        public int ParticleCount { get; }
        public int DisplacementMargin { get; }
        public int DisplacementWidth { get; }
        public int DisplacementHeight { get; }
        public string HotGrade { get; }
        public string ColdGrade { get; }
        public string NeutralGrade { get; }

        public HeatWaveBackdropResources(Func<AtlasEntry> resolveMist, Vector4[] hotColors, Vector4[] coldColors,
            Vector4 firstMistCold, Vector4 firstMistHot, Vector4 secondMistCold, Vector4 secondMistHot,
            Vector4 displacementColor, int width, int height, int particleCount,
            int displacementMargin, int displacementWidth, int displacementHeight,
            string hotGrade, string coldGrade, string neutralGrade)
        {
            ResolveMist = resolveMist ?? throw new ArgumentNullException(nameof(resolveMist));
            HotColors = hotColors ?? throw new ArgumentNullException(nameof(hotColors));
            ColdColors = coldColors ?? throw new ArgumentNullException(nameof(coldColors));
            if (hotColors.Length == 0 || hotColors.Length != coldColors.Length)
                throw new ArgumentException("Hot and cold palettes must have the same positive length.");
            if (width <= 0 || height <= 0 || particleCount < 0)
                throw new ArgumentOutOfRangeException(nameof(width));
            FirstMistCold = firstMistCold;
            FirstMistHot = firstMistHot;
            SecondMistCold = secondMistCold;
            SecondMistHot = secondMistHot;
            DisplacementColor = displacementColor;
            Width = width;
            Height = height;
            ParticleCount = particleCount;
            DisplacementMargin = displacementMargin;
            DisplacementWidth = displacementWidth;
            DisplacementHeight = displacementHeight;
            HotGrade = hotGrade;
            ColdGrade = coldGrade;
            NeutralGrade = neutralGrade;
        }
    }
}
