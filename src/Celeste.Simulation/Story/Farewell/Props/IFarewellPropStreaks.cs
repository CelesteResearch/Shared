using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Story.Farewell.Props
{
    // AscendManager.Streaks presentation contract (:11-111).
    public interface IFarewellPropStreaks
    {
        float Alpha { get; set; }
        bool Active { get; set; }
        bool Visible { get; set; }
        void Added();
        void Removed();
        void Update(float deltaTime, float rawDeltaTime);
        IEnumerable<ImagePlacement> Images(Vector2 cameraPosition);
    }
}
