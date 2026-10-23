using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal static class SourceFnaMemoryStreamAccess
    {
        private static readonly FieldInfo f_MemoryStream_Public =
            typeof(MemoryStream).GetField("_exposable", BindingFlags.Instance | BindingFlags.NonPublic) ??
            typeof(MemoryStream).GetField("allowGetBuffer", BindingFlags.Instance | BindingFlags.NonPublic);

        /// <summary>
        ///     Returns the array of unsigned bytes from which this stream was created.
        ///     The return value indicates whether the conversion succeeded.
        ///     This is similar to .NET 4.6's TryGetBuffer.
        /// </summary>
        /// <param name="stream">The stream to get the buffer from.</param>
        /// <param name="buffer">The byte array from which this stream was created.</param>
        /// <returns><b>true</b> if the conversion was successful; otherwise, <b>false</b>.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static bool TryGetBuffer(this MemoryStream stream, out byte[] buffer)
        {
            if (f_MemoryStream_Public != null)
            {
                if ((bool)f_MemoryStream_Public.GetValue(stream))
                {
                    buffer = stream.GetBuffer();
                    return true;
                }

                buffer = null;
                return false;
            }

            try
            {
                buffer = stream.GetBuffer();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                buffer = null;
                return false;
            }
        }
    }
}
