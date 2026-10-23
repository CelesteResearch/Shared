using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Parameters;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Audio;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Settings;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Localization.Lookup;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.SoundTest
{
    public class EverestSoundTestState : OuiState, IEverestModOptionsSubmenu
    {
        private readonly ISourceEngineContext engine;
        private OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;

        private EverestAudioEventNamePolicy AudioNames =>
            (EverestAudioEventNamePolicy)Audio.EventNamePolicy;

        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private DialogCatalog Dialog => ((IOriginalGameTextEnvironment)engine).Text.Dialog;
        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;
        private const float onScreenX = 960f;

        private const float offScreenX = 2880f;

        private FmodEventReference playing;

        private string playingPath;

        private string audioPrevMusic;

        private string audioPrevAmbience;

        private float pressedTimer;

        private float timer;

        private float ease;

        private readonly int[] digits = new int[5];

        private int selectedDigit;

        private string selectedBankPath;

        private string selectedPath;

        private readonly WigglerComponent[] wigglerDigits;

        private readonly WigglerComponent wigglerPath;

        private readonly WigglerComponent wigglerBankPath;

        private readonly PackedColor unselectColor = PackedColor.White;

        private readonly PackedColor unselectSpecialColor = PackedColor.LightSlateGray;

        private readonly PackedColor selectColorA = SourceHexColor.HexToColor("84FF54");

        private readonly PackedColor selectColorB = SourceHexColor.HexToColor("FCFF59");

        private TextMenuPresentation musicParamMenu;

        private float musicParamMenuEase;

        private readonly Dictionary<string, float> musicParams = new();

        public EverestSoundTestState(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            wigglerDigits = new WigglerComponent[digits.Length];
            for (var i = 0; i < digits.Length; i++)
                wigglerDigits[i] = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f);

            wigglerPath = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f);
            wigglerBankPath = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f);
            Position = new(0f, 1080f);
            Visible = false;
        }

        public override IEnumerator Enter(OuiState from)
        {
            audioPrevMusic = Audio.GetEventName(Audio.CurrentMusicEventInstance);
            Audio.SetMusic(null);
            audioPrevAmbience = Audio.GetEventName(Audio.CurrentAmbienceEventInstance);
            Audio.SetAmbience(null);
            Visible = true;
            musicParamMenu = new(engine);
            musicParamMenu.Focused = false;
            musicParamMenu.MinWidth = 500f;
            for (var i = 0; i < digits.Length; i++) digits[i] = 0;

            selectedDigit = digits.Length - 1;
            UpdateSelectedPath();
            var posFrom = Position;
            var posTo = Vector2.Zero;
            for (var t = 0f; t < 1f; t += engine.Frame.DeltaTime * 2f)
            {
                ease = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(t);
                Position = posFrom +
                           (posTo - posFrom) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(t);
                yield return null;
            }

            ease = 1f;
            _ = Vector2.Zero;
            _ = Vector2.Zero;
            yield return 0.2f;
            Focused = true;
            yield return 0.2f;
            for (var j = 0; j < digits.Length; j++) wigglerDigits[j].Start();

            wigglerPath.Start();
            wigglerBankPath.Start();
        }

        public override IEnumerator Leave(OuiState next)
        {
            Audio.SetMusic(audioPrevMusic);
            Audio.SetAmbience(audioPrevAmbience);
            Audio.Play("event:/ui/main/whoosh_large_out");
            if (playing != null) Audio.Stop(playing);

            Focused = false;
            var posFrom = Position;
            var posTo = new Vector2(0f, 1080f);
            for (var t = 0f; t < 1f; t += engine.Frame.DeltaTime * 2f)
            {
                ease = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(t);
                Position = posFrom +
                           (posTo - posFrom) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(t);
                yield return null;
            }

            Visible = false;
            musicParamMenu = null;
            playingPath = null;
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            if (playing != null) Audio.Stop(playing);
        }

        public override void Update()
        {
            musicParamMenuEase = ScalarMath.Approach(musicParamMenuEase, musicParamMenu?.Focused ?? false ? 1 : 0,
                engine.Frame.DeltaTime * 2f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (Selected && Focused)
            {
                if (musicParamMenu.Focused) musicParamMenu.Update();

                if (Focused && musicParamMenu != null && Input.MenuJournal.Pressed && musicParamMenu.Items.Count != 0)
                {
                    musicParamMenu.Selection = musicParamMenu.FirstPossibleSelection;
                    musicParamMenu.Focused = !musicParamMenu.Focused;
                }

                if (Input.MenuRight.Pressed && selectedDigit < digits.Length - 1 && !musicParamMenu.Focused)
                {
                    selectedDigit = Math.Min(selectedDigit + 1, digits.Length - 1);
                    wigglerDigits[selectedDigit].Start();
                    Audio.Play("event:/ui/main/rollover_down");
                }
                else if (Input.MenuLeft.Pressed && selectedDigit > 0 && !musicParamMenu.Focused)
                {
                    selectedDigit = Math.Max(selectedDigit - 1, 0);
                    wigglerDigits[selectedDigit].Start();
                    Audio.Play("event:/ui/main/rollover_up");
                }
                else if (Input.MenuDown.Pressed && !musicParamMenu.Focused)
                {
                    UpdateDigits(selectedDigit, -1);
                }
                else if (Input.MenuUp.Pressed && !musicParamMenu.Focused)
                {
                    UpdateDigits(selectedDigit, 1);
                }
                else if (Input.MenuConfirm.Pressed)
                {
                    if (playing != null) Audio.Stop(playing);

                    if (!string.IsNullOrEmpty(selectedPath))
                    {
                        playing = playWithMusicParams(selectedPath, musicParams);
                        playingPath = selectedPath;
                    }
                }
                else if (Input.MenuCancel.Pressed || Input.Pause.Pressed || Input.ESC.Pressed)
                {
                    if (musicParamMenu.Focused)
                    {
                        musicParamMenu.Focused = false;
                    }
                    else
                    {
                        Focused = false;
                        Audio.Play("event:/ui/main/button_back");
                        Overworld.Goto<EverestModOptionsState>();
                    }
                }
            }

            pressedTimer -= engine.Frame.DeltaTime;
            timer += engine.Frame.DeltaTime;
            for (var i = 0; i < digits.Length; i++) wigglerDigits[i].Update();

            wigglerPath.Update();
            wigglerBankPath.Update();
        }

        private FmodEventReference playWithMusicParams(string path, Dictionary<string, float> musicParams)
        {
            var eventInstance = Audio.CreateInstance(path, null, null);
            if (eventInstance != null)
            {
                foreach (var musicParam in musicParams) eventInstance.SetParameter(musicParam.Key, musicParam.Value);

                eventInstance.Start();
                eventInstance.Release();
            }

            return eventInstance;
        }

        private void UpdateDigits(int index, int dir)
        {
            var num = 0;
            for (var i = 0; i < digits.Length; i++) num += digits[i] * (int)Math.Pow(16.0, digits.Length - 1 - i);

            num += dir * (int)Math.Pow(16.0, digits.Length - 1 - index);
            if (num < 0) num = (int)Math.Pow(16.0, digits.Length) + num;

            for (var j = 0; j < digits.Length; j++)
            {
                var num2 = (int)Math.Pow(16.0, digits.Length - 1 - j);
                var num3 = num / num2 % 16;
                if (num3 != digits[j]) wigglerDigits[j].Start();

                digits[j] = num3;
            }

            if (index <= 1)
                wigglerBankPath.Start();
            else
                wigglerPath.Start();

            if (dir < 0)
                Audio.Play("event:/ui/main/button_toggle_off");
            else
                Audio.Play("event:/ui/main/button_toggle_on");

            UpdateSelectedPath();
        }

        private void UpdateSelectedPath()
        {
            selectedBankPath = "";
            selectedPath = "";
            musicParamMenu.Clear();
            musicParams.Clear();
            Audio.Device.Runtime.GetBankListNative(out var array);
            var num = 0;
            for (var i = 0; i <= 1; i++) num += digits[i] * (int)Math.Pow(16.0, 1 - i);

            if (num >= array.Length) return;

            var obj = array[num];
            if ((object)obj == null || !obj.IsValidNative()) return;

            var bank = array[num];
            selectedBankPath = AudioNames.GetBankName(bank);
            bank.GetEventListNative(out var array2);
            var list = (from e in array2
                where e?.IsValidNative() ?? false
                select AudioNames.GetEventName(e)).ToList();
            list.Sort();
            var num2 = 0;
            for (var num3 = 2; num3 < digits.Length; num3++)
                num2 += digits[num3] * (int)Math.Pow(16.0, digits.Length - 1 - num3);

            if (num2 >= list.Count) return;

            selectedPath = list[num2];
            var eventDescription =
                Audio.Device.Runtime.GetSourceEventDescription(selectedPath);
            if (!(eventDescription != null)) return;

            eventDescription.GetParameterCountNative(out var count);
            var list2 = new List<string>();
            for (var num4 = 0; num4 < count; num4++)
            {
                eventDescription.GetParameterByIndexNative(num4, out var parameter);
                list2.Add(parameter.Name);
            }

            list2.Sort();
            foreach (var item in list2)
            {
                eventDescription.GetParameterNative(item, out var param);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (param.Maximum == param.Minimum) continue;

                if (musicParamMenu.Items.Count == 0)
                    musicParamMenu.Add(new TextMenuPresentation.SubHeader(Dialog.Clean("SOUNDTEST_AUDIOPARAMS")));

                if (param.Maximum - param.Minimum < 3f)
                {
                    musicParamMenu.Add(new TextMenuPresentation.Slider(param.Name,
                        index => (index / 10f).ToString(), (int)(param.Minimum * 10f),
                        (int)(param.Maximum * 10f), (int)(getParamValueOrDefault(param) * 10f)).Change(
                        delegate(int value)
                        {
                            var value2 = value / 10f;
                            musicParams[param.Name] = value2;
                            if (playingPath == selectedPath) playing.SetParameter(param.Name, value2);
                        }));
                    continue;
                }

                musicParamMenu.Add(
                    new EverestMenuIntSlider(param.Name, (int)param.Minimum, (int)param.Maximum,
                        (int)getParamValueOrDefault(param)).Change(delegate(int value)
                    {
                        musicParams[param.Name] = value;
                        if (playingPath == selectedPath) playing.SetParameter(param.Name, value);
                    }));
            }
        }

        private float getParamValueOrDefault(FmodParameterDescription param)
        {
            if (playingPath == selectedPath)
            {
                playing.GetParameterValue(param.Name, out _, out var finalvalue);
                return finalvalue;
            }

            return param.DefaultValue;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (ease > 0f)
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * ease * 0.4f);

            base.Render(context);
            _ = Position + new Vector2(960f, 540f);
            var vector = Position + new Vector2(384f, 540f);
            var vector2 = vector;
            for (var i = 0; i < digits.Length; i++)
            {
                DrawOptionText(context, digits[i].ToString("X1"),
                    vector2 + new Vector2(0f, wigglerDigits[i].Value * 8f),
                    new(0f, 0.5f), Vector2.One, selectedDigit == i && !musicParamMenu.Focused, i <= 1);
                vector2.X += 48f;
            }

            vector2 = vector + new Vector2(96f, 51.2f + wigglerPath.Value * 2f);
            ActiveFont.DrawOutline(context, this, selectedPath ?? "", vector2, new(0f, 0.5f),
                Vector2.One * 0.75f,
                PackedColor.White * ease, 2f, PackedColor.Black * ease * ease * ease);
            vector2 = vector + new Vector2(0f, -51.2f + wigglerBankPath.Value * 2f);
            ActiveFont.DrawOutline(context, this, selectedBankPath ?? "", vector2, new(0f, 0.5f),
                Vector2.One * 0.75f, PackedColor.LightSlateGray * ease, 2f, PackedColor.Black * ease * ease * ease);
            if (musicParamMenu.Items.Count > 0)
            {
                vector2 = vector + new Vector2(0f, 128f + wigglerBankPath.Value * 2f);
                ActiveFont.DrawOutline(context, this, Dialog.Clean("SOUNDTEST_AUDIOPARAMS_OPEN_1"), vector2,
                    new(0f, 0.5f), Vector2.One * 0.75f, PackedColor.White * ease, 2f,
                    PackedColor.Black * ease * ease * ease);
                vector2.X += ActiveFont.Measure(Dialog.Clean("SOUNDTEST_AUDIOPARAMS_OPEN_1")).X * 0.75f + 10f;
                var mTexture = Input.GuiButton(Input.MenuJournal);
                SourceAtlasDrawing.DrawJustified(context, this, mTexture, vector2, new(0f, 0.5f),
                    PackedColor.White,
                    0.75f);
                vector2.X += mTexture.Width * 0.75f + 10f;
                ActiveFont.DrawOutline(context, this, Dialog.Clean("SOUNDTEST_AUDIOPARAMS_OPEN_2"), vector2,
                    new(0f, 0.5f), Vector2.One * 0.75f, PackedColor.White * ease, 2f,
                    PackedColor.Black * ease * ease * ease);
            }

            ActiveFont.DrawEdgeOutline(context, this, Dialog.Clean("soundtest_title"),
                Position + new Vector2(960f, 256f),
                new(0.5f, 0.5f), Vector2.One * 2f, PackedColor.Gray, 4f, PackedColor.DarkSlateBlue, 2f,
                PackedColor.Black);
            if (musicParamMenuEase > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f,
                    PackedColor.Black * 0.95f *
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(musicParamMenuEase));
                musicParamMenu.Alpha =
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(musicParamMenuEase);
                musicParamMenu.Render(context);
            }
        }

        private void DrawOptionText(ISourceRenderContext context, string text, Vector2 at, Vector2 justify,
            Vector2 scale,
            bool selected, bool special = false)
        {
            var color = !selected
                ? special ? unselectSpecialColor : unselectColor
                : !((IEverestCoreSettingsEnvironment)engine).CurrentCoreSettings.AllowTextHighlight ||
                  timer % (0.1f * 2f) > 0.1f
                    ? selectColorA
                    : selectColorB;
            ActiveFont.DrawOutline(context, this, text, at, justify, scale, color * ease, 2f,
                PackedColor.Black * ease * ease * ease);
        }
    }
}
