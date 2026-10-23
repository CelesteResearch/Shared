using System;
using Celeste.Audio.Fmod.Capture;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Parameters;

namespace Celeste.Audio.Fmod.IO
{
    // Device-local Studio calls. Handles and ABI translation belong to this device.
    public interface IFmodStudioDeviceIO
    {
        uint HeaderVersion { get; }
        void ValidateRuntimeArchitecture();
        FmodAudioCapture CreateAudioCapture(IntPtr core, Action<float[], int, int> receive);
        FmodResult StudioBankGetBusCount(IntPtr bank, out int count);

        FmodResult StudioBankGetBusList(IntPtr bank, IntPtr[] array, int capacity,
            out int count);

        FmodResult StudioBankGetEventCount(IntPtr bank, out int count);

        FmodResult StudioBankGetEventList(IntPtr bank, IntPtr[] array, int capacity,
            out int count);

        FmodResult StudioBankGetID(IntPtr bank, out Guid id);

        FmodResult StudioBankGetPath(IntPtr bank, byte[] path, int size,
            out int retrieved);

        FmodResult StudioBankGetVCACount(IntPtr bank, out int count);

        FmodResult StudioBankGetVCAList(IntPtr bank, IntPtr[] array, int capacity,
            out int count);

        FmodResult StudioBankLoadSampleData(IntPtr bank);
        FmodResult StudioBankUnload(IntPtr bank);
        FmodResult StudioBusGetMute(IntPtr bus, out int mute);

        FmodResult
            StudioBusGetPath(IntPtr bus, byte[] path, int size, out int retrieved);

        FmodResult StudioBusGetPaused(IntPtr bus, out int paused);

        FmodResult StudioBusGetVolume(IntPtr bus, out float volume,
            out float finalvolume);

        FmodResult StudioBusSetMute(IntPtr bus, int mute);
        FmodResult StudioBusSetPaused(IntPtr bus, int paused);
        FmodResult StudioBusSetVolume(IntPtr bus, float volume);
        FmodResult StudioBusStopAllEvents(IntPtr bus, int mode);

        FmodResult StudioEventDescriptionCreateInstance(IntPtr eventdescription,
            out IntPtr instance);

        FmodResult StudioEventDescriptionGetID(IntPtr eventdescription, out Guid id);

        FmodResult StudioEventDescriptionGetInstanceCount(IntPtr eventdescription,
            out int count);

        FmodResult StudioEventDescriptionGetLength(IntPtr eventdescription,
            out int length);

        FmodResult StudioEventDescriptionGetParameter(IntPtr description, byte[] name,
            out FmodParameterDescription parameter);

        FmodResult StudioEventDescriptionGetParameterByIndex(IntPtr eventdescription,
            int index, out FmodParameterDescription parameter);

        FmodResult StudioEventDescriptionGetParameterCount(IntPtr eventdescription,
            out int count);

        FmodResult StudioEventDescriptionGetPath(IntPtr eventdescription, byte[] path,
            int size, out int retrieved);

        FmodResult StudioEventDescriptionIs3D(IntPtr eventdescription, out int is3D);

        FmodResult StudioEventDescriptionIsOneshot(IntPtr eventdescription,
            out int oneshot);

        FmodResult StudioEventDescriptionLoadSampleData(IntPtr eventdescription);
        FmodResult StudioEventDescriptionUnloadSampleData(IntPtr description);

        FmodResult StudioEventInstanceGet3DAttributes(IntPtr _event,
            out FmodAttributes attributes);

        FmodResult StudioEventInstanceGetDescription(IntPtr _event,
            out IntPtr description);

        FmodResult StudioEventInstanceGetParameterValue(IntPtr _event, byte[] name,
            out float value, out float finalvalue);

        FmodResult StudioEventInstanceGetPaused(IntPtr _event, out int paused);

        FmodResult StudioEventInstanceGetPitch(IntPtr _event, out float pitch,
            out float finalpitch);

