using System;

namespace Celeste.Core.IO.Content.Manifests
{
    public sealed class ContentFileInfo
    {
        public string Path { get; }
        public string ResourcePath { get; }
        public long Size { get; }
        public string Sha256 { get; }
        public ContentTextureInfo Texture { get; }

        public ContentFileInfo(string path, long size, string sha256, ContentTextureInfo texture = null,
            string resourcePath = null)
        {
            ValidatePath(path);
            resourcePath ??= path;
            ValidatePath(resourcePath);
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            if (sha256 == null || sha256.Length != 64)
                throw new ArgumentException("A SHA-256 hexadecimal digest is required.", nameof(sha256));
            foreach (var character in sha256)
                if (!Uri.IsHexDigit(character))
                    throw new ArgumentException("A SHA-256 hexadecimal digest is required.", nameof(sha256));
            Path = path;
            ResourcePath = resourcePath;
            Size = size;
            Sha256 = sha256;
            Texture = texture;
        }

        internal static void ValidatePath(string path)
        {
            if (string.IsNullOrEmpty(path) || path.Contains("\\") || path.Contains(":") || path.StartsWith("/"))
                throw new ArgumentException("A relative logical content path using '/' is required.", nameof(path));
            foreach (var segment in path.Split('/'))
                if (segment.Length == 0 || segment == "." || segment == "..")
                    throw new ArgumentException("Content paths must be canonical.", nameof(path));
        }
    }
}
