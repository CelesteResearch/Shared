using System;
using Celeste.Everest.Audio;
using Celeste.Game.Audio;
using Celeste.Game.Profiles;
using Celeste.Game.Reflection.Bindings;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSfxEnvironment
    {
        private OriginalSfxProcess sourceSfx;

        public OriginalSfxProcess Sfx => sourceSfx ??
                                         throw new InvalidOperationException(
                                             "The source SFX process has not been published.");

        public void ConstructSourceSfxProcess()
        {
            if (sourceSfx != null) throw new InvalidOperationException("The source SFX process is already published.");
            if (SourceProfile == GameProfile.Original)
                sourceSfx = new(SourceMembers);
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourceSfx = new EverestSfxProcess(SourceMembers);
            else
                throw new InvalidOperationException("The source profile has not been selected.");
            SourceSfxPhysicalMemberBindings.Register(
                SourceMembers, sourceSfx, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        }
    }
}
