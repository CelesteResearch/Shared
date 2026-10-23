using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;

namespace Celeste.Everest.Content.Serialization
{
    public sealed class EverestYamlProcess
    {
        public IDeserializer Deserializer = EverestYamlDeserializerBuilder.Create().IgnoreUnmatchedProperties().Build();

        public ISerializer Serializer =
            new SerializerBuilder().ConfigureDefaultValuesHandling(DefaultValuesHandling.Preserve).Build();

        public IDeserializer DeserializerUsing(object objectToBind)
        {
            IObjectFactory defaultObjectFactory = new DefaultObjectFactory();
            var objectType = objectToBind.GetType();
            return EverestYamlDeserializerBuilder.Create().IgnoreUnmatchedProperties().WithObjectFactory(type =>
                !(type == objectType) ? defaultObjectFactory.Create(type) : objectToBind).Build();
        }
    }
}
