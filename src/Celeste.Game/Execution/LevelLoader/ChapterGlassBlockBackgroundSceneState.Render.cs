using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Physics.Collision;

namespace Celeste.Game.Execution.LevelLoader
{
    public partial class ChapterGlassBlockBackgroundSceneState
    {
        private void OnDisplacementRender()
        {
            var entities =
                GetGlassBlocks();
            foreach (var identity in entities)
            {
                var entity = (ISourceEntityCollider)identity;
                var context = ((ISourceRenderEnvironment)engine).CurrentContext;
                SourcePrimitiveDrawing.Rect(context, this, entity.Position.X + DisplacementInset.X,
                    entity.Position.Y + DisplacementInset.Y,
                    entity.Collider.Width - DisplacementInset.X * 2f, entity.Collider.Height - DisplacementInset.Y * 2f,
                    new(.5f, .5f, .2f, 1f));
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!hasBlocks) return;
            var camera = ((OriginalLevelSceneRoot)Scene).Camera.Position;
            var entities =
                GetGlassBlocks();
            foreach (var identity in entities)
            {
                var entity = (ISourceEntityCollider)identity;
                SourcePrimitiveDrawing.Rect(context, this, entity.Position.X + BlockShake(entity).X,
                    entity.Position.Y + BlockShake(entity).Y,
                    entity.Collider.Width, entity.Collider.Height, bgColor * Alpha * BlockAlpha(entity));
            }

            if (starsTarget != null && !starsTarget.IsDisposed)
                foreach (var identity in entities)
                {
                    var entity = (ISourceEntityCollider)identity;
                    var crop = new IntRect((int)(entity.Position.X + BlockShake(entity).X - camera.X),
                        (int)(entity.Position.Y + BlockShake(entity).Y - camera.Y),
                        (int)entity.Collider.Width, (int)entity.Collider.Height);
                    ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(starsTarget.Target,
                        entity.Position + BlockShake(entity), crop,
                        (PackedColor.White * BlockAlpha(entity)).PackedValue);
                }

            if (beamsTarget == null || beamsTarget.IsDisposed) return;
            foreach (var identity in entities)
            {
                var entity = (ISourceEntityCollider)identity;
                var crop = new IntRect((int)(entity.Position.X + BlockShake(entity).X - camera.X),
                    (int)(entity.Position.Y + BlockShake(entity).Y - camera.Y),
                    (int)entity.Collider.Width, (int)entity.Collider.Height);
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(beamsTarget.Target,
                    entity.Position + BlockShake(entity), crop,
                    (PackedColor.White * BlockAlpha(entity)).PackedValue);
            }
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            Dispose();
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            Dispose();
        }

        public void Dispose()
        {
            if (starsTarget != null && !starsTarget.IsDisposed) starsTarget.Dispose();
            if (beamsTarget != null && !beamsTarget.IsDisposed) beamsTarget.Dispose();
            starsTarget = null;
            beamsTarget = null;
        }
    }
}
