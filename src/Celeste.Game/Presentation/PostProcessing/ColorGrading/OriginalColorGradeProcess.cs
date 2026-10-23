using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Game.Presentation.PostProcessing.ColorGrading
{
    public sealed class OriginalColorGradeProcess
    {
        private readonly ISourceEngineContext engine;
        private readonly IOriginalColorGradeTexturePolicy texturePolicy;
        public bool Enabled = true;
        private AtlasEntry from;
        private AtlasEntry to;
        private float percent = 0f;

        public OriginalColorGradeProcess(ISourceEngineContext engine, IOriginalColorGradeTexturePolicy texturePolicy)
        {
            this.engine = engine;
            this.texturePolicy = texturePolicy;
        }

        private OriginalGameGraphicsResources Graphics
            => (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private SourceGraphicsDevice Device => ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice;
        public SourceEffect Effect => Graphics.FxColorGrading;

        public float Percent
        {
            get => percent;
            set => Set(from, to, value);
        }

        public void Set(AtlasEntry grade) => Set(grade, grade, 0f);

        public void Set(AtlasEntry fromTex, AtlasEntry toTex, float p)
        {
            if (!Enabled || fromTex == null || toTex == null)
            {
                from = Graphics.ColorGradesAtlas["none"];
                to = Graphics.ColorGradesAtlas["none"];
            }
            else
            {
                from = fromTex;
                to = toTex;
            }

            percent = ScalarMath.Clamp(p, 0f, 1f);
            if (from == to || percent <= 0f)
            {
                Effect.CurrentTechnique = Effect.Techniques["ColorGradeSingle"];
                Device.Textures[1] = texturePolicy.Read(from);
                return;
            }

            if (percent >= 1f)
            {
                Effect.CurrentTechnique = Effect.Techniques["ColorGradeSingle"];
                Device.Textures[1] = texturePolicy.Read(to);
                return;
            }

            Effect.CurrentTechnique = Effect.Techniques["ColorGrade"];
            Effect.Parameters["percent"].SetValue(percent);
            Device.Textures[1] = texturePolicy.Read(from);
            Device.Textures[2] = texturePolicy.Read(to);
        }
    }
}
