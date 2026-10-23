using System;
using System.Collections.Generic;
using System.Xml;
using Celeste.Core.Collections;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Core.Serialization.Xml;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Audio.Surfaces;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Chapters.Flow;
using Celeste.Everest.Diagnostics.Logging;
using Generated = Celeste.Graphics.Content.Tiles.Autotiling.AutotileGeneration;
using Behaviour = Celeste.Graphics.Content.Tiles.Autotiling.AutotileBehavior;
using Rectangle = Celeste.Core.Geometry.IntRect;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    public sealed partial class EverestAutotiler : Autotiler
    {
        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        private global::Celeste.Everest.Audio.Surfaces.EverestSurfaceIndex SurfaceIndices =>
            (global::Celeste.Everest.Audio.Surfaces.EverestSurfaceIndex)((IOriginalSurfaceIndexEnvironment)engine)
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

            public HashSet<char> IgnoreExceptions;

            public string Debris;

            public string DebrisImpactSfx;

            public int ScanWidth;

            public int ScanHeight;

            public List<Tiles> CustomFills;

            public Dictionary<byte, string> whitelists;

            public Dictionary<byte, string> blacklists;

            public TerrainType(char id)
            {
                orig_ctor(id);
                IgnoreExceptions = new HashSet<char>();
                whitelists = new Dictionary<byte, string>();
                blacklists = new Dictionary<byte, string>();
            }

            public bool Ignore(char c)
            {
                if (ID == c || IgnoreExceptions.Contains(c))
                {
                    return false;
                }

                if (!Ignores.Contains('*'))
                {
                    return Ignores.Contains(c);
                }

                return true;
            }

            public void orig_ctor(char id)
            {
                Ignores = new HashSet<char>();
                Masked = new List<Masked>();
                Center = new Tiles();
                Padded = new Tiles();

                ID = id;
            }
        }

        private class Masked
        {
            public byte[] Mask = new byte[9];

            public Tiles Tiles = new Tiles();

            public Masked()
            {
            }
        }

        private class Tiles
        {
            public List<MTexture> Textures = new List<MTexture>();

            public List<string> OverlapSprites = new List<string>();

            public bool HasOverlays;

            public Tiles()
            {
            }
        }

        private Dictionary<char, TerrainType> lookup = new Dictionary<char, TerrainType>();
        public override IReadOnlyCollection<char> TerrainIds => lookup.Keys;


        public EverestAutotiler(ISourceEngineContext engine, string filename, XmlDocument xml) : base(engine)
        {
            Dictionary<char, XmlElement> dictionary = new Dictionary<char, XmlElement>();
            foreach (XmlElement item in xml.GetElementsByTagName("Tileset"))
            {
                char c = item.SourceAttrChar("id");
                ThrowOnDuplicateId(c, filename);
                Tileset tileset = new Tileset(Graphics.GameAtlas["tilesets/" + item.Attr("path")], 8, 8, true);
                TerrainType terrainType = new TerrainType(c);
                ReadInto(terrainType, tileset, item);
                if (item.HasAttr("copy"))
                {
                    char key = item.SourceAttrChar("copy");
                    if (!dictionary.ContainsKey(key))
                    {
                        throw new Exception("Copied tilesets must be defined before the tilesets that copy them!");
                    }

                    ReadInto(terrainType, tileset, dictionary[key]);
                }

                if (item.HasAttr("ignores"))
                {
                    string[] array = item.Attr("ignores").Split(new char[1] { ',' });
                    foreach (string text in array)
                    {
                        if (text.Length > 0)
                        {
                            terrainType.Ignores.Add(text[0]);
                        }
                    }
                }

                dictionary.Add(c, item);
                lookup.Add(c, terrainType);
            }
        }
    }
}
