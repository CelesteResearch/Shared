using System.Xml;

namespace Celeste.Core.Serialization.Xml
{
    public sealed class OriginalXmlDocumentLoadingPolicy : ISourceXmlDocumentLoadingPolicy
    {
        private readonly global::Celeste.Core.IO.Content.IContentSource files;

        public OriginalXmlDocumentLoadingPolicy(global::Celeste.Core.IO.Content.IContentSource files = null)
            => this.files = files;

        public XmlDocument Load(string filename)
        {
            if (files == null) return SourceXmlDocumentLoader.Load(filename);
            var document = new XmlDocument();
            using System.IO.Stream stream = files.OpenTitleStream(filename);
            document.Load(stream);
            return document;
        }
    }
}
