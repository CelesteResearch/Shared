using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps.Backdrops.Stars;
using Celeste.Game.Presentation.Backdrops.Blackhole;
using Celeste.Game.Presentation.Backdrops.NorthernLights;
using Celeste.Game.Presentation.Backdrops.Tentacles;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Gui;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.Presentation.Backdrops.Godrays;
using Celeste.Simulation.Presentation.Backdrops.HeatWave;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Simulation.Presentation.Backdrops.Planets;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Backdrops.Stars;
using Celeste.Simulation.Presentation.Backdrops.Weather.Petals;
using Celeste.Simulation.Presentation.Backdrops.Weather.Rain;
using Celeste.Simulation.Presentation.Backdrops.Weather.Snow;

namespace Celeste.Game.Content.Maps.Backdrops
{
    public sealed class MapBackdropParser
    {
        private readonly OriginalChapterMapData map;
        private readonly IGameProfileEnvironment sourceProfile;
        private readonly ISourceGameGraphicsEnvironment graphics;
        private readonly ISourceEngineContext engine;

        public MapBackdropParser(ISourceEngineContext engine,
            OriginalChapterMapData map)
        {
            this.engine = engine;
            sourceProfile = (IGameProfileEnvironment)engine;
            this.map = map;
            graphics = (ISourceGameGraphicsEnvironment)engine;
        }

        private BackdropPresentation CreateBuiltin(
            BinaryPackerElement child)
        {
            if (child.Name.Equals("snowfg", StringComparison.OrdinalIgnoreCase))
                return new SnowBackdropPresentation(
                    engine, true);
            if (child.Name.Equals("snowbg", StringComparison.OrdinalIgnoreCase))
                return new SnowBackdropPresentation(
                    engine, false);
            if (child.Name.Equals("windsnow", StringComparison.OrdinalIgnoreCase))
                return new WindSnowBackdropPresentation(
                    engine);
            if (child.Name.Equals("dreamstars", StringComparison.OrdinalIgnoreCase))
                return new DreamStarsBackdropPresentation(
                    engine);
            if (child.Name.Equals("stars", StringComparison.OrdinalIgnoreCase))
                return new StarsBackdropPresentation(engine);
            if (child.Name.Equals("mirrorfg", StringComparison.OrdinalIgnoreCase))
                return new MirrorBackdropPresentation(engine);
            if (child.Name.Equals("reflectionfg", StringComparison.OrdinalIgnoreCase))
                return new ReflectionBackdropPresentation(
                    engine);
            if (child.Name.Equals("godrays", StringComparison.OrdinalIgnoreCase))
                return new GodraysBackdropPresentation(
                    engine);
            if (child.Name.Equals("tentacles", StringComparison.OrdinalIgnoreCase))
                return new TentaclesBackdropPresentation(
                    engine,
                    (TentaclesBackdropPresentation.Side)
                    Enum.Parse(
                        typeof(TentaclesBackdropPresentation.Side), child.Attr("side", "Right")),
                    SourceHexColor.HexToColor(child.Attr("color")),
                    child.AttrFloat("offset"));
            if (child.Name.Equals("northernlights", StringComparison.OrdinalIgnoreCase))
                return new NorthernLightsBackdropPresentation(engine);
            if (child.Name.Equals("bossStarField", StringComparison.OrdinalIgnoreCase))
                return new FinalBossStarfieldBackdropPresentation(engine);
            if (child.Name.Equals("petals", StringComparison.OrdinalIgnoreCase))
                return new PetalsBackdropPresentation(
                    engine);
            if (child.Name.Equals("heatwave", StringComparison.OrdinalIgnoreCase))
                return new HeatWaveBackdropPresentation(
                    engine);
            if (child.Name.Equals("corestarsfg", StringComparison.OrdinalIgnoreCase))
                return new CoreStarsBackdropPresentation(
                    engine);
            if (child.Name.Equals("starfield", StringComparison.OrdinalIgnoreCase))
                return new StarfieldBackdropPresentation(engine,
                    SourceHexColor.HexToColor(child.Attr("color")),
                    child.AttrFloat("speed", 1));
            if (child.Name.Equals("planets", StringComparison.OrdinalIgnoreCase))
                return new PlanetsBackdropPresentation(engine,
                    (int)child.AttrFloat("count", 32f), child.Attr("size", "small"));
            if (child.Name.Equals("rain", StringComparison.OrdinalIgnoreCase))
                return new RainBackdropPresentation(
                    engine);
            if (child.Name.Equals("stardust", StringComparison.OrdinalIgnoreCase))
                return new StardustBackdropPresentation(
                    engine);
            if (!child.Name.Equals("blackhole", StringComparison.OrdinalIgnoreCase))
                throw new("Background type " + child.Name + " does not exist");
            return new BlackholeBackdropPresentation(
                engine);
        }

