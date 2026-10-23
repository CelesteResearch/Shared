using Celeste.Simulation;
using Celeste.Simulation.Rendering;
using System.Runtime.Serialization;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState
    {
        [DataMember] public bool[] SummitGems;

        public void RegisterSummitGem(int gemID)
        {
            if (SummitGems == null) SummitGems = new bool[6];
            SummitGems[gemID] = true;
        }
    }
}
