using System.Collections.Generic;
using System.Xml;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Core.Serialization.Xml;
using Celeste.Everest.Audio.Surfaces;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Audio.Surfaces;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    public sealed partial class EverestAutotiler : Autotiler
    {
        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        private EverestSurfaceIndex SurfaceIndices =>
            (EverestSurfaceIndex)((IOriginalSurfaceIndexEnvironment)engine)
            .SurfaceIndex;

        private OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        private LevelEnterStaticState LevelEnterState => ((IEverestAutotilerSourceEnvironment)engine).LevelEnterState;
        private EverestLoggerProcess Logger => ((IEverestAutotilerSourceEnvironment)engine).Logger;

        private class TerrainType
        {
            public char ID;

            public HashSet<char> Ignores;

            public List<Masked> Masked;

            public Tiles Center;

            public Tiles Padded;

            public readonly HashSet<char> IgnoreExceptions;

            public string Debris;

            public string DebrisImpactSfx;

            public int ScanWidth;

            public int ScanHeight;

            public List<Tiles> CustomFills;

            public readonly Dictionary<byte, string> whitelists;

            public readonly Dictionary<byte, string> blacklists;

            public TerrainType(char id)
            {
                orig_ctor(id);
                IgnoreExceptions = [];
                whitelists = new();
                blacklists = new();
            }

            public bool Ignore(char c)
            {
                if (ID == c || IgnoreExceptions.Contains(c)) return false;

                return !Ignores.Contains('*') ? Ignores.Contains(c) : true;
            }

            public void orig_ctor(char id)
            {
                Ignores = [];
                Masked = [];
                Center = new();
                Padded = new();

                ID = id;
            }
        }

        private class Masked
        {
            public byte[] Mask = new byte[9];

            public readonly Tiles Tiles = new();
        }

        private class Tiles
        {
            public readonly List<MTexture> Textures = [];

            public readonly List<string> OverlapSprites = [];

            public bool HasOverlays;
        }

        private readonly Dictionary<char, TerrainType> lookup = new();
        public override IReadOnlyCollection<char> TerrainIds => lookup.Keys;


        public EverestAutotiler(ISourceEngineContext engine, string filename, XmlDocument xml) : base(engine)
        {
            var dictionary = new Dictionary<char, XmlElement>();
            foreach (XmlElement item in xml.GetElementsByTagName("Tileset"))
            {
                var c = item.SourceAttrChar("id");
                ThrowOnDuplicateId(c, filename);
                var tileset = new Tileset(Graphics.GameAtlas["tilesets/" + item.Attr("path")], 8, 8, true);
                var terrainType = new TerrainType(c);
                ReadInto(terrainType, tileset, item);
                if (item.HasAttr("copy"))
                {
                    var key = item.SourceAttrChar("copy");
                    if (!dictionary.ContainsKey(key))
                        throw new("Copied tilesets must be defined before the tilesets that copy them!");

                    ReadInto(terrainType, tileset, dictionary[key]);
                }

                if (item.HasAttr("ignores"))
                {
                    var array = item.Attr("ignores").Split([',']);
                    foreach (var text in array)
                        if (text.Length > 0)
                            terrainType.Ignores.Add(text[0]);
                }

                dictionary.Add(c, item);
                lookup.Add(c, terrainType);
            }
        }
    }
}
