using System;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Dialogs;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed partial class EverestDecalRegistry
    {
        public void Apply(SourceDecalEntityState decal)
        {
            string path = decal.Name.ToLower();
            if (path.StartsWith("decals/", StringComparison.Ordinal)) path = path.Substring(7);
            if (!RegisteredDecals.TryGetValue(path, out var info)) return;
            decal.RemoveImage();
            foreach (var handler in info.Handlers)
            {
                try
                {
                    handler.ApplyTo(decal);
                }
                catch (Exception exception)
                {
                    ((ILevelEntryErrorEnvironment)engine).LevelEntryErrors.ErrorMessage =
                        ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("postcard_decalregerror")
                        .Replace("((property))", handler.Name).Replace("((decal))", path);
                    logger.DecalApplyFailed(handler, path);
                    logger.LogDetailed(exception);
                }
            }

            RegistryApplied?.Invoke(decal, info);
            decal.EnsureDefaultImage();
        }
    }
}
