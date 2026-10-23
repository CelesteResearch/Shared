using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Interop
{
    public static class SourceFAudioLayout
    {
        [Flags]
        public enum FAudioDeviceRole
        {
            FAudioNotDefaultDevice = 0,
            FAudioDefaultConsoleDevice = 1,
            FAudioDefaultMultimediaDevice = 2,
            FAudioDefaultCommunicationsDevice = 4,
            FAudioDefaultGameDevice = 8,
            FAudioGlobalDefaultDevice = 0xF,
            FAudioInvalidDeviceRole = -16,
        }

        public enum FAudioFilterType
        {
            FAudioLowPassFilter,
            FAudioBandPassFilter,
            FAudioHighPassFilter,
            FAudioNotchFilter,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioGUID
        {
            public uint Data1;

            public ushort Data2;

            public ushort Data3;

            public unsafe fixed byte Data4[8];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioWaveFormatEx
        {
            public ushort wFormatTag;

            public ushort nChannels;

            public uint nSamplesPerSec;

            public uint nAvgBytesPerSec;

            public ushort nBlockAlign;

            public ushort wBitsPerSample;

            public ushort cbSize;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioWaveFormatExtensible
        {
            public FAudioWaveFormatEx Format;

            public ushort Samples;

            public uint dwChannelMask;

            public FAudioGUID SubFormat;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioADPCMCoefSet
        {
            public short iCoef1;

            public short iCoef2;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioADPCMWaveFormat
        {
            public FAudioWaveFormatEx wfx;

            public ushort wSamplesPerBlock;

            public ushort wNumCoef;

            public IntPtr aCoef;
        }

        public struct FAudioXMA2WaveFormatEx
        {
            public FAudioWaveFormatEx wfx;

            public ushort wNumStreams;

            public uint dwChannelMask;

            public uint dwSamplesEncoded;

            public uint dwBytesPerBlock;

            public uint dwPlayBegin;

            public uint dwPlayLength;

            public uint dwLoopBegin;

            public uint dwLoopLength;

            public byte bLoopCount;

            public byte bEncoderVersion;

            public ushort wBlockCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioDeviceDetails
        {
            public unsafe fixed short DeviceID[256];

            public unsafe fixed short DisplayName[256];

            public FAudioDeviceRole Role;

            public FAudioWaveFormatExtensible OutputFormat;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioVoiceDetails
        {
            public uint CreationFlags;

            public uint ActiveFlags;

            public uint InputChannels;

            public uint InputSampleRate;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioSendDescriptor
        {
            public uint Flags;

            public IntPtr pOutputVoice;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioVoiceSends
        {
            public uint SendCount;

            public IntPtr pSends;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioEffectDescriptor
        {
            public IntPtr pEffect;

            public int InitialState;

            public uint OutputChannels;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioEffectChain
        {
            public uint EffectCount;

            public IntPtr pEffectDescriptors;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioFilterParameters
        {
            public FAudioFilterType Type;

            public float Frequency;

            public float OneOverQ;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioBuffer
        {
            public uint Flags;

            public uint AudioBytes;

            public IntPtr pAudioData;

            public uint PlayBegin;

            public uint PlayLength;

            public uint LoopBegin;

            public uint LoopLength;

            public uint LoopCount;

            public IntPtr pContext;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioBufferWMA
        {
            public IntPtr pDecodedPacketCumulativeBytes;

            public uint PacketCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioVoiceState
        {
            public IntPtr pCurrentBufferContext;

            public uint BuffersQueued;

            public ulong SamplesPlayed;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioPerformanceData
        {
            public ulong AudioCyclesSinceLastQuery;

            public ulong TotalCyclesSinceLastQuery;

            public uint MinimumCyclesPerQuantum;

            public uint MaximumCyclesPerQuantum;

            public uint MemoryUsageInBytes;

            public uint CurrentLatencyInSamples;

            public uint GlitchesSinceEngineStarted;

            public uint ActiveSourceVoiceCount;

            public uint TotalSourceVoiceCount;

            public uint ActiveSubmixVoiceCount;

            public uint ActiveResamplerCount;

            public uint ActiveMatrixMixCount;

            public uint ActiveXmaSourceVoices;

            public uint ActiveXmaStreams;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FAudioDebugConfiguration
        {
            public uint TraceMask;

            public uint BreakMask;

            public int LogThreadID;

            public int LogFileline;

            public int LogFunctionName;

            public int LogTiming;
        }

        public struct FAudioEngineCallback
        {
            public IntPtr OnCriticalError;

            public IntPtr OnProcessingPassEnd;

            public IntPtr OnProcessingPassStart;
        }

        public struct FAudioVoiceCallback
        {
            public IntPtr OnBufferEnd;

            public IntPtr OnBufferStart;

            public IntPtr OnLoopEnd;

            public IntPtr OnStreamEnd;

            public IntPtr OnVoiceError;

            public IntPtr OnVoiceProcessingPassEnd;

            public IntPtr OnVoiceProcessingPassStart;
        }

        public struct FAudioFXReverbParameters
        {
            public float WetDryMix;

            public uint ReflectionsDelay;

            public byte ReverbDelay;

            public byte RearDelay;

            public byte PositionLeft;

            public byte PositionRight;

            public byte PositionMatrixLeft;

            public byte PositionMatrixRight;

            public byte EarlyDiffusion;

            public byte LateDiffusion;

            public byte LowEQGain;

            public byte LowEQCutoff;

            public byte HighEQGain;

            public byte HighEQCutoff;

            public float RoomFilterFreq;

            public float RoomFilterMain;

            public float RoomFilterHF;

            public float ReflectionsGain;

            public float ReverbGain;

            public float DecayTime;

            public float Density;

            public float RoomSize;
        }

        public struct FAudioFXReverbParameters9
        {
            public float WetDryMix;

            public uint ReflectionsDelay;

            public byte ReverbDelay;

            public byte RearDelay;

            public byte SideDelay;

            public byte PositionLeft;

            public byte PositionRight;

            public byte PositionMatrixLeft;

            public byte PositionMatrixRight;

            public byte EarlyDiffusion;

            public byte LateDiffusion;

            public byte LowEQGain;

            public byte LowEQCutoff;

            public byte HighEQGain;

            public byte HighEQCutoff;

            public float RoomFilterFreq;

            public float RoomFilterMain;

            public float RoomFilterHF;

            public float ReflectionsGain;

            public float ReverbGain;

            public float DecayTime;

            public float Density;

            public float RoomSize;
        }

        public enum FACTWaveBankSegIdx
        {
            FACT_WAVEBANK_SEGIDX_BANKDATA,

            FACT_WAVEBANK_SEGIDX_ENTRYMETADATA,

            FACT_WAVEBANK_SEGIDX_SEEKTABLES,

            FACT_WAVEBANK_SEGIDX_ENTRYNAMES,

            FACT_WAVEBANK_SEGIDX_ENTRYWAVEDATA,

            FACT_WAVEBANK_SEGIDX_COUNT,
        }

        public struct FACTRendererDetails
        {
            public unsafe fixed short rendererID[255];

            public unsafe fixed short displayName[255];

            public int defaultDevice;
        }

        public struct FACTOverlapped
        {
            public IntPtr Internal;

            public IntPtr InternalHigh;

            public uint Offset;

            public uint OffsetHigh;

            public IntPtr hEvent;
        }

        public struct FACTFileIOCallbacks
        {
            public IntPtr readFileCallback;

            public IntPtr getOverlappedResultCallback;
        }

        public struct FACTRuntimeParameters
        {
            public uint lookAheadTime;

            public IntPtr pGlobalSettingsBuffer;

            public uint globalSettingsBufferSize;

            public uint globalSettingsFlags;

            public uint globalSettingsAllocAttributes;

            public FACTFileIOCallbacks fileIOCallbacks;

            public IntPtr fnNotificationCallback;

            public IntPtr pRendererID;

            public IntPtr pXAudio2;

            public IntPtr pMasteringVoice;
        }

        public struct FACTStreamingParameters
        {
            public IntPtr file;

            public uint offset;

            public uint flags;

            public ushort packetSize;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTWaveBankRegion
        {
            public uint dwOffset;

            public uint dwLength;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTWaveBankSampleRegion
        {
            public uint dwStartSample;

            public uint dwTotalSamples;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTWaveBankMiniWaveFormat
        {
            public uint dwValue;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTWaveBankEntry
        {
            public uint dwFlagsAndDuration;

            public FACTWaveBankMiniWaveFormat Format;

            public FACTWaveBankRegion PlayRegion;

            public FACTWaveBankSampleRegion LoopRegion;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTWaveBankData
        {
            public uint dwFlags;

            public uint dwEntryCount;

            public unsafe fixed char szBankName[64];

            public uint dwEntryMetaDataElementSize;

            public uint dwEntryNameElementSize;

            public uint dwAlignment;

            public FACTWaveBankMiniWaveFormat CompactFormat;

            public ulong BuildTime;
        }

        public struct FACTWaveProperties
        {
            public unsafe fixed byte friendlyName[64];

            public FACTWaveBankMiniWaveFormat format;

            public uint durationInSamples;

            public FACTWaveBankSampleRegion loopRegion;

            public int streaming;
        }

        public struct FACTWaveInstanceProperties
        {
            public FACTWaveProperties properties;

            public int backgroundMusic;
        }

        public struct FACTCueProperties
        {
            public unsafe fixed char friendlyName[255];

            public int interactive;

            public ushort iaVariableIndex;

            public ushort numVariations;

            public byte maxInstances;

            public byte currentInstances;
        }

        public struct FACTTrackProperties
        {
            public uint duration;

            public ushort numVariations;

            public byte numChannels;

            public ushort waveVariation;

            public byte loopCount;
        }

        public struct FACTVariationProperties
        {
            public ushort index;

            public byte weight;

            public float iaVariableMin;

            public float iaVariableMax;

            public int linger;
        }

        public struct FACTSoundProperties
        {
            public ushort category;

            public byte priority;

            public short pitch;

            public float volume;

            public ushort numTracks;

            public FACTTrackProperties arrTrackProperties;
        }

        public struct FACTSoundVariationProperties
        {
            public FACTVariationProperties variationProperties;

            public FACTSoundProperties soundProperties;
        }

        public struct FACTCueInstanceProperties
        {
            public uint allocAttributes;

            public FACTCueProperties cueProperties;

            public FACTSoundVariationProperties activeVariationProperties;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTNotificationDescription
        {
            public byte type;

            public byte flags;

            public IntPtr pSoundBank;

            public IntPtr pWaveBank;

            public IntPtr pCue;

            public IntPtr pWave;

            public ushort cueIndex;

            public ushort waveIndex;

            public IntPtr pvContext;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTNotificationCue
        {
            public ushort cueIndex;

            public IntPtr pSoundBank;

            public IntPtr pCue;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTNotificationMarker
        {
            public ushort cueIndex;

            public IntPtr pSoundBank;

            public IntPtr pCue;

            public uint marker;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTNotificationSoundBank
        {
            public IntPtr pSoundBank;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTNotificationWaveBank
        {
            public IntPtr pWaveBank;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTNotificationVariable
        {
            public ushort cueIndex;

            public IntPtr pSoundBank;

            public IntPtr pCue;

            public ushort variableIndex;

            public float variableValue;

            public int local;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTNotificationGUI
        {
            public uint reserved;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTNotificationWave
        {
            public IntPtr pWaveBank;

            public ushort waveIndex;

            public ushort cueIndex;

            public IntPtr pSoundBank;

            public IntPtr pCue;

            public IntPtr pWave;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct FACTNotification_union
        {
            [FieldOffset(0)] public FACTNotificationCue cue;

            [FieldOffset(0)] public FACTNotificationMarker marker;

            [FieldOffset(0)] public FACTNotificationSoundBank soundBank;

            [FieldOffset(0)] public FACTNotificationWaveBank waveBank;

            [FieldOffset(0)] public FACTNotificationVariable variable;

            [FieldOffset(0)] public FACTNotificationGUI gui;

            [FieldOffset(0)] public FACTNotificationWave wave;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FACTNotification
        {
            public byte type;

            public int timeStamp;

            public IntPtr pvContext;

            public FACTNotification_union anon;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct F3DAUDIO_VECTOR
        {
            public float x;

            public float y;

            public float z;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct F3DAUDIO_DISTANCE_CURVE_POINT
        {
            public float Distance;

            public float DSPSetting;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct F3DAUDIO_DISTANCE_CURVE
        {
            private IntPtr pPoints;

            public uint PointCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct F3DAUDIO_CONE
        {
            public float InnerAngle;

            public float OuterAngle;

            public float InnerVolume;

            public float OuterVolume;

            public float InnerLPF;

            public float OuterLPF;

            public float InnerReverb;

            public float OuterReverb;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct F3DAUDIO_LISTENER
        {
            public F3DAUDIO_VECTOR OrientFront;

            public F3DAUDIO_VECTOR OrientTop;

            public F3DAUDIO_VECTOR Position;

            public F3DAUDIO_VECTOR Velocity;

            public IntPtr pCone;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct F3DAUDIO_EMITTER
        {
            public IntPtr pCone;

            public F3DAUDIO_VECTOR OrientFront;

            public F3DAUDIO_VECTOR OrientTop;

            public F3DAUDIO_VECTOR Position;

            public F3DAUDIO_VECTOR Velocity;

            public float InnerRadius;

            public float InnerRadiusAngle;

            public uint ChannelCount;

            public float ChannelRadius;

            public IntPtr pChannelAzimuths;

            public IntPtr pVolumeCurve;

            public IntPtr pLFECurve;

            public IntPtr pLPFDirectCurve;

            public IntPtr pLPFReverbCurve;

            public IntPtr pReverbCurve;

            public float CurveDistanceScaler;

            public float DopplerScaler;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct F3DAUDIO_DSP_SETTINGS
        {
            public IntPtr pMatrixCoefficients;

            public IntPtr pDelayTimes;

            public uint SrcChannelCount;

            public uint DstChannelCount;

            public float LPFDirectCoefficient;

            public float LPFReverbCoefficient;

            public float ReverbLevel;

            public float DopplerFactor;

            public float EmitterToListenerAngle;

            public float EmitterToListenerDistance;

            public float EmitterVelocityComponent;

            public float ListenerVelocityComponent;
        }

        public struct FAudioIOStream
        {
            public IntPtr data;

            public IntPtr read;

            public IntPtr seek;

            public IntPtr close;

            public IntPtr ioLock;
        }

        public struct stb_vorbis_alloc
        {
            public IntPtr alloc_buffer;

            public int alloc_buffer_length_in_bytes;
        }

        public struct stb_vorbis_info
        {
            public uint sample_rate;

            public int channels;

            public uint setup_memory_required;

            public uint setup_temp_memory_required;

            public uint temp_memory_required;

            public int max_frame_size;
        }

        public struct stb_vorbis_comment
        {
            public IntPtr vendor;

            public int comment_list_length;

            public IntPtr comment_list;
        }
    }
}
