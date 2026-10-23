using System;
using System.Collections.Generic;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public class AutotileTerrain
    {
        public char ID;

        public HashSet<char> Ignores = new HashSet<char>();

        public bool IgnoreOtherTerrains;

        public List<AutotileMaskRule> Masked = new List<AutotileMaskRule>();

        public AutotileCandidates Center = new AutotileCandidates();

        public AutotileCandidates Padded = new AutotileCandidates();

        public AutotileTerrain(char id)
        {
            ID = id;
        }

        public bool Ignore(char c)
        {
            if (ID != c)
            {
                if (!Ignores.Contains(c))
                {
                    return IgnoreOtherTerrains;
                }

                return true;
            }

            return false;
        }

        public void SortMasks()
        {
            Masked.Sort(delegate(AutotileMaskRule a, AutotileMaskRule b)
            {
                int num2 = 0;
                int num3 = 0;
                for (int k = 0; k < 9; k++)
                {
                    if (a.Mask[k] == 2)
                    {
                        num2++;
                    }

                    if (b.Mask[k] == 2)
                    {
                        num3++;
                    }
                }

                return num2 - num3;
            });
        }
    }
}
