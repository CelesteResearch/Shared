using System.IO;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    public interface ISaveXmlSerializer
    {
        void Serialize(Stream stream, SaveData save);
        SaveData Deserialize(Stream stream);
    }
}
