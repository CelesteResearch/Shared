using System;
using Celeste.Core.Rendering.Observation;
using Celeste.Graphics.Diagnostics.Presentation;

namespace Celeste.Graphics.Rendering.Batches
{
    public partial class SourceSpriteBatch
    {
        public SourceSpritePresentationCapture PresentationCapture { get; set; }

        public SourceSpritePresentationCapture
            ActivePresentationCapture
            => PresentationCapture?.IsRecording == true ? PresentationCapture : null;

        private SourceRenderObservationScope[] presentationScopes;
        private SourceRenderObservationScope[] sortedPresentationScopes;

        private void EnsurePresentationScopes()
        {
            if (presentationScopes == null || presentationScopes.Length < vertexInfo.Length)
            {
                Array.Resize(ref presentationScopes, vertexInfo.Length);
                Array.Resize(ref sortedPresentationScopes, vertexInfo.Length);
            }
        }
    }
}
