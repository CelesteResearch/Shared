using System;
using System.Collections;
using System.Threading;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.UI.Presentation
{
    public interface IPostcardPresentation
    {
        IEnumerator DisplayRoutine();
        void BeforeRender();
    }
}
