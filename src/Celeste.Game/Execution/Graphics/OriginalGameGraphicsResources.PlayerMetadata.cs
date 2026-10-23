using System;
using System.Xml;
using Celeste.Formats.Graphics.Xml;
using Celeste.Graphics.Content.Xml;
using Celeste.Simulation.Gameplay.Player.Presentation;

namespace Celeste.Game.Execution.Graphics
{
    public sealed partial class OriginalGameGraphicsResources
    {
        public void CreateFramesMetadata(string sprite)
        {
            foreach (var source in SpriteBank.SpriteData[sprite].Sources)
            {
                var xmlElement = source.XML["Metadata"];
                var text = source.Path;
                if (xmlElement == null) continue;

                if (!string.IsNullOrEmpty(source.OverridePath)) text = source.OverridePath;

                foreach (XmlElement item in xmlElement.GetElementsByTagName("Frames"))
                {
                    var text2 = text + item.Attr("path", "");
                    var array = item.Attr("hair").Split('|');
                    var array2 = item.Attr("carry", "").Split(',');
                    for (var i = 0; i < Math.Max(array.Length, array2.Length); i++)
                    {
                        var playerAnimMetadata = new PlayerAnimMetadata();
                        var text3 = text2 + (i < 10 ? "0" : "") + i;
                        if (i == 0 && !GameAtlas.Entries.ContainsKey(text3)) text3 = text2;

                        PlayerMetadata.Set(text3, playerAnimMetadata);
                        if (i < array.Length)
                        {
                            if (array[i].Equals("x", StringComparison.OrdinalIgnoreCase) || array[i].Length <= 0)
                            {
                                playerAnimMetadata.HasHair = false;
                            }
                            else
                            {
                                var array3 = array[i].Split(':');
                                var array4 = array3[0].Split(',');
                                playerAnimMetadata.HasHair = true;
                                playerAnimMetadata.HairOffset =
                                    new(Convert.ToInt32(array4[0]), Convert.ToInt32(array4[1]));
                                playerAnimMetadata.Frame = array3.Length >= 2 ? Convert.ToInt32(array3[1]) : 0;
                            }
                        }

                        if (i < array2.Length && array2[i].Length > 0)
                            playerAnimMetadata.CarryYOffset = int.Parse(array2[i]);
                    }
                }
            }
        }

        public void ClearFramesMetadata()
        {
            PlayerMetadata.Clear();
        }
    }
}
