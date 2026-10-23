using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NodeDeserializers;

namespace Celeste.Everest.Content.Serialization
{
    internal static class EverestYamlDeserializerBuilder
    {
        public static DeserializerBuilder Create()
        {
            ITypeInspector typeInspector = null;
            return new DeserializerBuilder()
                .WithTypeInspector<ITypeInspector>(inspector =>
                {
                    typeInspector = inspector;
                    return inspector;
                })
                .WithNodeDeserializer<NullableArrayNodeDeserializer>(
                    original => new NullableArrayNodeDeserializer(original, typeInspector),
                    location => location.InsteadOf<ArrayNodeDeserializer>());
        }
    }
}
