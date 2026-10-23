using System;

namespace Celeste.Everest.Modules.Persistence
{
    public interface IEverestModuleDataSerializer
    {
        void DeserializeInto(object target, Type type, byte[] data);
        byte[] Serialize(object value, Type type);
    }
}
