using System;

namespace Celeste.Scene.Tracking
{
    // A metadata binding to an actual CLR Type, never a replacement System.Type.
    public sealed class SceneRuntimeTypeRegistration
    {
        public string RuntimeFullName { get; }
        public string SourceType { get; }
        public Type ActualType { get; }
        public bool HasActualType => ActualType != null;

        internal SceneRuntimeTypeRegistration(string runtimeFullName, string sourceType, Type actualType)
        {
            RuntimeFullName = runtimeFullName;
            SourceType = sourceType;
            ActualType = actualType;
        }

        public Type RequireActualType()
        {
            if (ActualType == null)
                throw new InvalidOperationException("No actual CLR Type has been published for " + RuntimeFullName);
            return ActualType;
        }
    }
}
