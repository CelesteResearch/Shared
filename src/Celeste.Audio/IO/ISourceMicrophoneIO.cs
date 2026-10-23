using Celeste.Audio.Interop;

namespace Celeste.Audio.IO
{
    public interface ISourceMicrophoneIO
    {
        int InitializeCaptureAudio();
        int GetNumAudioDevices(int isCapture);
        string GetAudioDeviceName(int index, int isCapture);

        uint OpenAudioDevice(string device, int isCapture, ref SourceCaptureAudioSpec desired,
            out SourceCaptureAudioSpec obtained, int allowedChanges);

        int GetMicrophoneSamples(uint handle, byte[] buffer, int offset, int count);
        void StartMicrophone(uint handle);
        void StopMicrophone(uint handle);
        int GetMicrophoneQueuedBytes(uint handle);
    }
}
