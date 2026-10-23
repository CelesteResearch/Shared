using System;
using System.Numerics;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.DreamBlock;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        internal bool DreamDashCheck(Vector2 dir)
        {
            if (Inventory.DreamDash && DashAttacking &&
                (dir.X == (float)Math.Sign(Data.Direction.X) ||
                 dir.Y == (float)Math.Sign(Data.Direction.Y)))
            {
                ISourceDreamBlock dreamBlock = SourceTrackedEntityCollision.FirstAt<ISourceDreamBlock>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.DreamBlock", this, Position + dir);
                if (dreamBlock != null)
                {
                    if (SourceTrackedEntityCollision.CheckAtExcept(
                            ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", "Celeste.DreamBlock", this,
                            Position + dir))
                    {
                        Vector2 vector = new Vector2(Math.Abs(dir.Y), Math.Abs(dir.X));
                        bool flag;
                        bool flag2;
                        if (dir.X != 0f)
                        {
                            flag = Data.Motion.Normal.Speed.Y <= 0f;
                            flag2 = Data.Motion.Normal.Speed.Y >= 0f;
                        }
                        else
                        {
                            flag = Data.Motion.Normal.Speed.X <= 0f;
                            flag2 = Data.Motion.Normal.Speed.X >= 0f;
                        }

                        if (flag)
                        {
                            for (int num = -1; num >= -4; num--)
                            {
                                Vector2 at = Position + dir + vector * num;
                                if (!SourceTrackedEntityCollision.CheckAtExcept(
                                        ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                                        "Celeste.DreamBlock",
                                        this, at))
                                {
                                    Position += vector * num;
                                    this.dreamBlock = dreamBlock;
                                    return true;
                                }
                            }
                        }

                        if (flag2)
                        {
                            for (int i = 1; i <= 4; i++)
                            {
                                Vector2 at2 = Position + dir + vector * i;
                                if (!SourceTrackedEntityCollision.CheckAtExcept(
                                        ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                                        "Celeste.DreamBlock",
                                        this, at2))
                                {
                                    Position += vector * i;
                                    this.dreamBlock = dreamBlock;
                                    return true;
                                }
                            }
                        }

                        return false;
                    }

                    this.dreamBlock = dreamBlock;
                    return true;
                }
            }

            return false;
        }
    }
}
