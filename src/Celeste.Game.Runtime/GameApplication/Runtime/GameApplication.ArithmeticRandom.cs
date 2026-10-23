using System.Runtime.CompilerServices;
using System;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Intervals;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Game.Profiles;
using Celeste.Game.Gameplay.Mathematics.Curves;
using Celeste.Everest.Gameplay.Mathematics.Curves;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceScalarEnvironment,
        ISourceVectorEnvironment, ISourceCurveEnvironment, ISourceExtremaEnvironment,
        ISourceEasingEnvironment, ISourceSineWaveEnvironment, ISourceRandomProcessEnvironment,
        ISourceRandomProxyEnvironment, ISourceIntervalEnvironment
    {
        private ISourceScalarArithmetic sourceScalar;
        private ISourceVectorArithmetic sourceVector;
        private ISourceCurveArithmetic sourceCurve;
        private ISourceExtremaArithmetic sourceExtrema;
        private ISourceEasingArithmetic sourceEasing;
        private ISourceSineWaveArithmetic sourceSine;
        private ISourceIntervalArithmetic sourceInterval;
        private SourceRandomProcessState sourceRandom;

        public ISourceScalarArithmetic ScalarArithmetic =>
            sourceScalar ?? throw new InvalidOperationException("Source arithmetic is not constructed.");

        public ISourceVectorArithmetic VectorArithmetic =>
            sourceVector ?? throw new InvalidOperationException("Source arithmetic is not constructed.");

        public ISourceCurveArithmetic CurveArithmetic =>
            sourceCurve ?? throw new InvalidOperationException("Source arithmetic is not constructed.");

        public ISourceExtremaArithmetic ExtremaArithmetic
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => sourceExtrema ?? throw new InvalidOperationException("Source arithmetic is not constructed.");
        }

        public ISourceEasingArithmetic EasingArithmetic =>
            sourceEasing ?? throw new InvalidOperationException("Source arithmetic is not constructed.");

        public ISourceSineWaveArithmetic SineWaveArithmetic =>
            sourceSine ?? throw new InvalidOperationException("Source arithmetic is not constructed.");

        public ISourceIntervalArithmetic IntervalArithmetic
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => sourceInterval ?? throw new InvalidOperationException("Source arithmetic is not constructed.");
        }

        public SourceRandomProcessState RandomProcess => sourceRandom ??
                                                         throw new InvalidOperationException(
                                                             "The source random process is not constructed.");

        public ISourceRandom Random => RandomProcess.Random;
        public ISourceRandom RandomProxy => RandomProcess.Proxy;

        public void ConstructSourceArithmetic()
        {
            if (sourceScalar != null) throw new InvalidOperationException("Source arithmetic is already constructed.");
            bool original = SourceProfile == GameProfile.Original;
            sourceScalar = original
                ? (ISourceScalarArithmetic)new OriginalScalarArithmetic()
                : new InstalledScalarArithmetic();
            sourceVector = original
                ? (ISourceVectorArithmetic)OriginalVectorArithmetic.Shared
                : InstalledVectorArithmetic.Shared;
            sourceCurve = original
                ? (ISourceCurveArithmetic)new OriginalCurveArithmetic()
                : new EverestCurveArithmetic();
            sourceExtrema = original
                ? (ISourceExtremaArithmetic)new FrameworkExtremaArithmetic()
                : new SignedZeroExtremaArithmetic();
            sourceEasing = original
                ? (ISourceEasingArithmetic)new OriginalEasingArithmetic()
                : new InstalledEasingArithmetic();
            sourceInterval = original
                ? (ISourceIntervalArithmetic)SingleIntervalArithmetic.Shared
                : DoubleIntervalArithmetic.Shared;
            sourceSine = original
                ? (ISourceSineWaveArithmetic)new OriginalSineWaveArithmetic()
                : new InstalledSineWaveArithmetic();
        }

        public void ConstructSourceRandomProcess()
        {
            if (sourceRandom != null)
                throw new InvalidOperationException("The source random process is already constructed.");
            ISourceRandomFactory factory = SourceProfile == GameProfile.Original
                ? (ISourceRandomFactory)new Celeste.Game.Execution.Randomness.OriginalRandomFactory(PhysicalIO
                    .RandomSeeds)
                : new Celeste.Everest.Runtime.Randomness.InstalledRandomFactory(PhysicalIO.RandomSeeds);
            sourceRandom = new SourceRandomProcessState(factory);
        }
    }
}
