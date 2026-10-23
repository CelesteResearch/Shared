using Celeste.Input.Runtime;
using System;
using Celeste.Audio.Framework;
using Celeste.Audio.IO;
using Celeste.Core.Diagnostics;
using Celeste.Core.Framework.Time;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceFnaInputEnvironment,
        ISourceAudioEnvironment, ISourceTheoraEnvironment, ISourceFnaLoggingEnvironment, ISourceTimeSpanEnvironment
    {
        private SourceFnaInputProcess sourceFnaInput;
        private SourceAudioMediaDispatchState sourceAudioMedia;
        private SourceFnaLoggerProcess sourceFnaLogger;
        private ISourceTimeSpanPolicy sourceTimeSpans;

        public SourceFnaInputProcess FnaInput => sourceFnaInput ??
                                                 throw new InvalidOperationException(
                                                     "The actual FNA input process is not constructed.");

        public SourceAudioMediaDispatchState AudioMedia => sourceAudioMedia ??
                                                           throw new InvalidOperationException(
                                                               "The actual framework audio/media process is not constructed.");

        public SourceFnaLoggerProcess FnaLogger => sourceFnaLogger ??
                                                   throw new InvalidOperationException(
                                                       "The actual FNA logger is not constructed.");

        public ISourceTheoraIO TheoraIO => PhysicalIO.Theora;

        public ISourceTimeSpanPolicy TimeSpans => sourceTimeSpans ??
                                                  throw new InvalidOperationException(
                                                      "The selected source TimeSpan policy is not constructed.");

        public void ConstructSourceFrameworkProcesses()
        {
            if (sourceFnaInput != null)
                throw new InvalidOperationException("The actual framework processes are already constructed.");
            sourceTimeSpans = SourceProfile == GameProfile.Original
                ? (ISourceTimeSpanPolicy)new FrameworkTimeSpanPolicy(PhysicalIO.TimeResources)
                : new NetCoreifierTimeSpanPolicy();
            sourceFnaInput =
                new SourceFnaInputProcess(PhysicalIO.MouseTouch, PhysicalIO.InputClock, VectorArithmetic,
                    PhysicalIO.MouseTouch is not Celeste.Input.Devices.Mouse.ISourceGlobalMouseCapabilities capabilities
                    || capabilities.SupportsGlobalMouse);
            sourceAudioMedia = new SourceAudioMediaDispatchState(PhysicalIO.FrameworkAudioFactory.Create(this),
                PhysicalIO.Microphones, sourceTimeSpans);
        }

        private void DisposeSourceFrameworkAudio(object sender, EventArgs args)
        {
            sourceAudioMedia.Audio.Dispose();
        }

        public void ConstructSourceFnaLogging()
        {
            if (sourceFnaLogger != null)
                throw new InvalidOperationException("The actual FNA logger is already constructed.");
            sourceFnaLogger = new SourceFnaLoggerProcess(GraphicsIO as ISourceFnaLoggingDevice);
        }

        public void InitializeSourceFnaLogging()
        {
            FnaLogger.Initialize();
            FnaLogger.HookFna3D();
        }
    }
}