        FmodResult StudioEventInstanceGetPlaybackState(IntPtr _event,
            out FmodPlaybackState state);

        FmodResult StudioEventInstanceGetTimelinePosition(IntPtr _event,
            out int position);

        FmodResult StudioEventInstanceGetVolume(IntPtr _event, out float volume,
            out float finalvolume);

        FmodResult StudioEventInstanceRelease(IntPtr _event);

        FmodResult StudioEventInstanceSet3DAttributes(IntPtr _event,
            ref FmodAttributes attributes);

        FmodResult StudioEventInstanceSetParameterValue(IntPtr _event, byte[] name,
            float value);

        FmodResult StudioEventInstanceSetPaused(IntPtr _event, int paused);
        FmodResult StudioEventInstanceSetPitch(IntPtr _event, float pitch);
        FmodResult StudioEventInstanceSetTimelinePosition(IntPtr _event, int position);
        FmodResult StudioEventInstanceSetVolume(IntPtr _event, float volume);
        FmodResult StudioEventInstanceStart(IntPtr _event);
        FmodResult StudioEventInstanceStop(IntPtr _event, int mode);
        FmodResult StudioEventInstanceTriggerCue(IntPtr _event);
        FmodResult StudioSystemCreate(out IntPtr studiosystem, uint headerversion);
        FmodResult StudioSystemFlushCommands(IntPtr studiosystem);
        FmodResult StudioSystemFlushSampleLoading(IntPtr studiosystem);
        FmodResult StudioSystemGetBankCount(IntPtr studiosystem, out int count);

        FmodResult StudioSystemGetBankList(IntPtr studiosystem, IntPtr[] array,
            int capacity, out int count);

        FmodResult StudioSystemGetBus(IntPtr studiosystem, byte[] path, out IntPtr bus);

        FmodResult StudioSystemGetEvent(IntPtr studiosystem, byte[] path,
            out IntPtr description);

        FmodResult StudioSystemGetEventByID(IntPtr studio, ref Guid id, out IntPtr description);
        FmodResult StudioSystemGetLowLevelSystem(IntPtr studiosystem, out IntPtr system);
        FmodResult StudioSystemGetVCA(IntPtr studiosystem, byte[] path, out IntPtr vca);

        FmodResult StudioSystemInitialize(IntPtr studiosystem, int maxchannels,
            uint studioFlags, uint flags, IntPtr extradriverdata);

        FmodResult StudioSystemLoadBankCustom(IntPtr studio, ref FmodBankInfo info, uint flags, out IntPtr bank);

        // A blocking load that owns the bank bytes after this call returns.
        // The caller's memory need not remain pinned. No asynchronous flags are used.
        FmodResult StudioSystemLoadBankMemory(IntPtr studiosystem, ReadOnlyMemory<byte> buffer, out IntPtr bank);

        void ConfigureSourcePlatform(IntPtr core);

        FmodResult StudioSystemLoadBankFile(IntPtr studiosystem, byte[] filename,
            uint flags, out IntPtr bank);

        FmodResult StudioSystemRelease(IntPtr studiosystem);

        FmodResult StudioSystemSetListenerAttributes(IntPtr studiosystem, int listener,
            ref FmodAttributes attributes);

        FmodResult StudioSystemUnloadAll(IntPtr studiosystem);
        FmodResult StudioSystemUpdate(IntPtr studiosystem);

        FmodResult
            StudioVCAGetPath(IntPtr vca, byte[] path, int size, out int retrieved);

        FmodResult StudioVCAGetVolume(IntPtr vca, out float volume,
            out float finalvolume);

        FmodResult StudioVCASetVolume(IntPtr vca, float value);
        FmodResult SystemGetOutput(IntPtr system, out int output);
        FmodResult SystemGetVersion(IntPtr system, out uint version);
        FmodResult SystemSetOutput(IntPtr system, int output);

        FmodResult StudioEventDescriptionGetParameterInfoByIndex(IntPtr description, int index,
            out FmodParameterDescription parameter);
    }
}
