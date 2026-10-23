using System;
using System.IO;

namespace Celeste.Core.IO.Content
{
    public sealed class DirectoryContentSource : IContentSource
    {
        public string TitleLocation { get; }

        public DirectoryContentSource(string actualTitleLocation)
        {
            if (string.IsNullOrEmpty(actualTitleLocation))
                throw new ArgumentException("The actual title location is required.", nameof(actualTitleLocation));
            TitleLocation = Path.GetFullPath(actualTitleLocation);
        }

        public Stream OpenTitleStream(string name)
        {
            return File.OpenRead(ResolveContentPath(name));
        }

        public bool FileExists(string name)
        {
            return File.Exists(ResolveContentPath(name));
        }

        public string[] GetFiles(string directory, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return Directory.GetFiles(ResolveContentPath(directory), "*", searchOption);
        }

        private string ResolveContentPath(string name)
        {
            return ContentFilePath.Resolve(TitleLocation, name);
        }
    }
}
