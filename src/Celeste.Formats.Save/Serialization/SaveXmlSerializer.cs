using System;
using System.IO;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    public sealed class SaveXmlSerializer : ISaveXmlSerializer
    {
        private readonly bool includeEverestFields;

        public SaveXmlSerializer(bool includeEverestFields = true)
        {
            this.includeEverestFields = includeEverestFields;
        }

        public void Serialize(Stream stream, SaveData save)
        {
            SaveXmlWire.WriteDocument(stream, "SaveData",
                SaveXmlWire.WriteSaveData("SaveData", save, includeEverestFields));
        }

        public SaveData Deserialize(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            try
            {
                return SaveXmlWire.ReadSaveData(SaveXmlWire.ReadDocument(stream, "SaveData"), true,
                    includeEverestFields);
            }
            catch (Exception error)
            {
                throw new InvalidOperationException("There is an error in the XML document.", error);
            }
        }
    }
}
