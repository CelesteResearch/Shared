using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Streams;

namespace Celeste.Everest.Content.Sources
{
    public class ZipContentSource : EverestContentSource
    {
        public readonly string Path;

        private readonly ZipArchive zip;
        private readonly IEverestContentDiagnostics Diagnostics;

        public override string DefaultName => System.IO.Path.GetFileName(Path);

        public ZipContentSource(EverestContentRegistry registry, IEverestContentDiagnostics diagnostics, string path) :
            base(registry)
        {
            Path = path;
            Diagnostics = diagnostics;
            zip = ZipFile.OpenRead(path);
        }

        protected override void Crawl()
        {
            lock (zip)
            {
                foreach (var entry in zip.Entries)
                {
                    var text = entry.FullName.Replace('\\', '/');
                    if (!text.EndsWith("/")) Add(text, new ZipContentAsset(this, entry.FullName));
                }
            }
        }

        public Stream Open(string path)
        {
            lock (zip)
            {
                return new SynchronizedZipEntryStream(
                    zip.GetEntry(path) ??
                    throw new KeyNotFoundException("File " + path + " not found in archive " + Path),
                    Diagnostics);
            }
        }

        protected override void Dispose(bool disposing)
        {
            lock (zip)
            {
                base.Dispose(disposing);
                zip.Dispose();
            }
        }
    }
}
