using System;
using System.Collections.Generic;
using Celeste.Input.Bindings;
using Celeste.Input.Runtime;

namespace Celeste.Everest.Input
{
    public class SourceEverestVirtualIntegerAxis : SourceVirtualIntegerAxis
    {
        public List<SourceEverestVirtualAxis.Node> Nodes;

        public SourceEverestVirtualIntegerAxis(SourceMInputProcess process, SourceInputBinding negative,
            SourceInputBinding positive, int gamepadIndex, float threshold,
            OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer) : base(process, negative, positive,
            gamepadIndex,
            threshold, overlapBehavior)
        {
            Nodes = [];
        }

        public SourceEverestVirtualIntegerAxis(SourceMInputProcess process, SourceInputBinding negative,
            SourceInputBinding negativeAlt, SourceInputBinding positive, SourceInputBinding positiveAlt,
            int gamepadIndex,
            float threshold, OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer) : base(process, negative,
            negativeAlt, positive, positiveAlt, gamepadIndex, threshold, overlapBehavior)
        {
            Nodes = [];
        }

        public override void Update()
        {
            foreach (var node in Nodes) node.Update();

            base.Update();
            if (Process.Disabled) return;

            foreach (var node2 in Nodes)
            {
                var value = node2.Value;
                if (value != 0f)
                {
                    Value = Math.Sign(value);
                    if (Inverted) Value *= -1;

                    break;
                }
            }
        }
    }
}
