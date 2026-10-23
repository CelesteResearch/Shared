using System;
using System.Runtime.InteropServices;
using System.Text;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Parameters;
using Celeste.Audio.Fmod.Capture;

namespace Celeste.Audio.Fmod.IO;

public sealed class NativeFmodStudioDeviceIO : IFmodStudioDeviceIO
{
    public static NativeFmodStudioDeviceIO Instance { get; } = new();

    private NativeFmodStudioDeviceIO()
    {
    }

    public uint HeaderVersion => Runtime.FmodStudioRuntime.HeaderVersion;

    public void ValidateRuntimeArchitecture()
    {
        if (IntPtr.Size != 8)
            throw new PlatformNotSupportedException("This runtime requires a 64-bit FMOD 1.10.14 native library.");
    }

    public FmodAudioCapture CreateAudioCapture(IntPtr core, Action<float[], int, int> receive) => new(core, receive);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetBusCount(IntPtr bank, out int count) =>
        NativeMethods.FMOD_Studio_Bank_GetBusCount(bank, out count);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetBusList(IntPtr bank, IntPtr[] array, int capacity,
        out int count) => NativeMethods.FMOD_Studio_Bank_GetBusList(bank, array, capacity, out count);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetEventCount(IntPtr bank, out int count) =>
        NativeMethods.FMOD_Studio_Bank_GetEventCount(bank, out count);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetEventList(IntPtr bank, IntPtr[] array,
        int capacity, out int count) => NativeMethods.FMOD_Studio_Bank_GetEventList(bank, array, capacity, out count);

