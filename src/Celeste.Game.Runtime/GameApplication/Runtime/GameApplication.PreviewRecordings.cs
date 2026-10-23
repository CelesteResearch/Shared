using System;
using Celeste.Game.Diagnostics.Scenes;
using Celeste.Game.Profiles;
using Celeste.Everest.Diagnostics.Scenes;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalPreviewRecordingEnvironment
    {
        private IOriginalPreviewRecordingFactory sourcePreviewRecordings;

        public IOriginalPreviewRecordingFactory PreviewRecordings => sourcePreviewRecordings ??
                                                                     throw new InvalidOperationException(
                                                                         "The actual source recording preview factory has not been constructed.");

        internal void ConstructSourcePreviewRecordings()
        {
            if (sourcePreviewRecordings != null)
                throw new InvalidOperationException(
                    "The actual source recording preview factory is already constructed.");
            if (SourceProfile == GameProfile.Original)
                sourcePreviewRecordings = new OriginalPreviewRecordingFactory();
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourcePreviewRecordings = new EverestPreviewRecordingFactory();
            else
                throw new InvalidOperationException("The actual source profile has not been selected.");
        }
    }
}
