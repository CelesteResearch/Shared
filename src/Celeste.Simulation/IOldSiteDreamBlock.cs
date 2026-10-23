using System.Collections;

namespace Celeste.Simulation
{
    public interface IOldSiteDreamBlock
    {
        IEnumerator Activate();
        void ActivateNoRoutine();
    }
}
