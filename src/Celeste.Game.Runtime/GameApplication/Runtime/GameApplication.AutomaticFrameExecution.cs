using System;
using Celeste.Everest.Runtime.Engine.Timing;
using Celeste.Game.Diagnostics.Speedrun;
using Celeste.Game.Execution.Engine.Timing;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalEngineUpdateEnvironment
    {
        private OriginalEngineFrame sourceEngineFrame;
        private OriginalCelesteUpdate sourceCelesteUpdate;
        private OriginalAutoSplitterInfo sourceAutoSplitter;

        public OriginalEngineFrame SourceEngineFrame => sourceEngineFrame ??
                                                        throw new InvalidOperationException(
                                                            "The actual Engine update is not constructed.");

        public OriginalAutoSplitterInfo AutoSplitter => sourceAutoSplitter ??
                                                        throw new InvalidOperationException(
                                                            "The actual AutoSplitter source process is not constructed.");

        internal void BindSourceEngineFrameAndDraw()
        {
            if (sourceEngineFrame != null)
                throw new InvalidOperationException("The actual source frame execution is already bound.");
            IOriginalEngineTimeRatePolicy timeRate = SourceProfile == GameProfile.Original
                ? OriginalVanillaEngineTimeRatePolicy.Instance
                : EverestEngineTimeRatePolicy.Instance;
            sourceEngineFrame = new(Frame, this, this,
                Commands, this, timeRate,
                ActualGame.Framework, ActualGame.GameLoop, ExtremaArithmetic, this);
            sourceAutoSplitter = new(Frame.Scenes, SaveContext, SaveCounters);
            sourceCelesteUpdate = new(sourceEngineFrame, this,
                UserIO, sourceAutoSplitter, AudioSession, InputSource);
            ConstructSourceEngineDraw();
            ActualGame.BindSourceFrameExecution(sourceCelesteUpdate, EngineDraw, this);
        }

        OriginalEngineFrame IOriginalEngineUpdateEnvironment.EngineUpdate => SourceEngineFrame;
    }
}
