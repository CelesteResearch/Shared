using Celeste.Core.Components;
using Celeste.Core.Maps;

namespace Celeste.Scene.Entities
{
    public partial class SceneEntityState : ISourceEntitySourceData
    {
        private readonly ISourceEntitySourceDataRegistration sourceDataRegistration;
        private object sourceData;

        public object SourceData
        {
            get => sourceData;
            set
            {
                sourceDataRegistration.Register(this, value);
                sourceData = value;
            }
        }

        public MapEntityId SourceId;

        MapEntityId ISourceEntitySourceData.SourceId
        {
            get => SourceId;
            set => SourceId = value;
        }
    }
}
