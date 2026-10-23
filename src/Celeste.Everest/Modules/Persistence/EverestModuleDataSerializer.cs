using System;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;

namespace Celeste.Everest.Modules.Persistence
{
    public sealed class
        EverestModuleDataSerializer : IEverestModuleDataSerializer
    {
        public static EverestModuleDataSerializer Shared { get; } = new();

        private static readonly ISerializer yaml = new SerializerBuilder()
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.Preserve).Build();

        public void DeserializeInto(object target, Type type, byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                if (target is EverestModuleBinarySaveData save)
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        save.Read(reader);
                    }
                }
                else if (target is EverestModuleBinarySession session)
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        session.Read(reader);
                    }
                }
                else
                {
                    var fallback = new DefaultObjectFactory();
                    var reader = new DeserializerBuilder().IgnoreUnmatchedProperties()
                        .WithObjectFactory(t => t == target.GetType() ? target : fallback.Create(t)).Build();
                    using (var text = new StreamReader(stream))
                    {
                        reader.Deserialize(text, type);
                    }
                }
            }
        }

        public byte[] Serialize(object value, Type type)
        {
            using (var stream = new MemoryStream())
            {
                if (value is EverestModuleBinarySaveData save)
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                    {
                        save.Write(writer);
                    }
                else if (value is EverestModuleBinarySession session)
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                    {
                        session.Write(writer);
                    }
                else
                    using (var writer = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
                    {
                        yaml.Serialize(writer, value, type);
                    }

                return stream.ToArray();
            }
        }
    }
}
