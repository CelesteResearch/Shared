namespace Celeste.Core.Serialization.Xml
{
    public interface ISourceXmlDocumentLoadingEnvironment
    {
        ISourceXmlDocumentLoadingPolicy XmlDocumentLoading { get; }
    }
}
