using System;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Stars
{
    public readonly struct StarfieldBackdropLayout
    {
        public readonly BackdropViewport Viewport;
        public readonly int NodeCount, ClosingNodeCount;
        public readonly float NodeSpacing, NodeDriftMinimum, NodeDriftRange, VerticalMargin;
        public readonly float HorizontalPeriod, VerticalPeriod, HorizontalMargin;

        public StarfieldBackdropLayout(BackdropViewport viewport, int nodeCount, int closingNodeCount,
            float nodeSpacing, float nodeDriftMinimum, float nodeDriftRange, float verticalMargin)
        {
            if (viewport.Width <= 0 || viewport.Height <= 0) throw new ArgumentOutOfRangeException(nameof(viewport));
            if (nodeCount < 2) throw new ArgumentOutOfRangeException(nameof(nodeCount));
            if (closingNodeCount < 0 || closingNodeCount >= nodeCount)
                throw new ArgumentOutOfRangeException(nameof(closingNodeCount));
            if (nodeSpacing <= 0f) throw new ArgumentOutOfRangeException(nameof(nodeSpacing));
            if (nodeDriftMinimum < 0f) throw new ArgumentOutOfRangeException(nameof(nodeDriftMinimum));
            if (nodeDriftRange < 0f) throw new ArgumentOutOfRangeException(nameof(nodeDriftRange));
            if (verticalMargin < 0f) throw new ArgumentOutOfRangeException(nameof(verticalMargin));

            Viewport = viewport;
            NodeCount = nodeCount;
            ClosingNodeCount = closingNodeCount;
            NodeSpacing = nodeSpacing;
            NodeDriftMinimum = nodeDriftMinimum;
            NodeDriftRange = nodeDriftRange;
            VerticalMargin = verticalMargin;
            HorizontalPeriod = (nodeCount - 1) * nodeSpacing;
            VerticalPeriod = viewport.Height + verticalMargin * 2f;
            HorizontalMargin = (HorizontalPeriod - viewport.Width) / 2f;
            if (HorizontalMargin < 0f) throw new ArgumentOutOfRangeException(nameof(nodeCount));
        }
    }
}
