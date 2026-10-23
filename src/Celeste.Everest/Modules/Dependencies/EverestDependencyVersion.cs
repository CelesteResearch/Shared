using System;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Dependencies
{
    public static class EverestDependencyVersion
    {
        // Everest.Loader.VersionSatisfiesDependency, installed runtime implementation.
        public static bool Satisfies(Version requiredVersion, Version installedVersion)
        {
            if (installedVersion.Major == 0 && installedVersion.Minor == 0) return true;
            if (installedVersion.Major != requiredVersion.Major) return false;
            if (installedVersion.Minor < requiredVersion.Minor) return false;
            if (installedVersion.Minor == requiredVersion.Minor &&
                installedVersion.Build < requiredVersion.Build) return false;
            if (installedVersion.Minor == requiredVersion.Minor && installedVersion.Build == requiredVersion.Build &&
                installedVersion.Revision < requiredVersion.Revision) return false;
            return true;
        }
    }
}
