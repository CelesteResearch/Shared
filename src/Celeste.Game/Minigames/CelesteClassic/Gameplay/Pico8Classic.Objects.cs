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
        public class spring : Pico8ClassicObject
        {
            public int hide_in;

            private int hide_for;

            private int delay;

            public override void update()
            {
                if (hide_for > 0)
                {
                    hide_for--;
                    if (hide_for <= 0)
                    {
                        spr = 18f;
                        delay = 0;
                    }
                }
                else if (spr == 18f)
                {
                    player player2 = collide<player>(0, 0);
                    if (player2 != null && player2.spd.Y >= 0f)
                    {
                        spr = 19f;
                        player2.y = y - 4f;
                        player2.spd.X *= 0.2f;
                        player2.spd.Y = -3f;
                        player2.djump = G.max_djump;
                        delay = 10;
                        G.init_object(new smoke(), x, y);
                        fall_floor fall_floor2 = collide<fall_floor>(0, 1);
                        if (fall_floor2 != null)
                        {
                            G.break_fall_floor(fall_floor2);
                        }

                        G.psfx(8);
                    }
                }
                else if (delay > 0)
                {
                    delay--;
                    if (delay <= 0)
                    {
                        spr = 18f;
                    }
                }

                if (hide_in > 0)
                {
                    hide_in--;
                    if (hide_in <= 0)
                    {
                        hide_for = 60;
                        spr = 0f;
                    }
                }
            }
        }

        public class balloon : Pico8ClassicObject
        {
            private float offset;

            private float start;

            private float timer;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                e.BehaviorHooks?.BeforeBalloonInit(g);
                base.init(g, e);
                offset = E.rnd(1f);
                start = y;
                hitbox = new global::Celeste.Core.Geometry.IntRect(-1, -1, 10, 10);

                e.BehaviorHooks?.AfterBalloonInit();
            }

            public override void update()
            {
                if (spr == 22f)
                {
                    offset += 0.01f;
                    y = start + E.sin(offset) * 2f;
                    player player2 = collide<player>(0, 0);
                    if (player2 != null && player2.djump < G.max_djump)
                    {
                        G.psfx(6);
                        G.init_object(new smoke(), x, y);
                        player2.djump = G.max_djump;
                        spr = 0f;
                        timer = 60f;
                    }
                }
                else if (timer > 0f)
                {
                    timer -= 1f;
                }
                else
                {
                    G.psfx(7);
                    G.init_object(new smoke(), x, y);
                    spr = 22f;
                }
            }

            public override void draw()
            {
                if (spr == 22f)
                {
                    E.spr(13f + offset * 8f % 3f, x, y + 6f);
                    E.spr(spr, x, y);
                }
            }
        }

        public class fall_floor : Pico8ClassicObject
        {
            public int state;

            public bool solid = true;

            public int delay;

            public override void update()
            {
                if (state == 0)
                {
                    if (check<player>(0, -1) || check<player>(-1, 0) || check<player>(1, 0))
                    {
                        G.break_fall_floor(this);
                    }
                }
                else if (state == 1)
                {
                    delay--;
                    if (delay <= 0)
                    {
                        state = 2;
                        delay = 60;
                        collideable = false;
                    }
                }
                else if (state == 2)
                {
                    delay--;
                    if (delay <= 0 && !check<player>(0, 0))
                    {
                        G.psfx(7);
                        state = 0;
                        collideable = true;
                        G.init_object(new smoke(), x, y);
                    }
                }
            }

            public override void draw()
            {
                if (state != 2)
                {
                    if (state != 1)
                    {
                        E.spr(23f, x, y);
                    }
                    else
                    {
                        E.spr(23 + (15 - delay) / 5, x, y);
                    }
                }
            }
        }

        public class smoke : Pico8ClassicObject
        {
            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                spr = 29f;
                spd.Y = -0.1f;
                spd.X = 0.3f + E.rnd(0.2f);
                x += -1f + E.rnd(2f);
                y += -1f + E.rnd(2f);
                flipX = G.maybe();
                flipY = G.maybe();
                solids = false;
            }

            public override void update()
            {
                spr += 0.2f;
                if (spr >= 32f)
                {
                    G.destroy_object(this);
                }
            }
        }

        public class fruit : Pico8ClassicObject
        {
            private float start;

            private float off;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                spr = 26f;
                start = y;
                off = 0f;
            }

            public override void update()
            {
                player player2 = collide<player>(0, 0);
                if (player2 != null)
                {
                    player2.djump = G.max_djump;
                    G.sfx_timer = 20;
                    E.sfx(13);
                    G.got_fruit.Add(1 + G.level_index());
                    G.init_object(new lifeup(), x, y);
                    G.destroy_object(this);
                    E.IncrementStat(global::Celeste.Game.Minigames.CelesteClassic.Progress.Pico8Stat.Berries);
                }

                off += 1f;
                y = start + E.sin(off / 40f) * 2.5f;
            }
        }

        public class fly_fruit : Pico8ClassicObject
        {
            private float start;

            private bool fly;

            private float step = 0.5f;

            private float sfx_delay = 8f;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                start = y;
                solids = false;
            }

            public override void update()
            {
                if (fly)
                {
                    if (sfx_delay > 0f)
                    {
                        sfx_delay -= 1f;
                        if (sfx_delay <= 0f)
                        {
                            G.sfx_timer = 20;
                            E.sfx(14);
                        }
                    }

                    spd.Y = G.appr(spd.Y, -3.5f, 0.25f);
                    if (y < -16f)
                    {
                        G.destroy_object(this);
                    }
                }
                else
                {
                    if (G.has_dashed)
                    {
                        fly = true;
                    }

                    step += 0.05f;
                    spd.Y = E.sin(step) * 0.5f;
                }

                player player2 = collide<player>(0, 0);
                if (player2 != null)
                {
                    player2.djump = G.max_djump;
                    G.sfx_timer = 20;
                    E.sfx(13);
                    G.got_fruit.Add(1 + G.level_index());
                    G.init_object(new lifeup(), x, y);
                    G.destroy_object(this);
                    E.IncrementStat(global::Celeste.Game.Minigames.CelesteClassic.Progress.Pico8Stat.Berries);
                }
            }

            public override void draw()
            {
                float num = 0f;
                if (!fly)
                {
                    if (E.sin(step) < 0f)
                    {
                        num = 1f + E.max(0f, G.sign(y - start));
                    }
                }
                else
                {
                    num = (num + 0.25f) % 3f;
                }

                E.spr(45f + num, x - 6f, y - 2f, 1, 1, flipX: true);
                E.spr(spr, x, y);
                E.spr(45f + num, x + 6f, y - 2f);
            }
        }

        public class lifeup : Pico8ClassicObject
        {
            private int duration;

            private float flash;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                spd.Y = -0.25f;
                duration = 30;
                x -= 2f;
                y -= 4f;
                flash = 0f;
                solids = false;
            }

            public override void update()
            {
                duration--;
                if (duration <= 0)
                {
                    G.destroy_object(this);
                }
            }

            public override void draw()
            {
                flash += 0.5f;
                E.print("1000", x - 2f, y, 7f + flash % 2f);
            }
        }

        public class fake_wall : Pico8ClassicObject
        {
            public override void update()
            {
                hitbox = new global::Celeste.Core.Geometry.IntRect(-1, -1, 18, 18);
                player player2 = collide<player>(0, 0);
                if (player2 != null && player2.dash_effect_time > 0)
                {
                    player2.spd.X = (float)(-G.sign(player2.spd.X)) * 1.5f;
                    player2.spd.Y = -1.5f;
                    player2.dash_time = -1;
                    G.sfx_timer = 20;
                    E.sfx(16);
                    G.destroy_object(this);
                    G.init_object(new smoke(), x, y);
                    G.init_object(new smoke(), x + 8f, y);
                    G.init_object(new smoke(), x, y + 8f);
                    G.init_object(new smoke(), x + 8f, y + 8f);
                    G.init_object(new fruit(), x + 4f, y + 4f);
                }

                hitbox = new global::Celeste.Core.Geometry.IntRect(0, 0, 16, 16);
            }

            public override void draw()
            {
                E.spr(64f, x, y);
                E.spr(65f, x + 8f, y);
                E.spr(80f, x, y + 8f);
                E.spr(81f, x + 8f, y + 8f);
            }
        }

        public class key : Pico8ClassicObject
        {
            public override void update()
            {
                int num = E.flr(spr);
                spr = 9f + (E.sin((float)G.frames / 30f) + 0.5f) * 1f;
                int num2 = E.flr(spr);
                if (num2 == 10 && num2 != num)
                {
                    flipX = !flipX;
                }

                if (check<player>(0, 0))
                {
                    E.sfx(23);
                    G.sfx_timer = 20;
                    G.destroy_object(this);
                    G.has_key = true;
                }
            }
        }

        public class chest : Pico8ClassicObject
        {
            private float start;

            private float timer;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                x -= 4f;
                start = x;
                timer = 20f;
            }

            public override void update()
            {
                var hooks = E.BehaviorHooks;
                bool running = hooks?.BeforeChestUpdate(G, timer) ?? false;
                if (G.has_key)
                {
                    timer -= 1f;
                    x = start - 1f + E.rnd(3f);
                    if (timer <= 0f)
                    {
                        G.sfx_timer = 20;
                        E.sfx(16);
                        G.init_object(new fruit(), x, y - 4f);
                        G.destroy_object(this);
                    }
                }

                hooks?.AfterChestUpdate(running);
            }
        }

        public class platform : Pico8ClassicObject
        {
            public float dir;

            private float last;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                x -= 4f;
                solids = false;
                hitbox.Width = 16;
                last = x;
            }

            public override void update()
            {
                spd.X = dir * 0.65f;
                if (x < -16f)
                {
                    x = 128f;
                }

                if (x > 128f)
                {
                    x = -16f;
                }

                if (!check<player>(0, 0))
                {
                    collide<player>(0, -1)?.move_x((int)(x - last), 1);
                }

                last = x;
            }

            public override void draw()
            {
                E.spr(11f, x, y - 1f);
                E.spr(12f, x + 8f, y - 1f);
            }
        }

        public class message : Pico8ClassicObject
        {
            private float last;

            private float index;

            public override void draw()
            {
                string text = "-- celeste mountain --#this memorial to those# perished on the climb";
                if (check<player>(4, 0))
                {
                    if (index < (float)text.Length)
                    {
                        index += 0.5f;
                        if (index >= last + 1f)
                        {
                            last += 1f;
                            E.sfx(35);
                        }
                    }

                    Vector2 vector = new Vector2(8f, 96f);
                    for (int i = 0; (float)i < index; i++)
                    {
                        if (text[i] != '#')
                        {
                            E.rectfill(vector.X - 2f, vector.Y - 2f, vector.X + 7f, vector.Y + 6f, 7f);
                            E.print(text[i].ToString() ?? "", vector.X, vector.Y, 0f);
                            vector.X += 5f;
                        }
                        else
                        {
                            vector.X = 8f;
                            vector.Y += 7f;
                        }
                    }
                }
                else
                {
                    index = 0f;
                    last = 0f;
                }
            }
        }

        public class big_chest : Pico8ClassicObject
        {
            private class particle
            {
                public float x;

                public float y;

                public float h;

                public float spd;
            }

            private int state;

            private float timer;

            private List<particle> particles;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                hitbox.Width = 16;
            }

            public override void draw()
            {
                if (state == 0)
                {
                    player player2 = collide<player>(0, 8);
                    if (player2 != null && player2.is_solid(0, 1))
                    {
                        E.music(-1, 500, 7);
                        E.sfx(37);
                        G.pause_player = true;
                        player2.spd.X = 0f;
                        player2.spd.Y = 0f;
                        state = 1;
                        G.init_object(new smoke(), x, y);
                        G.init_object(new smoke(), x + 8f, y);
                        timer = 60f;
                        particles = new List<particle>();
                    }

                    E.spr(96f, x, y);
                    E.spr(97f, x + 8f, y);
                }
                else if (state == 1)
                {
                    timer -= 1f;
                    G.shake = 5;
                    G.flash_bg = true;
                    if (timer <= 45f && particles.Count < 50)
                    {
                        particles.Add(new particle
                        {
                            x = 1f + E.rnd(14f),
                            y = 0f,
                            h = 32f + E.rnd(32f),
                            spd = 8f + E.rnd(8f)
                        });
                    }

                    if (timer < 0f)
                    {
                        state = 2;
                        particles.Clear();
                        G.flash_bg = false;
                        G.new_bg = true;
                        G.init_object(new orb(), x + 4f, y + 4f);
                        G.pause_player = false;
                    }

                    foreach (particle particle in particles)
                    {
                        particle.y += particle.spd;
                        E.rectfill(x + particle.x, y + 8f - particle.y, x + particle.x,
                            E.min(y + 8f - particle.y + particle.h, y + 8f), 7f);
                    }
                }

                E.spr(112f, x, y + 8f);
                E.spr(113f, x + 8f, y + 8f);
            }
        }

        public class orb : Pico8ClassicObject
        {
            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                spd.Y = -4f;
                solids = false;
            }

            public override void draw()
            {
                spd.Y = G.appr(spd.Y, 0f, 0.5f);
                player player2 = collide<player>(0, 0);
                if (spd.Y == 0f && player2 != null)
                {
                    G.music_timer = 45;
                    E.sfx(51);
                    G.freeze = 10;
                    G.shake = 10;
                    G.destroy_object(this);
                    G.max_djump = 2;
                    player2.djump = 2;
                }

                E.spr(102f, x, y);
                float num = (float)G.frames / 30f;
                for (int i = 0; i <= 7; i++)
                {
                    E.circfill(x + 4f + E.cos(num + (float)i / 8f) * 8f, y + 4f + E.sin(num + (float)i / 8f) * 8f, 1f,
                        7f);
                }
            }
        }

        public class flag : Pico8ClassicObject
        {
            private float score;

            private bool show;

            public override void init(global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic g,
                global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime e)
            {
                base.init(g, e);
                x += 5f;
                score = G.got_fruit.Count;
                E.IncrementStat(global::Celeste.Game.Minigames.CelesteClassic.Progress.Pico8Stat.Completes);
                E.UnlockAchievement(global::Celeste.Game.Minigames.CelesteClassic.Progress.Pico8Achievement
                    .PICO8);
            }

            public override void draw()
            {
                spr = 118f + (float)G.frames / 5f % 3f;
                E.spr(spr, x, y);
                if (show)
                {
                    E.rectfill(32f, 2f, 96f, 31f, 0f);
                    E.spr(26f, 55f, 6f);
                    E.print("x" + score, 64f, 9f, 7f);
                    G.draw_time(49, 16);
                    E.print("deaths:" + G.deaths, 48f, 24f, 7f);
                }
                else if (check<player>(0, 0))
                {
                    E.sfx(55);
                    G.sfx_timer = 30;
                    show = true;
                }
            }
        }

        public class room_title : Pico8ClassicObject
        {
            private float delay = 5f;

            public override void draw()
            {
                delay -= 1f;
                if (delay < -30f)
                {
                    G.destroy_object(this);
                }
                else if (delay < 0f)
                {
                    E.rectfill(24f, 58f, 104f, 70f, 0f);
                    if (G.room.X == 3 && G.room.Y == 1)
                    {
                        E.print("old site", 48f, 62f, 7f);
                    }
                    else if (G.level_index() == 30)
                    {
                        E.print("summit", 52f, 62f, 7f);
                    }
                    else
                    {
                        int num = (1 + G.level_index()) * 100;
                        E.print(num + "m", 52 + ((num < 1000) ? 2 : 0), 62f, 7f);
                    }

                    G.draw_time(4, 4);
                }
            }
        }
    }
}
