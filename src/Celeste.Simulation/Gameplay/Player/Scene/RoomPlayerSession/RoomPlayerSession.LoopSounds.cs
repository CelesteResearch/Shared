using System.Numerics;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private void UpdateSourceWallSlideSound()
        {
            if (Sprite.CurrentAnimationID != null && Sprite.CurrentAnimationID.Equals("wallslide")
                                                  && Data.Motion.Normal.Speed.Y > 0f)
            {
                if (!WallSlideSoundComponent.Playing)
                    Loop(WallSlideSoundComponent, "event:/char/madeline/wallslide");
                var platform = FrameCallbackPlatform(Center + Vector2.UnitX * Data.Facing, "Celeste.Solid");
                if (platform.HasValue)
                    WallSlideSoundComponent.Param("surface_index", platform.GetWallSoundIndex(this, Data.Facing));
            }
            else Stop(WallSlideSoundComponent);
        }

        private void UpdateSourceSwimSurfaceSound()
        {
            if (Data.Motion.Normal.Speed.X != 0f
                && ((Machine.State == 3 && !World.SwimUnderwaterCheck())
                    || (Machine.State == 0 && SourceTrackedEntityCollision.CheckAt(
                        ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Water", this, Position))))
            {
                if (!SwimSurfaceSoundComponent.Playing)
                    SwimSurfaceSoundComponent.Play("event:/char/madeline/water_move_shallow");
            }
            else SwimSurfaceSoundComponent.Stop();
        }
    }
}
