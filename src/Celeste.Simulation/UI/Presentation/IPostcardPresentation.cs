using System.Collections;

namespace Celeste.Simulation.UI.Presentation
{
    public interface IPostcardPresentation
    {
        IEnumerator DisplayRoutine();
        void BeforeRender();
    }
}
