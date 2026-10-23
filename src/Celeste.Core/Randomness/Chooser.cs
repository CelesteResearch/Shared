using System;
using System.Collections.Generic;
using System.Globalization;

namespace Celeste.Core.Randomness
{
    public class Chooser<T>()
    {
        private class Choice(T value, float weight)
        {
            public T Value = value;
            public readonly float Weight = weight;
        }

        private readonly List<Choice> _choices = [];
        public int Count => _choices.Count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return _choices[index].Value;
            }

            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                _choices[index].Value = value;
            }
        }

        public float TotalWeight { get; private set; }
        public bool CanChoose => TotalWeight > 0f;

        public Chooser(T firstChoice, float weight) : this()
        {
            Add(firstChoice, weight);
        }

        public Chooser(params T[] choices) : this()
        {
            foreach (var choice in choices)
                Add(choice, 1f);
        }

        public Chooser<T> Add(T choice, float weight)
        {
            weight = Math.Max(weight, 0f);
            _choices.Add(new(choice, weight));
            TotalWeight += weight;
            return this;
        }

        public T Choose(ISourceRandom random)
        {
            if (TotalWeight <= 0f)
                return default;
            if (_choices.Count == 1)
                return _choices[0].Value;
            var num = random.NextDouble() * TotalWeight;
            var num2 = 0f;
            for (var i = 0; i < _choices.Count - 1; i++)
            {
                num2 += _choices[i].Weight;
                if (num < num2)
                    return _choices[i].Value;
            }

            return _choices[_choices.Count - 1].Value;
        }

        public static Chooser<TT> FromString<TT>(string data)
            where TT : IConvertible
        {
            var chooser = new Chooser<TT>();
            var array = data.Split(',');
            if (array.Length == 1 && array[0].IndexOf(':') == -1)
            {
                chooser.Add((TT)Convert.ChangeType(array[0], typeof(TT)), 1f);
                return chooser;
            }

            var array2 = array;
            foreach (var text in array2)
            {
                if (text.IndexOf(':') == -1)
                {
                    chooser.Add((TT)Convert.ChangeType(text, typeof(TT)), 1f);
                    continue;
                }

                var array3 = text.Split(':');
                var value = array3[0].Trim();
                var value2 = array3[1].Trim();
                chooser.Add((TT)Convert.ChangeType(value, typeof(TT)),
                    Convert.ToSingle(value2, CultureInfo.InvariantCulture));
            }

            return chooser;
        }
    }
}
