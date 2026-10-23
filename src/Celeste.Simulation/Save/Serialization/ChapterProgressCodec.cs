using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Celeste.Simulation;

namespace Celeste.Simulation.Save.Serialization
{
    public static class ChapterProgressCodec
    {
        private static DataContractSerializer Serializer() => new DataContractSerializer(
            typeof(global::Celeste.Simulation.Save.Progress.ChapterProgress),
            new DataContractSerializerSettings
                { PreserveObjectReferences = true, MaxItemsInObjectGraph = int.MaxValue });

        public static byte[] Serialize(global::Celeste.Simulation.Save.Progress.ChapterProgress progress)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = XmlDictionaryWriter.CreateTextWriter(stream, System.Text.Encoding.UTF8, false))
                    Serializer().WriteObject(writer, progress);
                return stream.ToArray();
            }
        }

        public static global::Celeste.Simulation.Save.Progress.ChapterProgress Deserialize(byte[] data,
            global::Celeste.Simulation.Progression.IChapterProgressionPolicy progressionPolicy)
        {
            using (var stream = new MemoryStream(data, false))
            using (var reader = XmlDictionaryReader.CreateTextReader(stream, XmlDictionaryReaderQuotas.Max))
            {
                var progress =
                    (global::Celeste.Simulation.Save.Progress.ChapterProgress)Serializer().ReadObject(reader);
                progress.ProgressionPolicy = progressionPolicy;
                return progress;
            }
        }
    }
}
