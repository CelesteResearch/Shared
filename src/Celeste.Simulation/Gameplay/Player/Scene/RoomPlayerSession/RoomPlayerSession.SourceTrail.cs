using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Graphics.Display;
using Celeste.Core.Rendering;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        internal void CreateTrail()
        {
            Vector2 scale = new(Math.Abs(Sprite.Scale.X) * Data.Facing, Sprite.Scale.Y);
            PackedColor color = GetTrailColor(Data.WasDashB);
            TrailManagerState.Add(engineContext, (ISourceRenderEnvironment)engineContext, this, scale, color);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public PackedColor GetTrailColor(bool wasDashB)
        {
            return Sprite.Mode == PlayerSpriteMode.MadelineAsBadeline
                ? wasDashB ? PlayerHairAppearance.NormalBadelineHairColor : PlayerHairAppearance.UsedHairColor
                : wasDashB
                    ? PlayerHairAppearance.NormalHairColor
                    : PlayerHairAppearance.UsedHairColor;
        }
    }
}
