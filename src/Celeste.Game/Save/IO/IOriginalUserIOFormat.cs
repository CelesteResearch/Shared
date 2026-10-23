using System.IO;

namespace Celeste.Game.Save.IO
{
// The serializer implementation belongs to the selected file-format project.
// UserIO owns the source storage and retry algorithms, independently of the wire types.
    public interface IOriginalUserIOFormat
    {
        byte[] Serialize<T>(T instance);
        T Deserialize<T>(Stream stream) where T : class;
        bool ValidatePersisted<T>(Stream stream) where T : class;
    }
}
