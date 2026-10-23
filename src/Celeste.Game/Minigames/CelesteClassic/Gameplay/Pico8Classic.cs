using Celeste.Core.Geometry;
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
        public global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime E;

        public global::Celeste.Core.Geometry.IntPoint room;

        private List<Pico8ClassicObject> objects;

        public IReadOnlyList<Pico8ClassicObject> Objects => objects;

        public player Player
        {
            get
            {
                if (objects != null)
                    foreach (var item in objects)
                        if (item is player currentPlayer)
                            return currentPlayer;
                return null;
            }
        }


        public int freeze;

        private int shake;

        private bool will_restart;

        private int delay_restart;

        private HashSet<int> got_fruit;

        private bool has_dashed;

        private int sfx_timer;

        public bool has_key;

        private bool pause_player;

        private bool flash_bg;

        private int music_timer;

        public bool new_bg;

#pragma warning disable CS0649 // never assigned in the original either
        private int k_left;
#pragma warning restore CS0649

        private int k_right = 1;

        private int k_up = 2;

        private int k_down = 3;

        private int k_jump = 4;

        private int k_dash = 5;

        public int frames;

        private int seconds;

        private int minutes;

        private int deaths;

        public int max_djump;

        private bool start_game;

        private int start_game_flash;

        private bool room_just_loaded;

        private List<Cloud> clouds;

        private List<Particle> particles;

        private List<DeadParticle> dead_particles;

        public void Init(global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime emulator)
        {
            InitCore(emulator);
            emulator.BehaviorHooks?.ClassicInitialized(this, emulator);
        }

        private void InitCore(
            global::Celeste.Game.Minigames.CelesteClassic.Emulation.ClassicConsoleRuntime emulator)
        {
            E = emulator;
            room = new global::Celeste.Core.Geometry.IntPoint(0, 0);
            objects = new List<Pico8ClassicObject>();
            freeze = 0;
            will_restart = false;
            delay_restart = 0;
            got_fruit = new HashSet<int>();
            has_dashed = false;
            sfx_timer = 0;
            has_key = false;
            pause_player = false;
            flash_bg = false;
            music_timer = 0;
            new_bg = false;
            room_just_loaded = false;
            frames = 0;
            seconds = 0;
            minutes = 0;
            deaths = 0;
            max_djump = 1;
            start_game = false;
            start_game_flash = 0;
            clouds = new List<Cloud>();
            for (int i = 0; i <= 16; i++)
            {
                clouds.Add(new Cloud
                {
                    x = E.rnd(128f),
                    y = E.rnd(128f),
                    spd = 1f + E.rnd(4f),
                    w = 32f + E.rnd(32f)
                });
            }

            particles = new List<Particle>();
            for (int j = 0; j <= 32; j++)
            {
                particles.Add(new Particle
                {
                    x = E.rnd(128f),
                    y = E.rnd(128f),
                    s = E.flr(E.rnd(5f) / 4f),
                    spd = 0.25f + E.rnd(5f),
                    off = E.rnd(1f),
                    c = 6 + E.flr(0.5f + E.rnd(1f))
                });
            }

            dead_particles = new List<DeadParticle>();
            title_screen();
        }

        private void title_screen()
        {
            got_fruit = new HashSet<int>();
            frames = 0;
            deaths = 0;
            max_djump = 1;
            start_game = false;
            start_game_flash = 0;
            E.music(40, 0, 7);
            load_room(7, 3);
        }

        private void begin_game()
        {
            frames = 0;
            seconds = 0;
            minutes = 0;
            music_timer = 0;
            start_game = false;
            E.music(0, 0, 7);
            load_room(0, 0);
        }

        public int level_index()
        {
            return room.X % 8 + room.Y * 8;
        }

        private bool is_title()
        {
            return level_index() == 31;
        }

        private void psfx(int num)
        {
            if (sfx_timer <= 0)
            {
                E.sfx(num);
            }
        }

        private void draw_player(Pico8ClassicObject obj, int djump)
        {
            int num = 0;
            switch (djump)
            {
                case 2:
                    num = ((E.flr(frames / 3 % 2) != 0) ? 144 : 160);
                    break;
                case 0:
                    num = 128;
                    break;
            }

            E.spr(obj.spr + (float)num, obj.x, obj.y, 1, 1, obj.flipX, obj.flipY);
        }

        private void break_spring(spring obj)
        {
            obj.hide_in = 15;
        }

        private void break_fall_floor(fall_floor obj)
        {
            if (obj.state == 0)
            {
                psfx(15);
                obj.state = 1;
                obj.delay = 15;
                init_object(new smoke(), obj.x, obj.y);
                spring spring2 = obj.collide<spring>(0, -1);
                if (spring2 != null)
                {
                    break_spring(spring2);
                }
            }
        }

        private T init_object<T>(T obj, float x, float y, int? tile = null) where T : Pico8ClassicObject
        {
            objects.Add(obj);
            if (tile.HasValue)
            {
                obj.spr = tile.Value;
            }

            obj.x = (int)x;
            obj.y = (int)y;
            obj.init(this, E);
            return obj;
        }

        private void destroy_object(Pico8ClassicObject obj)
        {
            int num = objects.IndexOf(obj);
            if (num >= 0)
            {
                objects[num] = null;
            }
        }

        private void kill_player(player obj)
        {
            sfx_timer = 12;
            E.sfx(0);
            deaths++;
            shake = 10;
            destroy_object(obj);
            E.IncrementStat(global::Celeste.Game.Minigames.CelesteClassic.Progress.Pico8Stat.Deaths);
            dead_particles.Clear();
            for (int i = 0; i <= 7; i++)
            {
                float num = (float)i / 8f;
                dead_particles.Add(new DeadParticle
                {
                    x = obj.x + 4f,
                    y = obj.y + 4f,
                    t = 10,
                    spd = new Vector2(E.cos(num) * 3f, E.sin(num + 0.5f) * 3f)
                });
            }

            restart_room();
        }

        private void restart_room()
        {
            will_restart = true;
            delay_restart = 15;
        }

        private void next_room()
        {
            if (room.X == 2 && room.Y == 1)
            {
                E.music(30, 500, 7);
            }
            else if (room.X == 3 && room.Y == 1)
            {
                E.music(20, 500, 7);
            }
            else if (room.X == 4 && room.Y == 2)
            {
                E.music(30, 500, 7);
            }
            else if (room.X == 5 && room.Y == 3)
            {
                E.music(30, 500, 7);
            }

            if (room.X == 7)
            {
                load_room(0, room.Y + 1);
            }
            else
            {
                load_room(room.X + 1, room.Y);
            }
        }

        public void load_room(int x, int y)
        {
            room_just_loaded = true;
            has_dashed = false;
            has_key = false;
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i] = null;
            }

            room.X = x;
            room.Y = y;
            for (int j = 0; j <= 15; j++)
            {
                for (int k = 0; k <= 15; k++)
                {
                    int num = E.mget(room.X * 16 + j, room.Y * 16 + k);
                    switch (num)
                    {
                        case 11:
                            init_object(new platform(), j * 8, k * 8).dir = -1f;
                            continue;
                        case 12:
                            init_object(new platform(), j * 8, k * 8).dir = 1f;
                            continue;
                    }

                    Pico8ClassicObject classicObject = null;
                    switch (num)
                    {
                        case 1:
                            classicObject = new player_spawn();
                            break;
                        case 18:
                            classicObject = new spring();
                            break;
                        case 22:
                            classicObject = new balloon();
                            break;
                        case 23:
                            classicObject = new fall_floor();
                            break;
                        case 86:
                            classicObject = new message();
                            break;
                        case 96:
                            classicObject = new big_chest();
                            break;
                        case 118:
                            classicObject = new flag();
                            break;
                        default:
                            if (!got_fruit.Contains(1 + level_index()))
                            {
                                switch (num)
                                {
                                    case 26:
                                        classicObject = new fruit();
                                        break;
                                    case 28:
                                        classicObject = new fly_fruit();
                                        break;
                                    case 64:
                                        classicObject = new fake_wall();
                                        break;
                                    case 8:
                                        classicObject = new key();
                                        break;
                                    case 20:
                                        classicObject = new chest();
                                        break;
                                }
                            }

                            break;
                    }

                    if (classicObject != null)
                    {
                        init_object(classicObject, j * 8, k * 8, num);
                    }
                }
            }

            if (!is_title())
            {
                init_object(new room_title(), 0f, 0f);
            }
        }

        public void Update()
        {
            UpdateCore();
            E.BehaviorHooks?.ClassicUpdated(this);
        }

        private void UpdateCore()
        {
            frames = (frames + 1) % 30;
            if (frames == 0 && level_index() < 30)
            {
                seconds = (seconds + 1) % 60;
                if (seconds == 0)
                {
                    minutes++;
                }
            }

            if (music_timer > 0)
            {
                music_timer--;
                if (music_timer <= 0)
                {
                    E.music(10, 0, 7);
                }
            }

            if (sfx_timer > 0)
            {
                sfx_timer--;
            }

            if (freeze > 0)
            {
                freeze--;
                return;
            }

            if (shake > 0 && E.ScreenShake !=
                global::Celeste.Game.Minigames.CelesteClassic.Options.Pico8ShakeAmount.Off)
            {
                shake--;
                E.camera();
                if (shake > 0)
                {
                    if (E.ScreenShake == global::Celeste.Game.Minigames.CelesteClassic.Options.Pico8ShakeAmount
                            .On)
                    {
                        E.camera(-2f + E.rnd(5f), -2f + E.rnd(5f));
                    }
                    else
                    {
                        E.camera(-1f + E.rnd(3f), -1f + E.rnd(3f));
                    }
                }
            }

            if (will_restart && delay_restart > 0)
            {
                delay_restart--;
                if (delay_restart <= 0)
                {
                    will_restart = true;
                    load_room(room.X, room.Y);
                }
            }

            room_just_loaded = false;
            int num = 0;
            while (num != -1)
            {
                int i = num;
                num = -1;
                for (; i < objects.Count; i++)
                {
                    Pico8ClassicObject classicObject = objects[i];
                    if (classicObject != null)
                    {
                        classicObject.move(classicObject.spd.X, classicObject.spd.Y);
                        classicObject.update();
                        if (room_just_loaded)
                        {
                            room_just_loaded = false;
                            num = i;
                            break;
                        }
                    }
                }

                while (objects.IndexOf(null) >= 0)
                {
                    objects.Remove(null);
                }
            }

            if (!is_title())
            {
                return;
            }

            if (!start_game && (E.btn(k_jump) || E.btn(k_dash)))
            {
                E.music(-1, 0, 0);
                start_game_flash = 50;
                start_game = true;
                E.sfx(38);
            }

            if (start_game)
            {
                start_game_flash--;
                if (start_game_flash <= -30)
                {
                    begin_game();
                }
            }
        }

        public void Draw()
        {
            E.pal();
            if (start_game)
            {
                int num = 10;
                if (start_game_flash <= 10)
                {
                    num = ((start_game_flash > 5) ? 2 : ((start_game_flash > 0) ? 1 : 0));
                }
                else if (frames % 10 < 5)
                {
                    num = 7;
                }

                if (num < 10)
                {
                    E.pal(6, num);
                    E.pal(12, num);
                    E.pal(13, num);
                    E.pal(5, num);
                    E.pal(1, num);
                    E.pal(7, num);
                }
            }

            int num2 = 0;
            if (flash_bg)
            {
                num2 = frames / 5;
            }
            else if (new_bg)
            {
                num2 = 2;
            }

            E.rectfill(0f, 0f, 128f, 128f, num2);
            if (!is_title())
            {
                foreach (Cloud cloud in clouds)
                {
                    cloud.x += cloud.spd;
                    E.rectfill(cloud.x, cloud.y, cloud.x + cloud.w, cloud.y + 4f + (1f - cloud.w / 64f) * 12f,
                        (!new_bg) ? 1 : 14);
                    if (cloud.x > 128f)
                    {
                        cloud.x = 0f - cloud.w;
                        cloud.y = E.rnd(120f);
                    }
                }
            }

            E.map(room.X * 16, room.Y * 16, 0, 0, 16, 16, 2);
            for (int i = 0; i < objects.Count; i++)
            {
                Pico8ClassicObject classicObject = objects[i];
                if (classicObject != null && (classicObject is platform || classicObject is big_chest))
                {
                    draw_object(classicObject);
                }
            }

            int tx = (is_title() ? (-4) : 0);
            E.map(room.X * 16, room.Y * 16, tx, 0, 16, 16, 1);
            for (int j = 0; j < objects.Count; j++)
            {
                Pico8ClassicObject classicObject2 = objects[j];
                if (classicObject2 != null && !(classicObject2 is platform) && !(classicObject2 is big_chest))
                {
                    draw_object(classicObject2);
                }
            }

            E.map(room.X * 16, room.Y * 16, 0, 0, 16, 16, 3);
            foreach (Particle particle in particles)
            {
                particle.x += particle.spd;
                particle.y += E.sin(particle.off);
                particle.off += E.min(0.05f, particle.spd / 32f);
                E.rectfill(particle.x, particle.y, particle.x + (float)particle.s, particle.y + (float)particle.s,
                    particle.c);
                if (particle.x > 132f)
                {
                    particle.x = -4f;
                    particle.y = E.rnd(128f);
                }
            }

            for (int num3 = dead_particles.Count - 1; num3 >= 0; num3--)
            {
                DeadParticle deadParticle = dead_particles[num3];
                deadParticle.x += deadParticle.spd.X;
                deadParticle.y += deadParticle.spd.Y;
                deadParticle.t--;
                if (deadParticle.t <= 0)
                {
                    dead_particles.RemoveAt(num3);
                }

                E.rectfill(deadParticle.x - (float)(deadParticle.t / 5), deadParticle.y - (float)(deadParticle.t / 5),
                    deadParticle.x + (float)(deadParticle.t / 5), deadParticle.y + (float)(deadParticle.t / 5),
                    14 + deadParticle.t % 2);
            }

            E.rectfill(-5f, -5f, -1f, 133f, 0f);
            E.rectfill(-5f, -5f, 133f, -1f, 0f);
            E.rectfill(-5f, 128f, 133f, 133f, 0f);
            E.rectfill(128f, -5f, 133f, 133f, 0f);
            if (is_title())
            {
                E.print("press button", 42f, 96f, 5f);
            }

            if (level_index() != 30)
            {
                return;
            }

            Pico8ClassicObject classicObject3 = null;
            foreach (Pico8ClassicObject @object in objects)
            {
                if (@object is player)
                {
                    classicObject3 = @object;
                    break;
                }
            }

            if (classicObject3 != null)
            {
                float num4 = E.min(24f, 40f - E.abs(classicObject3.x + 4f - 64f));
                E.rectfill(0f, 0f, num4, 128f, 0f);
                E.rectfill(128f - num4, 0f, 128f, 128f, 0f);
            }
        }

        private void draw_object(Pico8ClassicObject obj)
        {
            obj.draw();
        }

        private void draw_time(int x, int y)
        {
            int num = seconds;
            int num2 = minutes % 60;
            int num3 = E.flr(minutes / 60);
            E.rectfill(x, y, x + 32, y + 6, 0f);
            E.print(
                ((num3 < 10) ? "0" : "") + num3 + ":" + ((num2 < 10) ? "0" : "") + num2 + ":" +
                ((num < 10) ? "0" : "") + num, x + 1, y + 1, 7f);
        }

        private float clamp(float val, float a, float b)
        {
            return E.max(a, E.min(b, val));
        }

        private float appr(float val, float target, float amount)
        {
            if (!(val > target))
            {
                return E.min(val + amount, target);
            }

            return E.max(val - amount, target);
        }

        private int sign(float v)
        {
            if (!(v > 0f))
            {
                if (!(v < 0f))
                {
                    return 0;
                }

                return -1;
            }

            return 1;
        }

        private bool maybe()
        {
            return E.rnd(1f) < 0.5f;
        }

        private bool solid_at(float x, float y, float w, float h)
        {
            return tile_flag_at(x, y, w, h, 0);
        }

        private bool ice_at(float x, float y, float w, float h)
        {
            return tile_flag_at(x, y, w, h, 4);
        }

        private bool tile_flag_at(float x, float y, float w, float h, int flag)
        {
            for (int i = (int)E.max(0f, E.flr(x / 8f)); (float)i <= E.min(15f, (x + w - 1f) / 8f); i++)
            {
                for (int j = (int)E.max(0f, E.flr(y / 8f)); (float)j <= E.min(15f, (y + h - 1f) / 8f); j++)
                {
                    if (E.fget(tile_at(i, j), flag))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int tile_at(int x, int y)
        {
            return E.mget(room.X * 16 + x, room.Y * 16 + y);
        }

        private bool spikes_at(float x, float y, int w, int h, float xspd, float yspd)
        {
            for (int i = (int)E.max(0f, E.flr(x / 8f)); (float)i <= E.min(15f, (x + (float)w - 1f) / 8f); i++)
            {
                for (int j = (int)E.max(0f, E.flr(y / 8f)); (float)j <= E.min(15f, (y + (float)h - 1f) / 8f); j++)
                {
                    int num = tile_at(i, j);
                    if (num == 17 && (E.mod(y + (float)h - 1f, 8f) >= 6f || y + (float)h == (float)(j * 8 + 8)) &&
                        yspd >= 0f)
                    {
                        return true;
                    }

                    if (num == 27 && E.mod(y, 8f) <= 2f && yspd <= 0f)
                    {
                        return true;
                    }

                    if (num == 43 && E.mod(x, 8f) <= 2f && xspd <= 0f)
                    {
                        return true;
                    }

                    if (num == 59 && ((x + (float)w - 1f) % 8f >= 6f || x + (float)w == (float)(i * 8 + 8)) &&
                        xspd >= 0f)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
