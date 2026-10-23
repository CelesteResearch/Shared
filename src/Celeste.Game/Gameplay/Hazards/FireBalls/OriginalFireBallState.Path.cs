using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Components.Oscillation;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Audio.Sources;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public partial class OriginalFireBallState
    {
        protected Vector2 GetPercentPosition(float percent)
        {
            if (percent <= 0f)
            {
                return nodes[0];
            }

            if (percent >= 1f)
            {
                return nodes[nodes.Length - 1];
            }

            float num = lengths[lengths.Length - 1];
            float num2 = num * percent;
            int i;
            for (i = 0; i < lengths.Length - 1 && !(lengths[i + 1] > num2); i++)
            {
            }

            if (engine.FireBallPath.TryGetPastFinalPosition(nodes, i, lengths.Length, out Vector2 finalPosition))
                return finalPosition;
            float min = lengths[i] / num;
            float max = lengths[i + 1] / num;
            float num3 = ScalarMath.ClampedMap(percent, min, max);
            return Vector2Interpolation.Lerp(nodes[i], nodes[i + 1], num3, engine.ScalarArithmetic);
        }
    }
}
