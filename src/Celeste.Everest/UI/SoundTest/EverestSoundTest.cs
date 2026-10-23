using System;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Everest.UI.SoundTest
{
    // OuiSoundTest's five-digit hex selector. Bank order must come directly from
    // FMOD System.getBankList; each bank's events are then sorted by event path.
    public sealed class EverestSoundTest
    {
        private readonly int[] digits = new int[5];
        private readonly Dictionary<string, float> parameters = new();

        private IReadOnlyList<EverestSoundTestBank> banks =
            (EverestSoundTestBank[])[];

        public IReadOnlyList<int> Digits => digits;
        public int SelectedDigit { get; private set; } = 4;
        public string SelectedBankPath { get; private set; } = "";
        public string SelectedEventPath { get; private set; } = "";

        public IReadOnlyList<EverestSoundTestParameter> SelectedParameters { get; private set; } =
            (EverestSoundTestParameter[])[];

        public IReadOnlyDictionary<string, float> ParameterValues => parameters;

        public void Initialize(IReadOnlyList<EverestSoundTestBank> loadedBanks)
        {
            banks = loadedBanks ?? (EverestSoundTestBank[])[];
            Array.Clear(digits, 0, digits.Length);
            SelectedDigit = 4;
            Refresh();
        }

        public void MoveDigit(int direction)
        {
            SelectedDigit =
                Math.Max(0, Math.Min(4, SelectedDigit + Math.Sign(direction)));
        }

        public void ChangeDigit(int direction)
        {
            var value = 0;
            for (var i = 0; i < 5; i++) value = value * 16 + digits[i];
            var weight = 1 << (4 * (4 - SelectedDigit));
            value += Math.Sign(direction) * weight;
            if (value < 0) value += 0x100000;
            for (var i = 0; i < 5; i++) digits[i] = (value >> (4 * (4 - i))) & 15;
            Refresh();
        }

        public void SetParameter(string name, float value)
        {
            var description = SelectedParameters.FirstOrDefault(p => p.Name == name);
            if (description == null) throw new ArgumentOutOfRangeException(nameof(name));
            parameters[name] = value;
        }

        public float ParameterValue(EverestSoundTestParameter parameter)
        {
            return parameters.TryGetValue(parameter.Name, out var value) ? value : parameter.DefaultValue;
        }

        private void Refresh()
        {
            SelectedBankPath = SelectedEventPath = "";
            SelectedParameters = (EverestSoundTestParameter[])[];
            parameters.Clear();
            var bankIndex = digits[0] * 16 + digits[1];
            if (bankIndex >= banks.Count || banks[bankIndex] == null) return;
            var bank = banks[bankIndex];
            SelectedBankPath = bank.Path ?? "";
            var events = bank.Events?.OrderBy(e => e.Path, StringComparer.Ordinal).ToArray()
                         ?? [];
            var eventIndex = digits[2] * 256 + digits[3] * 16 + digits[4];
            if (eventIndex >= events.Length || events[eventIndex] == null) return;
            var selected = events[eventIndex];
            SelectedEventPath = selected.Path ?? "";
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            SelectedParameters = selected.Parameters?.Where(p => p.Maximum != p.Minimum)
                                     .OrderBy(p => p.Name, StringComparer.Ordinal).ToArray()
                                 ?? [];
        }
    }
}
