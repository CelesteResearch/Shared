using System;
using Celeste.Audio.Interop;

namespace Celeste.Audio.Framework
{
    internal sealed class SourceAudioContext
    {
        private readonly SourceAudioProcess process;
        private Celeste.Audio.IO.ISourceFAudioIO IO => process.IO;

        public readonly IntPtr Handle;

        public readonly byte[] Handle3D;

        public readonly IntPtr MasterVoice;

        public readonly SourceFAudioLayout.FAudioDeviceDetails DeviceDetails;

        public float CurveDistanceScaler;

        public float DopplerScale;

        public float SpeedOfSound;

        public IntPtr ReverbVoice;

        private SourceFAudioLayout.FAudioVoiceSends reverbSends;

        private SourceAudioContext(SourceAudioProcess process, IntPtr ctx, uint devices)
        {
            this.process = process;
            Handle = ctx;
            uint num;
            for (num = 0u; num < devices; num++)
            {
                IO.FAudio_GetDeviceDetails(Handle, num, out DeviceDetails);
                if ((DeviceDetails.Role & SourceFAudioLayout.FAudioDeviceRole.FAudioDefaultGameDevice) ==
                    SourceFAudioLayout.FAudioDeviceRole.FAudioDefaultGameDevice)
                {
                    break;
                }
            }

            if (num == devices)
            {
                num = 0u;
                IO.FAudio_GetDeviceDetails(Handle, num, out DeviceDetails);
            }

            if (IO.FAudio_CreateMasteringVoice(Handle, out MasterVoice, 0u, 0u, 0u, num, IntPtr.Zero) != 0)
            {
                IO.FAudio_Release(ctx);
                Handle = IntPtr.Zero;
                IO.LogError("Failed to create mastering voice!");
                return;
            }

            CurveDistanceScaler = 1f;
            DopplerScale = 1f;
            SpeedOfSound = 343.5f;
            Handle3D = new byte[20];
            IO.F3DAudioInitialize(DeviceDetails.OutputFormat.dwChannelMask, SpeedOfSound, Handle3D);
            process.Context = this;
        }

        public void Dispose()
        {
            if (ReverbVoice != IntPtr.Zero)
            {
                IO.FAudioVoice_DestroyVoice(ReverbVoice);
                ReverbVoice = IntPtr.Zero;
                IO.Free(reverbSends.pSends);
            }

            if (MasterVoice != IntPtr.Zero)
            {
                IO.FAudioVoice_DestroyVoice(MasterVoice);
            }

            if (Handle != IntPtr.Zero)
            {
                IO.FAudio_Release(Handle);
            }

            process.Context = null;
        }

        public unsafe void AttachReverb(IntPtr voice)
        {
            if (ReverbVoice == IntPtr.Zero)
            {
                IO.FAudioCreateReverb(out var ppApo, 0u);
                IntPtr intPtr =
                    IO.Malloc(System.Runtime.InteropServices.Marshal.SizeOf(
                        typeof(SourceFAudioLayout.FAudioEffectChain)));
                SourceFAudioLayout.FAudioEffectChain* ptr = (SourceFAudioLayout.FAudioEffectChain*)(void*)intPtr;
                ptr->EffectCount = 1u;
                ptr->pEffectDescriptors =
                    IO.Malloc(System.Runtime.InteropServices.Marshal.SizeOf(
                        typeof(SourceFAudioLayout.FAudioEffectDescriptor)));
                SourceFAudioLayout.FAudioEffectDescriptor* ptr2 =
                    (SourceFAudioLayout.FAudioEffectDescriptor*)(void*)ptr->pEffectDescriptors;
                ptr2->InitialState = 1;
                ptr2->OutputChannels = ((DeviceDetails.OutputFormat.Format.nChannels != 6) ? 1u : 6u);
                ptr2->pEffect = ppApo;
                IO.FAudio_CreateSubmixVoice(Handle, out ReverbVoice, 1u,
                    DeviceDetails.OutputFormat.Format.nSamplesPerSec,
                    0u, 0u, IntPtr.Zero, intPtr);
                IO.FAPOBase_Release(ppApo);
                IO.Free(ptr->pEffectDescriptors);
                IO.Free(intPtr);
                IntPtr intPtr2 =
                    IO.Malloc(System.Runtime.InteropServices.Marshal.SizeOf(
                        typeof(SourceFAudioLayout.FAudioFXReverbParameters)));
                SourceFAudioLayout.FAudioFXReverbParameters* ptr3 =
                    (SourceFAudioLayout.FAudioFXReverbParameters*)(void*)intPtr2;
                ptr3->WetDryMix = 100f;
                ptr3->ReflectionsDelay = 7u;
                ptr3->ReverbDelay = 11;
                ptr3->RearDelay = 5;
                ptr3->PositionLeft = 6;
                ptr3->PositionRight = 6;
                ptr3->PositionMatrixLeft = 27;
                ptr3->PositionMatrixRight = 27;
                ptr3->EarlyDiffusion = 15;
                ptr3->LateDiffusion = 15;
                ptr3->LowEQGain = 8;
                ptr3->LowEQCutoff = 4;
                ptr3->HighEQGain = 8;
                ptr3->HighEQCutoff = 6;
                ptr3->RoomFilterFreq = 5000f;
                ptr3->RoomFilterMain = -10f;
                ptr3->RoomFilterHF = -1f;
                ptr3->ReflectionsGain = -26.02f;
                ptr3->ReverbGain = 10f;
                ptr3->DecayTime = 1.49f;
                ptr3->Density = 100f;
                ptr3->RoomSize = 100f;
                IO.FAudioVoice_SetEffectParameters(ReverbVoice, 0u, intPtr2,
                    (uint)System.Runtime.InteropServices.Marshal.SizeOf(
                        typeof(SourceFAudioLayout.FAudioFXReverbParameters)), 0u);
                IO.Free(intPtr2);
                reverbSends = default(SourceFAudioLayout.FAudioVoiceSends);
                reverbSends.SendCount = 2u;
                reverbSends.pSends = IO.Malloc(2 *
                                               System.Runtime.InteropServices.Marshal.SizeOf(
                                                   typeof(SourceFAudioLayout.FAudioSendDescriptor)));
                SourceFAudioLayout.FAudioSendDescriptor* ptr4 =
                    (SourceFAudioLayout.FAudioSendDescriptor*)(void*)reverbSends.pSends;
                ptr4->Flags = 0u;
                ptr4->pOutputVoice = MasterVoice;
                ptr4[1].Flags = 0u;
                ptr4[1].pOutputVoice = ReverbVoice;
            }

            IO.FAudioVoice_SetOutputVoices(voice, ref reverbSends);
        }

        public static void Create(SourceAudioProcess process)
        {
            IntPtr ppFAudio;
            try
            {
                process.IO.FAudioCreate(out ppFAudio, 0u, uint.MaxValue);
            }
            catch (Exception ex)
            {
                process.IO.LogWarn("FAudio failed to load: " + ex.ToString());
                return;
            }

            process.IO.FAudio_GetDeviceCount(ppFAudio, out var pCount);
            if (pCount == 0)
            {
                process.IO.FAudio_Release(ppFAudio);
                return;
            }

            SourceAudioContext fAudioContext = new SourceAudioContext(process, ppFAudio, pCount);
            if (fAudioContext.Handle == IntPtr.Zero)
            {
                fAudioContext.Dispose();
            }
            else
            {
                process.Context = fAudioContext;
            }
        }
    }
}
