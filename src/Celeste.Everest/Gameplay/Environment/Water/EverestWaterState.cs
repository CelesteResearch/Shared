using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Environment.Water;
using WaterInteraction = Celeste.Simulation.Gameplay.Environment.Water.WaterInteractionState;
using Player = Celeste.Simulation.RoomPlayerSession;
using Rectangle = Celeste.Core.Geometry.IntRect;

namespace Celeste.Everest.Gameplay.Environment.Water
{
    public class EverestWaterState : OriginalWaterState
    {
        public EverestWaterState(ISourceEngineContext engine, EntityData data, Vector2 offset) : base(engine,
            data, offset)
        {
        }

        public EverestWaterState(ISourceEngineContext engine, Vector2 position, bool topSurface, bool bottomSurface,
            float width, float height)
            : base(engine, position, topSurface, bottomSurface, width, height)
        {
        }

        public override void Update()
        {
            UpdateComponentsAndSurfaces();
            foreach (WaterInteraction component in ((ISourceScene)Scene).SourceScene.Components.GetTrackedComponents(
                         "Celeste.WaterInteraction"))
            {
                var absoluteCenter = ((ISourceWaterCollisionInteraction)component).AbsoluteCenter;
                var entity = (ISourceEntityCollider)component.Entity;
                var flag = contains.Contains(component);
                var flag2 = ((ISourceWaterCollisionInteraction)component).Check(this);
                if (flag != flag2)
                {
                    if (absoluteCenter.Y <= Center.Y && TopSurface != null)
                        TopSurface.DoRipple(absoluteCenter, 1f);
                    else if (absoluteCenter.Y > Center.Y && BottomSurface != null)
                        BottomSurface.DoRipple(absoluteCenter, 1f);

                    var flag3 = component.IsDashing();
                    var num = absoluteCenter.Y < Center.Y &&
                              !_IsShallowAtRectangle(((ISourceWaterCollisionInteraction)component).Bounds)
                        ? 1
                        : 0;
                    if (flag)
                    {
                        if (flag3)
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_dash_out",
                                absoluteCenter, ((IOriginalGameplayProcess)engine).SaveContext, "deep", num);
                        else
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_out",
                                absoluteCenter, ((IOriginalGameplayProcess)engine).SaveContext, "deep", num);

                        component.DrippingTimer = 2f;
                    }
                    else
                    {
                        if (flag3 && num == 1)
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_dash_in",
                                absoluteCenter, ((IOriginalGameplayProcess)engine).SaveContext, "deep", num);
                        else
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_in",
                                absoluteCenter, ((IOriginalGameplayProcess)engine).SaveContext, "deep", num);

                        component.DrippingTimer = 0f;
                    }

                    if (flag)
                        contains.Remove(component);
                    else
                        contains.Add(component);
                }

                if (BottomSurface == null || !(component.Entity is Player)) continue;

                if (flag2 && entity.Position.Y > Bottom - 8f)
                {
                    if (playerBottomTension == null)
                        playerBottomTension = BottomSurface.SetTension(entity.Position, 0f);

                    playerBottomTension.Position = BottomSurface.GetPointAlong(entity.Position);
                    playerBottomTension.Strength =
                        ScalarMath.ClampedMap(entity.Position.Y, Bottom - 8f, Bottom + 4f);
                }
                else if (playerBottomTension != null)
                {
                    BottomSurface.RemoveTension(playerBottomTension);
                    playerBottomTension = null;
                }
            }
        }

        private bool _IsShallowAtRectangle(Rectangle rectangle)
        {
            return SourceSceneCollision.CheckLine(((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                new(rectangle.Left, Top + 8f), new(rectangle.Right, Top + 8f));
        }
    }
}
