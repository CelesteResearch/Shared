using Celeste.Core.Display;
using System.Numerics;
using Celeste.Graphics.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public sealed class ScreenWipeProcessState
    {
        public PackedColor WipeColor = PackedColor.Black;
        internal DreamWipePresentation.Circle[] DreamCircles;
        internal SourceVertexPositionColor[] DreamVertices;
        private bool starfieldInitialized;
        private SourceBlendState starfieldSubtractBlendmode;
        public SourceBlendState StarfieldSubtractBlendmode => starfieldSubtractBlendmode;

        internal void InitializeStarfield()
        {
            if (starfieldInitialized) return;
            starfieldSubtractBlendmode = new SourceBlendState
            {
                ColorSourceBlend = SourceBlendFactor.One,
                ColorDestinationBlend = SourceBlendFactor.One,
                ColorBlendFunction = SourceBlendFunction.ReverseSubtract,
                AlphaSourceBlend = SourceBlendFactor.One,
                AlphaDestinationBlend = SourceBlendFactor.One,
                AlphaBlendFunction = SourceBlendFunction.Add
            };
            starfieldInitialized = true;
        }

        private Vector2 spotlightFocusPoint;
        private float spotlightModifier;

        public Vector2 SpotlightFocusPoint
        {
            get
            {
                InitializeSpotlight();
                return spotlightFocusPoint;
            }
            set
            {
                InitializeSpotlight();
                spotlightFocusPoint = value;
            }
        }

        public float SpotlightModifier
        {
            get
            {
                InitializeSpotlight();
                return spotlightModifier;
            }
            set
            {
                InitializeSpotlight();
                spotlightModifier = value;
            }
        }

        internal SourceVertexPositionColor[] SpotlightVertices;

        internal void InitializeSpotlight()
        {
            if (SpotlightVertices == null)
                SpotlightVertices = new SourceVertexPositionColor[768];
        }
    }
}
