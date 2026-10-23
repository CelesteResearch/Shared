using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Graphics.Sprites;
using Celeste.Formats.Graphics.Tiles;
using Celeste.Game.Presentation.Particles;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Simulation.Gameplay.Player.Presentation;

namespace Celeste.Game.Execution.Graphics
{
// GFX.Game belongs to the game engine resource lifetime, not an individual Scene.
// Source rendering reads the current reference, including after an asset replacement.
    public sealed partial class OriginalGameGraphicsResources :
        ISourceGameGraphicsResources,
        ISourceAutotilingResources,
        IOriginalParticleResources
    {
        public readonly OriginalGameplayBuffers Buffers = new();
        public AtlasData GameAtlas { get; set; }
        public AtlasData GuiAtlas { get; set; }
        public AtlasData MiscAtlas { get; set; }
        public AtlasData PortraitsAtlas { get; set; }
        public SpriteBank GuiSpriteBank { get; set; }
        public SpriteBank PortraitsSpriteBank { get; set; }
        public SpriteBank SpriteBank { get; set; }
        public ISpriteFactory SpriteFactory => SpriteBank;
        public Autotiler BackgroundAutotiler { get; set; }
        public Autotiler ForegroundAutotiler { get; set; }
        public Tileset SceneryTiles { get; set; }

        public PlayerFramesMetadata
            PlayerMetadata { get; set; } =
            new();

        public AnimatedTileBank AnimatedTilesBank { get; set; }
        public XmlDocument CompleteScreensXml { get; set; }
        public bool DataLoaded { get; private set; }
        public AtlasEntry Pixel;
        public AtlasEntry Particle;
        public AtlasEntry DefaultParticleSource => Particle;

        public AtlasEntry GetGameParticleSource(string path)
        {
            return GameAtlas.Entries[path];
        }

        // The caller is the original guarded GFX.Load path, after Gui atlas loading.
        // All scenes borrow this bank; a menu resource lease does not recreate it.
        public void LoadGuiSpriteBank(XmlDocument spritesGui,
            ISourceRandom random,
            ISourceEngineContext engine)
        {
            GuiSpriteBank = new(engine, GuiAtlas, spritesGui);
        }

        // This method owns original GFX.LoadData policy. readXml is pure content IO,
        // invoked only at the source construction point, after prior publication.
        public void LoadGraphicsData(Func<string, XmlDocument> readXml,
            ISourceRandom random,
            ISourceEngineContext engine)
        {
            if (!DataLoaded)
            {
                var stopwatch = Stopwatch.StartNew();
                PortraitsSpriteBank = new(engine, PortraitsAtlas,
                    readXml(Path.Combine("Graphics", "Portraits.xml")));
                SpriteBank = new(engine, GameAtlas,
                    readXml(Path.Combine("Graphics", "Sprites.xml")));
                var backgroundFilename = Path.Combine("Graphics", "BackgroundTiles.xml");
                BackgroundAutotiler =
                    ((ISourceAutotilerConstructionEnvironment)engine)
                    .AutotilerConstruction.Create(engine, backgroundFilename, readXml(backgroundFilename), this);
                var foregroundFilename = Path.Combine("Graphics", "ForegroundTiles.xml");
                ForegroundAutotiler =
                    ((ISourceAutotilerConstructionEnvironment)engine)
                    .AutotilerConstruction.Create(engine, foregroundFilename, readXml(foregroundFilename), this);
                SceneryTiles =
                    new(GameAtlas.Entries["tilesets/scenery"], 8, 8);
                ClearFramesMetadata();
                CreateFramesMetadata("player");
                CreateFramesMetadata("player_no_backpack");
                CreateFramesMetadata("badeline");
                CreateFramesMetadata("player_badeline");
                CreateFramesMetadata("player_playback");
                CompleteScreensXml = readXml(Path.Combine("Graphics", "CompleteScreens.xml"));
                var animations = new AnimatedTileBank();
                AnimatedTilesBank = animations;
                AnimatedTileDefinitions.Append(animations,
                    readXml(Path.Combine("Graphics", "AnimatedTiles.xml")), GameAtlas);
                Console.WriteLine(" - GFX DATA LOAD: " + stopwatch.ElapsedMilliseconds + "ms");
            }

            DataLoaded = true;
        }

        public void PublishDrawingTextures()
        {
            var particle = GameAtlas.Entries["util/particle"];
            Particle = particle;
            Pixel = GameAtlas.Entries["util/pixel"].GetSubtexture(1, 1, 1, 1);
        }
    }
}
