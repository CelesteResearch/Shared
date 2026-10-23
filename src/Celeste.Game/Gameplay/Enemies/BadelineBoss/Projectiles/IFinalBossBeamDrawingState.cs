using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles
{
    public interface IFinalBossBeamDrawingState
    {
        ISourceEngineContext EngineContext { get; }
        object Scene { get; }
        Vector2 BeamOrigin { get; }
        float Angle { get; }
        Sprite BeamSprite { get; }
        Sprite StartSprite { get; }
        float BeamAlpha { get; }
        float SideFadeAlpha { get; }
        SourceVertexPositionColor[] Fade { get; }
        ISourceVectorArithmetic VectorArithmetic { get; }
    }
}
