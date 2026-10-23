using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Doors.HeartGems
{
    public class HeartGemDoorWhiteLineState : SceneEntityState
    {
        private readonly IOriginalHeartGemDoorProcess engine;
        private float fade = 1f;

        private readonly int blockSize;

        public HeartGemDoorWhiteLineState(Vector2 origin, int blockSize, IOriginalHeartGemDoorProcess engine)
            : base(engine.EntitySourceDataRegistration, origin)
        {
            this.engine = engine;
            Depth = -1000000;
            this.blockSize = blockSize;
        }

        public override void Update()
        {
            base.Update();
            fade = ScalarMath.Approach(fade, 0f, engine.DeltaTime, engine.ExtremaArithmetic);
            if (!(fade <= 0f)) return;

            RemoveSelf();
            var level = Scene as OriginalLevelSceneRoot;
            for (float num = (int)level.Camera.Left; num < level.Camera.Right; num += 1f)
                if (num < X || num >= X + blockSize)
                    level.Particles.Emit(engine.ParticleTypes.HeartGemDoor.P_Slice, new(num, Y));
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = (Scene as OriginalLevelSceneRoot).Camera.Position;
            var num = engine.ExtremaArithmetic.Max(1f, 4f * fade);
            SourcePrimitiveDrawing.Rect(context, this, position.X - 10f, Y - num / 2f, 340f, num,
                PackedColor.White);
        }
    }
}
