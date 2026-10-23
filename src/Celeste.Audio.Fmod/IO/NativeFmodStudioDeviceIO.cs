using System;
using System.Runtime.InteropServices;
using System.Text;
using Celeste.Audio.Fmod.Capture;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Parameters;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.IO
{
    public sealed class NativeFmodStudioDeviceIO : IFmodStudioDeviceIO
    {
        public static NativeFmodStudioDeviceIO Instance { get; } = new();

        private NativeFmodStudioDeviceIO()
        {
        }

        public uint HeaderVersion => FmodStudioRuntime.HeaderVersion;

        public void ValidateRuntimeArchitecture()
        {
            if (IntPtr.Size != 8)
                throw new PlatformNotSupportedException("This runtime requires a 64-bit FMOD 1.10.14 native library.");
        }

        public FmodAudioCapture CreateAudioCapture(IntPtr core, Action<float[], int, int> receive)
        {
            return new(core, receive);
        }

        public FmodResult StudioBankGetBusCount(IntPtr bank, out int count)
        {
            return NativeMethods.FMOD_Studio_Bank_GetBusCount(bank, out count);
        }

        public FmodResult StudioBankGetBusList(IntPtr bank, IntPtr[] array, int capacity,
            out int count)
        {
            return NativeMethods.FMOD_Studio_Bank_GetBusList(bank, array, capacity, out count);
        }

        public FmodResult StudioBankGetEventCount(IntPtr bank, out int count)
        {
            return NativeMethods.FMOD_Studio_Bank_GetEventCount(bank, out count);
        }

        public FmodResult StudioBankGetEventList(IntPtr bank, IntPtr[] array,
            int capacity, out int count)
        {
            return NativeMethods.FMOD_Studio_Bank_GetEventList(bank, array, capacity, out count);
        }

        public FmodResult StudioBankGetID(IntPtr bank, out Guid id)
        {
            return NativeMethods.FMOD_Studio_Bank_GetID(bank, out id);
        }

        public FmodResult StudioBankGetPath(IntPtr bank, byte[] path, int size,
            out int retrieved)
        {
            return NativeMethods.FMOD_Studio_Bank_GetPath(bank, path, size, out retrieved);
        }

        public FmodResult StudioBankGetVCACount(IntPtr bank, out int count)
        {
            return NativeMethods.FMOD_Studio_Bank_GetVCACount(bank, out count);
        }

        public FmodResult StudioBankGetVCAList(IntPtr bank, IntPtr[] array, int capacity,
            out int count)
        {
            return NativeMethods.FMOD_Studio_Bank_GetVCAList(bank, array, capacity, out count);
        }

        public FmodResult StudioBankLoadSampleData(IntPtr bank)
        {
            return NativeMethods.FMOD_Studio_Bank_LoadSampleData(bank);
        }

        public FmodResult StudioBankUnload(IntPtr bank)
        {
            return NativeMethods.FMOD_Studio_Bank_Unload(bank);
        }

        public FmodResult StudioBusGetMute(IntPtr bus, out int mute)
        {
            return NativeMethods.FMOD_Studio_Bus_GetMute(bus, out mute);
        }

        public FmodResult StudioBusGetPath(IntPtr bus, byte[] path, int size,
            out int retrieved)
        {
            return NativeMethods.FMOD_Studio_Bus_GetPath(bus, path, size, out retrieved);
        }

        public FmodResult StudioBusGetPaused(IntPtr bus, out int paused)
        {
            return NativeMethods.FMOD_Studio_Bus_GetPaused(bus, out paused);
        }

        public FmodResult StudioBusGetVolume(IntPtr bus, out float volume,
            out float finalvolume)
        {
            return NativeMethods.FMOD_Studio_Bus_GetVolume(bus, out volume, out finalvolume);
        }

        public FmodResult StudioBusSetMute(IntPtr bus, int mute)
        {
            return NativeMethods.FMOD_Studio_Bus_SetMute(bus, mute);
        }

        public FmodResult StudioBusSetPaused(IntPtr bus, int paused)
        {
            return NativeMethods.FMOD_Studio_Bus_SetPaused(bus, paused);
        }

        public FmodResult StudioBusSetVolume(IntPtr bus, float volume)
        {
            return NativeMethods.FMOD_Studio_Bus_SetVolume(bus, volume);
        }

        public FmodResult StudioBusStopAllEvents(IntPtr bus, int mode)
        {
            return NativeMethods.FMOD_Studio_Bus_StopAllEvents(bus, mode);
        }

        public FmodResult
            StudioEventDescriptionCreateInstance(IntPtr eventdescription, out IntPtr instance)
        {
            return NativeMethods.FMOD_Studio_EventDescription_CreateInstance(eventdescription, out instance);
        }

        public FmodResult
            StudioEventDescriptionGetID(IntPtr eventdescription, out Guid id)
        {
            return NativeMethods.FMOD_Studio_EventDescription_GetID(eventdescription, out id);
        }

        public FmodResult
            StudioEventDescriptionGetInstanceCount(IntPtr eventdescription, out int count)
        {
            return NativeMethods.FMOD_Studio_EventDescription_GetInstanceCount(eventdescription, out count);
        }

        public FmodResult
            StudioEventDescriptionGetLength(IntPtr eventdescription, out int length)
        {
            return NativeMethods.FMOD_Studio_EventDescription_GetLength(eventdescription, out length);
        }

        public FmodResult StudioEventDescriptionGetParameter(IntPtr description, byte[] name,
            out FmodParameterDescription parameter)
        {
            var result =
                NativeMethods.FMOD_Studio_EventDescription_GetParameter(description, name, out var nativeParameter);
            parameter = default;
            if (result == FmodResult.OK)
            {
                parameter.Name = FmodSourceMarshallingHelper.stringFromNativeUtf8(nativeParameter.Name);
                parameter.Index = nativeParameter.Index;
                parameter.Minimum = nativeParameter.Minimum;
                parameter.Maximum = nativeParameter.Maximum;
                parameter.DefaultValue = nativeParameter.DefaultValue;
                parameter.Type = nativeParameter.Type;
            }

            return result;
        }

        public FmodResult StudioEventDescriptionGetParameterByIndex(
            IntPtr eventdescription, int index, out FmodParameterDescription parameter)
        {
            var result =
                NativeMethods.FMOD_Studio_EventDescription_GetParameterByIndex(eventdescription, index,
                    out var nativeParameter);
            parameter = default;
            if (result == FmodResult.OK)
            {
                parameter.Name = FmodSourceMarshallingHelper.stringFromNativeUtf8(nativeParameter.Name);
                parameter.Index = nativeParameter.Index;
                parameter.Minimum = nativeParameter.Minimum;
                parameter.Maximum = nativeParameter.Maximum;
                parameter.DefaultValue = nativeParameter.DefaultValue;
                parameter.Type = nativeParameter.Type;
            }

            return result;
        }

        public FmodResult
            StudioEventDescriptionGetParameterCount(IntPtr eventdescription, out int count)
        {
            return NativeMethods.FMOD_Studio_EventDescription_GetParameterCount(eventdescription, out count);
        }

        public FmodResult StudioEventDescriptionGetPath(IntPtr eventdescription,
            byte[] path, int size, out int retrieved)
        {
            return NativeMethods.FMOD_Studio_EventDescription_GetPath(eventdescription, path, size, out retrieved);
        }

        public FmodResult
            StudioEventDescriptionIs3D(IntPtr eventdescription, out int is3D)
        {
            return NativeMethods.FMOD_Studio_EventDescription_Is3D(eventdescription, out is3D);
        }

        public FmodResult
            StudioEventDescriptionIsOneshot(IntPtr eventdescription, out int oneshot)
        {
            return NativeMethods.FMOD_Studio_EventDescription_IsOneshot(eventdescription, out oneshot);
        }

        public FmodResult
            StudioEventDescriptionLoadSampleData(IntPtr eventdescription)
        {
            return NativeMethods.FMOD_Studio_EventDescription_LoadSampleData(eventdescription);
        }

        public FmodResult StudioEventDescriptionUnloadSampleData(IntPtr description)
        {
            return NativeMethods.FMOD_Studio_EventDescription_UnloadSampleData(description);
        }

        public FmodResult StudioEventInstanceGet3DAttributes(IntPtr _event,
            out FmodAttributes attributes)
        {
            return NativeMethods.FMOD_Studio_EventInstance_Get3DAttributes(_event, out attributes);
        }

        public FmodResult
            StudioEventInstanceGetDescription(IntPtr _event, out IntPtr description)
        {
            return NativeMethods.FMOD_Studio_EventInstance_GetDescription(_event, out description);
        }

        public FmodResult StudioEventInstanceGetParameterValue(IntPtr _event,
            byte[] name, out float value, out float finalvalue)
        {
            return NativeMethods.FMOD_Studio_EventInstance_GetParameterValue(_event, name, out value, out finalvalue);
        }

        public FmodResult StudioEventInstanceGetPaused(IntPtr _event, out int paused)
        {
            return NativeMethods.FMOD_Studio_EventInstance_GetPaused(_event, out paused);
        }

        public FmodResult StudioEventInstanceGetPitch(IntPtr _event, out float pitch,
            out float finalpitch)
        {
            return NativeMethods.FMOD_Studio_EventInstance_GetPitch(_event, out pitch, out finalpitch);
        }

        public FmodResult StudioEventInstanceGetPlaybackState(IntPtr _event,
            out FmodPlaybackState state)
        {
            return NativeMethods.FMOD_Studio_EventInstance_GetPlaybackState(_event, out state);
        }

        public FmodResult
            StudioEventInstanceGetTimelinePosition(IntPtr _event, out int position)
        {
            return NativeMethods.FMOD_Studio_EventInstance_GetTimelinePosition(_event, out position);
        }

        public FmodResult StudioEventInstanceGetVolume(IntPtr _event, out float volume,
            out float finalvolume)
        {
            return NativeMethods.FMOD_Studio_EventInstance_GetVolume(_event, out volume, out finalvolume);
        }

        public FmodResult StudioEventInstanceRelease(IntPtr _event)
        {
            return NativeMethods.FMOD_Studio_EventInstance_Release(_event);
        }

        public FmodResult StudioEventInstanceSet3DAttributes(IntPtr _event,
            ref FmodAttributes attributes)
        {
            return NativeMethods.FMOD_Studio_EventInstance_Set3DAttributes(_event, ref attributes);
        }

        public FmodResult
            StudioEventInstanceSetParameterValue(IntPtr _event, byte[] name, float value)
        {
            return NativeMethods.FMOD_Studio_EventInstance_SetParameterValue(_event, name, value);
        }

        public FmodResult StudioEventInstanceSetPaused(IntPtr _event, int paused)
        {
            return NativeMethods.FMOD_Studio_EventInstance_SetPaused(_event, paused);
        }

        public FmodResult StudioEventInstanceSetPitch(IntPtr _event, float pitch)
        {
            return NativeMethods.FMOD_Studio_EventInstance_SetPitch(_event, pitch);
        }

        public FmodResult
            StudioEventInstanceSetTimelinePosition(IntPtr _event, int position)
        {
            return NativeMethods.FMOD_Studio_EventInstance_SetTimelinePosition(_event, position);
        }

        public FmodResult StudioEventInstanceSetVolume(IntPtr _event, float volume)
        {
            return NativeMethods.FMOD_Studio_EventInstance_SetVolume(_event, volume);
        }

        public FmodResult StudioEventInstanceStart(IntPtr _event)
        {
            return NativeMethods.FMOD_Studio_EventInstance_Start(_event);
        }

        public FmodResult StudioEventInstanceStop(IntPtr _event, int mode)
        {
            return NativeMethods.FMOD_Studio_EventInstance_Stop(_event, mode);
        }

        public FmodResult StudioEventInstanceTriggerCue(IntPtr _event)
        {
            return NativeMethods.FMOD_Studio_EventInstance_TriggerCue(_event);
        }

        public FmodResult
            StudioSystemCreate(out IntPtr studiosystem, uint headerversion)
        {
            return NativeMethods.FMOD_Studio_System_Create(out studiosystem, headerversion);
        }

        public FmodResult StudioSystemFlushCommands(IntPtr studiosystem)
        {
            return NativeMethods.FMOD_Studio_System_FlushCommands(studiosystem);
        }

        public FmodResult StudioSystemFlushSampleLoading(IntPtr studiosystem)
        {
            return NativeMethods.FMOD_Studio_System_FlushSampleLoading(studiosystem);
        }

        public FmodResult StudioSystemGetBankCount(IntPtr studiosystem, out int count)
        {
            return NativeMethods.FMOD_Studio_System_GetBankCount(studiosystem, out count);
        }

        public FmodResult StudioSystemGetBankList(IntPtr studiosystem, IntPtr[] array,
            int capacity, out int count)
        {
            return NativeMethods.FMOD_Studio_System_GetBankList(studiosystem, array, capacity, out count);
        }

        public FmodResult StudioSystemGetBus(IntPtr studiosystem, byte[] path,
            out IntPtr bus)
        {
            return NativeMethods.FMOD_Studio_System_GetBus(studiosystem, path, out bus);
        }

        public FmodResult StudioSystemGetEvent(IntPtr studiosystem, byte[] path,
            out IntPtr description)
        {
            return NativeMethods.FMOD_Studio_System_GetEvent(studiosystem, path, out description);
        }

        public FmodResult StudioSystemGetEventByID(IntPtr studio, ref Guid id, out IntPtr description)
        {
            return NativeMethods.FMOD_Studio_System_GetEventByID(studio, ref id, out description);
        }

        public FmodResult
            StudioSystemGetLowLevelSystem(IntPtr studiosystem, out IntPtr system)
        {
            return NativeMethods.FMOD_Studio_System_GetLowLevelSystem(studiosystem, out system);
        }

        public FmodResult StudioSystemGetVCA(IntPtr studiosystem, byte[] path,
            out IntPtr vca)
        {
            return NativeMethods.FMOD_Studio_System_GetVCA(studiosystem, path, out vca);
        }

        public FmodResult StudioSystemInitialize(IntPtr studiosystem, int maxchannels,
            uint studioFlags, uint flags, IntPtr extradriverdata)
        {
            return NativeMethods.FMOD_Studio_System_Initialize(studiosystem, maxchannels, studioFlags, flags,
                extradriverdata);
        }

        public FmodResult StudioSystemLoadBankCustom(IntPtr studio, ref FmodBankInfo info, uint flags, out IntPtr bank)
        {
            return NativeMethods.FMOD_Studio_System_LoadBankCustom(studio, ref info, flags, out bank);
        }

        public unsafe FmodResult StudioSystemLoadBankMemory(IntPtr studiosystem, ReadOnlyMemory<byte> buffer,
            out IntPtr bank)
        {
            using (var pinned = buffer.Pin())
            {
                return NativeMethods.FMOD_Studio_System_LoadBankMemory(studiosystem, (IntPtr)pinned.Pointer,
                    buffer.Length, 0, 0, out bank);
            }
        }

        public void ConfigureSourcePlatform(IntPtr core)
        {
            if (FmodStudioRuntime.GetSourceSdlPlatformNative().Equals("Linux"))
                FmodStudioRuntime.RegisterSourceSdlSystemNative(core);
        }

        public FmodResult StudioSystemLoadBankFile(IntPtr studiosystem, byte[] filename,
            uint flags, out IntPtr bank)
        {
            return NativeMethods.FMOD_Studio_System_LoadBankFile(studiosystem, filename, flags, out bank);
        }

        public FmodResult StudioSystemRelease(IntPtr studiosystem)
        {
            return NativeMethods.FMOD_Studio_System_Release(studiosystem);
        }

        public FmodResult StudioSystemSetListenerAttributes(IntPtr studiosystem,
            int listener, ref FmodAttributes attributes)
        {
            return NativeMethods.FMOD_Studio_System_SetListenerAttributes(studiosystem, listener, ref attributes);
        }

        public FmodResult StudioSystemUnloadAll(IntPtr studiosystem)
        {
            return NativeMethods.FMOD_Studio_System_UnloadAll(studiosystem);
        }

        public FmodResult StudioSystemUpdate(IntPtr studiosystem)
        {
            return NativeMethods.FMOD_Studio_System_Update(studiosystem);
        }

        public FmodResult StudioVCAGetPath(IntPtr vca, byte[] path, int size,
            out int retrieved)
        {
            return NativeMethods.FMOD_Studio_VCA_GetPath(vca, path, size, out retrieved);
        }

        public FmodResult StudioVCAGetVolume(IntPtr vca, out float volume,
            out float finalvolume)
        {
            return NativeMethods.FMOD_Studio_VCA_GetVolume(vca, out volume, out finalvolume);
        }

        public FmodResult StudioVCASetVolume(IntPtr vca, float value)
        {
            return NativeMethods.FMOD_Studio_VCA_SetVolume(vca, value);
        }

        public FmodResult SystemGetOutput(IntPtr system, out int output)
        {
            return NativeMethods.FMOD_System_GetOutput(system, out output);
        }

        public FmodResult SystemGetVersion(IntPtr system, out uint version)
        {
            return NativeMethods.FMOD_System_GetVersion(system, out version);
        }

        public FmodResult SystemSetOutput(IntPtr system, int output)
        {
            return NativeMethods.FMOD_System_SetOutput(system, output);
        }

        public FmodResult StudioEventDescriptionGetParameterInfoByIndex(IntPtr description, int index,
            out FmodParameterDescription parameter)
        {
            var result =
                NativeMethods.FMOD_Studio_EventDescription_GetParameterByIndex(description, index,
                    out var nativeParameter);
            return ConvertParameterInfo(result, nativeParameter, out parameter);
        }

        internal static FmodResult ConvertParameterInfo(FmodResult result, NativeParameterDescription nativeParameter,
            out FmodParameterDescription parameter)
        {
            parameter = default;
            if (result != FmodResult.OK) return result;
            parameter.Name = ReadUtf8(nativeParameter.Name);
            parameter.Index = nativeParameter.Index;
            parameter.Minimum = nativeParameter.Minimum;
            parameter.Maximum = nativeParameter.Maximum;
            parameter.DefaultValue = nativeParameter.DefaultValue;
            parameter.Type = nativeParameter.Type;
            return result;
        }

        private static string ReadUtf8(IntPtr pointer)
        {
            if (pointer == IntPtr.Zero) return null;
            var size = 0;
            while (Marshal.ReadByte(pointer, size) != 0)
            {
                size++;
                if (size > 1024 * 1024) throw new InvalidOperationException("FMOD returned an invalid UTF-8 string.");
            }

            var bytes = new byte[size];
            Marshal.Copy(pointer, bytes, 0, size);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
