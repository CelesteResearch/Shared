using Celeste.Formats.Save.Serialization;

namespace Celeste.Game.Save.Formats.Original
{
    public sealed class OriginalSaveXmlFormatPolicy : IOriginalSaveXmlFormatPolicy
    {
        private static readonly ISaveXmlSerializer Serializer = new SaveXmlSerializer(false);

        public ISaveXmlSerializer CreateSerializer()
        {
            return Serializer;
        }
    }
}
