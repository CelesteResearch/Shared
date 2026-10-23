using System;
using Celeste.Game.Audio;
using Celeste.Everest.Audio;
using Celeste.Game.Profiles;

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
                sourceSfx = new OriginalSfxProcess(SourceMembers);
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourceSfx = new EverestSfxProcess(SourceMembers);
            else
                throw new InvalidOperationException("The source profile has not been selected.");
            global::Celeste.Game.Reflection.Bindings.SourceSfxPhysicalMemberBindings.Register(
                SourceMembers, sourceSfx, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        }
    }
}
