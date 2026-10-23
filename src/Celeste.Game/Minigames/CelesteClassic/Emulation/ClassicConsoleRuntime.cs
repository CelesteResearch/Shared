using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
using Celeste.Audio.Fmod.Events;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Minigames.CelesteClassic.Content;
using Celeste.Game.Minigames.CelesteClassic.Extensions;
using Celeste.Game.Minigames.CelesteClassic.Gameplay;
using Celeste.Game.Minigames.CelesteClassic.Options;
using Celeste.Game.Minigames.CelesteClassic.Progress;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Settings;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Game.Minigames.CelesteClassic.Emulation
{
    public class ClassicConsoleRuntime : SourceSceneState, IOriginalEngineDashAssistScene
    {
        private static string MapData =>
            ClassicCartridgeData.MapData;

        public SourceSceneState ReturnTo;
        private readonly ISourceEngineContext _engine;
        public bool IsGameUninitialized => Game == null;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public Pico8Classic Game => game;
        public IntPoint BootLevel => _bootLevel;

        public IClassicBehaviorHooks BehaviorHooks => SourceRuntimeExtensions
            .Get<IClassicBehaviorEnvironment>(_engine)?.ClassicBehaviorHooks;

        public void UpdateFirstTrackedDashAssist()
        {
            OriginalEngineDashAssistSceneBody.UpdateFirstTrackedDashAssist(SourceScene, EngineContext);
        }

        public void CommitEntityLists()
        {
            OriginalEngineDashAssistSceneBody.CommitEntityLists(SourceScene);
        }

        public Pico8ShakeAmount ScreenShake =>
            (Pico8ShakeAmount)
            ((ISettingsContext)_engine).Settings.ScreenShake;

        private Pico8Classic game;

        private int _gameFrame;

        private bool _gameActive = true;

        private float _gameDelay;

        private readonly IntPoint _bootLevel;

        private bool _leaving;

        private bool _skipFrame = true;

        private FmodEventReference _bgSfx;

        private readonly VirtualRenderTarget _buffer;

        private readonly PackedColor[] _pixels = new PackedColor[16384];

        private Vector2 _offset = Vector2.Zero;

        private TextMenuPresentation _pauseMenu;

        private float _pauseFade;

        private FmodEventReference _snapshot;

        private readonly AtlasEntry _picoBootLogo;

        private byte[] _tilemap;

        private readonly AtlasEntry[] _sprites;

        private readonly byte[] _mask =
        [
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
            0, 2, 2, 2, 2, 2, 2, 2,
        ];

        private readonly PackedColor[] _colors =
        [
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
            SourceHexColor.HexToColor("ffccaa"),
        ];

        private readonly Dictionary<PackedColor, int> _paletteSwap = new();

        private readonly AtlasEntry[] _font;

        private const string FontMap = "abcdefghijklmnopqrstuvwxyz0123456789~!@#4%^&*()_+-=?:.";

        public bool CanPause => _pauseMenu == null;

        public static ClassicConsoleRuntime Create(ISourceEngineContext engine, SourceSceneState returnTo,
            int levelX = 0, int levelY = 0)
        {
            SourceRuntimeExtensions.Get<IClassicBehaviorEnvironment>(engine)
                ?.ClassicBehaviorHooks?.EmulatorConstructing();
            var emulator = new ClassicConsoleRuntime(engine, returnTo, levelX, levelY);
            ((IOriginalClassicConsolePolicyEnvironment)engine).ClassicConsolePolicy.AfterConstructor(emulator);
            return emulator;
        }

        private bool Booting => Game == null;

        private ClassicConsoleRuntime(ISourceEngineContext engine, SourceSceneState returnTo, int levelX = 0,
            int levelY = 0)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            _engine = engine;
            ReturnTo = returnTo;
            _bootLevel = new(levelX, levelY);
            _buffer = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("pico-8", 128, 128);
            var mTexture = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["pico8/atlas"];
            _sprites = new AtlasEntry[mTexture.FrameWidth / 8 * (mTexture.FrameHeight / 8)];
            for (var i = 0; i < mTexture.FrameHeight / 8; i++)
            for (var j = 0; j < mTexture.FrameWidth / 8; j++)
                _sprites[j + i * (mTexture.FrameWidth / 8)] = mTexture.GetSubtexture(j * 8, i * 8, 8, 8);

            var input = MapData;
            input = Regex.Replace(input, "\\s+", "");
            _tilemap = new byte[input.Length / 2];
            var k = 0;
            var length = input.Length;
            var num = length / 2;
            for (; k < length; k += 2)
            {
                var c = input[k];
                var c2 = input[k + 1];
                var s = k < num ? c.ToString() + c2 : c2.ToString() + c;
                _tilemap[k / 2] = (byte)int.Parse(s, NumberStyles.HexNumber);
            }

            var mTexture2 = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["pico8/font"];
            _font = new AtlasEntry[mTexture2.FrameWidth / 4 * (mTexture2.FrameHeight / 6)];
            for (var l = 0; l < mTexture2.FrameHeight / 6; l++)
            for (var m = 0; m < mTexture2.FrameWidth / 4; m++)
                _font[m + l * (mTexture2.FrameWidth / 4)] = mTexture2.GetSubtexture(m * 4, l * 6, 4, 6);

            _picoBootLogo = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["pico8/logo"];
            ResetScreen();
            ((IOriginalGameplayProcess)engine).AudioSession.SetMusic(null);
            ((IOriginalGameplayProcess)engine).AudioSession.SetAmbience(null);
            _ = new FadeWipePresentation(this, true);
            Renderers.UpdateLists();
        }

        public void InstallTilemapText(string input)
        {
            input = Regex.Replace(input, "\\s+", "");
            _tilemap = new byte[input.Length / 2];
            var length = input.Length;
            var num = length / 2;
            Span<char> pair = stackalloc char[2];
            for (var i = 0; i < length; i += 2)
            {
                var c = input[i];
                var c2 = input[i + 1];
                var array = _tilemap;
                var num2 = i / 2;
                pair[0] = i >= num ? c2 : c;
                pair[1] = i >= num ? c : c2;
                var s = new string(pair);
                array[num2] = (byte)int.Parse(s, NumberStyles.HexNumber);
            }
        }

        public override void Begin()
        {
            _bgSfx = ((IOriginalGameplayProcess)_engine).AudioSession.Play("event:/env/amb/03_pico8_closeup");
            base.Begin();
        }

        public override void End()
        {
            _buffer.Dispose();
            ((IOriginalGameplayProcess)_engine).AudioSession.BusStopAll("bus:/gameplay_sfx");
            ((IOriginalGameplayProcess)_engine).AudioSession.Stop(_bgSfx);
            if (_snapshot != null) ((IOriginalGameplayProcess)_engine).AudioSession.ReleaseSnapshot(_snapshot);

            _snapshot = null;
            ((IOriginalPlatformStatisticsEnvironment)_engine).Statistics.Store();
            base.End();
        }

        private void ResetScreen()
        {
            ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.Textures[0] = null;
            ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.Textures[1] = null;
            for (var i = 0; i < 128; i++)
            for (var j = 0; j < 128; j++)
                _pixels[i + j * 128] = PackedColor.Black;

            _buffer.Target.SetData(_pixels);
        }

        public override void Update()
        {
            base.Update();
            if (_pauseMenu != null)
            {
                _pauseMenu.Update();
            }
            else if (!_leaving && (((IOriginalGameInputProcessEnvironment)_engine).InputSource.Pause.Pressed ||
                                   ((IOriginalGameInputProcessEnvironment)_engine).InputSource.ESC.Pressed))
            {
                ((IOriginalGameInputProcessEnvironment)_engine).InputSource.Pause.ConsumeBuffer();
                ((IOriginalGameInputProcessEnvironment)_engine).InputSource.ESC.ConsumeBuffer();
                CreatePauseMenu();
            }

            _pauseFade = ScalarMath.Approach(_pauseFade, _pauseMenu != null ? 0.75f : 0f, _engine.DeltaTime * 6f,
                ((ISourceExtremaEnvironment)_engine).ExtremaArithmetic);
            _skipFrame = !_skipFrame;
            if (_skipFrame) return;

            _gameDelay -= _engine.DeltaTime;
            if (!_gameActive || _gameDelay > 0f) return;

            if (Booting)
            {
                ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.Textures[0] = null;
                ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.Textures[1] = null;
                _gameFrame++;
                var num = _gameFrame - 20;
                switch (num)
                {
                    case 1:
                    {
                        for (var i = 0; i < 128; i++)
                        for (var j = 2; j < 128; j += 8)
                            _pixels[j + i * 128] = _colors[((ISourceRandomEnvironment)_engine).Random.Next(4) + i / 32];

                        _buffer.Target.SetData(_pixels);

                        break;
                    }
                    case 4:
                    {
                        for (var k = 0; k < 128; k += 2)
                        for (var l = 0; l < 128; l += 4)
                            _pixels[l + k * 128] = _colors[6 + (((l + k) / 8) & 7)];

                        _buffer.Target.SetData(_pixels);

                        break;
                    }
                    case 7:
                    {
                        for (var m = 0; m < 128; m += 3)
                        for (var n = 2; n < 128; n += 4)
                            _pixels[n + m * 128] = _colors[10 + ((ISourceRandomEnvironment)_engine).Random.Next(4)];

                        _buffer.Target.SetData(_pixels);

                        break;
                    }
                    case 9:
                    {
                        for (var num2 = 0; num2 < 128; num2++)
                        for (var num3 = 1; num3 < 127; num3 += 2)
                            _pixels[num3 + num2 * 128] = _pixels[num3 + 1 + num2 * 128];

                        _buffer.Target.SetData(_pixels);

                        break;
                    }
                    case 12:
                    {
                        for (var num4 = 0; num4 < 128; num4++)
                            if ((num4 & 3) > 0)
                                for (var num5 = 0; num5 < 128; num5++)
                                    _pixels[num5 + num4 * 128] = _colors[0];

                        _buffer.Target.SetData(_pixels);

                        break;
                    }
                    case 15:
                    {
                        for (var num6 = 0; num6 < 128; num6++)
                        for (var num7 = 0; num7 < 128; num7++)
                            _pixels[num7 + num6 * 128] = _colors[0];

                        _buffer.Target.SetData(_pixels);

                        break;
                    }
                    case 30:
                    {
                        ((IOriginalGameplayProcess)_engine).AudioSession.Play("event:/classic/pico8_boot");

                        break;
                    }
                }

                switch (num)
                {
                    case 30 or 35 or 40:
                    {
                        ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.SetRenderTarget(_buffer.Target);
                        ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.Clear(_colors[0]);
                        ((ISourceDrawScope)_engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                            SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp, null,
                            SourceRasterizerState.CullNone);
                        SourceAtlasDrawing.Draw((ISourceDrawScope)_engine, _picoBootLogo, new(1f, 1f), Vector2.Zero,
                            PackedColor.White);
                        if (num >= 35) print("pico-8 0.1.9B", 1f, 18f, 6f);

                        if (num >= 40)
                        {
                            print("(c) 2014-16 lexaloffle games llp", 1f, 24f, 6f);
                            print("booting cartridge..", 1f, 36f, 6f);
                        }

                        ((ISourceDrawScope)_engine).Draw.SpriteBatch.End();
                        ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.SetRenderTarget(null);

                        break;
                    }
                }

                if (num != 90) return;
                _gameFrame = 0;
                game = new();
                Game.Init(this);
                if (_bootLevel is not { X: 0, Y: 0 }) Game.load_room(_bootLevel.X, _bootLevel.Y);


                return;
            }

            _gameFrame++;
            Game.Update();
            if (Game.freeze > 0) return;

            ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.SetRenderTarget(_buffer.Target);
            ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.Clear(_colors[0]);
            ((ISourceDrawScope)_engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, null, SourceRasterizerState.CullNone, null,
                SourceMatrixMath.CreateTranslation(0f - _offset.X, 0f - _offset.Y, 0f));
            Game.Draw();
            ((ISourceDrawScope)_engine).Draw.SpriteBatch.End();
            ((ISourceGraphicsDeviceEnvironment)_engine).GraphicsDevice.SetRenderTarget(null);
            if (_paletteSwap.Count <= 0) return;

            _buffer.Target.GetData(_pixels);
            for (var num8 = 0; num8 < _pixels.Length; num8++)
                if (_paletteSwap.TryGetValue(_pixels[num8], out var value))
                    _pixels[num8] = _colors[value];

            _buffer.Target.SetData(_pixels);
        }

        public override void Render()
        {
            ((ISourceDrawScope)_engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, null, SourceRasterizerState.CullNone, null,
                ((IOriginalEngineGraphicsEnvironment)_engine).EngineGraphics.ScreenMatrix);
            const int num = 6;
            var vector = new Vector2(_buffer.Width * num, _buffer.Height * num);
            var position = new Vector2(1920f - vector.X, 1080f - vector.Y) / 2f;
            var flag = ((IOriginalGameplayProcess)_engine).SaveContext.CurrentSave is { Assists.MirrorMode: true };
            SourceAtlasDrawing.Draw((ISourceDrawScope)_engine,
                ((ISourceGameGraphicsEnvironment)_engine).GameGraphics.GameAtlas["pico8/consoleBG"], Vector2.Zero,
                Vector2.Zero, PackedColor.White, num);
            ((ISourceDrawScope)_engine).Draw.SpriteBatch.Draw(_buffer.Target, position, _buffer.Bounds,
                PackedColor.White.PackedValue, 0f, Vector2.Zero, num,
                flag ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None, 0f);
            ((ISourceDrawScope)_engine).Draw.SpriteBatch.End();
            if (_pauseMenu != null || _pauseFade > 0f)
            {
                ((ISourceDrawScope)_engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, SourceRasterizerState.CullNone,
                    null,
                    ((IOriginalEngineGraphicsEnvironment)_engine).EngineGraphics.ScreenMatrix);
                SourcePrimitiveDrawing.Rect((ISourceDrawScope)_engine, -1f, -1f, 1922f, 1082f,
                    PackedColor.Black * _pauseFade);
                _pauseMenu?.Render(SourceRenderContext);

                ((ISourceDrawScope)_engine).Draw.SpriteBatch.End();
            }

            base.Render();
        }

        public void CreatePauseMenu()
        {
            ((IOriginalGameplayProcess)_engine).AudioSession.Play("event:/ui/game/pause");
            ((IOriginalGameplayProcess)_engine).AudioSession.PauseGameplaySfx = true;
            _snapshot = ((IOriginalGameplayProcess)_engine).AudioSession.CreateSnapshot("snapshot:/pause_menu");
            var menu = new TextMenuPresentation(_engine);
            menu.Add(new TextMenuPresentation.Button(
                    ((IOriginalGameTextEnvironment)_engine).Text.CleanDialog("pico8_pause_continue"))
                .Pressed(delegate { menu.OnCancel(); }));
            menu.Add(new TextMenuPresentation.Button(
                ((IOriginalGameTextEnvironment)_engine).Text.CleanDialog("pico8_pause_restart")).Pressed(delegate
            {
                _pauseMenu = null;
                music(-1, 0, 0);
                _ = new FadeWipePresentation(this, false, delegate
                {
                    ((IOriginalGameplayProcess)_engine).AudioSession.BusStopAll("bus:/gameplay_sfx");
                    ((IOriginalGameplayProcess)_engine).AudioSession.PauseGameplaySfx = false;
                    ((IOriginalGameplayProcess)_engine).AudioSession.ReleaseSnapshot(_snapshot);
                    _snapshot = null;
                    ResetScreen();
                    game = null;
                    _gameFrame = 0;
                    _gameActive = true;
                    _ = new FadeWipePresentation(this, true);
                });
            }));
            menu.Add(new TextMenuPresentation.Button(
                ((IOriginalGameTextEnvironment)_engine).Text.CleanDialog("pico8_pause_quit")).Pressed(delegate
            {
                _leaving = true;
                _gameActive = false;
                _pauseMenu = null;
                music(-1, 0, 0);
                _ = new FadeWipePresentation(this, false, delegate
                {
                    ((IOriginalGameplayProcess)_engine).AudioSession.BusStopAll("bus:/gameplay_sfx");
                    ((IOriginalGameplayProcess)_engine).AudioSession.PauseGameplaySfx = false;
                    ((IOriginalGameplayProcess)_engine).AudioSession.ReleaseSnapshot(_snapshot);
                    ((IOriginalGameplayProcess)_engine).AudioSession.Stop(_bgSfx);
                    _snapshot = null;
                    if (ReturnTo != null)
                    {
                        if (ReturnTo is OriginalLevelSceneRoot level)
                        {
                            OriginalAudioSession.Apply(level.Session.Audio,
                                ((IOriginalGameplayProcess)_engine).AudioSession.ChannelOutput,
                                ((IOriginalGameplayProcess)_engine).AudioApplyPolicy);
                            _ = new FadeWipePresentation(ReturnTo, true);
                        }

                        _engine.Frame.Scenes.NextScene = ReturnTo;
                    }
                    else
                    {
                        _engine.Frame.Scenes.NextScene =
                            ((IOriginalOverworldLoaderEnvironment)_engine).OverworldLoaders.CreateOverworldLoader(
                                OverworldStartMode.Titlescreen);
                    }
                });
            }));
            menu.OnCancel = menu.OnESC = menu.OnPause = delegate
            {
                ((IOriginalGameplayProcess)_engine).AudioSession.PauseGameplaySfx = false;
                ((IOriginalGameplayProcess)_engine).AudioSession.ReleaseSnapshot(_snapshot);
                _snapshot = null;
                _gameDelay = 0.1f;
                _pauseMenu = null;
                _gameActive = true;
                menu.RemoveSelf();
            };
            _gameActive = false;
            _pauseMenu = menu;
        }

        public void music(int index, int fade, int mask)
        {
            switch (index)
            {
                case -1:
                    ((IOriginalGameplayProcess)_engine).AudioSession.SetMusic(null);
                    break;
                case 0:
                    ((IOriginalGameplayProcess)_engine).AudioSession.SetMusic("event:/classic/pico8_mus_01");
                    break;
                case 10:
                    ((IOriginalGameplayProcess)_engine).AudioSession.SetMusic("event:/classic/pico8_mus_03");
                    break;
                case 20:
                    ((IOriginalGameplayProcess)_engine).AudioSession.SetMusic("event:/classic/pico8_mus_02");
                    break;
                case 30:
                    ((IOriginalGameplayProcess)_engine).AudioSession.SetMusic("event:/classic/sfx61");
                    break;
                case 40:
                    ((IOriginalGameplayProcess)_engine).AudioSession.SetMusic("event:/classic/pico8_mus_00");
                    break;
            }
        }

        public void sfx(int sfx)
        {
            ((IOriginalGameplayProcess)_engine).AudioSession.Play("event:/classic/sfx" + sfx);
        }

        public float rnd(float max)
        {
            return SourceRandomMath.NextFloat(((ISourceRandomEnvironment)_engine).Random, max);
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
            return ((ISourceExtremaEnvironment)_engine).ExtremaArithmetic.Min(a, b);
        }

        public float max(float a, float b)
        {
            return ((ISourceExtremaEnvironment)_engine).ExtremaArithmetic.Max(a, b);
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
            var num = a % b;
            if (!(num >= 0f)) return b + num;

            return num;
        }

        public void IncrementStat(Pico8Stat statistic)
        {
            var sourceStatistic = statistic switch
            {
                Pico8Stat.Deaths => OriginalStatistic.PICO_DEATHS,
                Pico8Stat.Completes => OriginalStatistic.PICO_COMPLETES,
                Pico8Stat.Berries => OriginalStatistic.PICO_BERRIES,
                _ => throw new ArgumentOutOfRangeException(nameof(statistic)),
            };
            ((IOriginalPlatformStatisticsEnvironment)_engine).Statistics.Increment(sourceStatistic);
        }

        public void UnlockAchievement(Pico8Achievement achievement)
        {
            if (achievement != Pico8Achievement.PICO8)
                throw new ArgumentOutOfRangeException(nameof(achievement));
            ((IOriginalPlatformStatisticsEnvironment)_engine).Statistics.Achievements
                .Register(OriginalAchievement.PICO8);
        }

        public bool btn(int index)
        {
            var vector = new Vector2(((IOriginalGameInputProcessEnvironment)_engine).InputSource.MoveX.Value,
                ((IOriginalGameInputProcessEnvironment)_engine).InputSource.MoveY.Value);
            return index switch
            {
                0 => vector.X < 0f,
                1 => vector.X > 0f,
                2 => vector.Y < 0f,
                3 => vector.Y > 0f,
                4 => ((IOriginalGameInputProcessEnvironment)_engine).InputSource.Jump.Check,
                5 => ((IOriginalGameInputProcessEnvironment)_engine).InputSource.Dash.Check,
                _ => false,
            };
        }

        private Vector2 AimVector()
        {
            var vector = ((IOriginalGameInputProcessEnvironment)_engine).InputSource.Aim.Value;
            if (vector == Vector2.Zero) return vector;
            if (((IOriginalGameplayProcess)_engine).SaveContext.CurrentSave is { Assists.ThreeSixtyDashing: true })
            {
                vector = ((ISourceVectorEnvironment)_engine).VectorArithmetic.SafeNormalize(vector);
            }
            else
            {
                var num = Vector2Geometry.Angle(vector);
                var num2 = num < 0f ? 1 : 0;
                var num3 = (float)Math.PI / 8f - num2 * 0.08726646f;
                vector = Math.Abs(ScalarMath.AngleDiff(num, 0f)) < num3
                    ? new(1f, 0f)
                    : Math.Abs(ScalarMath.AngleDiff(num, (float)Math.PI)) < num3
                        ? new(-1f, 0f)
                        : Math.Abs(ScalarMath.AngleDiff(num, -(float)Math.PI / 2f)) < num3
                            ? new(0f, -1f)
                            : !(Math.Abs(ScalarMath.AngleDiff(num, (float)Math.PI / 2f)) < num3)
                                ? ((ISourceVectorEnvironment)_engine).VectorArithmetic.SafeNormalize(
                                    new Vector2(Math.Sign(vector.X), Math.Sign(vector.Y)))
                                : new(0f, 1f);
            }


            return vector;
        }

        public int dashDirectionX(int facing)
        {
            return Math.Sign(AimVector().X);
        }

        public int dashDirectionY(int facing)
        {
            return Math.Sign(AimVector().Y);
        }

        public int mget(int tx, int ty)
        {
            return _tilemap[tx + ty * 128];
        }

        public bool fget(int tile, int flag)
        {
            if (tile < _mask.Length) return (_mask[tile] & (1 << flag)) != 0;

            return false;
        }

        public void camera()
        {
            _offset = Vector2.Zero;
        }

        public void camera(float x, float y)
        {
            _offset = new((int)Math.Round(x), (int)Math.Round(y));
        }

        public void pal()
        {
            _paletteSwap.Clear();
        }

        public void pal(int a, int b)
        {
            var key = _colors[a];
            _paletteSwap[key] = b;
        }

        public void rectfill(float x, float y, float x2, float y2, float c)
        {
            var num = Math.Min(x, x2);
            var num2 = Math.Min(y, y2);
            var width = Math.Max(x, x2) - num + 1f;
            var height = Math.Max(y, y2) - num2 + 1f;
            SourcePrimitiveDrawing.Rect((ISourceDrawScope)_engine, num, num2, width, height, _colors[(int)c % 16]);
        }

        public void circfill(float x, float y, float r, float c)
        {
            var color = _colors[(int)c % 16];
            switch (r)
            {
                case <= 1f:
                {
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)_engine, x - 1f, y, 3f, 1f, color);
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)_engine, x, y - 1f, 1f, 3f, color);

                    break;
                }
                case <= 2f:
                {
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)_engine, x - 2f, y - 1f, 5f, 3f, color);
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)_engine, x - 1f, y - 2f, 3f, 5f, color);

                    break;
                }
                case <= 3f:
                {
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)_engine, x - 3f, y - 1f, 7f, 3f, color);
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)_engine, x - 1f, y - 3f, 3f, 7f, color);
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)_engine, x - 2f, y - 2f, 5f, 5f, color);

                    break;
                }
            }
        }

        public void print(string str, float x, float y, float c)
        {
            var num = x;
            var color = _colors[(int)c % 16];
            foreach (var c2 in str)
            {
                var num2 = -1;
                for (var j = 0; j < FontMap.Length; j++)
                    if (FontMap[j] == c2)
                    {
                        num2 = j;
                        break;
                    }

                if (num2 >= 0)
                    SourceAtlasDrawing.Draw((ISourceDrawScope)_engine, _font[num2], new(num, y), Vector2.Zero,
                        color);

                num += 4f;
            }
        }

        public void map(int mx, int my, int tx, int ty, int mw, int mh, int mask = 0)
        {
            for (var i = 0; i < mw; i++)
            for (var j = 0; j < mh; j++)
            {
                var b = _tilemap[i + mx + (j + my) * 128];
                if (b < _sprites.Length && (mask == 0 || fget(b, mask)))
                    SourceAtlasDrawing.Draw((ISourceDrawScope)_engine, _sprites[b],
                        new(tx + i * 8, ty + j * 8),
                        Vector2.Zero, PackedColor.White);
            }
        }

        public void spr(float sprite, float x, float y, int columns = 1, int rows = 1, bool flipX = false,
            bool flipY = false)
        {
            var spriteEffects = SourceSpriteEffects.None;
            if (flipX) spriteEffects |= SourceSpriteEffects.FlipHorizontally;

            if (flipY) spriteEffects |= SourceSpriteEffects.FlipVertically;

            for (var i = 0; i < columns; i++)
            for (var j = 0; j < rows; j++)
                SourceAtlasDrawing.Draw((ISourceDrawScope)_engine, _sprites[(int)sprite + i + j * 16],
                    new((int)Math.Floor(x + i * 8), (int)Math.Floor(y + j * 8)),
                    Vector2.Zero,
                    PackedColor.White, 1f, 0f, (spriteEffects & SourceSpriteEffects.FlipHorizontally) != 0,
                    (spriteEffects & SourceSpriteEffects.FlipVertically) != 0);
        }
    }
}
