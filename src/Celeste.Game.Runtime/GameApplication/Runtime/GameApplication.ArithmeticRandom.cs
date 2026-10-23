using System;
using System.Runtime.CompilerServices;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Intervals;
using Celeste.Core.Randomness;
using Celeste.Everest.Gameplay.Mathematics.Curves;
using Celeste.Everest.Runtime.Randomness;
using Celeste.Game.Execution.Randomness;
using Celeste.Game.Gameplay.Mathematics.Curves;
using Celeste.Game.Profiles;

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
            var original = SourceProfile == GameProfile.Original;
            sourceScalar = original
                ? new OriginalScalarArithmetic()
                : new InstalledScalarArithmetic();
            sourceVector = original
                ? OriginalVectorArithmetic.Shared
                : InstalledVectorArithmetic.Shared;
            sourceCurve = original
                ? new OriginalCurveArithmetic()
                : new EverestCurveArithmetic();
            sourceExtrema = original
                ? new FrameworkExtremaArithmetic()
                : new SignedZeroExtremaArithmetic();
            sourceEasing = original
                ? new OriginalEasingArithmetic()
                : new InstalledEasingArithmetic();
            sourceInterval = original
                ? SingleIntervalArithmetic.Shared
                : DoubleIntervalArithmetic.Shared;
            sourceSine = original
                ? new OriginalSineWaveArithmetic()
                : new InstalledSineWaveArithmetic();
        }

        public void ConstructSourceRandomProcess()
        {
            if (sourceRandom != null)
                throw new InvalidOperationException("The source random process is already constructed.");
            var factory = SourceProfile == GameProfile.Original
                ? (ISourceRandomFactory)new OriginalRandomFactory(PhysicalIO
                    .RandomSeeds)
                : new InstalledRandomFactory(PhysicalIO.RandomSeeds);
            sourceRandom = new(factory);
        }
    }
}
