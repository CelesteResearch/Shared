using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Gameplay.Doors.HeartGems
{
    public class HeartGemDoorWhiteLineState : SceneEntityState
    {
        private readonly IOriginalHeartGemDoorProcess engine;
        private float fade = 1f;

        private int blockSize;

        public HeartGemDoorWhiteLineState(Vector2 origin, int blockSize, IOriginalHeartGemDoorProcess engine)
            : base(engine.EntitySourceDataRegistration, origin)
        {
            this.engine = engine;
            base.Depth = -1000000;
            this.blockSize = blockSize;
        }

        public override void Update()
        {
            base.Update();
            fade = ScalarMath.Approach(fade, 0f, engine.DeltaTime, engine.ExtremaArithmetic);
            if (!(fade <= 0f))
            {
                return;
            }

            RemoveSelf();
            OriginalLevelSceneRoot level = Scene as OriginalLevelSceneRoot;
            for (float num = (int)level.Camera.Left; num < level.Camera.Right; num += 1f)
            {
                if (num < base.X || num >= base.X + (float)blockSize)
                {
                    level.Particles.Emit(engine.ParticleTypes.HeartGemDoor.P_Slice, new Vector2(num, base.Y));
                }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 position = (base.Scene as OriginalLevelSceneRoot).Camera.Position;
            float num = engine.ExtremaArithmetic.Max(1f, 4f * fade);
            SourcePrimitiveDrawing.Rect(context, this, position.X - 10f, base.Y - num / 2f, 340f, num,
                PackedColor.White);
        }
    }
}
