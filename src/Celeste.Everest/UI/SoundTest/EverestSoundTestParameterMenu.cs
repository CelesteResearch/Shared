using System;
using Celeste.Simulation.Rendering;
using Celeste.Everest;

namespace Celeste.Everest.UI.SoundTest
{
    // The two hosts supply FMOD reads/writes; slider range, selection and
    // replay-cache behavior follow OuiSoundTest in one place.
    public static class EverestSoundTestParameterMenu
    {
        public static void Build(global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation menu,
            global::Celeste.Everest.UI.SoundTest.EverestSoundTestInteraction interaction, string header,
            Func<string, float?> playingFinalValue,
            Action<string, float> setPlayingParameter)
        {
            menu.Clear();
            global::Celeste.Everest.UI.SoundTest.EverestSoundTest state = interaction.Selection;
            if (state.SelectedParameters.Count == 0) return;
            menu.Add(new global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.SubHeader(header));
            foreach (var parameter in state.SelectedParameters)
            {
                float? final = interaction.ReadsPlayingValue
                    ? playingFinalValue(parameter.Name)
                    : null;
                float selected = interaction.SliderInitialValue(parameter, final);
                bool fractional = parameter.Maximum - parameter.Minimum < 3;
                int min = fractional ? (int)(parameter.Minimum * 10) : (int)parameter.Minimum;
                int max = fractional ? (int)(parameter.Maximum * 10) : (int)parameter.Maximum;
                int selectedIndex = fractional ? (int)(selected * 10) : (int)selected;
                var slider =
                    new global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.Option<object>(parameter.Name);
                for (int i = min; i <= max; i++)
                {
                    float value = fractional ? i / 10f : i;
                    slider.Add(value.ToString(), value, i == selectedIndex);
                }

                string name = parameter.Name;
                slider.Change(value =>
                {
                    float amount = (float)value;
                    state.SetParameter(name, amount);
                    if (interaction.ApplyParameterToPlaying)
                        setPlayingParameter(name, amount);
                });
                menu.Add(slider);
            }
        }
    }
}
