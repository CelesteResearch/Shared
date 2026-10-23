using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Celeste.Audio.Fmod.Capture
{
    // Master-mixer tap and frame barrier from TAS Recorder AudioCapture. The mixer never
    // advances unrecorded blocks while a frame is being encoded or the engine is paused.
    public sealed class FmodAudioCapture : IDisposable
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate global::Celeste.Audio.Fmod.Interop.FmodResult ReadCallback(IntPtr state, IntPtr input,
            IntPtr output,
            uint samples,
            int inputChannels, ref int outputChannels);

        private readonly object gate = new object();
        private readonly ReadCallback read;
        private readonly Action<float[], int, int> receive;
        private IntPtr group, dsp;
        private bool recording, pending, disposed, synchronizeFrames;
        private int target, captured, error, ignored = 5;
        private Exception failure;
        public int SampleRate { get; }
        public int Channels { get; }

        internal FmodAudioCapture(IntPtr system, Action<float[], int, int> receive)
        {
            this.receive = receive ?? throw new ArgumentNullException(nameof(receive));
            Check(
                global::Celeste.Audio.Fmod.Interop.CaptureNative.SoftwareFormat(system, out int rate,
                    out int speakerMode,
                    out int rawChannels),
                "getSoftwareFormat");
            SampleRate = rate;
            // FMOD_SPEAKERMODE: DEFAULT, RAW, MONO, STEREO, QUAD, SURROUND, 5POINT1, 7POINT1.
            Channels = speakerMode == 1 ? rawChannels :
                speakerMode == 2 ? 1 :
                speakerMode == 4 ? 4 :
                speakerMode == 5 ? 5 :
                speakerMode == 6 ? 6 :
                speakerMode == 7 ? 8 : 2;
            Check(global::Celeste.Audio.Fmod.Interop.CaptureNative.MasterGroup(system, out group),
                "getMasterChannelGroup");
            read = Read;
            var description = new global::Celeste.Audio.Fmod.Interop.CaptureNative.Description
            {
                Name = new byte[32], Version = 65536, Inputs = 1, Outputs = 1,
                Read = Marshal.GetFunctionPointerForDelegate(read)
            };
            Check(global::Celeste.Audio.Fmod.Interop.CaptureNative.Create(system, ref description, out dsp),
                "createDSP");
            try
            {
                Check(global::Celeste.Audio.Fmod.Interop.CaptureNative.Bypass(dsp, 1), "setBypass");
                Check(global::Celeste.Audio.Fmod.Interop.CaptureNative.Add(group, 0, dsp), "addDSP");
            }
            catch
            {
                global::Celeste.Audio.Fmod.Interop.CaptureNative.Release(dsp);
                dsp = IntPtr.Zero;
                throw;
            }
        }

        public void Start(bool synchronizeFrames = true)
        {
            lock (gate)
            {
                if (disposed)
                    throw new ObjectDisposedException(nameof(global::Celeste.Audio.Fmod.Capture.FmodAudioCapture));
                this.synchronizeFrames = synchronizeFrames;
                captured = error = 0;
                ignored = 5;
                pending = false;
                recording = true;
            }

            Check(global::Celeste.Audio.Fmod.Interop.CaptureNative.Bypass(dsp, 0), "setBypass");
        }

        // Called once at the beginning of every recorded engine/render frame, not per wall tick.
        public void BeginFrame(int framesPerSecond)
        {
            if (framesPerSecond < 1) throw new ArgumentOutOfRangeException(nameof(framesPerSecond));
            lock (gate)
            {
                while (recording && pending && failure == null) Monitor.Wait(gate);
                if (failure != null) throw new InvalidOperationException("FMOD recording callback failed.", failure);
                if (!recording) return;
                // The reference uses 48000 / FPS even when FMOD has another output format.
                target = 48000 / framesPerSecond;
                if (error >= target)
                {
                    error -= target;
                    return;
                }

                captured = 0;
                pending = true;
                Monitor.PulseAll(gate);
            }
        }

        public void Stop()
        {
            lock (gate)
            {
                recording = false;
                pending = false;
                Monitor.PulseAll(gate);
            }

            if (dsp != IntPtr.Zero) Check(global::Celeste.Audio.Fmod.Interop.CaptureNative.Bypass(dsp, 1), "setBypass");
        }

        private global::Celeste.Audio.Fmod.Interop.FmodResult Read(IntPtr state, IntPtr input, IntPtr output,
            uint sampleCount, int inputChannels,
            ref int outputChannels)
        {
            try
            {
                int samples = checked((int)sampleCount);
                var pcm = new float[checked(samples * inputChannels)];
                Marshal.Copy(input, pcm, 0, pcm.Length);
                if (inputChannels == outputChannels) Marshal.Copy(pcm, 0, output, pcm.Length);
                else
                {
                    var passed = new float[checked(samples * outputChannels)];
                    for (int s = 0; s < samples; s++)
                    for (int c = 0; c < outputChannels; c++)
                        passed[s * outputChannels + c] = inputChannels == 0
                            ? 0
                            : pcm[s * inputChannels + Math.Min(c, inputChannels - 1)];
                    Marshal.Copy(passed, 0, output, passed.Length);
                }

                lock (gate)
                {
                    while (recording && synchronizeFrames && !pending) Monitor.Wait(gate);
                    if (!recording) return 0;
                    if (ignored > 0)
                    {
                        Array.Clear(pcm, 0, pcm.Length);
                        ignored--;
                    }

                    receive(pcm, samples, inputChannels);
                    captured += samples;
                    if (synchronizeFrames && captured >= target)
                    {
                        error += captured - target;
                        captured = 0;
                        pending = false;
                        Monitor.PulseAll(gate);
                    }
                }
            }
            catch (Exception ex)
            {
                lock (gate)
                {
                    failure = ex;
                    recording = false;
                    pending = false;
                    Monitor.PulseAll(gate);
                }
            }

            return 0;
        }

        public void Dispose()
        {
            if (disposed) return;
            Stop();
            disposed = true;
            if (dsp != IntPtr.Zero)
            {
                global::Celeste.Audio.Fmod.Interop.CaptureNative.Remove(group, dsp);
                global::Celeste.Audio.Fmod.Interop.CaptureNative.Release(dsp);
                dsp = IntPtr.Zero;
            }

            GC.KeepAlive(read);
        }

        private static void Check(global::Celeste.Audio.Fmod.Interop.FmodResult result, string operation)
        {
            if (result != 0) throw new global::Celeste.Audio.Fmod.Interop.FmodException(result, operation);
        }
    }
}
