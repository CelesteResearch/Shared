using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Content.Atlases
{
    public sealed class EverestAtlasEvents
    {
        public delegate AtlasEntry CustomFallbackHandler(AtlasData atlas, string id);

        public event CustomFallbackHandler OnGetCustomFallback;

        internal AtlasEntry GetCustomFallback(AtlasData atlas, string id)
        {
            var handlers = OnGetCustomFallback;
            if (handlers == null) return null;
            var args = new object[] { atlas, id };
            var invocationList = handlers.GetInvocationList();
            for (var i = 0; i < invocationList.Length; i++)
            {
                var value = (AtlasEntry)invocationList[i].DynamicInvoke(args);
                if (value != null) return value;
            }

            return null;
        }
    }
}
