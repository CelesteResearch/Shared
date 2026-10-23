using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public partial class OriginalDreamBlockState
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private float Lerp(float a, float b, float percent)
        {
            return DreamBlockBorderDrawing.Lerp(a, b, percent);
        }

        protected struct DreamParticleVisual
        {
            public Vector2 Position;
            public PackedColor Color;
            public AtlasEntry Texture;
            public float Rotation;
            public Vector2 DrawOffset;
        }

        protected PackedColor SourceActiveBackColor => activeBackColor;
        protected PackedColor SourceDisabledBackColor => disabledBackColor;
        protected PackedColor SourceActiveLineColor => activeLineColor;
        protected PackedColor SourceDisabledLineColor => disabledLineColor;
        // ReSharper disable once ConvertToAutoProperty
        public ISourceEngineContext EngineContext => engine;
        public int DreamParticleCount => particles?.Length ?? 0;

        public int GetDreamParticleLayer(int index)
        {
            return particles[index].Layer;
        }

        public void SetDreamParticleColor(int index, PackedColor color)
        {
            particles[index].Color = color;
        }

        protected ref float SourceWobbleFrom => ref wobbleFrom;
        protected ref float SourceWobbleTo => ref wobbleTo;
        protected ref float SourceWobbleEase => ref wobbleEase;
        protected ref bool SourceOneUse => ref oneUse;

        protected virtual bool RenderTopWobble => true;
        protected virtual bool RenderRightWobble => true;
        protected virtual bool RenderBottomWobble => true;
        protected virtual bool RenderLeftWobble => true;

        protected Vector2 WrapDreamParticlePosition(Vector2 position)
        {
            return PutInside(position);
        }

        protected void RenderDreamWobbleLine(ISourceRenderContext context, Vector2 from, Vector2 to, float offset)
        {
            WobbleLine(context, from, to, offset);
        }

        protected float GetDreamLineAmplitude(float seed, float index)
        {
            return DreamBlockBorderDrawing.LineAmplitude(seed, index);
        }

        protected AtlasEntry GetDreamParticleTexture(int index, AtlasEntry[] textures)
        {
            switch (particles[index].Layer)
            {
                case 0:
                {
                    var frame = (int)((particles[index].TimeOffset * 4f + animTimer) % 4f);
                    return textures[3 - frame];
                }
                case 1:
                {
                    var frame = (int)((particles[index].TimeOffset * 2f + animTimer) % 2f);
                    return textures[1 + frame];
                }
                default:
                    return textures[2];
            }
        }

        protected virtual DreamParticleVisual GetParticleVisual(int index, Vector2 cameraPosition)
        {
            return new()
            {
                Position = particles[index].Position + cameraPosition * (0.3f + 0.25f * particles[index].Layer),
                Color = particles[index].Color,
                Texture = GetDreamParticleTexture(index, particleTextures),
                Rotation = 0f,
                DrawOffset = shake,
            };
        }
    }
}
