using System.Xml;
using Celeste.Core.IO.Content;

namespace Celeste.Core.Serialization.Xml
{
    public sealed class OriginalXmlDocumentLoadingPolicy(IContentSource files = null) : ISourceXmlDocumentLoadingPolicy
    {
        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly IContentSource _files = files;

        public XmlDocument Load(string filename)
        {
            if (_files == null)
                return SourceXmlDocumentLoader.Load(filename);
            var document = new XmlDocument();
            using var stream = _files.OpenTitleStream(filename);
            document.Load(stream);
            return document;
        }
    }
}
