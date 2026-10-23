using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        internal void CreateTrail()
        {
            Vector2 scale = new(Math.Abs(Sprite.Scale.X) * Data.Facing, Sprite.Scale.Y);
            var color = GetTrailColor(Data.WasDashB);
            TrailManagerState.Add(EngineContext, (ISourceRenderEnvironment)EngineContext, this, scale, color);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
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
