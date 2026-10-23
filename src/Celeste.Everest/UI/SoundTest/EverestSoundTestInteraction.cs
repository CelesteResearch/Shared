using System;
using System.Collections.Generic;
using Celeste.Everest;

namespace Celeste.Everest.UI.SoundTest
{
    // Draft of the engine-independent input/playback state. FMOD instances and UI remain host ports.
    public sealed class EverestSoundTestInteraction
    {
        public global::Celeste.Everest.UI.SoundTest.EverestSoundTest Selection { get; } =
            new global::Celeste.Everest.UI.SoundTest.EverestSoundTest();

        public bool ParametersFocused { get; private set; }
        public string PlayingPath { get; private set; }
        public string PreviousMusic { get; private set; }
        public string PreviousAmbience { get; private set; }

        public void Enter(IReadOnlyList<global::Celeste.Everest.UI.SoundTest.EverestSoundTestBank> banks, string music,
            string ambience)
        {
            PreviousMusic = music;
            PreviousAmbience = ambience;
            PlayingPath = null;
            ParametersFocused = false;
            Selection.Initialize(banks);
        }

        public global::Celeste.Everest.UI.SoundTest.EverestSoundTestAction Step(
            global::Celeste.Everest.UI.SoundTest.EverestSoundTestInput input, bool hasParameterMenuItems)
        {
            // OuiSoundTest.Update toggles journal first, then still evaluates Confirm.
            if (input.Journal && hasParameterMenuItems)
                ParametersFocused = !ParametersFocused;

            if (input.Right && Selection.SelectedDigit < 4 && !ParametersFocused)
            {
                Selection.MoveDigit(1);
                return global::Celeste.Everest.UI.SoundTest.EverestSoundTestAction.DigitMoved;
            }

            if (input.Left && Selection.SelectedDigit > 0 && !ParametersFocused)
            {
                Selection.MoveDigit(-1);
                return global::Celeste.Everest.UI.SoundTest.EverestSoundTestAction.DigitMoved;
            }

            if (input.Down && !ParametersFocused)
            {
                Selection.ChangeDigit(-1);
                return global::Celeste.Everest.UI.SoundTest.EverestSoundTestAction.SelectionChanged;
            }

            if (input.Up && !ParametersFocused)
            {
                Selection.ChangeDigit(1);
                return global::Celeste.Everest.UI.SoundTest.EverestSoundTestAction.SelectionChanged;
            }

            if (input.Confirm) return global::Celeste.Everest.UI.SoundTest.EverestSoundTestAction.PlaySelection;
            if (input.Cancel)
            {
                if (ParametersFocused) ParametersFocused = false;
                else return global::Celeste.Everest.UI.SoundTest.EverestSoundTestAction.Exit;
            }

            return global::Celeste.Everest.UI.SoundTest.EverestSoundTestAction.None;
        }

        public void MarkStarted(string path) => PlayingPath = path;
        public bool ReadsPlayingValue => PlayingPath == Selection.SelectedEventPath;

        public float SliderInitialValue(global::Celeste.Everest.UI.SoundTest.EverestSoundTestParameter parameter,
            float? playingFinal)
            => ReadsPlayingValue && playingFinal.HasValue
                ? playingFinal.Value
                : Selection.ParameterValue(parameter);

        public bool ApplyParameterToPlaying => ReadsPlayingValue;

        public void Leave()
        {
            ParametersFocused = false;
            PlayingPath = null;
        }
    }
}
