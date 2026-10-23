using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Celeste.Simulation.Progression;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Simulation.Save.Serialization
{
    public static class ChapterProgressCodec
    {
        private static DataContractSerializer Serializer()
        {
            return new(
                typeof(ChapterProgress),
                new DataContractSerializerSettings
                    { PreserveObjectReferences = true, MaxItemsInObjectGraph = int.MaxValue });
        }

        public static byte[] Serialize(ChapterProgress progress)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8, false))
                {
                    Serializer().WriteObject(writer, progress);
                }

                return stream.ToArray();
            }
        }

        public static ChapterProgress Deserialize(byte[] data,
            IChapterProgressionPolicy progressionPolicy)
        {
            using (var stream = new MemoryStream(data, false))
            using (var reader = XmlDictionaryReader.CreateTextReader(stream, XmlDictionaryReaderQuotas.Max))
            {
                var progress =
                    (ChapterProgress)Serializer().ReadObject(reader);
                progress.ProgressionPolicy = progressionPolicy;
                return progress;
            }
        }
    }
}
