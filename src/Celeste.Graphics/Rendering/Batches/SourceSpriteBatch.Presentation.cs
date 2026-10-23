using System;

namespace Celeste.Graphics.Rendering.Batches
{
    public partial class SourceSpriteBatch
    {
        public global::Celeste.Graphics.Diagnostics.Presentation.SourceSpritePresentationCapture PresentationCapture
        {
            get;
            set;
        }

        public global::Celeste.Graphics.Diagnostics.Presentation.SourceSpritePresentationCapture
            ActivePresentationCapture
            => PresentationCapture?.IsRecording == true ? PresentationCapture : null;

        private global::Celeste.Core.Rendering.Observation.SourceRenderObservationScope[] presentationScopes;
        private global::Celeste.Core.Rendering.Observation.SourceRenderObservationScope[] sortedPresentationScopes;

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
