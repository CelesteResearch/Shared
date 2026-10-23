using System.Xml.Serialization;

namespace Celeste.Game.Save.Formats.Original
{
    public interface IOriginalSaveXmlFormatEnvironment
    {
        IOriginalSaveXmlFormatPolicy SaveXmlFormat { get; }
    }
}
