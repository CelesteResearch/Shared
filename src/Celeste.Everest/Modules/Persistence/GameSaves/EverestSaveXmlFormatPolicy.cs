using Celeste.Formats.Save.Serialization;
using Celeste.Game.Save.Formats.Original;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed class EverestSaveXmlFormatPolicy : IOriginalSaveXmlFormatPolicy
    {
        private static readonly ISaveXmlSerializer Serializer = new SaveXmlSerializer();
        public ISaveXmlSerializer CreateSerializer() => Serializer;
    }
}
