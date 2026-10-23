using System.Collections.Generic;

namespace Celeste.Everest.UI.SoundTest
{
    // Draft of the engine-independent input/playback state. FMOD instances and UI remain host ports.
    public sealed class EverestSoundTestInteraction
    {
        public EverestSoundTest Selection { get; } = new();

        public bool ParametersFocused { get; private set; }
        public string PlayingPath { get; private set; }
        public string PreviousMusic { get; private set; }
        public string PreviousAmbience { get; private set; }

        public void Enter(IReadOnlyList<EverestSoundTestBank> banks, string music,
            string ambience)
        {
            PreviousMusic = music;
            PreviousAmbience = ambience;
            PlayingPath = null;
            ParametersFocused = false;
            Selection.Initialize(banks);
        }

        public EverestSoundTestAction Step(
            EverestSoundTestInput input, bool hasParameterMenuItems)
        {
            // OuiSoundTest.Update toggles journal first, then still evaluates Confirm.
            if (input.Journal && hasParameterMenuItems)
                ParametersFocused = !ParametersFocused;

            if (input.Right && Selection.SelectedDigit < 4 && !ParametersFocused)
            {
                Selection.MoveDigit(1);
                return EverestSoundTestAction.DigitMoved;
            }

            if (input.Left && Selection.SelectedDigit > 0 && !ParametersFocused)
            {
                Selection.MoveDigit(-1);
                return EverestSoundTestAction.DigitMoved;
            }

            if (input.Down && !ParametersFocused)
            {
                Selection.ChangeDigit(-1);
                return EverestSoundTestAction.SelectionChanged;
            }

            if (input.Up && !ParametersFocused)
            {
                Selection.ChangeDigit(1);
                return EverestSoundTestAction.SelectionChanged;
            }

            if (input.Confirm) return EverestSoundTestAction.PlaySelection;
            if (input.Cancel)
            {
                if (ParametersFocused) ParametersFocused = false;
                else return EverestSoundTestAction.Exit;
            }

            return EverestSoundTestAction.None;
        }

        public void MarkStarted(string path)
        {
            PlayingPath = path;
        }

        public bool ReadsPlayingValue => PlayingPath == Selection.SelectedEventPath;

        public float SliderInitialValue(EverestSoundTestParameter parameter,
            float? playingFinal)
        {
            return ReadsPlayingValue && playingFinal.HasValue
                ? playingFinal.Value
                : Selection.ParameterValue(parameter);
        }

        public bool ApplyParameterToPlaying => ReadsPlayingValue;

        public void Leave()
        {
            ParametersFocused = false;
            PlayingPath = null;
        }
    }
}
