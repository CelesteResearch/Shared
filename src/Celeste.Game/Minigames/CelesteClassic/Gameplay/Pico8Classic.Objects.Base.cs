// ---------------------------------------------------------------------------------------------
// Port of Celeste.Pico8.Classic (Artifacts/Reference/Original/Celeste.Pico8/Classic.cs, 1943
// lines): the Celeste Classic cart that runs inside the Pico-8 fantasy console.
//
// This file is the original cart source mechanically rewritten at the engine boundary only (see
// tools/Transform-Classic.ps1); every statement, expression, literal, field, method, nested type
// and evaluation order is the original's:
//   Classic                  -> Pico8Classic
//   ClassicObject            -> Pico8ClassicObject
//   Emulator                 -> Pico8Emulator
//   Microsoft.Xna.Framework  -> System.Numerics (Vector2) + Celeste.Simulation.Rendering (IntRect)
//   XNA Rectangle            -> IntRect                       (same X/Y/Width/Height fields)
//   XNA Point                -> Pico8Point                    (same X/Y fields)
//   Stats.Increment(Stat.X)  -> G.IncrementStat(Pico8Stat.X)  (Celeste.Stats is a game-global)
//   Achievements.Register(..)-> G.UnlockAchievement(..)       (game-global unlock service)
//   Settings.Instance.ScreenShake -> E.ScreenShake (Pico8ShakeAmount, Celeste.ScreenshakeAmount)
// ---------------------------------------------------------------------------------------------

using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Game.Minigames.CelesteClassic.Emulation;

namespace Celeste.Game.Minigames.CelesteClassic.Gameplay
{
    public sealed partial class Pico8Classic
    {
        public class Pico8ClassicObject
        {
            public Pico8Classic G;

            public ClassicConsoleRuntime E;

            public int type;

            public bool collideable = true;

            public bool solids = true;

            public float spr;

            public bool flipX;

            public bool flipY;

            public float x;

            public float y;

            public IntRect hitbox = new(0, 0, 8, 8);

            public Vector2 spd = new(0f, 0f);

            public Vector2 rem = new(0f, 0f);

            public virtual void init(Pico8Classic g,
                ClassicConsoleRuntime e)
            {
                G = g;
                E = e;
            }

            public virtual void update()
            {
            }

            public virtual void draw()
            {
                if (spr > 0f) E.spr(spr, x, y, 1, 1, flipX, flipY);
            }

            public bool is_solid(int ox, int oy)
            {
                if (oy > 0 && !check<platform>(ox, 0) && check<platform>(ox, oy)) return true;

                if (!G.solid_at(x + hitbox.X + ox, y + hitbox.Y + oy, hitbox.Width,
                        hitbox.Height) && !check<fall_floor>(ox, oy))
                    return check<fake_wall>(ox, oy);

                return true;
            }

            public bool is_ice(int ox, int oy)
            {
                return G.ice_at(x + hitbox.X + ox, y + hitbox.Y + oy, hitbox.Width,
                    hitbox.Height);
            }

            public T collide<T>(int ox, int oy) where T : Pico8ClassicObject
            {
                var typeFromHandle = typeof(T);
                foreach (var @object in G.objects)
                    if (@object != null && @object.GetType() == typeFromHandle && @object != this &&
                        @object.collideable &&
                        @object.x + @object.hitbox.X + @object.hitbox.Width >
                        x + hitbox.X + ox &&
                        @object.y + @object.hitbox.Y + @object.hitbox.Height >
                        y + hitbox.Y + oy &&
                        @object.x + @object.hitbox.X < x + hitbox.X + hitbox.Width + ox &&
                        @object.y + @object.hitbox.Y < y + hitbox.Y + hitbox.Height + oy)
                        return @object as T;

                return null;
            }

            public bool check<T>(int ox, int oy) where T : Pico8ClassicObject
            {
                return collide<T>(ox, oy) != null;
            }

            public void move(float ox, float oy)
            {
                var num = 0;
                rem.X += ox;
                num = E.flr(rem.X + 0.5f);
                rem.X -= num;
                move_x(num, 0);
                rem.Y += oy;
                num = E.flr(rem.Y + 0.5f);
                rem.Y -= num;
                move_y(num);
            }

            public void move_x(int amount, int start)
            {
                if (solids)
                {
                    var num = G.sign(amount);
                    for (var i = start; i <= E.abs(amount); i++)
                    {
                        if (!is_solid(num, 0))
                        {
                            x += num;
                            continue;
                        }

                        spd.X = 0f;
                        rem.X = 0f;
                        break;
                    }
                }
                else
                {
                    x += amount;
                }
            }

            public void move_y(int amount)
            {
                if (solids)
                {
                    var num = G.sign(amount);
                    for (var i = 0; i <= E.abs(amount); i++)
                    {
                        if (!is_solid(0, num))
                        {
                            y += num;
                            continue;
                        }

                        spd.Y = 0f;
                        rem.Y = 0f;
                        break;
                    }
                }
                else
                {
                    y += amount;
                }
            }
        }
    }
}
