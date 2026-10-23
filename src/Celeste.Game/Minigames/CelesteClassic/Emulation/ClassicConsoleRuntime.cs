using Celeste.Core.Display;
using Celeste.Game.Execution.Engine;
using Celeste.Graphics.Content;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Audio;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Game.Controls.Source;
using Celeste.Scene.Scheduling;
using Celeste.Game.Settings;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Minigames.CelesteClassic.Progress;
using Celeste.Game.Minigames.CelesteClassic.Extensions;
using Celeste.Scene.Rendering;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Audio.Fmod.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Celeste.Game.Minigames.CelesteClassic.Emulation
{
    public class ClassicConsoleRuntime : SourceSceneState, IOriginalEngineDashAssistScene
    {
        private static string MapData =>
            global::Celeste.Game.Minigames.CelesteClassic.Content.ClassicCartridgeData.MapData;

        public SourceSceneState ReturnTo;
        private readonly ISourceEngineContext engine;
        public bool IsGameUninitialized => game == null;
        public global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic Game => game;
        public global::Celeste.Core.Geometry.IntPoint BootLevel => bootLevel;

        public IClassicBehaviorHooks BehaviorHooks => global::Celeste.Core.Scheduling.SourceRuntimeExtensions
            .Get<IClassicBehaviorEnvironment>(engine)?.ClassicBehaviorHooks;

        public void UpdateFirstTrackedDashAssist() =>
            OriginalEngineDashAssistSceneBody.UpdateFirstTrackedDashAssist(SourceScene, EngineContext);

        public void CommitEntityLists() => OriginalEngineDashAssistSceneBody.CommitEntityLists(SourceScene);

        public global::Celeste.Game.Minigames.CelesteClassic.Options.Pico8ShakeAmount ScreenShake =>
            (global::Celeste.Game.Minigames.CelesteClassic.Options.Pico8ShakeAmount)
            ((ISettingsContext)engine).Settings.ScreenShake;

        private global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic game;

        private int gameFrame;

        private bool gameActive = true;

        private float gameDelay;

        private global::Celeste.Core.Geometry.IntPoint bootLevel;

        private bool leaving;

        private bool skipFrame = true;

        private FmodEventReference bgSfx;

        private VirtualRenderTarget buffer;

        private PackedColor[] pixels = new PackedColor[16384];

        private Vector2 offset = Vector2.Zero;

        private TextMenuPresentation pauseMenu;

        private float pauseFade;

        private FmodEventReference snapshot;

        private AtlasEntry picoBootLogo;

        private byte[] tilemap;

        private AtlasEntry[] sprites;

        private byte[] mask = new byte[128]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 4, 2, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 2, 0, 0,
            0, 0, 3, 3, 3, 3, 3, 3, 3, 3,
            4, 4, 4, 2, 2, 0, 0, 0, 3, 3,
            3, 3, 3, 3, 3, 3, 4, 4, 4, 2,
            2, 2, 2, 2, 0, 0, 19, 19, 19, 19,
            2, 2, 3, 2, 2, 2, 2, 2, 2, 2,
            0, 0, 19, 19, 19, 19, 2, 2, 4, 2,
            2, 2, 2, 2, 2, 2, 0, 0, 19, 19,
            19, 19, 0, 4, 4, 2, 2, 2, 2, 2,
            2, 2, 0, 0, 19, 19, 19, 19, 0, 0,
            0, 2, 2, 2, 2, 2, 2, 2
        };

        private PackedColor[] colors = new PackedColor[16]
        {
            SourceHexColor.HexToColor("000000"),
            SourceHexColor.HexToColor("1d2b53"),
            SourceHexColor.HexToColor("7e2553"),
            SourceHexColor.HexToColor("008751"),
            SourceHexColor.HexToColor("ab5236"),
            SourceHexColor.HexToColor("5f574f"),
            SourceHexColor.HexToColor("c2c3c7"),
            SourceHexColor.HexToColor("fff1e8"),
            SourceHexColor.HexToColor("ff004d"),
            SourceHexColor.HexToColor("ffa300"),
            SourceHexColor.HexToColor("ffec27"),
            SourceHexColor.HexToColor("00e436"),
            SourceHexColor.HexToColor("29adff"),
            SourceHexColor.HexToColor("83769c"),
            SourceHexColor.HexToColor("ff77a8"),
            SourceHexColor.HexToColor("ffccaa")
        };

        private Dictionary<PackedColor, int> paletteSwap = new Dictionary<PackedColor, int>();

        private AtlasEntry[] font;

        private string fontMap = "abcdefghijklmnopqrstuvwxyz0123456789~!@#4%^&*()_+-=?:.";

        public bool CanPause => pauseMenu == null;

        public static ClassicConsoleRuntime Create(ISourceEngineContext engine, SourceSceneState returnTo,
            int levelX = 0, int levelY = 0)
        {
            global::Celeste.Core.Scheduling.SourceRuntimeExtensions.Get<IClassicBehaviorEnvironment>(engine)
                ?.ClassicBehaviorHooks?.EmulatorConstructing();
            ClassicConsoleRuntime emulator = new ClassicConsoleRuntime(engine, returnTo, levelX, levelY);
            ((IOriginalClassicConsolePolicyEnvironment)engine).ClassicConsolePolicy.AfterConstructor(emulator);
            return emulator;
        }

        private bool booting => game == null;

        private ClassicConsoleRuntime(ISourceEngineContext engine, SourceSceneState returnTo, int levelX = 0,
            int levelY = 0)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            this.engine = engine;
            ReturnTo = returnTo;
            bootLevel = new global::Celeste.Core.Geometry.IntPoint(levelX, levelY);
            buffer = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("pico-8", 128, 128);
            AtlasEntry mTexture = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["pico8/atlas"];
            sprites = new AtlasEntry[mTexture.FrameWidth / 8 * (mTexture.FrameHeight / 8)];
            for (int i = 0; i < mTexture.FrameHeight / 8; i++)
            {
                for (int j = 0; j < mTexture.FrameWidth / 8; j++)
                {
                    sprites[j + i * (mTexture.FrameWidth / 8)] = mTexture.GetSubtexture(j * 8, i * 8, 8, 8);
                }
            }

            string input = MapData;
            input = Regex.Replace(input, "\\s+", "");
            tilemap = new byte[input.Length / 2];
            int k = 0;
            int length = input.Length;
            int num = length / 2;
            for (; k < length; k += 2)
            {
                char c = input[k];
                char c2 = input[k + 1];
                string s = ((k < num) ? (c.ToString() + c2) : (c2.ToString() + c));
                tilemap[k / 2] = (byte)int.Parse(s, NumberStyles.HexNumber);
            }

            AtlasEntry mTexture2 = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["pico8/font"];
            font = new AtlasEntry[mTexture2.FrameWidth / 4 * (mTexture2.FrameHeight / 6)];
            for (int l = 0; l < mTexture2.FrameHeight / 6; l++)
            {
                for (int m = 0; m < mTexture2.FrameWidth / 4; m++)
                {
                    font[m + l * (mTexture2.FrameWidth / 4)] = mTexture2.GetSubtexture(m * 4, l * 6, 4, 6);
                }
            }

            picoBootLogo = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["pico8/logo"];
            ResetScreen();
            ((IOriginalGameplayProcess)engine).AudioSession.SetMusic(null);
            ((IOriginalGameplayProcess)engine).AudioSession.SetAmbience(null);
            new FadeWipePresentation(this, wipeIn: true);
            Renderers.UpdateLists();
        }

        public void InstallTilemapText(string input)
        {
            input = Regex.Replace(input, "\\s+", "");
            tilemap = new byte[input.Length / 2];
            int length = input.Length;
            int num = length / 2;
            Span<char> pair = stackalloc char[2];
            for (int i = 0; i < length; i += 2)
            {
                char c = input[i];
                char c2 = input[i + 1];
                byte[] array = tilemap;
                int num2 = i / 2;
                pair[0] = i >= num ? c2 : c;
                pair[1] = i >= num ? c : c2;
                string s = new string(pair);
                array[num2] = (byte)int.Parse(s, NumberStyles.HexNumber);
            }
        }

        public override void Begin()
        {
            bgSfx = ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/env/amb/03_pico8_closeup");
            base.Begin();
        }

        public override void End()
        {
            buffer.Dispose();
            ((IOriginalGameplayProcess)engine).AudioSession.BusStopAll("bus:/gameplay_sfx");
            ((IOriginalGameplayProcess)engine).AudioSession.Stop(bgSfx);
            if (snapshot != null)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.ReleaseSnapshot(snapshot);
            }

            snapshot = null;
            ((IOriginalPlatformStatisticsEnvironment)engine).Statistics.Store();
            base.End();
        }

        private void ResetScreen()
        {
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[0] = null;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[1] = null;
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    pixels[i + j * 128] = PackedColor.Black;
                }
            }

            buffer.Target.SetData(pixels);
        }

        public override void Update()
        {
            base.Update();
            if (pauseMenu != null)
            {
                pauseMenu.Update();
            }
            else if (!leaving && (((IOriginalGameInputProcessEnvironment)engine).InputSource.Pause.Pressed ||
                                  ((IOriginalGameInputProcessEnvironment)engine).InputSource.ESC.Pressed))
            {
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.Pause.ConsumeBuffer();
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.ESC.ConsumeBuffer();
                CreatePauseMenu();
            }

            pauseFade = ScalarMath.Approach(pauseFade, (pauseMenu != null) ? 0.75f : 0f, engine.DeltaTime * 6f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            skipFrame = !skipFrame;
            if (skipFrame)
            {
                return;
            }

            gameDelay -= engine.DeltaTime;
            if (!gameActive || gameDelay > 0f)
            {
                return;
            }

            if (booting)
            {
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[0] = null;
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[1] = null;
                gameFrame++;
                int num = gameFrame - 20;
                if (num == 1)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        for (int j = 2; j < 128; j += 8)
                        {
                            pixels[j + i * 128] = colors[((ISourceRandomEnvironment)engine).Random.Next(4) + i / 32];
                        }
                    }

                    buffer.Target.SetData(pixels);
                }

                if (num == 4)
                {
                    for (int k = 0; k < 128; k += 2)
                    {
                        for (int l = 0; l < 128; l += 4)
                        {
                            pixels[l + k * 128] = colors[6 + (((l + k) / 8) & 7)];
                        }
                    }

                    buffer.Target.SetData(pixels);
                }

                if (num == 7)
                {
                    for (int m = 0; m < 128; m += 3)
                    {
                        for (int n = 2; n < 128; n += 4)
                        {
                            pixels[n + m * 128] = colors[10 + ((ISourceRandomEnvironment)engine).Random.Next(4)];
                        }
                    }

                    buffer.Target.SetData(pixels);
                }

                if (num == 9)
                {
                    for (int num2 = 0; num2 < 128; num2++)
                    {
                        for (int num3 = 1; num3 < 127; num3 += 2)
                        {
                            pixels[num3 + num2 * 128] = pixels[num3 + 1 + num2 * 128];
                        }
                    }

                    buffer.Target.SetData(pixels);
                }

                if (num == 12)
                {
                    for (int num4 = 0; num4 < 128; num4++)
                    {
                        if ((num4 & 3) > 0)
                        {
                            for (int num5 = 0; num5 < 128; num5++)
                            {
                                pixels[num5 + num4 * 128] = colors[0];
                            }
                        }
                    }

                    buffer.Target.SetData(pixels);
                }

                if (num == 15)
                {
                    for (int num6 = 0; num6 < 128; num6++)
                    {
                        for (int num7 = 0; num7 < 128; num7++)
                        {
                            pixels[num7 + num6 * 128] = colors[0];
                        }
                    }

                    buffer.Target.SetData(pixels);
                }

                if (num == 30)
                {
                    ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/classic/pico8_boot");
                }

                if (num == 30 || num == 35 || num == 40)
                {
                    ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(buffer.Target);
                    ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(colors[0]);
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                        SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp, null,
                        SourceRasterizerState.CullNone);
                    SourceAtlasDrawing.Draw((ISourceDrawScope)engine, picoBootLogo, new Vector2(1f, 1f), Vector2.Zero,
                        PackedColor.White);
                    if (num >= 35)
                    {
                        print("pico-8 0.1.9B", 1f, 18f, 6f);
                    }

                    if (num >= 40)
                    {
                        print("(c) 2014-16 lexaloffle games llp", 1f, 24f, 6f);
                        print("booting cartridge..", 1f, 36f, 6f);
                    }

                    ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                    ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(null);
                }

                if (num == 90)
                {
                    gameFrame = 0;
                    game = new global::Celeste.Game.Minigames.CelesteClassic.Gameplay.Pico8Classic();
                    game.Init(this);
                    if (bootLevel.X != 0 || bootLevel.Y != 0)
                    {
                        game.load_room(bootLevel.X, bootLevel.Y);
                    }
                }

                return;
            }

            gameFrame++;
            game.Update();
            if (game.freeze > 0)
            {
                return;
            }

            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(buffer.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(colors[0]);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, null, SourceRasterizerState.CullNone, null,
                SourceMatrixMath.CreateTranslation(0f - offset.X, 0f - offset.Y, 0f));
            game.Draw();
            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(null);
            if (paletteSwap.Count <= 0)
            {
                return;
            }

            buffer.Target.GetData(pixels);
            for (int num8 = 0; num8 < pixels.Length; num8++)
            {
                int value = 0;
                if (paletteSwap.TryGetValue(pixels[num8], out value))
                {
                    pixels[num8] = colors[value];
                }
            }

            buffer.Target.SetData(pixels);
        }

        public override void Render()
        {
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, null, SourceRasterizerState.CullNone, null,
                ((IOriginalEngineGraphicsEnvironment)engine).EngineGraphics.ScreenMatrix);
            int num = 6;
            Vector2 vector = new Vector2(buffer.Width * num, buffer.Height * num);
            Vector2 position = new Vector2(1920f - vector.X, 1080f - vector.Y) / 2f;
            bool flag = ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                        ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode;
            SourceAtlasDrawing.Draw((ISourceDrawScope)engine,
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["pico8/consoleBG"], Vector2.Zero,
                Vector2.Zero, PackedColor.White, num);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(buffer.Target, position, buffer.Bounds,
                PackedColor.White.PackedValue, 0f, Vector2.Zero, num,
                flag ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None, 0f);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            if (pauseMenu != null || pauseFade > 0f)
            {
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, SourceRasterizerState.CullNone,
                    null,
                    ((IOriginalEngineGraphicsEnvironment)engine).EngineGraphics.ScreenMatrix);
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, -1f, -1f, 1922f, 1082f,
                    PackedColor.Black * pauseFade);
                if (pauseMenu != null)
                {
                    pauseMenu.Render(SourceRenderContext);
                }

                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            }

            base.Render();
        }

        public void CreatePauseMenu()
        {
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/ui/game/pause");
            ((IOriginalGameplayProcess)engine).AudioSession.PauseGameplaySfx = true;
            snapshot = ((IOriginalGameplayProcess)engine).AudioSession.CreateSnapshot("snapshot:/pause_menu");
            TextMenuPresentation menu = new TextMenuPresentation(engine);
            menu.Add(new TextMenuPresentation.Button(
                    ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("pico8_pause_continue"))
                .Pressed(delegate { menu.OnCancel(); }));
            menu.Add(new TextMenuPresentation.Button(
                ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("pico8_pause_restart")).Pressed(delegate
            {
                pauseMenu = null;
                music(-1, 0, 0);
                new FadeWipePresentation(this, wipeIn: false, delegate
                {
                    ((IOriginalGameplayProcess)engine).AudioSession.BusStopAll("bus:/gameplay_sfx");
                    ((IOriginalGameplayProcess)engine).AudioSession.PauseGameplaySfx = false;
                    ((IOriginalGameplayProcess)engine).AudioSession.ReleaseSnapshot(snapshot);
                    snapshot = null;
                    ResetScreen();
                    game = null;
                    gameFrame = 0;
                    gameActive = true;
                    new FadeWipePresentation(this, wipeIn: true);
                });
            }));
            menu.Add(new TextMenuPresentation.Button(
                ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("pico8_pause_quit")).Pressed(delegate
            {
                leaving = true;
                gameActive = false;
                pauseMenu = null;
                music(-1, 0, 0);
                new FadeWipePresentation(this, wipeIn: false, delegate
                {
                    ((IOriginalGameplayProcess)engine).AudioSession.BusStopAll("bus:/gameplay_sfx");
                    ((IOriginalGameplayProcess)engine).AudioSession.PauseGameplaySfx = false;
                    ((IOriginalGameplayProcess)engine).AudioSession.ReleaseSnapshot(snapshot);
                    ((IOriginalGameplayProcess)engine).AudioSession.Stop(bgSfx);
                    snapshot = null;
                    if (ReturnTo != null)
                    {
                        if (ReturnTo is OriginalLevelSceneRoot)
                        {
                            OriginalAudioSession.Apply((ReturnTo as OriginalLevelSceneRoot).Session.Audio,
                                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
                            new FadeWipePresentation((ISourceRendererScene)ReturnTo, wipeIn: true);
                        }

                        engine.Frame.Scenes.NextScene = ReturnTo;
                    }
                    else
                    {
                        engine.Frame.Scenes.NextScene =
                            ((IOriginalOverworldLoaderEnvironment)engine).OverworldLoaders.CreateOverworldLoader(
                                OverworldStartMode.Titlescreen);
                    }
                });
            }));
            menu.OnCancel = (menu.OnESC = (menu.OnPause = delegate
            {
                ((IOriginalGameplayProcess)engine).AudioSession.PauseGameplaySfx = false;
                ((IOriginalGameplayProcess)engine).AudioSession.ReleaseSnapshot(snapshot);
                snapshot = null;
                gameDelay = 0.1f;
                pauseMenu = null;
                gameActive = true;
                menu.RemoveSelf();
            }));
            gameActive = false;
            pauseMenu = menu;
        }

        public void music(int index, int fade, int mask)
        {
            switch (index)
            {
                case -1:
                    ((IOriginalGameplayProcess)engine).AudioSession.SetMusic(null);
                    break;
                case 0:
                    ((IOriginalGameplayProcess)engine).AudioSession.SetMusic("event:/classic/pico8_mus_01");
                    break;
                case 10:
                    ((IOriginalGameplayProcess)engine).AudioSession.SetMusic("event:/classic/pico8_mus_03");
                    break;
                case 20:
                    ((IOriginalGameplayProcess)engine).AudioSession.SetMusic("event:/classic/pico8_mus_02");
                    break;
                case 30:
                    ((IOriginalGameplayProcess)engine).AudioSession.SetMusic("event:/classic/sfx61");
                    break;
                case 40:
                    ((IOriginalGameplayProcess)engine).AudioSession.SetMusic("event:/classic/pico8_mus_00");
                    break;
            }
        }

        public void sfx(int sfx)
        {
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/classic/sfx" + sfx);
        }

        public float rnd(float max)
        {
            return SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, max);
        }

        public int flr(float value)
        {
            return (int)Math.Floor(value);
        }

        public int sign(float value)
        {
            return Math.Sign(value);
        }

        public float abs(float value)
        {
            return Math.Abs(value);
        }

        public float min(float a, float b)
        {
            return ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(a, b);
        }

        public float max(float a, float b)
        {
            return ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(a, b);
        }

        public float sin(float a)
        {
            return (float)Math.Sin((1f - a) * ((float)Math.PI * 2f));
        }

        public float cos(float a)
        {
            return (float)Math.Cos((1f - a) * ((float)Math.PI * 2f));
        }

        public float mod(float a, float b)
        {
            float num = a % b;
            if (!(num >= 0f))
            {
                return b + num;
            }

            return num;
        }

        public void IncrementStat(Pico8Stat statistic)
        {
            OriginalStatistic sourceStatistic = statistic switch
            {
                Pico8Stat.Deaths => OriginalStatistic.PICO_DEATHS,
                Pico8Stat.Completes => OriginalStatistic.PICO_COMPLETES,
                Pico8Stat.Berries => OriginalStatistic.PICO_BERRIES,
                _ => throw new ArgumentOutOfRangeException(nameof(statistic))
            };
            ((IOriginalPlatformStatisticsEnvironment)engine).Statistics.Increment(sourceStatistic);
        }

        public void UnlockAchievement(Pico8Achievement achievement)
        {
            if (achievement != Pico8Achievement.PICO8)
                throw new ArgumentOutOfRangeException(nameof(achievement));
            ((IOriginalPlatformStatisticsEnvironment)engine).Statistics.Achievements
                .Register(OriginalAchievement.PICO8);
        }

        public bool btn(int index)
        {
            Vector2 vector = new Vector2(((IOriginalGameInputProcessEnvironment)engine).InputSource.MoveX.Value,
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.MoveY.Value);
            return index switch
            {
                0 => vector.X < 0f,
                1 => vector.X > 0f,
                2 => vector.Y < 0f,
                3 => vector.Y > 0f,
                4 => ((IOriginalGameInputProcessEnvironment)engine).InputSource.Jump.Check,
                5 => ((IOriginalGameInputProcessEnvironment)engine).InputSource.Dash.Check,
                _ => false,
            };
        }

        private Vector2 aimVector()
        {
            Vector2 vector = ((IOriginalGameInputProcessEnvironment)engine).InputSource.Aim.Value;
            if (vector != Vector2.Zero)
            {
                if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                    ((IOriginalGameplayProcess)engine)
                    .SaveContext.CurrentSave.Assists.ThreeSixtyDashing)
                {
                    vector = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(vector);
                }
                else
                {
                    float num = Vector2Geometry.Angle(vector);
                    int num2 = ((num < 0f) ? 1 : 0);
                    float num3 = (float)Math.PI / 8f - (float)num2 * 0.08726646f;
                    vector = ((Math.Abs(ScalarMath.AngleDiff(num, 0f)) < num3)
                        ? new Vector2(1f, 0f)
                        : ((Math.Abs(ScalarMath.AngleDiff(num, (float)Math.PI)) < num3)
                            ? new Vector2(-1f, 0f)
                            : ((Math.Abs(ScalarMath.AngleDiff(num, -(float)Math.PI / 2f)) < num3)
                                ? new Vector2(0f, -1f)
                                : ((!(Math.Abs(ScalarMath.AngleDiff(num, (float)Math.PI / 2f)) < num3))
                                    ? ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                                        new Vector2(Math.Sign(vector.X), Math.Sign(vector.Y)))
                                    : new Vector2(0f, 1f)))));
                }
            }

            return vector;
        }

        public int dashDirectionX(int facing)
        {
            return Math.Sign(aimVector().X);
        }

        public int dashDirectionY(int facing)
        {
            return Math.Sign(aimVector().Y);
        }

        public int mget(int tx, int ty)
        {
            return tilemap[tx + ty * 128];
        }

        public bool fget(int tile, int flag)
        {
            if (tile < mask.Length)
            {
                return (mask[tile] & (1 << flag)) != 0;
            }

            return false;
        }

        public void camera()
        {
            offset = Vector2.Zero;
        }

        public void camera(float x, float y)
        {
            offset = new Vector2((int)Math.Round(x), (int)Math.Round(y));
        }

        public void pal()
        {
            paletteSwap.Clear();
        }

        public void pal(int a, int b)
        {
            PackedColor key = colors[a];
            if (paletteSwap.ContainsKey(key))
            {
                paletteSwap[key] = b;
            }
            else
            {
                paletteSwap.Add(key, b);
            }
        }

        public void rectfill(float x, float y, float x2, float y2, float c)
        {
            float num = Math.Min(x, x2);
            float num2 = Math.Min(y, y2);
            float width = Math.Max(x, x2) - num + 1f;
            float height = Math.Max(y, y2) - num2 + 1f;
            SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, num, num2, width, height, colors[(int)c % 16]);
        }

        public void circfill(float x, float y, float r, float c)
        {
            PackedColor color = colors[(int)c % 16];
            if (r <= 1f)
            {
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, x - 1f, y, 3f, 1f, color);
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, x, y - 1f, 1f, 3f, color);
            }
            else if (r <= 2f)
            {
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, x - 2f, y - 1f, 5f, 3f, color);
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, x - 1f, y - 2f, 3f, 5f, color);
            }
            else if (r <= 3f)
            {
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, x - 3f, y - 1f, 7f, 3f, color);
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, x - 1f, y - 3f, 3f, 7f, color);
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, x - 2f, y - 2f, 5f, 5f, color);
            }
        }

        public void print(string str, float x, float y, float c)
        {
            float num = x;
            PackedColor color = colors[(int)c % 16];
            foreach (char c2 in str)
            {
                int num2 = -1;
                for (int j = 0; j < fontMap.Length; j++)
                {
                    if (fontMap[j] == c2)
                    {
                        num2 = j;
                        break;
                    }
                }

                if (num2 >= 0)
                {
                    SourceAtlasDrawing.Draw((ISourceDrawScope)engine, font[num2], new Vector2(num, y), Vector2.Zero,
                        color);
                }

                num += 4f;
            }
        }

        public void map(int mx, int my, int tx, int ty, int mw, int mh, int mask = 0)
        {
            for (int i = 0; i < mw; i++)
            {
                for (int j = 0; j < mh; j++)
                {
                    byte b = tilemap[i + mx + (j + my) * 128];
                    if (b < sprites.Length && (mask == 0 || fget(b, mask)))
                    {
                        SourceAtlasDrawing.Draw((ISourceDrawScope)engine, sprites[b],
                            new Vector2(tx + i * 8, ty + j * 8),
                            Vector2.Zero, PackedColor.White);
                    }
                }
            }
        }

        public void spr(float sprite, float x, float y, int columns = 1, int rows = 1, bool flipX = false,
            bool flipY = false)
        {
            SourceSpriteEffects spriteEffects = SourceSpriteEffects.None;
            if (flipX)
            {
                spriteEffects |= SourceSpriteEffects.FlipHorizontally;
            }

            if (flipY)
            {
                spriteEffects |= SourceSpriteEffects.FlipVertically;
            }

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    SourceAtlasDrawing.Draw((ISourceDrawScope)engine, sprites[(int)sprite + i + j * 16],
                        new Vector2((int)Math.Floor(x + (float)(i * 8)), (int)Math.Floor(y + (float)(j * 8))),
                        Vector2.Zero,
                        PackedColor.White, 1f, 0f, (spriteEffects & SourceSpriteEffects.FlipHorizontally) != 0,
                        (spriteEffects & SourceSpriteEffects.FlipVertically) != 0);
                }
            }
        }
    }
}