    public FmodResult StudioBankGetID(IntPtr bank, out Guid id) => NativeMethods.FMOD_Studio_Bank_GetID(bank, out id);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetPath(IntPtr bank, byte[] path, int size,
        out int retrieved) => NativeMethods.FMOD_Studio_Bank_GetPath(bank, path, size, out retrieved);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetVCACount(IntPtr bank, out int count) =>
        NativeMethods.FMOD_Studio_Bank_GetVCACount(bank, out count);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetVCAList(IntPtr bank, IntPtr[] array, int capacity,
        out int count) => NativeMethods.FMOD_Studio_Bank_GetVCAList(bank, array, capacity, out count);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankLoadSampleData(IntPtr bank) =>
        NativeMethods.FMOD_Studio_Bank_LoadSampleData(bank);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankUnload(IntPtr bank) =>
        NativeMethods.FMOD_Studio_Bank_Unload(bank);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusGetMute(IntPtr bus, out int mute) =>
        NativeMethods.FMOD_Studio_Bus_GetMute(bus, out mute);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusGetPath(IntPtr bus, byte[] path, int size,
        out int retrieved) => NativeMethods.FMOD_Studio_Bus_GetPath(bus, path, size, out retrieved);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusGetPaused(IntPtr bus, out int paused) =>
        NativeMethods.FMOD_Studio_Bus_GetPaused(bus, out paused);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusGetVolume(IntPtr bus, out float volume,
        out float finalvolume) => NativeMethods.FMOD_Studio_Bus_GetVolume(bus, out volume, out finalvolume);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusSetMute(IntPtr bus, int mute) =>
        NativeMethods.FMOD_Studio_Bus_SetMute(bus, mute);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusSetPaused(IntPtr bus, int paused) =>
        NativeMethods.FMOD_Studio_Bus_SetPaused(bus, paused);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusSetVolume(IntPtr bus, float volume) =>
        NativeMethods.FMOD_Studio_Bus_SetVolume(bus, volume);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusStopAllEvents(IntPtr bus, int mode) =>
        NativeMethods.FMOD_Studio_Bus_StopAllEvents(bus, mode);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventDescriptionCreateInstance(IntPtr eventdescription, out IntPtr instance) =>
        NativeMethods.FMOD_Studio_EventDescription_CreateInstance(eventdescription, out instance);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventDescriptionGetID(IntPtr eventdescription, out Guid id) =>
        NativeMethods.FMOD_Studio_EventDescription_GetID(eventdescription, out id);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventDescriptionGetInstanceCount(IntPtr eventdescription, out int count) =>
        NativeMethods.FMOD_Studio_EventDescription_GetInstanceCount(eventdescription, out count);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventDescriptionGetLength(IntPtr eventdescription, out int length) =>
        NativeMethods.FMOD_Studio_EventDescription_GetLength(eventdescription, out length);

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

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionGetParameterByIndex(
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

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventDescriptionGetParameterCount(IntPtr eventdescription, out int count) =>
        NativeMethods.FMOD_Studio_EventDescription_GetParameterCount(eventdescription, out count);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionGetPath(IntPtr eventdescription,
        byte[] path, int size, out int retrieved) =>
        NativeMethods.FMOD_Studio_EventDescription_GetPath(eventdescription, path, size, out retrieved);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventDescriptionIs3D(IntPtr eventdescription, out int is3D) =>
        NativeMethods.FMOD_Studio_EventDescription_Is3D(eventdescription, out is3D);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventDescriptionIsOneshot(IntPtr eventdescription, out int oneshot) =>
        NativeMethods.FMOD_Studio_EventDescription_IsOneshot(eventdescription, out oneshot);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventDescriptionLoadSampleData(IntPtr eventdescription) =>
        NativeMethods.FMOD_Studio_EventDescription_LoadSampleData(eventdescription);

    public FmodResult StudioEventDescriptionUnloadSampleData(IntPtr description) =>
        NativeMethods.FMOD_Studio_EventDescription_UnloadSampleData(description);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGet3DAttributes(IntPtr _event,
        out global::Celeste.Audio.Fmod.Interop.FmodAttributes attributes) =>
        NativeMethods.FMOD_Studio_EventInstance_Get3DAttributes(_event, out attributes);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventInstanceGetDescription(IntPtr _event, out IntPtr description) =>
        NativeMethods.FMOD_Studio_EventInstance_GetDescription(_event, out description);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetParameterValue(IntPtr _event,
        byte[] name, out float value, out float finalvalue) =>
        NativeMethods.FMOD_Studio_EventInstance_GetParameterValue(_event, name, out value, out finalvalue);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetPaused(IntPtr _event, out int paused) =>
        NativeMethods.FMOD_Studio_EventInstance_GetPaused(_event, out paused);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetPitch(IntPtr _event, out float pitch,
        out float finalpitch) => NativeMethods.FMOD_Studio_EventInstance_GetPitch(_event, out pitch, out finalpitch);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetPlaybackState(IntPtr _event,
        out global::Celeste.Audio.Fmod.Events.FmodPlaybackState state) =>
        NativeMethods.FMOD_Studio_EventInstance_GetPlaybackState(_event, out state);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventInstanceGetTimelinePosition(IntPtr _event, out int position) =>
        NativeMethods.FMOD_Studio_EventInstance_GetTimelinePosition(_event, out position);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetVolume(IntPtr _event, out float volume,
        out float finalvolume) =>
        NativeMethods.FMOD_Studio_EventInstance_GetVolume(_event, out volume, out finalvolume);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceRelease(IntPtr _event) =>
        NativeMethods.FMOD_Studio_EventInstance_Release(_event);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSet3DAttributes(IntPtr _event,
        ref global::Celeste.Audio.Fmod.Interop.FmodAttributes attributes) =>
        NativeMethods.FMOD_Studio_EventInstance_Set3DAttributes(_event, ref attributes);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventInstanceSetParameterValue(IntPtr _event, byte[] name, float value) =>
        NativeMethods.FMOD_Studio_EventInstance_SetParameterValue(_event, name, value);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSetPaused(IntPtr _event, int paused) =>
        NativeMethods.FMOD_Studio_EventInstance_SetPaused(_event, paused);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSetPitch(IntPtr _event, float pitch) =>
        NativeMethods.FMOD_Studio_EventInstance_SetPitch(_event, pitch);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioEventInstanceSetTimelinePosition(IntPtr _event, int position) =>
        NativeMethods.FMOD_Studio_EventInstance_SetTimelinePosition(_event, position);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSetVolume(IntPtr _event, float volume) =>
        NativeMethods.FMOD_Studio_EventInstance_SetVolume(_event, volume);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceStart(IntPtr _event) =>
        NativeMethods.FMOD_Studio_EventInstance_Start(_event);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceStop(IntPtr _event, int mode) =>
        NativeMethods.FMOD_Studio_EventInstance_Stop(_event, mode);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceTriggerCue(IntPtr _event) =>
        NativeMethods.FMOD_Studio_EventInstance_TriggerCue(_event);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioSystemCreate(out IntPtr studiosystem, uint headerversion) =>
        NativeMethods.FMOD_Studio_System_Create(out studiosystem, headerversion);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemFlushCommands(IntPtr studiosystem) =>
        NativeMethods.FMOD_Studio_System_FlushCommands(studiosystem);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemFlushSampleLoading(IntPtr studiosystem) =>
        NativeMethods.FMOD_Studio_System_FlushSampleLoading(studiosystem);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetBankCount(IntPtr studiosystem, out int count) =>
        NativeMethods.FMOD_Studio_System_GetBankCount(studiosystem, out count);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetBankList(IntPtr studiosystem, IntPtr[] array,
        int capacity, out int count) =>
        NativeMethods.FMOD_Studio_System_GetBankList(studiosystem, array, capacity, out count);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetBus(IntPtr studiosystem, byte[] path,
        out IntPtr bus) => NativeMethods.FMOD_Studio_System_GetBus(studiosystem, path, out bus);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetEvent(IntPtr studiosystem, byte[] path,
        out IntPtr description) => NativeMethods.FMOD_Studio_System_GetEvent(studiosystem, path, out description);

    public FmodResult StudioSystemGetEventByID(IntPtr studio, ref Guid id, out IntPtr description) =>
        NativeMethods.FMOD_Studio_System_GetEventByID(studio, ref id, out description);

    public global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioSystemGetLowLevelSystem(IntPtr studiosystem, out IntPtr system) =>
        NativeMethods.FMOD_Studio_System_GetLowLevelSystem(studiosystem, out system);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetVCA(IntPtr studiosystem, byte[] path,
        out IntPtr vca) => NativeMethods.FMOD_Studio_System_GetVCA(studiosystem, path, out vca);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemInitialize(IntPtr studiosystem, int maxchannels,
        uint studioFlags, uint flags, IntPtr extradriverdata) =>
        NativeMethods.FMOD_Studio_System_Initialize(studiosystem, maxchannels, studioFlags, flags, extradriverdata);

    public FmodResult StudioSystemLoadBankCustom(IntPtr studio, ref FmodBankInfo info, uint flags, out IntPtr bank) =>
        NativeMethods.FMOD_Studio_System_LoadBankCustom(studio, ref info, flags, out bank);

    public unsafe FmodResult StudioSystemLoadBankMemory(IntPtr studiosystem, ReadOnlyMemory<byte> buffer,
        out IntPtr bank)
    {
        using (var pinned = buffer.Pin())
            return NativeMethods.FMOD_Studio_System_LoadBankMemory(studiosystem, (IntPtr)pinned.Pointer,
                buffer.Length, 0, 0, out bank);
    }

    public void ConfigureSourcePlatform(IntPtr core)
    {
        if (Runtime.FmodStudioRuntime.GetSourceSdlPlatformNative().Equals("Linux"))
            Runtime.FmodStudioRuntime.RegisterSourceSdlSystemNative(core);
    }

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemLoadBankFile(IntPtr studiosystem, byte[] filename,
        uint flags, out IntPtr bank) =>
        NativeMethods.FMOD_Studio_System_LoadBankFile(studiosystem, filename, flags, out bank);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemRelease(IntPtr studiosystem) =>
        NativeMethods.FMOD_Studio_System_Release(studiosystem);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemSetListenerAttributes(IntPtr studiosystem,
        int listener, ref global::Celeste.Audio.Fmod.Interop.FmodAttributes attributes) =>
        NativeMethods.FMOD_Studio_System_SetListenerAttributes(studiosystem, listener, ref attributes);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemUnloadAll(IntPtr studiosystem) =>
        NativeMethods.FMOD_Studio_System_UnloadAll(studiosystem);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemUpdate(IntPtr studiosystem) =>
        NativeMethods.FMOD_Studio_System_Update(studiosystem);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioVCAGetPath(IntPtr vca, byte[] path, int size,
        out int retrieved) => NativeMethods.FMOD_Studio_VCA_GetPath(vca, path, size, out retrieved);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioVCAGetVolume(IntPtr vca, out float volume,
        out float finalvolume) => NativeMethods.FMOD_Studio_VCA_GetVolume(vca, out volume, out finalvolume);

    public global::Celeste.Audio.Fmod.Interop.FmodResult StudioVCASetVolume(IntPtr vca, float value) =>
        NativeMethods.FMOD_Studio_VCA_SetVolume(vca, value);

    public global::Celeste.Audio.Fmod.Interop.FmodResult SystemGetOutput(IntPtr system, out int output) =>
        NativeMethods.FMOD_System_GetOutput(system, out output);

    public global::Celeste.Audio.Fmod.Interop.FmodResult SystemGetVersion(IntPtr system, out uint version) =>
        NativeMethods.FMOD_System_GetVersion(system, out version);

    public global::Celeste.Audio.Fmod.Interop.FmodResult SystemSetOutput(IntPtr system, int output) =>
        NativeMethods.FMOD_System_SetOutput(system, output);

    public FmodResult StudioEventDescriptionGetParameterInfoByIndex(IntPtr description, int index,
        out FmodParameterDescription parameter)
    {
        var result =
            NativeMethods.FMOD_Studio_EventDescription_GetParameterByIndex(description, index, out var nativeParameter);
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
        int size = 0;
        while (Marshal.ReadByte(pointer, size) != 0)
        {
            size++;
            if (size > 1024 * 1024) throw new InvalidOperationException("FMOD returned an invalid UTF-8 string.");
        }

        byte[] bytes = new byte[size];
        Marshal.Copy(pointer, bytes, 0, size);
        return Encoding.UTF8.GetString(bytes);
    }
}