        public List<BackdropPresentation> CreateBackdrops(
            BinaryPackerElement data)
        {
            var result = new List<BackdropPresentation>();
            if (data == null || data.Children == null) return result;
            foreach (var child in data.Children)
                if (child.Name.Equals("apply", StringComparison.OrdinalIgnoreCase))
                {
                    if (child.Children == null) continue;
                    foreach (var nested in child
                                 .Children)
                        result.Add(ParseBackdrop(nested, child));
                }
                else
                {
                    result.Add(ParseBackdrop(child));
                }

            return result;
        }

        public BackdropPresentation ParseBackdrop(
            BinaryPackerElement child,
            BinaryPackerElement above = null)
        {
            var backdrop =
                sourceProfile.SourceProfile == GameProfile.InstalledEverest
                    ? ((IOriginalBackdropLoadEnvironment)engine).BackdropLoadPolicy.LoadCustomBackdrop(child, above,
                        map)
                    : null;
            if (backdrop == null && child.Name.Equals("parallax", StringComparison.OrdinalIgnoreCase))
            {
                string id = child.Attr("texture"), atlas = child.Attr("atlas", "game");
                var texture = atlas == "game" && graphics.GameGraphics.GameAtlas.Has(id)
                    ? graphics.GameGraphics.GameAtlas[id]
                    : atlas == "gui" &&
                      ((ISourceGuiAtlasResources)graphics.GameGraphics).GuiAtlas
                      .Has(id)
                        ? ((ISourceGuiAtlasResources)graphics.GameGraphics)
                        .GuiAtlas[id]
                        : ((ISourceMiscAtlasResources)graphics.GameGraphics)
                        .MiscAtlas[id];
                var parallax =
                    new ParallaxBackdropPresentation(
                        texture);
                var blendMode = "";
                if (child.HasAttr("blendmode"))
                    blendMode = child.Attr("blendmode", "alphablend").ToLower();
                else if (above != null && above.HasAttr("blendmode"))
                    blendMode = above.Attr("blendmode", "alphablend").ToLower();
                if (blendMode.Equals("additive"))
                    parallax.BlendState = SourceBlendState.Additive;
                parallax.DoFadeIn = bool.Parse(child.Attr("fadeIn", "false"));
                backdrop = parallax;
            }
            else if (backdrop == null)
            {
                backdrop = CreateBuiltin(child);
            }

            if (child.HasAttr("tag"))
            {
                if (sourceProfile.SourceProfile == GameProfile.InstalledEverest)
                    foreach (var tag in child.Attr("tag").Split(','))
                        backdrop.Tags.Add(tag);
                else backdrop.Tags.Add(child.Attr("tag"));
            }

            if (above != null && above.HasAttr("tag"))
            {
                if (sourceProfile.SourceProfile == GameProfile.InstalledEverest)
                    foreach (var tag in above.Attr("tag").Split(','))
                        backdrop.Tags.Add(tag);
                else backdrop.Tags.Add(above.Attr("tag"));
            }

            if (child.HasAttr("x"))
                backdrop.Position.X = child.AttrFloat("x");
            else if (above != null && above.HasAttr("x")) backdrop.Position.X = above.AttrFloat("x");

            if (child.HasAttr("y"))
                backdrop.Position.Y = child.AttrFloat("y");
            else if (above != null && above.HasAttr("y")) backdrop.Position.Y = above.AttrFloat("y");

            if (child.HasAttr("scrollx"))
                backdrop.Scroll.X = child.AttrFloat("scrollx");
            else if (above != null && above.HasAttr("scrollx")) backdrop.Scroll.X = above.AttrFloat("scrollx");

            if (child.HasAttr("scrolly"))
                backdrop.Scroll.Y = child.AttrFloat("scrolly");
            else if (above != null && above.HasAttr("scrolly")) backdrop.Scroll.Y = above.AttrFloat("scrolly");

            if (child.HasAttr("speedx"))
                backdrop.Speed.X = child.AttrFloat("speedx");
            else if (above != null && above.HasAttr("speedx")) backdrop.Speed.X = above.AttrFloat("speedx");

            if (child.HasAttr("speedy"))
                backdrop.Speed.Y = child.AttrFloat("speedy");
            else if (above != null && above.HasAttr("speedy")) backdrop.Speed.Y = above.AttrFloat("speedy");

            backdrop.Color = PackedColor.White;
            if (child.HasAttr("color"))
                backdrop.Color =
                    SourceHexColor.HexToColor(child.Attr("color"));
            else if (above != null && above.HasAttr("color"))
                backdrop.Color =
                    SourceHexColor.HexToColor(above.Attr("color"));

            if (child.HasAttr("alpha"))
                backdrop.Color *= child.AttrFloat("alpha");
            else if (above != null && above.HasAttr("alpha")) backdrop.Color *= above.AttrFloat("alpha");

            if (child.HasAttr("flipx"))
                backdrop.FlipX = child.AttrBool("flipx");
            else if (above != null && above.HasAttr("flipx")) backdrop.FlipX = above.AttrBool("flipx");

            if (child.HasAttr("flipy"))
                backdrop.FlipY = child.AttrBool("flipy");
            else if (above != null && above.HasAttr("flipy")) backdrop.FlipY = above.AttrBool("flipy");

            if (child.HasAttr("loopx"))
                backdrop.LoopX = child.AttrBool("loopx");
            else if (above != null && above.HasAttr("loopx")) backdrop.LoopX = above.AttrBool("loopx");

            if (child.HasAttr("loopy"))
                backdrop.LoopY = child.AttrBool("loopy");
            else if (above != null && above.HasAttr("loopy")) backdrop.LoopY = above.AttrBool("loopy");

            if (child.HasAttr("wind"))
                backdrop.WindMultiplier = child.AttrFloat("wind");
            else if (above != null && above.HasAttr("wind")) backdrop.WindMultiplier = above.AttrFloat("wind");

            string text3 = null;
            if (child.HasAttr("exclude"))
                text3 = child.Attr("exclude");
            else if (above != null && above.HasAttr("exclude")) text3 = above.Attr("exclude");

            if (text3 != null) backdrop.ExcludeFrom = ParseLevelsList(text3);

            string text4 = null;
            if (child.HasAttr("only"))
                text4 = child.Attr("only");
            else if (above != null && above.HasAttr("only")) text4 = above.Attr("only");

            if (text4 != null) backdrop.OnlyIn = ParseLevelsList(text4);

            string text5 = null;
            if (child.HasAttr("flag"))
                text5 = child.Attr("flag");
            else if (above != null && above.HasAttr("flag")) text5 = above.Attr("flag");

            if (text5 != null) backdrop.OnlyIfFlag = text5;

            string text6 = null;
            if (child.HasAttr("notflag"))
                text6 = child.Attr("notflag");
            else if (above != null && above.HasAttr("notflag")) text6 = above.Attr("notflag");

            if (text6 != null) backdrop.OnlyIfNotFlag = text6;

            string text7 = null;
            if (child.HasAttr("always"))
                text7 = child.Attr("always");
            else if (above != null && above.HasAttr("always")) text7 = above.Attr("always");

            if (text7 != null) backdrop.AlsoIfFlag = text7;

            bool? dreaming = null;
            if (child.HasAttr("dreaming"))
                dreaming = child.AttrBool("dreaming");
            else if (above != null && above.HasAttr("dreaming")) dreaming = above.AttrBool("dreaming");

            if (dreaming.HasValue) backdrop.Dreaming = dreaming;

            if (child.HasAttr("instantIn"))
                backdrop.InstantIn = child.AttrBool("instantIn");
            else if (above != null && above.HasAttr("instantIn")) backdrop.InstantIn = above.AttrBool("instantIn");

            if (child.HasAttr("instantOut"))
                backdrop.InstantOut = child.AttrBool("instantOut");
            else if (above != null && above.HasAttr("instantOut")) backdrop.InstantOut = above.AttrBool("instantOut");

            string text8 = null;
            if (child.HasAttr("fadex"))
                text8 = child.Attr("fadex");
            else if (above != null && above.HasAttr("fadex")) text8 = above.Attr("fadex");

            if (text8 != null)
            {
                backdrop.FadeX =
                    new();
                var array = text8.Split(':');
                for (var i = 0; i < array.Length; i++)
                {
                    var array2 = array[i].Split(',');
                    if (array2.Length == 2)
                    {
                        var array3 = array2[0].Split('-');
                        var array4 = array2[1].Split('-');
                        var fadeFrom = float.Parse(array4[0], CultureInfo.InvariantCulture);
                        var fadeTo = float.Parse(array4[1], CultureInfo.InvariantCulture);
                        var num = 1;
                        var num2 = 1;
                        if (array3[0][0] == 'n')
                        {
                            num = -1;
                            array3[0] = array3[0].Substring(1);
                        }

                        if (array3[1][0] == 'n')
                        {
                            num2 = -1;
                            array3[1] = array3[1].Substring(1);
                        }

                        backdrop.FadeX.Add(num * int.Parse(array3[0]), num2 * int.Parse(array3[1]), fadeFrom, fadeTo);
                    }
                }
            }

            string text9 = null;
            if (child.HasAttr("fadey"))
                text9 = child.Attr("fadey");
            else if (above != null && above.HasAttr("fadey")) text9 = above.Attr("fadey");

            if (text9 != null)
            {
                backdrop.FadeY =
                    new();
                var array = text9.Split(':');
                for (var i = 0; i < array.Length; i++)
                {
                    var array5 = array[i].Split(',');
                    if (array5.Length == 2)
                    {
                        var array6 = array5[0].Split('-');
                        var array7 = array5[1].Split('-');
                        var fadeFrom2 = float.Parse(array7[0], CultureInfo.InvariantCulture);
                        var fadeTo2 = float.Parse(array7[1], CultureInfo.InvariantCulture);
                        var num3 = 1;
                        var num4 = 1;
                        if (array6[0][0] == 'n')
                        {
                            num3 = -1;
                            array6[0] = array6[0].Substring(1);
                        }

                        if (array6[1][0] == 'n')
                        {
                            num4 = -1;
                            array6[1] = array6[1].Substring(1);
                        }

                        backdrop.FadeY.Add(num3 * int.Parse(array6[0]), num4 * int.Parse(array6[1]), fadeFrom2,
                            fadeTo2);
                    }
                }
            }

            return backdrop;
        }

        public HashSet<string> ParseLevelsList(string list)
        {
            var result = new HashSet<string>();
            foreach (var token in list.Split(','))
                if (token.Contains("*"))
                {
                    var pattern = "^" + Regex.Escape(token).Replace("\\*", ".*") + "$";
                    foreach (var level in map.Levels)
                        if (Regex.IsMatch(level.Name, pattern))
                            result.Add(level.Name);
                }
                else
                {
                    result.Add(token);
                }

            return result;
        }
    }
}
