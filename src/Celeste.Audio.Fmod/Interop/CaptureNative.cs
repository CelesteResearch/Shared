using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Fmod.Interop
{
    internal static class CaptureNative
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct Description
        {
            public uint PluginSdkVersion;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] Name;

            public uint Version;
            public int Inputs, Outputs;
            public IntPtr Create, Release, Reset, Read, Process, SetPosition;
            public int ParameterCount;

            public IntPtr Parameters,
                SetFloat,
                SetInt,
                SetBool,
                SetData,
                GetFloat,
                GetInt,
                GetBool,
                GetData,
                ShouldProcess,
                UserData,
                Register,
                Deregister,
                Mix;
        }

        private static readonly bool Windows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        internal static global::Celeste.Audio.Fmod.Interop.FmodResult MasterGroup(IntPtr system, out IntPtr group) =>
            Windows
                ? Win.FMOD_System_GetMasterChannelGroup(system, out group)
                : Unix.FMOD_System_GetMasterChannelGroup(system, out group);

        internal static global::Celeste.Audio.Fmod.Interop.FmodResult SoftwareFormat(IntPtr system, out int rate,
            out int mode, out int channels) =>
            Windows
                ? Win.FMOD_System_GetSoftwareFormat(system, out rate, out mode, out channels)
                : Unix.FMOD_System_GetSoftwareFormat(system, out rate, out mode, out channels);

        internal static global::Celeste.Audio.Fmod.Interop.FmodResult Create(IntPtr system, ref Description description,
            out IntPtr dsp) => Windows
            ? Win.FMOD_System_CreateDSP(system, ref description, out dsp)
            : Unix.FMOD_System_CreateDSP(system, ref description, out dsp);

        internal static global::Celeste.Audio.Fmod.Interop.FmodResult Add(IntPtr group, int index, IntPtr dsp) =>
            Windows
                ? Win.FMOD_ChannelGroup_AddDSP(group, index, dsp)
                : Unix.FMOD_ChannelGroup_AddDSP(group, index, dsp);

        internal static global::Celeste.Audio.Fmod.Interop.FmodResult Remove(IntPtr group, IntPtr dsp) => Windows
            ? Win.FMOD_ChannelGroup_RemoveDSP(group, dsp)
            : Unix.FMOD_ChannelGroup_RemoveDSP(group, dsp);

        internal static global::Celeste.Audio.Fmod.Interop.FmodResult Bypass(IntPtr dsp, int bypass) =>
            Windows ? Win.FMOD_DSP_SetBypass(dsp, bypass) : Unix.FMOD_DSP_SetBypass(dsp, bypass);

        internal static global::Celeste.Audio.Fmod.Interop.FmodResult Release(IntPtr dsp) =>
            Windows ? Win.FMOD_DSP_Release(dsp) : Unix.FMOD_DSP_Release(dsp);

        private static class Win
        {
            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_System_GetMasterChannelGroup(
                IntPtr system, out IntPtr group);

            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_System_GetSoftwareFormat(
                IntPtr system,
                out int rate, out int mode,
                out int channels);

            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_System_CreateDSP(IntPtr system,
                ref Description description,
                out IntPtr dsp);

            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_ChannelGroup_AddDSP(IntPtr group,
                int index, IntPtr dsp);

            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_ChannelGroup_RemoveDSP(
                IntPtr group,
                IntPtr dsp);

            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_DSP_SetBypass(IntPtr dsp,
                int bypass);

            [DllImport("fmod64", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_DSP_Release(IntPtr dsp);
        }

        private static class Unix
        {
            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_System_GetMasterChannelGroup(
                IntPtr system, out IntPtr group);

            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_System_GetSoftwareFormat(
                IntPtr system,
                out int rate, out int mode,
                out int channels);

            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_System_CreateDSP(IntPtr system,
                ref Description description,
                out IntPtr dsp);

            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_ChannelGroup_AddDSP(IntPtr group,
                int index, IntPtr dsp);

            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_ChannelGroup_RemoveDSP(
                IntPtr group,
                IntPtr dsp);

            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_DSP_SetBypass(IntPtr dsp,
                int bypass);

            [DllImport("fmod", CallingConvention = CallingConvention.Winapi)]
            internal static extern global::Celeste.Audio.Fmod.Interop.FmodResult FMOD_DSP_Release(IntPtr dsp);
        }
    }
}
