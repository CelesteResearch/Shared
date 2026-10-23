using System;
using System.IO;
using System.Text;
using System.Threading;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Persistence
{
    public sealed class
        EverestModuleDataSerializer : global::Celeste.Everest.Modules.Persistence.IEverestModuleDataSerializer
    {
        public static global::Celeste.Everest.Modules.Persistence.EverestModuleDataSerializer Shared { get; } =
            new global::Celeste.Everest.Modules.Persistence.EverestModuleDataSerializer();

        static readonly ISerializer yaml = new SerializerBuilder()
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.Preserve).Build();

        public void DeserializeInto(object target, Type type, byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                if (target is global::Celeste.Everest.Modules.Persistence.EverestModuleBinarySaveData save)
                {
                    using (var reader = new BinaryReader(stream)) save.Read(reader);
                }
                else if (target is global::Celeste.Everest.Modules.Persistence.EverestModuleBinarySession session)
                {
                    using (var reader = new BinaryReader(stream)) session.Read(reader);
                }
                else
                {
                    var fallback = new DefaultObjectFactory();
                    var reader = new DeserializerBuilder().IgnoreUnmatchedProperties()
                        .WithObjectFactory(t => t == target.GetType() ? target : fallback.Create(t)).Build();
                    using (var text = new StreamReader(stream)) reader.Deserialize(text, type);
                }
            }
        }

        public byte[] Serialize(object value, Type type)
        {
            using (var stream = new MemoryStream())
            {
                if (value is global::Celeste.Everest.Modules.Persistence.EverestModuleBinarySaveData save)
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, true)) save.Write(writer);
                }
                else if (value is global::Celeste.Everest.Modules.Persistence.EverestModuleBinarySession session)
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, true)) session.Write(writer);
                }
                else
                {
                    using (var writer = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
                        yaml.Serialize(writer, value, type);
                }

                return stream.ToArray();
            }
        }
    }
}
