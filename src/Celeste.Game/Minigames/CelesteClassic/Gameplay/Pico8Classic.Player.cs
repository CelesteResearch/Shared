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

using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Minigames.CelesteClassic.Gameplay
{
    public sealed partial class Pico8Classic
    {
        public class player : Pico8ClassicObject
        {
            public bool p_jump;

            public bool p_dash;

            public int grace;

            public int jbuffer;

            public int djump;

            public int dash_time;

            public int dash_effect_time;

            public Vector2 dash_target = new Vector2(0f, 0f);

            public Vector2 dash_accel = new Vector2(0f, 0f);

            public float spr_off;

            public bool was_on_ground;

            public player_hair hair;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                spr = 1f;
                djump = g.max_djump;
                hitbox = new global::Celeste.Core.Geometry.IntRect(1, 3, 6, 5);
            }

            public override void update()
            {
                if (G.pause_player)
                {
                    return;
                }

                int num = (E.btn(G.k_right) ? 1 : (E.btn(G.k_left) ? (-1) : 0));
                if (G.spikes_at(x + (float)hitbox.X, y + (float)hitbox.Y, hitbox.Width, hitbox.Height, spd.X, spd.Y))
                {
                    G.kill_player(this);
                }

                if (y > 128f)
                {
                    G.kill_player(this);
                }

                bool flag2 = is_solid(0, 1);
                bool flag3 = is_ice(0, 1);
                if (flag2 && !was_on_ground)
                {
                    G.init_object(new smoke(), x, y + 4f);
                }

                bool num2 = E.btn(G.k_jump) && !p_jump;
                p_jump = E.btn(G.k_jump);
                if (num2)
                {
                    jbuffer = 4;
                }
                else if (jbuffer > 0)
                {
                    jbuffer--;
                }

                bool flag4 = E.btn(G.k_dash) && !p_dash;
                p_dash = E.btn(G.k_dash);
                if (flag2)
                {
                    grace = 6;
                    if (djump < G.max_djump)
                    {
                        G.psfx(54);
                        djump = G.max_djump;
                    }
                }
                else if (grace > 0)
                {
                    grace--;
                }

                dash_effect_time--;
                if (dash_time > 0)
                {
                    G.init_object(new smoke(), x, y);
                    dash_time--;
                    spd.X = G.appr(spd.X, dash_target.X, dash_accel.X);
                    spd.Y = G.appr(spd.Y, dash_target.Y, dash_accel.Y);
                }
                else
                {
                    int num3 = 1;
                    float amount = 0.6f;
                    float amount2 = 0.15f;
                    if (!flag2)
                    {
                        amount = 0.4f;
                    }
                    else if (flag3)
                    {
                        amount = 0.05f;
                        if (num == ((!flipX) ? 1 : (-1)))
                        {
                            amount = 0.05f;
                        }
                    }

                    if (E.abs(spd.X) > (float)num3)
                    {
                        spd.X = G.appr(spd.X, E.sign(spd.X) * num3, amount2);
                    }
                    else
                    {
                        spd.X = G.appr(spd.X, num * num3, amount);
                    }

                    if (spd.X != 0f)
                    {
                        flipX = spd.X < 0f;
                    }

                    float target = 2f;
                    float num4 = 0.21f;
                    if (E.abs(spd.Y) <= 0.15f)
                    {
                        num4 *= 0.5f;
                    }

                    if (num != 0 && is_solid(num, 0) && !is_ice(num, 0))
                    {
                        target = 0.4f;
                        if (E.rnd(10f) < 2f)
                        {
                            G.init_object(new smoke(), x + (float)(num * 6), y);
                        }
                    }

                    if (!flag2)
                    {
                        spd.Y = G.appr(spd.Y, target, num4);
                    }

                    if (jbuffer > 0)
                    {
                        if (grace > 0)
                        {
                            G.psfx(1);
                            jbuffer = 0;
                            grace = 0;
                            spd.Y = -2f;
                            G.init_object(new smoke(), x, y + 4f);
                        }
                        else
                        {
                            int num5 = (is_solid(-3, 0) ? (-1) : (is_solid(3, 0) ? 1 : 0));
                            if (num5 != 0)
                            {
                                G.psfx(2);
                                jbuffer = 0;
                                spd.Y = -2f;
                                spd.X = -num5 * (num3 + 1);
                                if (!is_ice(num5 * 3, 0))
                                {
                                    G.init_object(new smoke(), x + (float)(num5 * 6), y);
                                }
                            }
                        }
                    }

                    int num6 = 5;
                    float num7 = (float)num6 * 0.70710677f;
                    if (djump > 0 && flag4)
                    {
                        G.init_object(new smoke(), x, y);
                        djump--;
                        dash_time = 4;
                        G.has_dashed = true;
                        dash_effect_time = 10;
                        int num8 = E.dashDirectionX((!flipX) ? 1 : (-1));
                        int num9 = E.dashDirectionY((!flipX) ? 1 : (-1));
                        if (num8 != 0 && num9 != 0)
                        {
                            spd.X = (float)num8 * num7;
                            spd.Y = (float)num9 * num7;
                        }
                        else if (num8 != 0)
                        {
                            spd.X = num8 * num6;
                            spd.Y = 0f;
                        }
                        else if (num9 != 0)
                        {
                            spd.X = 0f;
                            spd.Y = num9 * num6;
                        }
                        else
                        {
                            spd.X = ((!flipX) ? 1 : (-1));
                            spd.Y = 0f;
                        }

                        G.psfx(3);
                        G.freeze = 2;
                        G.shake = 6;
                        dash_target.X = 2 * E.sign(spd.X);
                        dash_target.Y = 2 * E.sign(spd.Y);
                        dash_accel.X = 1.5f;
                        dash_accel.Y = 1.5f;
                        if (spd.Y < 0f)
                        {
                            dash_target.Y *= 0.75f;
                        }

                        if (spd.Y != 0f)
                        {
                            dash_accel.X *= 0.70710677f;
                        }

                        if (spd.X != 0f)
                        {
                            dash_accel.Y *= 0.70710677f;
                        }
                    }
                    else if (flag4 && djump <= 0)
                    {
                        G.psfx(9);
                        G.init_object(new smoke(), x, y);
                    }
                }

                spr_off += 0.25f;
                if (!flag2)
                {
                    if (is_solid(num, 0))
                    {
                        spr = 5f;
                    }
                    else
                    {
                        spr = 3f;
                    }
                }
                else if (E.btn(G.k_down))
                {
                    spr = 6f;
                }
                else if (E.btn(G.k_up))
                {
                    spr = 7f;
                }
                else if (spd.X == 0f || (!E.btn(G.k_left) && !E.btn(G.k_right)))
                {
                    spr = 1f;
                }
                else
                {
                    spr = 1f + spr_off % 4f;
                }

                if (y < -4f && G.level_index() < 30)
                {
                    G.next_room();
                }

                was_on_ground = flag2;
            }

            public override void draw()
            {
                if (x < -1f || x > 121f)
                {
                    x = G.clamp(x, -1f, 121f);
                    spd.X = 0f;
                }

                hair.draw_hair(this, (!flipX) ? 1 : (-1), djump);
                G.draw_player(this, djump);
            }
        }

        public class player_hair
        {
            private class node
            {
                public float x;

                public float y;

                public float size;
            }

            private node[] hair = new node[5];

            private global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime E;

            private global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic G;

            public player_hair(Pico8ClassicObject obj)
            {
                E = obj.E;
                G = obj.G;
                for (int i = 0; i <= 4; i++)
                {
                    hair[i] = new node
                    {
                        x = obj.x,
                        y = obj.y,
                        size = E.max(1f, E.min(2f, 3 - i))
                    };
                }
            }

            public void draw_hair(Pico8ClassicObject obj, int facing, int djump)
            {
                int num = djump switch
                {
                    2 => 7 + E.flr(G.frames / 3 % 2) * 4,
                    1 => 8,
                    _ => 12,
                };
                Vector2 vector = new Vector2(obj.x + 4f - (float)(facing * 2),
                    obj.y + (float)(E.btn(G.k_down) ? 4 : 3));
                node[] array = hair;
                foreach (node node2 in array)
                {
                    node2.x += (vector.X - node2.x) / 1.5f;
                    node2.y += (vector.Y + 0.5f - node2.y) / 1.5f;
                    E.circfill(node2.x, node2.y, node2.size, num);
                    vector = new Vector2(node2.x, node2.y);
                }
            }
        }

        public class player_spawn : Pico8ClassicObject
        {
            private Vector2 target;

            private int state;

            private int delay;

            private player_hair hair;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                spr = 3f;
                target = new Vector2(x, y);
                y = 128f;
                spd.Y = -4f;
                state = 0;
                delay = 0;
                solids = false;
                hair = new player_hair(this);
                E.sfx(4);
            }

            public override void update()
            {
                if (state == 0)
                {
                    if (y < target.Y + 16f)
                    {
                        state = 1;
                        delay = 3;
                    }
                }
                else if (state == 1)
                {
                    spd.Y += 0.5f;
                    if (spd.Y > 0f && delay > 0)
                    {
                        spd.Y = 0f;
                        delay--;
                    }

                    if (spd.Y > 0f && y > target.Y)
                    {
                        y = target.Y;
                        spd = new Vector2(0f, 0f);
                        state = 2;
                        delay = 5;
                        G.shake = 5;
                        G.init_object(new smoke(), x, y + 4f);
                        E.sfx(5);
                    }
                }
                else if (state == 2)
                {
                    delay--;
                    spr = 6f;
                    if (delay < 0)
                    {
                        G.destroy_object(this);
                        G.init_object(new player(), x, y).hair = hair;
                    }
                }
            }

            public override void draw()
            {
                hair.draw_hair(this, 1, G.max_djump);
                G.draw_player(this, G.max_djump);
            }
        }
    }
}
