using System.Collections.Generic;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public class AutotileTerrain
    {
        public char ID;
        public HashSet<char> Ignores = [];
        public bool IgnoreOtherTerrains;
        public List<AutotileMaskRule> Masked = [];
        public AutotileCandidates Center = new();
        public AutotileCandidates Padded = new();

        // ReSharper disable once ConvertToPrimaryConstructor
        public AutotileTerrain(char id)
        {
            ID = id;
        }

        public bool Ignore(char c)
        {
            if (ID != c)
            {
                if (!Ignores.Contains(c))
                    return IgnoreOtherTerrains;
                return true;
            }

            return false;
        }

        public void SortMasks()
        {
            Masked.Sort(delegate(AutotileMaskRule a, AutotileMaskRule b)
            {
                var num2 = 0;
                var num3 = 0;
                for (var k = 0; k < 9; k++)
                {
                    if (a.Mask[k] == 2)
                        num2++;
                    if (b.Mask[k] == 2)
                        num3++;
                }

                return num2 - num3;
            });
        }
    }
}
