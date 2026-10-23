using Celeste.Core.Display;
using System;
using System.Linq;
using System.Numerics;
using Celeste.Everest.Entities.Decoration.Cobwebs;
using Celeste.Everest.Gameplay.Platforms.Clouds;
using Celeste.Everest.Gameplay.Platforms.Crumble;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Entities.Decoration.Construction;
using Celeste.Game.Entities.Environment.Space;
using Celeste.Game.Entities.Hazards.Spinners.Crystal;
using Celeste.Game.Gameplay.Checkpoints;
using Celeste.Game.Gameplay.Hazards.Spinners.Dust;
using Celeste.Game.Gameplay.Hazards.Spinners.Moving;
using Celeste.Game.Gameplay.Platforms.Clouds;
using Celeste.Game.Gameplay.Platforms.Crumble;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Crystal;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestLevelEntityOverrides
    {
        private static CrystalSpinnerColor ReadSpinnerColor(OriginalLevelEntityData data)
        {
            string name = EntityAttributeReader.Attr(data.Values, "color");
            switch (name)
            {
                case "Core": return (CrystalSpinnerColor)(-1);
                case "Blue":
                case "Red":
                case "Purple":
                case "Rainbow":
                    // Preserve the second attribute read, including custom ToString behavior.
                    return ReadNonCoreSpinnerColor(EntityAttributeReader.Attr(data.Values, "color"));
                default:
                    if ("core".Equals(name, StringComparison.InvariantCultureIgnoreCase))
                        return (CrystalSpinnerColor)(-1);
                    return ReadNonCoreSpinnerColor(EntityAttributeReader.Attr(data.Values, "color"));
            }
        }

        private static CrystalSpinnerColor ReadNonCoreSpinnerColor(string name)
        {
            switch (name)
            {
                case "Blue": return CrystalSpinnerColor.Blue;
                case "Red": return CrystalSpinnerColor.Red;
                case "Purple": return CrystalSpinnerColor.Purple;
                case "Rainbow": return CrystalSpinnerColor.Rainbow;
                default:
                    return Enum.TryParse(name, true, out CrystalSpinnerColor color)
                        ? color
                        : CrystalSpinnerColor.Blue;
            }
        }

        public SceneEntityState Create(OriginalLevelSceneRoot level, OriginalLevelEntityData record, Vector2 offset)
        {
            var data = record;
            switch (data.Name)
            {
                case "everest/spaceController":
                    return new OriginalSpaceController(level.EngineContext);
                case "trackSpinner":
                    return ((IOriginalMovingSpinnerEnvironment)level.EngineContext).MovingSpinnerFactory
                        .Create(level, data, offset, false);
                case "rotateSpinner":
                    return ((IOriginalMovingSpinnerEnvironment)level.EngineContext).MovingSpinnerFactory
                        .Create(level, data, offset, true);
                case "spinner":
                {
                    if (level.Session.AreaID == 3 ||
                        (level.Session.AreaID == 7 && level.Session.Level.StartsWith("d-")) ||
                        EntityAttributeReader.Bool(data.Values, "dust"))
                        return new OriginalDustStaticSpinnerState(data, offset, level.EngineContext);
                    CrystalSpinnerColor color;
                    switch (level.Session.AreaID)
                    {
                        case 5: color = CrystalSpinnerColor.Red; break;
                        case 6: color = CrystalSpinnerColor.Purple; break;
                        case 10: color = CrystalSpinnerColor.Rainbow; break;
                        default:
                            color = ReadSpinnerColor(data);
                            break;
                    }

                    return new OriginalCrystalStaticSpinner(data, offset, color, level.EngineContext);
                }
                case "checkpoint":
                    if (data.Position == Vector2.Zero && !EntityAttributeReader.Bool(data.Values, "allowOrigin"))
                        return new OriginalCheckpointState(data, offset,
                            (IOriginalCheckpointProcess)level.EngineContext);
                    return null;
                case "cloud":
                {
                    var cloud = new EverestCloudState(level.EngineContext, data, offset,
                        ((ISourcePlatformCollisionScene)level).SolidWorldFactory.CreateJumpThru(data.Position + offset,
                            false));
                    if (data.Values != null && EntityAttributeReader.Has(data.Values, "small"))
                        cloud.Small = EntityAttributeReader.Bool(data.Values, "small");
                    return cloud;
                }
                case "crumbleBlock":
                {
                    var crumble = new EverestCrumblePlatformState(data, offset,
                        (IOriginalCrumbleProcess)level.EngineContext,
                        ((ISourcePlatformCollisionScene)level).SolidWorldFactory);
                    if (data.Values != null && EntityAttributeReader.Has(data.Values, "texture"))
                        crumble.OverrideTexture = EntityAttributeReader.Attr(data.Values, "texture");
                    return crumble;
                }
                case "cobweb":
                {
                    var cobweb = (InstalledCobwebState)((IOriginalDecorationEnvironment)level.EngineContext)
                        .Decorations.CreateCobweb(data, offset, level.EngineContext);
                    if (data.Values != null && EntityAttributeReader.Has(data.Values, "color"))
                        cobweb.OverrideColors = (EntityAttributeReader.Attr(data.Values, "color")?.Split(','))
                            .Select(text => SourceHexColor.HexToColor(text)).ToArray();
                    return cobweb;
                }
                case "wire":
                {
                    var wire = ((IOriginalDecorationEnvironment)level.EngineContext)
                        .Decorations.CreateWire(data, offset, level.EngineContext);
                    if (data.Values != null && EntityAttributeReader.Has(data.Values, "color"))
                    {
                        PackedColor color = default;
                        if (data.Values.TryGetValue("color", out var value))
                        {
                            var text = value.ToString();
                            if (text.Length == 6) color = SourceHexColor.HexToColor(text);
                        }

                        wire.Color = color;
                    }

                    return wire;
                }
                case "movingPlatform":
                {
                    var platform = new global::Celeste.Game.Entities.Platforms.Wood.OriginalMovingPlatformState(
                        data, offset, ((ISourcePlatformCollisionScene)level).SolidWorldFactory);
                    if (data.Values != null && EntityAttributeReader.Has(data.Values, "texture"))
                        platform.OverrideTexture = EntityAttributeReader.Attr(data.Values, "texture");
                    return platform;
                }
                case "sinkingPlatform":
                {
                    var platform = new global::Celeste.Game.Entities.Platforms.Wood.OriginalSinkingPlatformState(
                        data, offset, ((ISourcePlatformCollisionScene)level).SolidWorldFactory);
                    if (data.Values != null && EntityAttributeReader.Has(data.Values, "texture"))
                        platform.OverrideTexture = EntityAttributeReader.Attr(data.Values, "texture");
                    return platform;
                }
                default:
                    return null;
            }
        }
    }
}
