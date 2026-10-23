using System.Collections.ObjectModel;

namespace Celeste.Audio.Media
{
    public class SourceVisualizationData
    {
        internal const int Size = 256;

        internal float[] freq;

        internal float[] samp;

        public ReadOnlyCollection<float> Frequencies => new(freq);

        public ReadOnlyCollection<float> Samples => new(samp);

        public SourceVisualizationData()
        {
            freq = new float[256];
            samp = new float[256];
        }
    }
}
