using System.Collections.Generic;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuEnumerableSlider<T> : TextMenuPresentation.Option<T>
    {
        /// <summary>
        ///       Creates a new <see cref="T:Celeste.TextMenuExt.EnumerableSlider`1" /></summary>
        /// <param name="label">Slider label</param>
        /// <param name="options" />
        /// <param name="startValue">Initial value</param>
        public EverestMenuEnumerableSlider(string label, IEnumerable<T> options, T startValue)
            : base(label)
        {
            foreach (T option in options)
            {
                Add(option.ToString(), option, option.Equals(startValue));
            }
        }

        /// <summary>
        ///       Creates a new <see cref="T:Celeste.TextMenuExt.EnumerableSlider`1" /></summary>
        /// <param name="label">Slider label</param>
        /// <param name="options">IEnumerable containing <typeparamref name="T" />, <see cref="T:System.String" /> pairs.</param>
        /// <param name="startValue">Initial value</param>
        public EverestMenuEnumerableSlider(string label, IEnumerable<KeyValuePair<T, string>> options, T startValue)
            : base(label)
        {
            foreach (KeyValuePair<T, string> option in options)
            {
                Add(option.Value, option.Key, option.Key.Equals(startValue));
            }
        }
    }
}
