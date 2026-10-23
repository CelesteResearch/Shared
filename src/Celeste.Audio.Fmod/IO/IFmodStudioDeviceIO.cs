using System;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Parameters;
using Celeste.Audio.Fmod.Capture;

namespace Celeste.Audio.Fmod.IO;

// Device-local Studio calls. Handles and ABI translation belong to this device.
public interface IFmodStudioDeviceIO
{
    uint HeaderVersion { get; }
    void ValidateRuntimeArchitecture();
    FmodAudioCapture CreateAudioCapture(IntPtr core, Action<float[], int, int> receive);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetBusCount(IntPtr bank, out int count);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetBusList(IntPtr bank, IntPtr[] array, int capacity,
        out int count);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetEventCount(IntPtr bank, out int count);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetEventList(IntPtr bank, IntPtr[] array, int capacity,
        out int count);

    FmodResult StudioBankGetID(IntPtr bank, out Guid id);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetPath(IntPtr bank, byte[] path, int size,
        out int retrieved);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetVCACount(IntPtr bank, out int count);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankGetVCAList(IntPtr bank, IntPtr[] array, int capacity,
        out int count);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankLoadSampleData(IntPtr bank);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBankUnload(IntPtr bank);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusGetMute(IntPtr bus, out int mute);

    global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioBusGetPath(IntPtr bus, byte[] path, int size, out int retrieved);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusGetPaused(IntPtr bus, out int paused);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusGetVolume(IntPtr bus, out float volume,
        out float finalvolume);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusSetMute(IntPtr bus, int mute);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusSetPaused(IntPtr bus, int paused);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusSetVolume(IntPtr bus, float volume);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioBusStopAllEvents(IntPtr bus, int mode);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionCreateInstance(IntPtr eventdescription,
        out IntPtr instance);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionGetID(IntPtr eventdescription, out Guid id);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionGetInstanceCount(IntPtr eventdescription,
        out int count);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionGetLength(IntPtr eventdescription,
        out int length);

    FmodResult StudioEventDescriptionGetParameter(IntPtr description, byte[] name,
        out FmodParameterDescription parameter);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionGetParameterByIndex(IntPtr eventdescription,
        int index, out FmodParameterDescription parameter);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionGetParameterCount(IntPtr eventdescription,
        out int count);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionGetPath(IntPtr eventdescription, byte[] path,
        int size, out int retrieved);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionIs3D(IntPtr eventdescription, out int is3D);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionIsOneshot(IntPtr eventdescription,
        out int oneshot);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventDescriptionLoadSampleData(IntPtr eventdescription);
    FmodResult StudioEventDescriptionUnloadSampleData(IntPtr description);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGet3DAttributes(IntPtr _event,
        out global::Celeste.Audio.Fmod.Interop.FmodAttributes attributes);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetDescription(IntPtr _event,
        out IntPtr description);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetParameterValue(IntPtr _event, byte[] name,
        out float value, out float finalvalue);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetPaused(IntPtr _event, out int paused);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetPitch(IntPtr _event, out float pitch,
        out float finalpitch);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetPlaybackState(IntPtr _event,
        out global::Celeste.Audio.Fmod.Events.FmodPlaybackState state);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetTimelinePosition(IntPtr _event,
        out int position);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceGetVolume(IntPtr _event, out float volume,
        out float finalvolume);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceRelease(IntPtr _event);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSet3DAttributes(IntPtr _event,
        ref global::Celeste.Audio.Fmod.Interop.FmodAttributes attributes);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSetParameterValue(IntPtr _event, byte[] name,
        float value);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSetPaused(IntPtr _event, int paused);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSetPitch(IntPtr _event, float pitch);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSetTimelinePosition(IntPtr _event, int position);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceSetVolume(IntPtr _event, float volume);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceStart(IntPtr _event);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceStop(IntPtr _event, int mode);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioEventInstanceTriggerCue(IntPtr _event);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemCreate(out IntPtr studiosystem, uint headerversion);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemFlushCommands(IntPtr studiosystem);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemFlushSampleLoading(IntPtr studiosystem);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetBankCount(IntPtr studiosystem, out int count);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetBankList(IntPtr studiosystem, IntPtr[] array,
        int capacity, out int count);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetBus(IntPtr studiosystem, byte[] path, out IntPtr bus);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetEvent(IntPtr studiosystem, byte[] path,
        out IntPtr description);

    FmodResult StudioSystemGetEventByID(IntPtr studio, ref Guid id, out IntPtr description);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetLowLevelSystem(IntPtr studiosystem, out IntPtr system);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemGetVCA(IntPtr studiosystem, byte[] path, out IntPtr vca);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemInitialize(IntPtr studiosystem, int maxchannels,
        uint studioFlags, uint flags, IntPtr extradriverdata);

    FmodResult StudioSystemLoadBankCustom(IntPtr studio, ref FmodBankInfo info, uint flags, out IntPtr bank);

    // A blocking load that owns the bank bytes after this call returns.
    // The caller's memory need not remain pinned. No asynchronous flags are used.
    FmodResult StudioSystemLoadBankMemory(IntPtr studiosystem, ReadOnlyMemory<byte> buffer, out IntPtr bank);

    void ConfigureSourcePlatform(IntPtr core);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemLoadBankFile(IntPtr studiosystem, byte[] filename,
        uint flags, out IntPtr bank);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemRelease(IntPtr studiosystem);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemSetListenerAttributes(IntPtr studiosystem, int listener,
        ref global::Celeste.Audio.Fmod.Interop.FmodAttributes attributes);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemUnloadAll(IntPtr studiosystem);
    global::Celeste.Audio.Fmod.Interop.FmodResult StudioSystemUpdate(IntPtr studiosystem);

    global::Celeste.Audio.Fmod.Interop.FmodResult
        StudioVCAGetPath(IntPtr vca, byte[] path, int size, out int retrieved);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioVCAGetVolume(IntPtr vca, out float volume,
        out float finalvolume);

    global::Celeste.Audio.Fmod.Interop.FmodResult StudioVCASetVolume(IntPtr vca, float value);
    global::Celeste.Audio.Fmod.Interop.FmodResult SystemGetOutput(IntPtr system, out int output);
    global::Celeste.Audio.Fmod.Interop.FmodResult SystemGetVersion(IntPtr system, out uint version);
    global::Celeste.Audio.Fmod.Interop.FmodResult SystemSetOutput(IntPtr system, int output);

    FmodResult StudioEventDescriptionGetParameterInfoByIndex(IntPtr description, int index,
        out FmodParameterDescription parameter);
}
