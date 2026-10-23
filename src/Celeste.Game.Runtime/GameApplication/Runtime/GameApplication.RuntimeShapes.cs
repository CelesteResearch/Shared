using System;
using Celeste.Core.Reflection.RuntimeShapes;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceRuntimeShapeEnvironment
    {
        private SourceRuntimeShapeCatalog sourceRuntimeShapes;

        public SourceRuntimeShapeCatalog SourceRuntimeShapes => sourceRuntimeShapes ??
                                                                throw new InvalidOperationException(
                                                                    "The actual source runtime shapes have not been constructed.");

        internal void ConstructSourceRuntimeShapes()
        {
            if (sourceRuntimeShapes != null)
                throw new InvalidOperationException("The actual source runtime shapes are already constructed.");
            sourceRuntimeShapes = new SourceRuntimeShapeCatalog(SourceMembers);
        }
    }
}
