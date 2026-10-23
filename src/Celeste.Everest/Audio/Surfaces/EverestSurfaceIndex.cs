using System.Collections.Generic;
using Celeste.Game.Execution.Audio.Surfaces;

namespace Celeste.Everest.Audio.Surfaces
{
    public sealed class EverestSurfaceIndex : OriginalSurfaceIndex
    {
        public Dictionary<int, string> IndexToCustomPath = new Dictionary<int, string>();
        public Dictionary<int, int> IndexToSoundParam = new Dictionary<int, int>();

        public string GetPathFromIndex(int key)
        {
            if (IndexToCustomPath.TryGetValue(key, out var value)) return value;
            return "event:/char/madeline";
        }

        public int GetSoundParamFromIndex(int key)
        {
            if (IndexToSoundParam.TryGetValue(key, out var value)) return value;
            return key;
        }

        public void ResetForLevelLoader()
        {
            TileToIndex = new Dictionary<char, int>
            {
                { '1', 3 },
                { '3', 4 },
                { '4', 7 },
                { '5', 8 },
                { '6', 8 },
                { '7', 8 },
                { '8', 8 },
                { '9', 13 },
                { 'a', 8 },
                { 'b', 23 },
                { 'c', 8 },
                { 'd', 8 },
                { 'e', 8 },
                { 'f', 8 },
                { 'g', 8 },
                { 'G', 8 },
                { 'h', 33 },
                { 'i', 4 },
                { 'j', 8 },
                { 'k', 3 },
                { 'l', 25 },
                { 'm', 44 },
                { 'n', 40 },
                { 'o', 43 }
            };
            IndexToCustomPath.Clear();
            IndexToSoundParam.Clear();
        }
    }
}
