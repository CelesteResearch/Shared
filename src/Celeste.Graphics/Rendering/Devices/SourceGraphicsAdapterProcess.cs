using System.Collections.Generic;
using System.Collections.ObjectModel;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public sealed class SourceGraphicsAdapterProcess(ISourceGraphicsAdapterDisplayIO displayIO)
    {
        private ReadOnlyCollection<SourceGraphicsAdapter> adapters;
        private readonly ISourceGraphicsAdapterDisplayIO displayIO = displayIO;
        public SourceGraphicsAdapter DefaultAdapter => Adapters[0];

        public ReadOnlyCollection<SourceGraphicsAdapter> Adapters
        {
            get
            {
                if (adapters == null)
                    adapters = new(GetGraphicsAdapters());
                return adapters;
            }
        }

        private SourceGraphicsAdapter[] GetGraphicsAdapters()
        {
            SourceNativeDisplayMode nativeMode = default;
            var array = new SourceGraphicsAdapter[displayIO.GetNumVideoDisplays()];
            for (var i = 0; i < array.Length; i++)
            {
                var list = new List<SourceDisplayMode>();
                for (var mode = displayIO.GetNumDisplayModes(i) - 1; mode >= 0; mode--)
                {
                    displayIO.GetDisplayMode(i, mode, out nativeMode);
                    var found = false;
                    foreach (var item in list)
                        if (nativeMode.w == item.Width && nativeMode.h == item.Height)
                            found = true;
                    if (!found)
                        list.Add(new(nativeMode.w, nativeMode.h, SourceSurfaceFormat.Color));
                }

                array[i] = new(this, new(list), "\\\\.\\DISPLAY" + (i + 1), displayIO.GetDisplayName(i));
            }

            return array;
        }

        public SourceDisplayMode GetCurrentDisplayMode(int adapterIndex)
        {
            SourceNativeDisplayMode nativeMode = default;
            displayIO.GetCurrentDisplayMode(adapterIndex, out nativeMode);
            return new(nativeMode.w, nativeMode.h, SourceSurfaceFormat.Color);
        }

        internal void AdaptersChanged()
        {
            adapters = null;
        }
    }
}
