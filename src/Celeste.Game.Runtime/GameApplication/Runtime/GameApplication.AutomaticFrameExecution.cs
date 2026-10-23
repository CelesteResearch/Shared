using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Game.Execution.Engine.Timing;
using Celeste.Game.Diagnostics.Speedrun;
using Celeste.Game.Profiles;
using Celeste.Framework.Diagnostics.Commands;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
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
                : Celeste.Everest.Runtime.Engine.Timing.EverestEngineTimeRatePolicy.Instance;
            sourceEngineFrame = new OriginalEngineFrame(Frame, this, this,
                ((ISourceCommandsProcessEnvironment)this).Commands, this, timeRate,
                ActualGame.Framework, ActualGame.GameLoop, ExtremaArithmetic, this);
            sourceAutoSplitter = new OriginalAutoSplitterInfo(Frame.Scenes, SaveContext, SaveCounters);
            sourceCelesteUpdate = new OriginalCelesteUpdate(sourceEngineFrame, this,
                UserIO, sourceAutoSplitter, AudioSession, InputSource);
            ConstructSourceEngineDraw();
            ActualGame.BindSourceFrameExecution(sourceCelesteUpdate, EngineDraw, this);
        }
    }
}
