using System;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private IOriginalAreaDataResolver sourceAreas;

        public IOriginalAreaDataResolver AreaDataResolver => sourceAreas ??
                                                             throw new InvalidOperationException(
                                                                 "The actual Level area resolver is not bound.");

        public IOriginalAreaData AreaData => AreaDataResolver.Get(Session.AreaID);

        public void BindSourceAreaDataResolver(IOriginalAreaDataResolver areas)
        {
            if (areas == null) throw new ArgumentNullException(nameof(areas));
            if (sourceAreas != null)
                throw new InvalidOperationException("The actual Level area resolver is already bound.");
            sourceAreas = areas;
        }
    }
}
