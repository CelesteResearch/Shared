using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Celeste.Simulation;

namespace Celeste.Simulation.Runtime.Session
{
    public sealed partial class ChapterCompletionSession
    {
        public sealed class Slider
        {
            private readonly global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session;
            private float value;
            public string Name { get; }

            internal Slider(global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session, string name,
                float value)
            {
                this.session = session;
                Name = name;
                this.value = value;
            }

            public float Value
            {
                get => value;
                set
                {
                    float previous = this.value;
                    this.value = value;
                    SimulationSessionHooks.SliderChanged?.Invoke(session, this, previous);
                }
            }
        }

        public static class SerializationOnly
        {
            [DataContract]
            public struct Slider
            {
                [DataMember] public string Name;
                [DataMember] public float Value;
            }
        }

        private Dictionary<string, Slider> sliders = new Dictionary<string, Slider>();
        private Dictionary<string, Slider> SliderValues => sliders ?? (sliders = new Dictionary<string, Slider>());

        public IReadOnlyDictionary<string, Slider> Sliders => SliderValues;

        // Restoring persisted values does not invoke OnSliderChanged in Everest.
        [DataMember]
        public SerializationOnly.Slider[] SlidersSerializationOnly
        {
            get
            {
                var result = new SerializationOnly.Slider[SliderValues.Count];
                int index = 0;
                foreach (var pair in SliderValues)
                    result[index++] = new SerializationOnly.Slider { Name = pair.Key, Value = pair.Value.Value };
                return result;
            }
            set
            {
                SliderValues.Clear();
                foreach (var item in value)
                    SliderValues[item.Name] = new Slider(this, item.Name, item.Value);
            }
        }

        public float GetSlider(string name) => SliderValues.TryGetValue(name, out var slider) ? slider.Value : 0f;

        public Slider GetSliderObject(string name)
        {
            if (!SliderValues.TryGetValue(name, out var slider))
            {
                SliderValues[name] = slider = new Slider(this, name, 0f);
                SimulationSessionHooks.SliderChanged?.Invoke(this, slider, null);
            }

            return slider;
        }

        public void SetSlider(string name, float value) => GetSliderObject(name).Value = value;
        public void AddToSlider(string name, float amount) => GetSliderObject(name).Value += amount;
    }
}
