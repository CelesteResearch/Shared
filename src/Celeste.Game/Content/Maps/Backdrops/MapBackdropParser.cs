using Celeste.Core.Display;
using Celeste.Simulation.Rendering;
using Celeste.Game.Profiles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Celeste.Game.Content.Maps.Backdrops
{
    public sealed class MapBackdropParser
    {
        private readonly global::Celeste.Game.Content.Maps.OriginalChapterMapData map;
        private readonly IGameProfileEnvironment sourceProfile;
        private readonly global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment graphics;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        public MapBackdropParser(global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            OriginalChapterMapData map)
        {
            this.engine = engine;
            this.sourceProfile = (IGameProfileEnvironment)engine;
            this.map = map;
            this.graphics = (global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine;
        }

        private global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation CreateBuiltin(
            global::Celeste.Formats.Map.Binary.Source.BinaryPackerElement child)
        {
            if (child.Name.Equals("snowfg", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Weather.Snow.SnowBackdropPresentation(
                    engine, true);
            else if (child.Name.Equals("snowbg", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Weather.Snow.SnowBackdropPresentation(
                    engine, false);
            else if (child.Name.Equals("windsnow", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Weather.Snow.WindSnowBackdropPresentation(
                    engine);
            else if (child.Name.Equals("dreamstars", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Stars.DreamStarsBackdropPresentation(
                    engine);
            else if (child.Name.Equals("stars", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Stars.StarsBackdropPresentation(engine);
            else if (child.Name.Equals("mirrorfg", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Game.Content.Maps.Backdrops.Stars.MirrorBackdropPresentation(engine);
            else if (child.Name.Equals("reflectionfg", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Game.Content.Maps.Backdrops.Stars.ReflectionBackdropPresentation(
                    engine);
            else if (child.Name.Equals("godrays", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Godrays.GodraysBackdropPresentation(
                    engine);
            else if (child.Name.Equals("tentacles", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Game.Presentation.Backdrops.Tentacles.TentaclesBackdropPresentation(
                    engine,
                    (global::Celeste.Game.Presentation.Backdrops.Tentacles.TentaclesBackdropPresentation.Side)
                    Enum.Parse(
                        typeof(global::Celeste.Game.Presentation.Backdrops.Tentacles.
                            TentaclesBackdropPresentation.Side), child.Attr("side", "Right")),
                    global::Celeste.Graphics.Display.Colors.SourceHexColor.HexToColor(child.Attr("color")),
                    child.AttrFloat("offset"));
            else if (child.Name.Equals("northernlights", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Game.Presentation.Backdrops.NorthernLights.
                    NorthernLightsBackdropPresentation(engine);
            else if (child.Name.Equals("bossStarField", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Stars.
                    FinalBossStarfieldBackdropPresentation(engine);
            else if (child.Name.Equals("petals", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Weather.Petals.PetalsBackdropPresentation(
                    engine);
            else if (child.Name.Equals("heatwave", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.HeatWave.HeatWaveBackdropPresentation(
                    engine);
            else if (child.Name.Equals("corestarsfg", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Game.Content.Maps.Backdrops.Stars.CoreStarsBackdropPresentation(
                    engine);
            else if (child.Name.Equals("starfield", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Stars.StarfieldBackdropPresentation(engine,
                    global::Celeste.Graphics.Display.Colors.SourceHexColor.HexToColor(child.Attr("color")),
                    child.AttrFloat("speed", 1));
            else if (child.Name.Equals("planets", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Planets.PlanetsBackdropPresentation(engine,
                    (int)child.AttrFloat("count", 32f), child.Attr("size", "small"));
            else if (child.Name.Equals("rain", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Simulation.Presentation.Backdrops.Weather.Rain.RainBackdropPresentation(
                    engine);
            else if (child.Name.Equals("stardust", StringComparison.OrdinalIgnoreCase))
                return new global::Celeste.Game.Content.Maps.Backdrops.Stars.StardustBackdropPresentation(
                    engine);
            if (!child.Name.Equals("blackhole", StringComparison.OrdinalIgnoreCase))
                throw new Exception("Background type " + child.Name + " does not exist");
            return new global::Celeste.Game.Presentation.Backdrops.Blackhole.BlackholeBackdropPresentation(
                engine);
        }

        public List<global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation> CreateBackdrops(
            global::Celeste.Formats.Map.Binary.Source.BinaryPackerElement data)
        {
            var result = new List<global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation>();
            if (data == null || data.Children == null) return result;
            foreach (global::Celeste.Formats.Map.Binary.Source.BinaryPackerElement child in data.Children)
            {
                if (child.Name.Equals("apply", StringComparison.OrdinalIgnoreCase))
                {
                    if (child.Children == null) continue;
                    foreach (global::Celeste.Formats.Map.Binary.Source.BinaryPackerElement nested in child
                                 .Children)
                        result.Add(ParseBackdrop(nested, child));
                }
                else result.Add(ParseBackdrop(child));
            }

            return result;
        }

        public global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation ParseBackdrop(
            global::Celeste.Formats.Map.Binary.Source.BinaryPackerElement child,
            global::Celeste.Formats.Map.Binary.Source.BinaryPackerElement above = null)
        {
            global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation backdrop =
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
                      ((global::Celeste.Graphics.Content.Gui.ISourceGuiAtlasResources)graphics.GameGraphics).GuiAtlas
                      .Has(id)
                        ? ((global::Celeste.Graphics.Content.Gui.ISourceGuiAtlasResources)graphics.GameGraphics)
                        .GuiAtlas[id]
                        : ((global::Celeste.Graphics.Content.ISourceMiscAtlasResources)graphics.GameGraphics)
                        .MiscAtlas[id];
                var parallax =
                    new global::Celeste.Simulation.Presentation.Backdrops.Parallax.ParallaxBackdropPresentation(
                        texture);
                string blendMode = "";
                if (child.HasAttr("blendmode"))
                    blendMode = child.Attr("blendmode", "alphablend").ToLower();
                else if (above != null && above.HasAttr("blendmode"))
                    blendMode = above.Attr("blendmode", "alphablend").ToLower();
                if (blendMode.Equals("additive"))
                    parallax.BlendState = global::Celeste.Core.Rendering.States.SourceBlendState.Additive;
                parallax.DoFadeIn = bool.Parse(child.Attr("fadeIn", "false"));
                backdrop = parallax;
            }
            else if (backdrop == null) backdrop = CreateBuiltin(child);

            if (child.HasAttr("tag"))
            {
                if (sourceProfile.SourceProfile == GameProfile.InstalledEverest)
                    foreach (string tag in child.Attr("tag").Split(','))
                        backdrop.Tags.Add(tag);
                else backdrop.Tags.Add(child.Attr("tag"));
            }

            if (above != null && above.HasAttr("tag"))
            {
                if (sourceProfile.SourceProfile == GameProfile.InstalledEverest)
                    foreach (string tag in above.Attr("tag").Split(','))
                        backdrop.Tags.Add(tag);
                else backdrop.Tags.Add(above.Attr("tag"));
            }

            if (child.HasAttr("x"))
            {
                backdrop.Position.X = child.AttrFloat("x");
            }
            else if (above != null && above.HasAttr("x"))
            {
                backdrop.Position.X = above.AttrFloat("x");
            }

            if (child.HasAttr("y"))
            {
                backdrop.Position.Y = child.AttrFloat("y");
            }
            else if (above != null && above.HasAttr("y"))
            {
                backdrop.Position.Y = above.AttrFloat("y");
            }

            if (child.HasAttr("scrollx"))
            {
                backdrop.Scroll.X = child.AttrFloat("scrollx");
            }
            else if (above != null && above.HasAttr("scrollx"))
            {
                backdrop.Scroll.X = above.AttrFloat("scrollx");
            }

            if (child.HasAttr("scrolly"))
            {
                backdrop.Scroll.Y = child.AttrFloat("scrolly");
            }
            else if (above != null && above.HasAttr("scrolly"))
            {
                backdrop.Scroll.Y = above.AttrFloat("scrolly");
            }

            if (child.HasAttr("speedx"))
            {
                backdrop.Speed.X = child.AttrFloat("speedx");
            }
            else if (above != null && above.HasAttr("speedx"))
            {
                backdrop.Speed.X = above.AttrFloat("speedx");
            }

            if (child.HasAttr("speedy"))
            {
                backdrop.Speed.Y = child.AttrFloat("speedy");
            }
            else if (above != null && above.HasAttr("speedy"))
            {
                backdrop.Speed.Y = above.AttrFloat("speedy");
            }

            backdrop.Color = global::Celeste.Core.Display.PackedColor.White;
            if (child.HasAttr("color"))
            {
                backdrop.Color =
                    global::Celeste.Graphics.Display.Colors.SourceHexColor.HexToColor(child.Attr("color"));
            }
            else if (above != null && above.HasAttr("color"))
            {
                backdrop.Color =
                    global::Celeste.Graphics.Display.Colors.SourceHexColor.HexToColor(above.Attr("color"));
            }

            if (child.HasAttr("alpha"))
            {
                backdrop.Color *= child.AttrFloat("alpha");
            }
            else if (above != null && above.HasAttr("alpha"))
            {
                backdrop.Color *= above.AttrFloat("alpha");
            }

            if (child.HasAttr("flipx"))
            {
                backdrop.FlipX = child.AttrBool("flipx");
            }
            else if (above != null && above.HasAttr("flipx"))
            {
                backdrop.FlipX = above.AttrBool("flipx");
            }

            if (child.HasAttr("flipy"))
            {
                backdrop.FlipY = child.AttrBool("flipy");
            }
            else if (above != null && above.HasAttr("flipy"))
            {
                backdrop.FlipY = above.AttrBool("flipy");
            }

            if (child.HasAttr("loopx"))
            {
                backdrop.LoopX = child.AttrBool("loopx");
            }
            else if (above != null && above.HasAttr("loopx"))
            {
                backdrop.LoopX = above.AttrBool("loopx");
            }

            if (child.HasAttr("loopy"))
            {
                backdrop.LoopY = child.AttrBool("loopy");
            }
            else if (above != null && above.HasAttr("loopy"))
            {
                backdrop.LoopY = above.AttrBool("loopy");
            }

            if (child.HasAttr("wind"))
            {
                backdrop.WindMultiplier = child.AttrFloat("wind");
            }
            else if (above != null && above.HasAttr("wind"))
            {
                backdrop.WindMultiplier = above.AttrFloat("wind");
            }

            string text3 = null;
            if (child.HasAttr("exclude"))
            {
                text3 = child.Attr("exclude");
            }
            else if (above != null && above.HasAttr("exclude"))
            {
                text3 = above.Attr("exclude");
            }

            if (text3 != null)
            {
                backdrop.ExcludeFrom = ParseLevelsList(text3);
            }

            string text4 = null;
            if (child.HasAttr("only"))
            {
                text4 = child.Attr("only");
            }
            else if (above != null && above.HasAttr("only"))
            {
                text4 = above.Attr("only");
            }

            if (text4 != null)
            {
                backdrop.OnlyIn = ParseLevelsList(text4);
            }

            string text5 = null;
            if (child.HasAttr("flag"))
            {
                text5 = child.Attr("flag");
            }
            else if (above != null && above.HasAttr("flag"))
            {
                text5 = above.Attr("flag");
            }

            if (text5 != null)
            {
                backdrop.OnlyIfFlag = text5;
            }

            string text6 = null;
            if (child.HasAttr("notflag"))
            {
                text6 = child.Attr("notflag");
            }
            else if (above != null && above.HasAttr("notflag"))
            {
                text6 = above.Attr("notflag");
            }

            if (text6 != null)
            {
                backdrop.OnlyIfNotFlag = text6;
            }

            string text7 = null;
            if (child.HasAttr("always"))
            {
                text7 = child.Attr("always");
            }
            else if (above != null && above.HasAttr("always"))
            {
                text7 = above.Attr("always");
            }

            if (text7 != null)
            {
                backdrop.AlsoIfFlag = text7;
            }

            bool? dreaming = null;
            if (child.HasAttr("dreaming"))
            {
                dreaming = child.AttrBool("dreaming");
            }
            else if (above != null && above.HasAttr("dreaming"))
            {
                dreaming = above.AttrBool("dreaming");
            }

            if (dreaming.HasValue)
            {
                backdrop.Dreaming = dreaming;
            }

            if (child.HasAttr("instantIn"))
            {
                backdrop.InstantIn = child.AttrBool("instantIn");
            }
            else if (above != null && above.HasAttr("instantIn"))
            {
                backdrop.InstantIn = above.AttrBool("instantIn");
            }

            if (child.HasAttr("instantOut"))
            {
                backdrop.InstantOut = child.AttrBool("instantOut");
            }
            else if (above != null && above.HasAttr("instantOut"))
            {
                backdrop.InstantOut = above.AttrBool("instantOut");
            }

            string text8 = null;
            if (child.HasAttr("fadex"))
            {
                text8 = child.Attr("fadex");
            }
            else if (above != null && above.HasAttr("fadex"))
            {
                text8 = above.Attr("fadex");
            }

            if (text8 != null)
            {
                backdrop.FadeX =
                    new global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation.Fader();
                string[] array = text8.Split(':');
                for (int i = 0; i < array.Length; i++)
                {
                    string[] array2 = array[i].Split(',');
                    if (array2.Length == 2)
                    {
                        string[] array3 = array2[0].Split('-');
                        string[] array4 = array2[1].Split('-');
                        float fadeFrom = float.Parse(array4[0], CultureInfo.InvariantCulture);
                        float fadeTo = float.Parse(array4[1], CultureInfo.InvariantCulture);
                        int num = 1;
                        int num2 = 1;
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
            {
                text9 = child.Attr("fadey");
            }
            else if (above != null && above.HasAttr("fadey"))
            {
                text9 = above.Attr("fadey");
            }

            if (text9 != null)
            {
                backdrop.FadeY =
                    new global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation.Fader();
                string[] array = text9.Split(':');
                for (int i = 0; i < array.Length; i++)
                {
                    string[] array5 = array[i].Split(',');
                    if (array5.Length == 2)
                    {
                        string[] array6 = array5[0].Split('-');
                        string[] array7 = array5[1].Split('-');
                        float fadeFrom2 = float.Parse(array7[0], CultureInfo.InvariantCulture);
                        float fadeTo2 = float.Parse(array7[1], CultureInfo.InvariantCulture);
                        int num3 = 1;
                        int num4 = 1;
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
            foreach (string token in list.Split(','))
            {
                if (token.Contains("*"))
                {
                    string pattern = "^" + Regex.Escape(token).Replace("\\*", ".*") + "$";
                    foreach (var level in map.Levels)
                        if (Regex.IsMatch(level.Name, pattern))
                            result.Add(level.Name);
                }
                else result.Add(token);
            }

            return result;
        }
    }
}
