using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using System;
using System.Collections.Generic;
using System.Numerics;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;

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
            Nodes = new List<SourceEverestVirtualAxis.Node>();
        }

        public SourceEverestVirtualIntegerAxis(SourceMInputProcess process, SourceInputBinding negative,
            SourceInputBinding negativeAlt, SourceInputBinding positive, SourceInputBinding positiveAlt,
            int gamepadIndex,
            float threshold, OverlapBehaviors overlapBehavior = OverlapBehaviors.TakeNewer) : base(process, negative,
            negativeAlt, positive, positiveAlt, gamepadIndex, threshold, overlapBehavior)
        {
            Nodes = new List<SourceEverestVirtualAxis.Node>();
        }

        public override void Update()
        {
            foreach (SourceEverestVirtualAxis.Node node in Nodes)
            {
                node.Update();
            }

            base.Update();
            if (Process.Disabled)
            {
                return;
            }

            foreach (SourceEverestVirtualAxis.Node node2 in Nodes)
            {
                float value = node2.Value;
                if (value != 0f)
                {
                    Value = Math.Sign(value);
                    if (Inverted)
                    {
                        Value *= -1;
                    }

                    break;
                }
            }
        }
    }
}
