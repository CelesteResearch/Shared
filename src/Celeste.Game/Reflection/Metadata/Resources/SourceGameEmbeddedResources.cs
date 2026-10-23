using System;
using System.Collections.Generic;
using System.IO;
using Celeste.Core.Reflection.Resources;

namespace Celeste.Game.Reflection.Metadata.Resources;

public static class SourceGameEmbeddedResources
{
    public static void PublishOriginal(SourceAssemblyResourceCatalog resources)
    {
        if (resources == null) throw new ArgumentNullException(nameof(resources));
        resources.RegisterCompleteEmbeddedResourceTable(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new Dictionary<string, byte[]>(StringComparer.Ordinal)
            {
                { "Microsoft.Xna.Framework.RuntimeProfile", ReadPayload("Celeste.SourceResource.Original.000") },
            }, new string[]
            {
                "Microsoft.Xna.Framework.RuntimeProfile",
            });
    }

    public static void PublishInstalled(SourceAssemblyResourceCatalog resources)
    {
        if (resources == null) throw new ArgumentNullException(nameof(resources));
        resources.RegisterCompleteEmbeddedResourceTable(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new Dictionary<string, byte[]>(StringComparer.Ordinal)
            {
                { "Microsoft.Xna.Framework.RuntimeProfile", ReadPayload("Celeste.SourceResource.Installed.000") },
                { "Content/Dialog/Brazilian Portuguese.txt", ReadPayload("Celeste.SourceResource.Installed.001") },
                { "Content/Dialog/English.txt", ReadPayload("Celeste.SourceResource.Installed.002") },
                {
                    "Content/Dialog/Fonts/japanese-missing-debug.txt",
                    ReadPayload("Celeste.SourceResource.Installed.003")
                },
                { "Content/Dialog/French.txt", ReadPayload("Celeste.SourceResource.Installed.004") },
                { "Content/Dialog/German.txt", ReadPayload("Celeste.SourceResource.Installed.005") },
                { "Content/Dialog/Japanese.txt", ReadPayload("Celeste.SourceResource.Installed.006") },
                { "Content/Dialog/Korean.txt", ReadPayload("Celeste.SourceResource.Installed.007") },
                { "Content/Dialog/Polish.txt", ReadPayload("Celeste.SourceResource.Installed.008") },
                { "Content/Dialog/Russian.txt", ReadPayload("Celeste.SourceResource.Installed.009") },
                { "Content/Dialog/Simplified Chinese.txt", ReadPayload("Celeste.SourceResource.Installed.010") },
                { "Content/Dialog/Fonts/chinese.fnt", ReadPayload("Celeste.SourceResource.Installed.011") },
                { "Content/Dialog/Fonts/japanese.fnt", ReadPayload("Celeste.SourceResource.Installed.012") },
                { "Content/Dialog/Fonts/korean.fnt", ReadPayload("Celeste.SourceResource.Installed.013") },
                { "Content/Dialog/Fonts/chinese_generated_0.png", ReadPayload("Celeste.SourceResource.Installed.014") },
                { "Content/Dialog/Fonts/chinese_generated_1.png", ReadPayload("Celeste.SourceResource.Installed.015") },
                { "Content/Dialog/Fonts/japanese_everest_0.png", ReadPayload("Celeste.SourceResource.Installed.016") },
                { "Content/Dialog/Fonts/japanese_everest_1.png", ReadPayload("Celeste.SourceResource.Installed.017") },
                { "Content/Dialog/Fonts/korean_everest_0.png", ReadPayload("Celeste.SourceResource.Installed.018") },
                {
                    "Content/Graphics/Atlases/Gameplay/tilesets/subFolder/betterTemplate.png",
                    ReadPayload("Celeste.SourceResource.Installed.019")
                },
                {
                    "Content/Graphics/Atlases/Gameplay/__fallback.png",
                    ReadPayload("Celeste.SourceResource.Installed.020")
                },
                {
                    "Content/Graphics/Atlases/Gui/areas/new-yellow.png",
                    ReadPayload("Celeste.SourceResource.Installed.021")
                },
                { "Content/Graphics/Atlases/Gui/areas/null.png", ReadPayload("Celeste.SourceResource.Installed.022") },
                {
                    "Content/Graphics/Atlases/Gui/areas/null_back.png",
                    ReadPayload("Celeste.SourceResource.Installed.023")
                },
                { "Content/Graphics/Atlases/Gui/areas/steam.png", ReadPayload("Celeste.SourceResource.Installed.024") },
                {
                    "Content/Graphics/Atlases/Gui/areas/steam_back.png",
                    ReadPayload("Celeste.SourceResource.Installed.025")
                },
                {
                    "Content/Graphics/Atlases/Gui/areaselect/title.png",
                    ReadPayload("Celeste.SourceResource.Installed.026")
                },
                {
                    "Content/Graphics/Atlases/Gui/controls/mouse/Left.png",
                    ReadPayload("Celeste.SourceResource.Installed.027")
                },
                {
                    "Content/Graphics/Atlases/Gui/controls/mouse/Middle.png",
                    ReadPayload("Celeste.SourceResource.Installed.028")
                },
                {
                    "Content/Graphics/Atlases/Gui/controls/mouse/Right.png",
                    ReadPayload("Celeste.SourceResource.Installed.029")
                },
                {
                    "Content/Graphics/Atlases/Gui/controls/mouse/XButton1.png",
                    ReadPayload("Celeste.SourceResource.Installed.030")
                },
                {
                    "Content/Graphics/Atlases/Gui/controls/mouse/XButton2.png",
                    ReadPayload("Celeste.SourceResource.Installed.031")
                },
                {
                    "Content/Graphics/Atlases/Gui/emoji/checkpoint.m.png",
                    ReadPayload("Celeste.SourceResource.Installed.032")
                },
                {
                    "Content/Graphics/Atlases/Gui/emoji/everest.m.png",
                    ReadPayload("Celeste.SourceResource.Installed.033")
                },
                { "Content/Graphics/Atlases/Gui/emoji/glad.png", ReadPayload("Celeste.SourceResource.Installed.034") },
                {
                    "Content/Graphics/Atlases/Gui/emoji/gladbw.m.png",
                    ReadPayload("Celeste.SourceResource.Installed.035")
                },
                {
                    "Content/Graphics/Atlases/Gui/emoji/thinking.png",
                    ReadPayload("Celeste.SourceResource.Installed.036")
                },
                {
                    "Content/Graphics/Atlases/Gui/emoji/thinkingbw.m.png",
                    ReadPayload("Celeste.SourceResource.Installed.037")
                },
                {
                    "Content/Graphics/Atlases/Gui/logo_everest.png", ReadPayload("Celeste.SourceResource.Installed.038")
                },
                {
                    "Content/Graphics/Atlases/Gui/menu/everest.png", ReadPayload("Celeste.SourceResource.Installed.039")
                },
                {
                    "Content/Graphics/Atlases/Gui/menu/langnoicon.png",
                    ReadPayload("Celeste.SourceResource.Installed.040")
                },
                {
                    "Content/Graphics/Atlases/Gui/menu/maplist.png", ReadPayload("Celeste.SourceResource.Installed.041")
                },
                {
                    "Content/Graphics/Atlases/Gui/menu/mapsearch.png",
                    ReadPayload("Celeste.SourceResource.Installed.042")
                },
                {
                    "Content/Graphics/Atlases/Gui/menu/modoptions.png",
                    ReadPayload("Celeste.SourceResource.Installed.043")
                },
                {
                    "Content/Graphics/Atlases/Gui/menu/modoptions_new.png",
                    ReadPayload("Celeste.SourceResource.Installed.044")
                },
                {
                    "Content/Graphics/Atlases/Gui/reloader/cogwheel.png",
                    ReadPayload("Celeste.SourceResource.Installed.045")
                },
                {
                    "Content/Graphics/Atlases/Gui/title_everest.png",
                    ReadPayload("Celeste.SourceResource.Installed.046")
                },
                { "Content/Graphics/Atlases/Gui/__fallback.png", ReadPayload("Celeste.SourceResource.Installed.047") },
                { "Content/Graphics/Atlases/Misc/__fallback.png", ReadPayload("Celeste.SourceResource.Installed.048") },
                {
                    "Content/Graphics/Atlases/Portraits/textbox/madeline_mini.png",
                    ReadPayload("Celeste.SourceResource.Installed.049")
                },
                {
                    "Content/Graphics/Atlases/Gui/areas/null.meta.yaml",
                    ReadPayload("Celeste.SourceResource.Installed.050")
                },
                {
                    "Content/Graphics/Atlases/Gui/areas/null_back.meta.yaml",
                    ReadPayload("Celeste.SourceResource.Installed.051")
                },
                {
                    "Content/Graphics/Atlases/Gui/areas/steam.meta.yaml",
                    ReadPayload("Celeste.SourceResource.Installed.052")
                },
                {
                    "Content/Graphics/Atlases/Gui/areas/steam_back.meta.yaml",
                    ReadPayload("Celeste.SourceResource.Installed.053")
                },
                {
                    "Content/Graphics/Atlases/Gui/menu/maplist.meta.yaml",
                    ReadPayload("Celeste.SourceResource.Installed.054")
                },
                {
                    "Content/Graphics/Atlases/Gui/menu/modoptions.meta.yaml",
                    ReadPayload("Celeste.SourceResource.Installed.055")
                },
                { "Content/Lua/boot.lua", ReadPayload("Celeste.SourceResource.Installed.056") },
                { "Content/Lua/typebuilder.lua", ReadPayload("Celeste.SourceResource.Installed.057") },
            }, new string[]
            {
                "Microsoft.Xna.Framework.RuntimeProfile",
                "Content/Dialog/Brazilian Portuguese.txt",
                "Content/Dialog/English.txt",
                "Content/Dialog/Fonts/japanese-missing-debug.txt",
                "Content/Dialog/French.txt",
                "Content/Dialog/German.txt",
                "Content/Dialog/Japanese.txt",
                "Content/Dialog/Korean.txt",
                "Content/Dialog/Polish.txt",
                "Content/Dialog/Russian.txt",
                "Content/Dialog/Simplified Chinese.txt",
                "Content/Dialog/Fonts/chinese.fnt",
                "Content/Dialog/Fonts/japanese.fnt",
                "Content/Dialog/Fonts/korean.fnt",
                "Content/Dialog/Fonts/chinese_generated_0.png",
                "Content/Dialog/Fonts/chinese_generated_1.png",
                "Content/Dialog/Fonts/japanese_everest_0.png",
                "Content/Dialog/Fonts/japanese_everest_1.png",
                "Content/Dialog/Fonts/korean_everest_0.png",
                "Content/Graphics/Atlases/Gameplay/tilesets/subFolder/betterTemplate.png",
                "Content/Graphics/Atlases/Gameplay/__fallback.png",
                "Content/Graphics/Atlases/Gui/areas/new-yellow.png",
                "Content/Graphics/Atlases/Gui/areas/null.png",
                "Content/Graphics/Atlases/Gui/areas/null_back.png",
                "Content/Graphics/Atlases/Gui/areas/steam.png",
                "Content/Graphics/Atlases/Gui/areas/steam_back.png",
                "Content/Graphics/Atlases/Gui/areaselect/title.png",
                "Content/Graphics/Atlases/Gui/controls/mouse/Left.png",
                "Content/Graphics/Atlases/Gui/controls/mouse/Middle.png",
                "Content/Graphics/Atlases/Gui/controls/mouse/Right.png",
                "Content/Graphics/Atlases/Gui/controls/mouse/XButton1.png",
                "Content/Graphics/Atlases/Gui/controls/mouse/XButton2.png",
                "Content/Graphics/Atlases/Gui/emoji/checkpoint.m.png",
                "Content/Graphics/Atlases/Gui/emoji/everest.m.png",
                "Content/Graphics/Atlases/Gui/emoji/glad.png",
                "Content/Graphics/Atlases/Gui/emoji/gladbw.m.png",
                "Content/Graphics/Atlases/Gui/emoji/thinking.png",
                "Content/Graphics/Atlases/Gui/emoji/thinkingbw.m.png",
                "Content/Graphics/Atlases/Gui/logo_everest.png",
                "Content/Graphics/Atlases/Gui/menu/everest.png",
                "Content/Graphics/Atlases/Gui/menu/langnoicon.png",
                "Content/Graphics/Atlases/Gui/menu/maplist.png",
                "Content/Graphics/Atlases/Gui/menu/mapsearch.png",
                "Content/Graphics/Atlases/Gui/menu/modoptions.png",
                "Content/Graphics/Atlases/Gui/menu/modoptions_new.png",
                "Content/Graphics/Atlases/Gui/reloader/cogwheel.png",
                "Content/Graphics/Atlases/Gui/title_everest.png",
                "Content/Graphics/Atlases/Gui/__fallback.png",
                "Content/Graphics/Atlases/Misc/__fallback.png",
                "Content/Graphics/Atlases/Portraits/textbox/madeline_mini.png",
                "Content/Graphics/Atlases/Gui/areas/null.meta.yaml",
                "Content/Graphics/Atlases/Gui/areas/null_back.meta.yaml",
                "Content/Graphics/Atlases/Gui/areas/steam.meta.yaml",
                "Content/Graphics/Atlases/Gui/areas/steam_back.meta.yaml",
                "Content/Graphics/Atlases/Gui/menu/maplist.meta.yaml",
                "Content/Graphics/Atlases/Gui/menu/modoptions.meta.yaml",
                "Content/Lua/boot.lua",
                "Content/Lua/typebuilder.lua",
            });
    }

    private static byte[] ReadPayload(string logicalName)
    {
        using Stream source = typeof(SourceGameEmbeddedResources).Assembly.GetManifestResourceStream(logicalName)
                              ?? throw new InvalidOperationException(
                                  "The compiled source resource payload is missing: " + logicalName);
        using var bytes = new MemoryStream();
        source.CopyTo(bytes);
        return bytes.ToArray();
    }
}
