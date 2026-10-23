using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Dependencies
{
    public readonly struct EverestDownloadProgress
    {
        public readonly long Position, Length;
        public readonly int KiBPerSecond;

        public EverestDownloadProgress(long position, long length, int speed)
        {
            Position = position;
            Length = length;
            KiBPerSecond = speed;
        }

        public string Text => Length > 0
            ? (int)Math.Floor(100.0 * Position / Length) + "% @ " + KiBPerSecond + " KiB/s"
            : (int)Math.Floor(Position / 1000.0) + "KiB @ " + KiBPerSecond + " KiB/s";
    }
}
