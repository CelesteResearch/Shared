using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Structure;
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
                Vector2 absoluteCenter = ((ISourceWaterCollisionInteraction)component).AbsoluteCenter;
                var entity = (ISourceEntityCollider)component.Entity;
                bool flag = contains.Contains(component);
                bool flag2 = ((ISourceWaterCollisionInteraction)component).Check(this);
                if (flag != flag2)
                {
                    if (absoluteCenter.Y <= base.Center.Y && TopSurface != null)
                    {
                        TopSurface.DoRipple(absoluteCenter, 1f);
                    }
                    else if (absoluteCenter.Y > base.Center.Y && BottomSurface != null)
                    {
                        BottomSurface.DoRipple(absoluteCenter, 1f);
                    }

                    bool flag3 = component.IsDashing();
                    int num = ((absoluteCenter.Y < base.Center.Y &&
                                !_IsShallowAtRectangle(((ISourceWaterCollisionInteraction)component).Bounds))
                        ? 1
                        : 0);
                    if (flag)
                    {
                        if (flag3)
                        {
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_dash_out",
                                absoluteCenter, ((IOriginalGameplayProcess)engine).SaveContext, "deep", num);
                        }
                        else
                        {
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_out",
                                absoluteCenter, ((IOriginalGameplayProcess)engine).SaveContext, "deep", num);
                        }

                        component.DrippingTimer = 2f;
                    }
                    else
                    {
                        if (flag3 && num == 1)
                        {
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_dash_in",
                                absoluteCenter, ((IOriginalGameplayProcess)engine).SaveContext, "deep", num);
                        }
                        else
                        {
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_in",
                                absoluteCenter, ((IOriginalGameplayProcess)engine).SaveContext, "deep", num);
                        }

                        component.DrippingTimer = 0f;
                    }

                    if (flag)
                    {
                        contains.Remove(component);
                    }
                    else
                    {
                        contains.Add(component);
                    }
                }

                if (BottomSurface == null || !(component.Entity is Player))
                {
                    continue;
                }

                if (flag2 && entity.Position.Y > base.Bottom - 8f)
                {
                    if (playerBottomTension == null)
                    {
                        playerBottomTension = BottomSurface.SetTension(entity.Position, 0f);
                    }

                    playerBottomTension.Position = BottomSurface.GetPointAlong(entity.Position);
                    playerBottomTension.Strength =
                        ScalarMath.ClampedMap(entity.Position.Y, base.Bottom - 8f, base.Bottom + 4f);
                }
                else if (playerBottomTension != null)
                {
                    BottomSurface.RemoveTension(playerBottomTension);
                    playerBottomTension = null;
                }
            }
        }

        private bool _IsShallowAtRectangle(Rectangle rectangle)
            => SourceSceneCollision.CheckLine(((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                new Vector2(rectangle.Left, Top + 8f), new Vector2(rectangle.Right, Top + 8f));
    }
}
