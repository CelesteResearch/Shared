using System.Collections;
using System.Collections.Generic;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public class SourceDisplayModeCollection : IEnumerable<SourceDisplayMode>, IEnumerable
    {
        private readonly List<SourceDisplayMode> modes;

        public IEnumerable<SourceDisplayMode> this[SourceSurfaceFormat format]
        {
            get
            {
                var list = new List<SourceDisplayMode>();
                foreach (var mode in modes)
                    if (mode.Format == format)
                        list.Add(mode);

                return list;
            }
        }

        internal SourceDisplayModeCollection(List<SourceDisplayMode> setmodes)
        {
            modes = setmodes;
        }

        public IEnumerator<SourceDisplayMode> GetEnumerator()
        {
            return modes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return modes.GetEnumerator();
        }
    }
}
