using System.Collections.Generic;
using System.Collections.ObjectModel;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public sealed class SourceGraphicsAdapterProcess
    {
        private ReadOnlyCollection<SourceGraphicsAdapter> adapters;
        private readonly ISourceGraphicsAdapterDisplayIO displayIO;

        public SourceGraphicsAdapterProcess(ISourceGraphicsAdapterDisplayIO displayIO)
        {
            this.displayIO = displayIO;
        }

        public SourceGraphicsAdapter DefaultAdapter => Adapters[0];

        public ReadOnlyCollection<SourceGraphicsAdapter> Adapters
        {
            get
            {
                if (adapters == null)
                {
                    adapters = new ReadOnlyCollection<SourceGraphicsAdapter>(GetGraphicsAdapters());
                }

                return adapters;
            }
        }

        private SourceGraphicsAdapter[] GetGraphicsAdapters()
        {
            SourceNativeDisplayMode nativeMode = default;
            SourceGraphicsAdapter[] array = new SourceGraphicsAdapter[displayIO.GetNumVideoDisplays()];
            for (int i = 0; i < array.Length; i++)
            {
                List<SourceDisplayMode> list = new List<SourceDisplayMode>();
                for (int mode = displayIO.GetNumDisplayModes(i) - 1; mode >= 0; mode--)
                {
                    displayIO.GetDisplayMode(i, mode, out nativeMode);
                    bool found = false;
                    foreach (SourceDisplayMode item in list)
                    {
                        if (nativeMode.w == item.Width && nativeMode.h == item.Height)
                        {
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        list.Add(new SourceDisplayMode(nativeMode.w, nativeMode.h, SourceSurfaceFormat.Color));
                    }
                }

                array[i] = new SourceGraphicsAdapter(this, new SourceDisplayModeCollection(list),
                    "\\\\.\\DISPLAY" + (i + 1), displayIO.GetDisplayName(i));
            }

            return array;
        }

        public SourceDisplayMode GetCurrentDisplayMode(int adapterIndex)
        {
            SourceNativeDisplayMode nativeMode = default;
            displayIO.GetCurrentDisplayMode(adapterIndex, out nativeMode);
            return new SourceDisplayMode(nativeMode.w, nativeMode.h, SourceSurfaceFormat.Color);
        }

        internal void AdaptersChanged()
        {
            adapters = null;
        }
    }
}
