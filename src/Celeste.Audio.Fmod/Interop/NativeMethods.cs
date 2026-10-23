using System;
using System.Runtime.InteropServices;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Audio.Fmod.Interop
{
    internal static partial class NativeMethods
    {
        internal const string StudioLibrary = "fmodstudio";

        // Keep both native bindings in the same managed assembly. The running OS, not the
        // Unity build target (or absence of Unity defines), selects FMOD's native library name.
        private static readonly bool Windows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_Create(
            out IntPtr studiosystem, uint headerversion);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_Initialize(
            IntPtr studiosystem, int maxchannels,
            uint studioFlags, uint flags, IntPtr extradriverdata);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_System_UnloadAll(IntPtr studiosystem);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_Release(
            IntPtr studiosystem);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_Update(
            IntPtr studiosystem);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_GetLowLevelSystem(
            IntPtr studiosystem, out IntPtr system);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_GetEvent(
            IntPtr studiosystem,
            byte[] path,
            out IntPtr description);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_GetBus(
            IntPtr studiosystem,
            byte[] path, out IntPtr bus);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_GetVCA(
            IntPtr studiosystem,
            byte[] path, out IntPtr vca);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_LoadBankFile(
            IntPtr studiosystem, byte[] filename,
            uint flags, out IntPtr bank);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_LoadBankMemory(IntPtr studiosystem, IntPtr buffer,
            int length, int mode, uint flags, out IntPtr bank);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_GetBankCount(
            IntPtr studiosystem, out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_GetBankList(
            IntPtr studiosystem, IntPtr[] array,
            int capacity, out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_FlushCommands(
            IntPtr studiosystem);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_FlushSampleLoading(
            IntPtr studiosystem);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_SetListenerAttributes(
            IntPtr studiosystem, int listener,
            ref FmodAttributes attributes);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_Unload(IntPtr bank);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_LoadSampleData(
            IntPtr bank);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_GetPath(IntPtr bank,
            [Out] byte[] path, int size,
            out int retrieved);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_GetEventCount(IntPtr bank,
            out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_GetEventList(IntPtr bank,
            IntPtr[] array, int capacity,
            out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_GetBusCount(IntPtr bank,
            out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_GetBusList(IntPtr bank,
            IntPtr[] array, int capacity,
            out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_GetVCACount(IntPtr bank,
            out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_GetVCAList(IntPtr bank,
            IntPtr[] array, int capacity,
            out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventDescription_GetID(
            IntPtr eventdescription, out Guid id);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventDescription_GetPath(
            IntPtr eventdescription,
            [Out] byte[] path, int size, out int retrieved);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_EventDescription_GetParameterCount(
                IntPtr eventdescription,
                out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_EventDescription_GetParameterByIndex(
                IntPtr eventdescription,
                int index, out NativeParameterDescription parameter);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventDescription_GetLength(
            IntPtr eventdescription,
            out int length);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventDescription_IsOneshot(
            IntPtr eventdescription,
            out int oneshot);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventDescription_Is3D(
            IntPtr eventdescription, out int is3D);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_EventDescription_LoadSampleData(
                IntPtr eventdescription);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_EventDescription_CreateInstance(
                IntPtr eventdescription,
                out IntPtr instance);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_EventDescription_GetInstanceCount(
                IntPtr eventdescription,
                out int count);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_GetDescription(
            IntPtr _event,
            out IntPtr description);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_Start(
            IntPtr _event);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_Stop(
            IntPtr _event,
            int mode);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_Release(
            IntPtr _event);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_GetVolume(
            IntPtr _event, out float volume,
            out float finalvolume);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_SetVolume(
            IntPtr _event, float volume);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_GetPitch(
            IntPtr _event,
            out float pitch,
            out float finalpitch);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_SetPitch(
            IntPtr _event,
            float pitch);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_GetPaused(
            IntPtr _event, out int paused);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_SetPaused(
            IntPtr _event, int paused);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_EventInstance_GetTimelinePosition(IntPtr _event, out int position);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_EventInstance_SetTimelinePosition(
                IntPtr _event, int position);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_GetPlaybackState(
            IntPtr _event,
            out FmodPlaybackState state);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_EventInstance_GetParameterValue(
                IntPtr _event, byte[] name,
                out float value, out float finalvalue);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_EventInstance_SetParameterValue(
                IntPtr _event, byte[] name,
                float value);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_Set3DAttributes(
            IntPtr _event,
            ref FmodAttributes attributes);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_Get3DAttributes(
            IntPtr _event,
            out FmodAttributes attributes);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventInstance_TriggerCue(
            IntPtr _event);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bus_GetPath(IntPtr bus,
            [Out] byte[] path, int size,
            out int retrieved);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_Bus_GetVolume(IntPtr bus, out float volume, out float finalvolume);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bus_SetVolume(IntPtr bus,
            float volume);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bus_GetPaused(IntPtr bus,
            out int paused);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_Bus_SetPaused(IntPtr bus, int paused);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_Bus_GetMute(IntPtr bus, out int mute);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bus_SetMute(IntPtr bus,
            int mute);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bus_StopAllEvents(IntPtr bus,
            int mode);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_VCA_GetPath(IntPtr vca,
            [Out] byte[] path, int size,
            out int retrieved);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult
            FMOD_Studio_VCA_GetVolume(IntPtr vca, out float volume, out float finalvolume);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_VCA_SetVolume(IntPtr vca,
            float value);

        internal static FmodResult FMOD_System_GetVersion(IntPtr system,
            out uint version)
        {
            return Windows
                ? WindowsCore.FMOD_System_GetVersion(system, out version)
                : UnixCore.FMOD_System_GetVersion(system, out version);
        }

        internal static FmodResult FMOD_System_GetOutput(IntPtr system,
            out int output)
        {
            return Windows
                ? WindowsCore.FMOD_System_GetOutput(system, out output)
                : UnixCore.FMOD_System_GetOutput(system, out output);
        }

        internal static FmodResult FMOD_System_SetOutput(IntPtr system, int output)
        {
            return Windows
                ? WindowsCore.FMOD_System_SetOutput(system, output)
                : UnixCore.FMOD_System_SetOutput(system, output);
        }

        private static class WindowsCore
        {
            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern FmodResult FMOD_System_GetVersion(IntPtr system,
                out uint version);

            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern FmodResult FMOD_System_SetOutput(IntPtr system,
                int output);

            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern FmodResult FMOD_System_GetOutput(IntPtr system,
                out int output);
        }

        private static class UnixCore
        {
            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern FmodResult FMOD_System_GetVersion(IntPtr system,
                out uint version);

            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern FmodResult FMOD_System_SetOutput(IntPtr system,
                int output);

            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern FmodResult FMOD_System_GetOutput(IntPtr system,
                out int output);
        }
    }
}
