using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace Celeste.Platform.Native.Windowing
{
    public sealed class Win32WindowStartupVisibility : IDisposable
    {
        private const uint WmStyleChanging = 0x007c;
        private const uint WmWindowPosChanging = 0x0046;
        private const uint WmNcDestroy = 0x0082;
        private const int GwlStyle = -16;
        private const int GwlExStyle = -20;
        private const uint WsVisible = 0x10000000;
        private const uint WsExNoActivate = 0x08000000;
        private const uint SwpShowWindow = 0x0040;
        private const uint SwpNoActivate = 0x0010;
        private static long nextSubclassId;
        private readonly uint ownerThread;
        private readonly UIntPtr subclassId;
        private IntPtr window;
        private SubclassCallback? callback;
        private uint targetExStyle;
        private bool subclassInstalled;
        private bool applyingLoanStyle;
        private bool completed;
        private bool disposed;

        public Win32WindowStartupVisibility(IntPtr actualWindow)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || IntPtr.Size != 8)
                throw new PlatformNotSupportedException("The physical window visibility loan requires Windows x64.");
            ownerThread = GetCurrentThreadId();
            if (actualWindow == IntPtr.Zero || GetWindowThreadProcessId(actualWindow, out _) != ownerThread)
                throw new ArgumentException("Borrow the actual window on its owner thread.", nameof(actualWindow));
            window = actualWindow;
            targetExStyle = unchecked((uint)GetWindowLongPtr(window, GwlExStyle).ToInt64());
            subclassId = new UIntPtr(unchecked((ulong)Interlocked.Increment(ref nextSubclassId)));
            callback = WindowProcedure;
            if (!SetWindowSubclass(window, callback, subclassId, UIntPtr.Zero))
                throw new Win32Exception(Marshal.GetLastWin32Error());
            subclassInstalled = true;
            applyingLoanStyle = true;
            try
            {
                SetWindowLongPtr(window, GwlExStyle, new IntPtr(targetExStyle | WsExNoActivate));
                ShowWindow(window, 0);
            }
            finally
            {
                applyingLoanStyle = false;
            }
        }

        public void Complete()
        {
            RequireOwner();
            if (disposed) throw new ObjectDisposedException(nameof(Win32WindowStartupVisibility));
            if (completed) return;
            RemoveSubclass();
            SetWindowLongPtr(window, GwlExStyle, new IntPtr(targetExStyle));
            completed = true;
            ShowWindow(window, 4);
        }

        public void Dispose()
        {
            RequireOwner();
            if (disposed) return;
            RemoveSubclass();
            if (window != IntPtr.Zero && !completed)
            {
                // Failure releases the loan without exposing a partially initialized game.
                ShowWindow(window, 0);
                SetWindowLongPtr(window, GwlExStyle, new IntPtr(targetExStyle));
            }

            disposed = true;
            window = IntPtr.Zero;
        }

        private IntPtr WindowProcedure(IntPtr hwnd, uint message, UIntPtr wParam, IntPtr lParam,
            UIntPtr id, UIntPtr referenceData)
        {
            var activeCallback = callback;
            if (message == WmNcDestroy)
            {
                RemoveWindowSubclass(hwnd, callback!, subclassId);
                subclassInstalled = false;
                callback = null;
                window = IntPtr.Zero;
                disposed = true;
            }
            else if (message == WmStyleChanging)
            {
                FilterStyleChange(unchecked((int)wParam.ToUInt64()), lParam);
            }
            else if (message == WmWindowPosChanging)
            {
                FilterWindowPosition(lParam);
            }

            var result = DefSubclassProc(hwnd, message, wParam, lParam);
            GC.KeepAlive(activeCallback);
            return result;
        }

        private void FilterStyleChange(int index, IntPtr pointer)
        {
            var style = Marshal.PtrToStructure<StyleChange>(pointer);
            if (index == GwlStyle)
                style.New &= ~WsVisible;
            else if (index == GwlExStyle)
            {
                if (!applyingLoanStyle) targetExStyle = style.New;
                style.New |= WsExNoActivate;
            }

            Marshal.StructureToPtr(style, pointer, false);
        }

        private static void FilterWindowPosition(IntPtr pointer)
        {
            var position = Marshal.PtrToStructure<WindowPosition>(pointer);
            position.Flags = (position.Flags & ~SwpShowWindow) | SwpNoActivate;
            Marshal.StructureToPtr(position, pointer, false);
        }

        private void RequireOwner()
        {
            if (GetCurrentThreadId() != ownerThread)
                throw new InvalidOperationException("Release the window visibility loan on its owner thread.");
        }

        private void RemoveSubclass()
        {
            if (!subclassInstalled) return;
            if (!RemoveWindowSubclass(window, callback!, subclassId))
                throw new Win32Exception(Marshal.GetLastWin32Error());
            subclassInstalled = false;
            callback = null;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct StyleChange
        {
            public uint Old;
            public uint New;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowPosition
        {
            public IntPtr Window;
            public IntPtr InsertAfter;
            public int X;
            public int Y;
            public int Width;
            public int Height;
            public uint Flags;
        }

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate IntPtr SubclassCallback(IntPtr hwnd, uint message, UIntPtr wParam, IntPtr lParam,
            UIntPtr id, UIntPtr referenceData);

        [DllImport("comctl32.dll", SetLastError = true)]
        private static extern bool SetWindowSubclass(IntPtr window, SubclassCallback callback, UIntPtr id,
            UIntPtr referenceData);

        [DllImport("comctl32.dll", SetLastError = true)]
        private static extern bool RemoveWindowSubclass(IntPtr window, SubclassCallback callback, UIntPtr id);

        [DllImport("comctl32.dll")]
        private static extern IntPtr DefSubclassProc(IntPtr window, uint message, UIntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr window, out uint processId);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtrW")]
        private static extern IntPtr GetWindowLongPtr(IntPtr window, int index);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtrW")]
        private static extern IntPtr SetWindowLongPtr(IntPtr window, int index, IntPtr value);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr window, int command);
    }
}
