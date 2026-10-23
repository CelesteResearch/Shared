using Celeste.Formats.Save.Serialization;

namespace Celeste.Game.Save.Formats.Original
{
    public interface IOriginalSaveXmlFormatPolicy
    {
        ISaveXmlSerializer CreateSerializer();
    }
}
