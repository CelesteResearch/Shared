using System;
using System.Runtime.InteropServices;
using System.Text;
using Celeste.Audio.Interop;
using Celeste.Audio.IO;

namespace Celeste.Platform.Native.Audio.Capture
{
    public sealed unsafe class NativeSourceMicrophoneIO : ISourceMicrophoneIO
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_InitSubSystem(uint flags);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_GetNumAudioDevices(int isCapture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetAudioDeviceName(int index, int isCapture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern uint SDL_OpenAudioDevice(byte* device, int isCapture, ref SourceCaptureAudioSpec desired,
            out SourceCaptureAudioSpec obtained, int allowedChanges);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern uint SDL_DequeueAudio(uint device, IntPtr buffer, uint count);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern uint SDL_GetQueuedAudioSize(uint device);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_PauseAudioDevice(uint device, int paused);

        public int InitializeCaptureAudio()
        {
            return SDL_InitSubSystem(16u);
        }

        public int GetNumAudioDevices(int isCapture)
        {
            return SDL_GetNumAudioDevices(isCapture);
        }

        public string GetAudioDeviceName(int index, int isCapture)
        {
            var pointer = SDL_GetAudioDeviceName(index, isCapture);
            if (pointer == IntPtr.Zero) return null;
            var count = 0;
            while (Marshal.ReadByte(pointer, count) != 0) count++;
            return Encoding.UTF8.GetString((byte*)pointer, count);
        }

        public uint OpenAudioDevice(string device, int isCapture, ref SourceCaptureAudioSpec desired,
            out SourceCaptureAudioSpec obtained, int allowedChanges)
        {
            var size = device == null ? 0 : device.Length * 4 + 1;
            var buffer = stackalloc byte[size];
            if (device == null) return SDL_OpenAudioDevice(null, isCapture, ref desired, out obtained, allowedChanges);
            fixed (char* chars = device)
            {
                Encoding.UTF8.GetBytes(chars, device.Length + 1, buffer, size);
            }

            return SDL_OpenAudioDevice(buffer, isCapture, ref desired, out obtained, allowedChanges);
        }

        public int GetMicrophoneSamples(uint handle, byte[] buffer, int offset, int count)
        {
            fixed (byte* pointer = &buffer[offset])
            {
                return (int)SDL_DequeueAudio(handle, (IntPtr)pointer, (uint)count);
            }
        }

        public void StartMicrophone(uint handle)
        {
            SDL_PauseAudioDevice(handle, 0);
        }

        public void StopMicrophone(uint handle)
        {
            SDL_PauseAudioDevice(handle, 1);
        }

        public int GetMicrophoneQueuedBytes(uint handle)
        {
            return (int)SDL_GetQueuedAudioSize(handle);
        }
    }
}
