using System;
using Celeste.Audio.Interop;

namespace Celeste.Audio.IO
{
    public interface ISourceFAudioIO : ISourceMediaPlayerIO
    {
        void F3DAudioCalculate(byte[] Instance, ref SourceFAudioLayout.F3DAUDIO_LISTENER pListener,
            ref SourceFAudioLayout.F3DAUDIO_EMITTER pEmitter, uint Flags,
            ref SourceFAudioLayout.F3DAUDIO_DSP_SETTINGS pDSPSettings);

        void F3DAudioInitialize(uint SpeakerChannelMask, float SpeedOfSound, byte[] Instance);
        uint FAPOBase_Release(IntPtr fapo);
        uint FAudioCreate(out IntPtr ppFAudio, uint Flags, uint XAudio2Processor);
        uint FAudioCreateReverb(out IntPtr ppApo, uint Flags);
        uint FAudioSourceVoice_ExitLoop(IntPtr voice, uint OperationSet);
        uint FAudioSourceVoice_FlushSourceBuffers(IntPtr voice);
        void FAudioSourceVoice_GetState(IntPtr voice, out SourceFAudioLayout.FAudioVoiceState pVoiceState, uint Flags);
        uint FAudioSourceVoice_SetFrequencyRatio(IntPtr voice, float Ratio, uint OperationSet);
        uint FAudioSourceVoice_Start(IntPtr voice, uint Flags, uint OperationSet);
        uint FAudioSourceVoice_Stop(IntPtr voice, uint Flags, uint OperationSet);

        uint FAudioSourceVoice_SubmitSourceBuffer(IntPtr voice, ref SourceFAudioLayout.FAudioBuffer pBuffer,
            IntPtr pBufferWMA);

        uint FAudioSourceVoice_SubmitSourceBuffer(IntPtr voice, ref SourceFAudioLayout.FAudioBuffer pBuffer,
            ref SourceFAudioLayout.FAudioBufferWMA pBufferWMA);

        void FAudioVoice_DestroyVoice(IntPtr voice);
        void FAudioVoice_GetVolume(IntPtr voice, out float pVolume);

        uint FAudioVoice_SetEffectParameters(IntPtr voice, uint EffectIndex, IntPtr pParameters,
            uint ParametersByteSize,
            uint OperationSet);

        uint FAudioVoice_SetFilterParameters(IntPtr voice, ref SourceFAudioLayout.FAudioFilterParameters pParameters,
            uint OperationSet);

        uint FAudioVoice_SetOutputMatrix(IntPtr voice, IntPtr pDestinationVoice, uint SourceChannels,
            uint DestinationChannels, IntPtr pLevelMatrix, uint OperationSet);

        uint FAudioVoice_SetOutputVoices(IntPtr voice, ref SourceFAudioLayout.FAudioVoiceSends pSendList);
        uint FAudioVoice_SetVolume(IntPtr voice, float Volume, uint OperationSet);

        uint FAudio_CreateMasteringVoice(IntPtr audio, out IntPtr ppMasteringVoice, uint InputChannels,
            uint InputSampleRate, uint Flags, uint DeviceIndex, IntPtr pEffectChain);

        uint FAudio_CreateSourceVoice(IntPtr audio, out IntPtr ppSourceVoice,
            ref SourceFAudioLayout.FAudioWaveFormatEx pSourceFormat, uint Flags, float MaxFrequencyRatio,
            IntPtr pCallback,
            IntPtr pSendList, IntPtr pEffectChain);

        uint FAudio_CreateSourceVoice(IntPtr audio, out IntPtr ppSourceVoice, IntPtr pSourceFormat, uint Flags,
            float MaxFrequencyRatio, IntPtr pCallback, IntPtr pSendList, IntPtr pEffectChain);

        uint FAudio_CreateSubmixVoice(IntPtr audio, out IntPtr ppSubmixVoice, uint InputChannels, uint InputSampleRate,
            uint Flags, uint ProcessingStage, IntPtr pSendList, IntPtr pEffectChain);

        uint FAudio_GetDeviceCount(IntPtr audio, out uint pCount);

        uint FAudio_GetDeviceDetails(IntPtr audio, uint Index,
            out SourceFAudioLayout.FAudioDeviceDetails pDeviceDetails);

        uint FAudio_Release(IntPtr audio);
        IntPtr Malloc(int bytes);
        void Free(IntPtr memory);
        void LogError(string message);
        void LogWarn(string message);
    }
}
