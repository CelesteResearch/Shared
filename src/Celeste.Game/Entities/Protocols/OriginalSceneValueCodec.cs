using System;
using Celeste.Scene.Scheduling;

namespace Celeste.Game.Entities.Protocols
{
    public static class OriginalSceneValueCodec
    {
        public static Type ProtocolType(Type storageType)
        {
            return storageType == typeof(SceneTagSet) ? typeof(OriginalSceneEntityTags)
                : storageType == typeof(SceneModeKey) ? typeof(OriginalSceneUpdateMode) : null;
        }

        public static object ToProtocol(object value)
        {
            return value is SceneTagSet tags ? (OriginalSceneEntityTags)(int)tags
                : value is SceneModeKey mode ? (OriginalSceneUpdateMode)mode.Value : value;
        }

        public static bool TryFromProtocol(object value, Type storageType, out object converted)
        {
            var protocolType = ProtocolType(storageType);
            if (protocolType == null)
            {
                converted = null;
                return false;
            }

            if (storageType.IsInstanceOfType(value))
            {
                converted = value;
                return true;
            }

            var bits = value == null ? 0 : Convert.ToInt32(Enum.Parse(protocolType, value.ToString(), true));
            converted = storageType == typeof(SceneTagSet) ? new SceneTagSet(bits) : new SceneModeKey(bits);
            return true;
        }
    }
}
