using System;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.SoundTest
{
    // The two hosts supply FMOD reads/writes; slider range, selection and
    // replay-cache behavior follow OuiSoundTest in one place.
    public static class EverestSoundTestParameterMenu
    {
        public static void Build(TextMenuPresentation menu,
            EverestSoundTestInteraction interaction, string header,
            Func<string, float?> playingFinalValue,
            Action<string, float> setPlayingParameter)
        {
            menu.Clear();
            var state = interaction.Selection;
            if (state.SelectedParameters.Count == 0) return;
            menu.Add(new TextMenuPresentation.SubHeader(header));
            foreach (var parameter in state.SelectedParameters)
            {
                var final = interaction.ReadsPlayingValue
                    ? playingFinalValue(parameter.Name)
                    : null;
                var selected = interaction.SliderInitialValue(parameter, final);
                var fractional = parameter.Maximum - parameter.Minimum < 3;
                var min = fractional ? (int)(parameter.Minimum * 10) : (int)parameter.Minimum;
                var max = fractional ? (int)(parameter.Maximum * 10) : (int)parameter.Maximum;
                var selectedIndex = fractional ? (int)(selected * 10) : (int)selected;
                var slider =
                    new TextMenuPresentation.Option<object>(parameter.Name);
                for (var i = min; i <= max; i++)
                {
                    var value = fractional ? i / 10f : i;
                    slider.Add(value.ToString(), value, i == selectedIndex);
                }

                var name = parameter.Name;
                slider.Change(value =>
                {
                    var amount = (float)value;
                    state.SetParameter(name, amount);
                    if (interaction.ApplyParameterToPlaying)
                        setPlayingParameter(name, amount);
                });
                menu.Add(slider);
            }
        }
    }
}
