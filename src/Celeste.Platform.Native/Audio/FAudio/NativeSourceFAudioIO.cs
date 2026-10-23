using System;
using System.Runtime.InteropServices;
using System.Text;
using Celeste.Audio.Interop;
using Celeste.Audio.IO;
using Celeste.Core.Diagnostics;

namespace Celeste.Platform.Native.Audio.FAudio
{
    public sealed unsafe class NativeSourceFAudioIO : ISourceFAudioIO
    {
        private readonly ISourceFnaLoggingEnvironment logging;

        public NativeSourceFAudioIO(ISourceFnaLoggingEnvironment logging)
        {
            this.logging = logging;
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "F3DAudioCalculate")]
        private static extern void Native_F3DAudioCalculate(byte[] Instance,
            ref SourceFAudioLayout.F3DAUDIO_LISTENER pListener, ref SourceFAudioLayout.F3DAUDIO_EMITTER pEmitter,
            uint Flags, ref SourceFAudioLayout.F3DAUDIO_DSP_SETTINGS pDSPSettings);

        public void F3DAudioCalculate(byte[] Instance, ref SourceFAudioLayout.F3DAUDIO_LISTENER pListener,
            ref SourceFAudioLayout.F3DAUDIO_EMITTER pEmitter, uint Flags,
            ref SourceFAudioLayout.F3DAUDIO_DSP_SETTINGS pDSPSettings)
        {
            Native_F3DAudioCalculate(Instance, ref pListener, ref pEmitter, Flags, ref pDSPSettings);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "F3DAudioInitialize")]
        private static extern void Native_F3DAudioInitialize(uint SpeakerChannelMask, float SpeedOfSound,
            byte[] Instance);

        public void F3DAudioInitialize(uint SpeakerChannelMask, float SpeedOfSound, byte[] Instance)
        {
            Native_F3DAudioInitialize(SpeakerChannelMask, SpeedOfSound, Instance);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAPOBase_Release")]
        private static extern uint Native_FAPOBase_Release(IntPtr fapo);

        public uint FAPOBase_Release(IntPtr fapo)
        {
            return Native_FAPOBase_Release(fapo);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioCreate")]
        private static extern uint Native_FAudioCreate(out IntPtr ppFAudio, uint Flags, uint XAudio2Processor);

        public uint FAudioCreate(out IntPtr ppFAudio, uint Flags, uint XAudio2Processor)
        {
            return Native_FAudioCreate(out ppFAudio, Flags, XAudio2Processor);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioCreateReverb")]
        private static extern uint Native_FAudioCreateReverb(out IntPtr ppApo, uint Flags);

        public uint FAudioCreateReverb(out IntPtr ppApo, uint Flags)
        {
            return Native_FAudioCreateReverb(out ppApo, Flags);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioSourceVoice_ExitLoop")]
        private static extern uint Native_FAudioSourceVoice_ExitLoop(IntPtr voice, uint OperationSet);

        public uint FAudioSourceVoice_ExitLoop(IntPtr voice, uint OperationSet)
        {
            return Native_FAudioSourceVoice_ExitLoop(voice, OperationSet);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "FAudioSourceVoice_FlushSourceBuffers")]
        private static extern uint Native_FAudioSourceVoice_FlushSourceBuffers(IntPtr voice);

        public uint FAudioSourceVoice_FlushSourceBuffers(IntPtr voice)
        {
            return Native_FAudioSourceVoice_FlushSourceBuffers(voice);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioSourceVoice_GetState")]
        private static extern void Native_FAudioSourceVoice_GetState(IntPtr voice,
            out SourceFAudioLayout.FAudioVoiceState pVoiceState, uint Flags);

        public void FAudioSourceVoice_GetState(IntPtr voice, out SourceFAudioLayout.FAudioVoiceState pVoiceState,
            uint Flags)
        {
            Native_FAudioSourceVoice_GetState(voice, out pVoiceState, Flags);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "FAudioSourceVoice_SetFrequencyRatio")]
        private static extern uint Native_FAudioSourceVoice_SetFrequencyRatio(IntPtr voice, float Ratio,
            uint OperationSet);

        public uint FAudioSourceVoice_SetFrequencyRatio(IntPtr voice, float Ratio, uint OperationSet)
        {
            return Native_FAudioSourceVoice_SetFrequencyRatio(voice, Ratio, OperationSet);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioSourceVoice_Start")]
        private static extern uint Native_FAudioSourceVoice_Start(IntPtr voice, uint Flags, uint OperationSet);

        public uint FAudioSourceVoice_Start(IntPtr voice, uint Flags, uint OperationSet)
        {
            return Native_FAudioSourceVoice_Start(voice, Flags, OperationSet);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioSourceVoice_Stop")]
        private static extern uint Native_FAudioSourceVoice_Stop(IntPtr voice, uint Flags, uint OperationSet);

        public uint FAudioSourceVoice_Stop(IntPtr voice, uint Flags, uint OperationSet)
        {
            return Native_FAudioSourceVoice_Stop(voice, Flags, OperationSet);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "FAudioSourceVoice_SubmitSourceBuffer")]
        private static extern uint Native_FAudioSourceVoice_SubmitSourceBuffer(IntPtr voice,
            ref SourceFAudioLayout.FAudioBuffer pBuffer, IntPtr pBufferWMA);

        public uint FAudioSourceVoice_SubmitSourceBuffer(IntPtr voice, ref SourceFAudioLayout.FAudioBuffer pBuffer,
            IntPtr pBufferWMA)
        {
            return Native_FAudioSourceVoice_SubmitSourceBuffer(voice, ref pBuffer, pBufferWMA);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "FAudioSourceVoice_SubmitSourceBuffer")]
        private static extern uint Native_FAudioSourceVoice_SubmitSourceBuffer(IntPtr voice,
            ref SourceFAudioLayout.FAudioBuffer pBuffer, ref SourceFAudioLayout.FAudioBufferWMA pBufferWMA);

        public uint FAudioSourceVoice_SubmitSourceBuffer(IntPtr voice, ref SourceFAudioLayout.FAudioBuffer pBuffer,
            ref SourceFAudioLayout.FAudioBufferWMA pBufferWMA)
        {
            return Native_FAudioSourceVoice_SubmitSourceBuffer(voice, ref pBuffer, ref pBufferWMA);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioVoice_DestroyVoice")]
        private static extern void Native_FAudioVoice_DestroyVoice(IntPtr voice);

        public void FAudioVoice_DestroyVoice(IntPtr voice)
        {
            Native_FAudioVoice_DestroyVoice(voice);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioVoice_GetVolume")]
        private static extern void Native_FAudioVoice_GetVolume(IntPtr voice, out float pVolume);

        public void FAudioVoice_GetVolume(IntPtr voice, out float pVolume)
        {
            Native_FAudioVoice_GetVolume(voice, out pVolume);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "FAudioVoice_SetEffectParameters")]
        private static extern uint Native_FAudioVoice_SetEffectParameters(IntPtr voice, uint EffectIndex,
            IntPtr pParameters, uint ParametersByteSize, uint OperationSet);

        public uint FAudioVoice_SetEffectParameters(IntPtr voice, uint EffectIndex, IntPtr pParameters,
            uint ParametersByteSize, uint OperationSet)
        {
            return Native_FAudioVoice_SetEffectParameters(voice, EffectIndex, pParameters, ParametersByteSize,
                OperationSet);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "FAudioVoice_SetFilterParameters")]
        private static extern uint Native_FAudioVoice_SetFilterParameters(IntPtr voice,
            ref SourceFAudioLayout.FAudioFilterParameters pParameters, uint OperationSet);

        public uint FAudioVoice_SetFilterParameters(IntPtr voice,
            ref SourceFAudioLayout.FAudioFilterParameters pParameters, uint OperationSet)
        {
            return Native_FAudioVoice_SetFilterParameters(voice, ref pParameters, OperationSet);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioVoice_SetOutputMatrix")]
        private static extern uint Native_FAudioVoice_SetOutputMatrix(IntPtr voice, IntPtr pDestinationVoice,
            uint SourceChannels, uint DestinationChannels, IntPtr pLevelMatrix, uint OperationSet);

        public uint FAudioVoice_SetOutputMatrix(IntPtr voice, IntPtr pDestinationVoice, uint SourceChannels,
            uint DestinationChannels, IntPtr pLevelMatrix, uint OperationSet)
        {
            return Native_FAudioVoice_SetOutputMatrix(voice, pDestinationVoice, SourceChannels, DestinationChannels,
                pLevelMatrix, OperationSet);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioVoice_SetOutputVoices")]
        private static extern uint Native_FAudioVoice_SetOutputVoices(IntPtr voice,
            ref SourceFAudioLayout.FAudioVoiceSends pSendList);

        public uint FAudioVoice_SetOutputVoices(IntPtr voice, ref SourceFAudioLayout.FAudioVoiceSends pSendList)
        {
            return Native_FAudioVoice_SetOutputVoices(voice, ref pSendList);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudioVoice_SetVolume")]
        private static extern uint Native_FAudioVoice_SetVolume(IntPtr voice, float Volume, uint OperationSet);

        public uint FAudioVoice_SetVolume(IntPtr voice, float Volume, uint OperationSet)
        {
            return Native_FAudioVoice_SetVolume(voice, Volume, OperationSet);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudio_CreateMasteringVoice")]
        private static extern uint Native_FAudio_CreateMasteringVoice(IntPtr audio, out IntPtr ppMasteringVoice,
            uint InputChannels, uint InputSampleRate, uint Flags, uint DeviceIndex, IntPtr pEffectChain);

        public uint FAudio_CreateMasteringVoice(IntPtr audio, out IntPtr ppMasteringVoice, uint InputChannels,
            uint InputSampleRate, uint Flags, uint DeviceIndex, IntPtr pEffectChain)
        {
            return Native_FAudio_CreateMasteringVoice(audio, out ppMasteringVoice, InputChannels, InputSampleRate,
                Flags,
                DeviceIndex, pEffectChain);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudio_CreateSourceVoice")]
        private static extern uint Native_FAudio_CreateSourceVoice(IntPtr audio, out IntPtr ppSourceVoice,
            ref SourceFAudioLayout.FAudioWaveFormatEx pSourceFormat, uint Flags, float MaxFrequencyRatio,
            IntPtr pCallback, IntPtr pSendList, IntPtr pEffectChain);

        public uint FAudio_CreateSourceVoice(IntPtr audio, out IntPtr ppSourceVoice,
            ref SourceFAudioLayout.FAudioWaveFormatEx pSourceFormat, uint Flags, float MaxFrequencyRatio,
            IntPtr pCallback, IntPtr pSendList, IntPtr pEffectChain)
        {
            return Native_FAudio_CreateSourceVoice(audio,
                out ppSourceVoice, ref pSourceFormat, Flags, MaxFrequencyRatio, pCallback, pSendList, pEffectChain);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudio_CreateSourceVoice")]
        private static extern uint Native_FAudio_CreateSourceVoice(IntPtr audio, out IntPtr ppSourceVoice,
            IntPtr pSourceFormat, uint Flags, float MaxFrequencyRatio, IntPtr pCallback, IntPtr pSendList,
            IntPtr pEffectChain);

        public uint FAudio_CreateSourceVoice(IntPtr audio, out IntPtr ppSourceVoice, IntPtr pSourceFormat, uint Flags,
            float MaxFrequencyRatio, IntPtr pCallback, IntPtr pSendList, IntPtr pEffectChain)
        {
            return Native_FAudio_CreateSourceVoice(audio, out ppSourceVoice, pSourceFormat, Flags, MaxFrequencyRatio,
                pCallback, pSendList, pEffectChain);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudio_CreateSubmixVoice")]
        private static extern uint Native_FAudio_CreateSubmixVoice(IntPtr audio, out IntPtr ppSubmixVoice,
            uint InputChannels, uint InputSampleRate, uint Flags, uint ProcessingStage, IntPtr pSendList,
            IntPtr pEffectChain);

        public uint FAudio_CreateSubmixVoice(IntPtr audio, out IntPtr ppSubmixVoice, uint InputChannels,
            uint InputSampleRate, uint Flags, uint ProcessingStage, IntPtr pSendList, IntPtr pEffectChain)
        {
            return Native_FAudio_CreateSubmixVoice(audio, out ppSubmixVoice, InputChannels, InputSampleRate, Flags,
                ProcessingStage, pSendList, pEffectChain);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudio_GetDeviceCount")]
        private static extern uint Native_FAudio_GetDeviceCount(IntPtr audio, out uint pCount);

        public uint FAudio_GetDeviceCount(IntPtr audio, out uint pCount)
        {
            return Native_FAudio_GetDeviceCount(audio, out pCount);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudio_GetDeviceDetails")]
        private static extern uint Native_FAudio_GetDeviceDetails(IntPtr audio, uint Index,
            out SourceFAudioLayout.FAudioDeviceDetails pDeviceDetails);

        public uint FAudio_GetDeviceDetails(IntPtr audio, uint Index,
            out SourceFAudioLayout.FAudioDeviceDetails pDeviceDetails)
        {
            return Native_FAudio_GetDeviceDetails(audio, Index, out pDeviceDetails);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FAudio_Release")]
        private static extern uint Native_FAudio_Release(IntPtr audio);

        public uint FAudio_Release(IntPtr audio)
        {
            return Native_FAudio_Release(audio);
        }

        public IntPtr Malloc(int bytes)
        {
            return Marshal.AllocHGlobal(bytes);
        }

        public void Free(IntPtr memory)
        {
            Marshal.FreeHGlobal(memory);
        }

        public void LogError(string message)
        {
            logging.FnaLogger.LogError(message);
        }

        public void LogWarn(string message)
        {
            logging.FnaLogger.LogWarn(message);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_SetSongVolume")]
        private static extern void Native_XNA_SetSongVolume(float volume);

        public void XNA_SetSongVolume(float volume)
        {
            Native_XNA_SetSongVolume(volume);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_VisualizationEnabled")]
        private static extern uint Native_XNA_VisualizationEnabled();

        public uint XNA_VisualizationEnabled()
        {
            return Native_XNA_VisualizationEnabled();
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_EnableVisualization")]
        private static extern void Native_XNA_EnableVisualization(uint enabled);

        public void XNA_EnableVisualization(uint enabled)
        {
            Native_XNA_EnableVisualization(enabled);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_PauseSong")]
        private static extern void Native_XNA_PauseSong();

        public void XNA_PauseSong()
        {
            Native_XNA_PauseSong();
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_ResumeSong")]
        private static extern void Native_XNA_ResumeSong();

        public void XNA_ResumeSong()
        {
            Native_XNA_ResumeSong();
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_StopSong")]
        private static extern void Native_XNA_StopSong();

        public void XNA_StopSong()
        {
            Native_XNA_StopSong();
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_GetSongVisualizationData")]
        private static extern void
            Native_XNA_GetSongVisualizationData(float[] frequencies, float[] samples, uint count);

        public void XNA_GetSongVisualizationData(float[] frequencies, float[] samples, uint count)
        {
            Native_XNA_GetSongVisualizationData(frequencies, samples, count);
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_GetSongEnded")]
        private static extern uint Native_XNA_GetSongEnded();

        public uint XNA_GetSongEnded()
        {
            return Native_XNA_GetSongEnded();
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_SongQuit")]
        private static extern void Native_XNA_SongQuit();

        public void XNA_SongQuit()
        {
            Native_XNA_SongQuit();
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_SongInit")]
        private static extern void Native_XNA_SongInit();

        public void XNA_SongInit()
        {
            Native_XNA_SongInit();
        }

        [DllImport("FAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "XNA_PlaySong")]
        private static extern float Native_XNA_PlaySong(byte* name);

        public float XNA_PlaySong(string handle)
        {
            var size = handle.Length * 4 + 1;
            var buffer = stackalloc byte[size];
            fixed (char* chars = handle)
            {
                Encoding.UTF8.GetBytes(chars, handle.Length + 1, buffer, size);
            }

            return Native_XNA_PlaySong(buffer);
        }
    }
}
