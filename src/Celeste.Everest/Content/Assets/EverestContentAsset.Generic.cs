using Celeste.Everest.Content.Sources;

namespace Celeste.Everest.Content.Assets
{
    public abstract class EverestContentAsset<TSource> : EverestContentAsset where TSource : EverestContentSource
    {
        public new TSource Source
        {
            get => (TSource)base.Source;
            set => base.Source = value;
        }

        protected EverestContentAsset(TSource source) : base(source)
        {
        }
    }
}
