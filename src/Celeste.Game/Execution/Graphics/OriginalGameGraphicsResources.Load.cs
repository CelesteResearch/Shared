using Celeste.Core.Display;
using System;
using System.Diagnostics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Profiles;
using System.IO;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Presentation.Particles;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Execution.Graphics
{
    public sealed partial class OriginalGameGraphicsResources
    {
        public AtlasData OpeningAtlas { get; set; }
        public AtlasData ColorGradesAtlas { get; set; }
        public VirtualTexture MagicGlowNoise { get; set; }
        public bool Loaded { get; private set; }

        public void LoadGraphics(ISourceAtlasLoaderEnvironment environment, ISourceRandom random,
            OriginalParticleCatalog particleTypes, IOriginalParticleResources particleResources,
            ISourceEngineContext sourceEngine)
        {
            if (!Loaded)
            {
                var stopwatch = Stopwatch.StartNew();
                GameAtlas = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Gameplay"),
                    AtlasDataFormat.Packer, environment);
                OpeningAtlas = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Opening"),
                    AtlasDataFormat.PackerNoAtlas, environment);
                GuiAtlas = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Gui"),
                    AtlasDataFormat.Packer,
                    environment);
                LoadGuiSpriteBank(environment.LoadContentXml(Path.Combine("Graphics", "SpritesGui.xml")), random,
                    sourceEngine);
                MiscAtlas = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Misc"),
                    AtlasDataFormat.PackerNoAtlas, environment);
                PortraitsAtlas = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Portraits"),
                    AtlasDataFormat.PackerNoAtlas, environment);
                ((ISourceDrawScope)environment).Draw.Particle = GameAtlas["util/particle"];
                ((ISourceDrawScope)environment).Draw.Pixel = GameAtlas["util/pixel"].GetSubtexture(1, 1, 1, 1);
                particleTypes.Load(particleResources,
                    ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)sourceEngine).ScalarArithmetic);
                ColorGradesAtlas =
                    SourceAtlasLoader.FromDirectory(Path.Combine("Graphics", "ColorGrading"), environment);
                MagicGlowNoise = environment.VirtualContent.CreateTexture("glow-noise", 128, 128, PackedColor.White);
                var colors = new PackedColor[MagicGlowNoise.Width * MagicGlowNoise.Height];
                for (int i = 0; i < colors.Length; i++)
                    colors[i] = new PackedColor(
                        SourceRandomMath.NextFloat(((ISourceRandomEnvironment)sourceEngine).Random),
                        SourceRandomMath.NextFloat(((ISourceRandomEnvironment)sourceEngine).Random),
                        SourceRandomMath.NextFloat(((ISourceRandomEnvironment)sourceEngine).Random), 0f);
                if (((IGameProfileEnvironment)sourceEngine).SourceProfile ==
                    GameProfile.InstalledEverest)
                    MagicGlowNoise.TextureSafe.SetData(colors);
                else
                    MagicGlowNoise.Texture.SetData(colors);
                Console.WriteLine(" - GFX LOAD: " + stopwatch.ElapsedMilliseconds + "ms");
            }

            Loaded = true;
        }
    }
}
