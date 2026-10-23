using System.Collections;
using System.Numerics;

namespace Celeste.Simulation
{
    public interface ITheoPhonePlayer
    {
        bool ScenePresent { get; }
        Vector2 Position { get; }
        int State { get; set; }
        int Facing { get; set; }
        bool DummyAutoAnimate { get; set; }
        IEnumerator DummyWalkToExact(int x);
        void PlaySprite(string id);
    }
}
