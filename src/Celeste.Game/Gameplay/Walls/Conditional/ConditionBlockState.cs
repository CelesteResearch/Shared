using System;
using Celeste.Core.Maps;
using Celeste.Formats.Map.Identifiers;
using Celeste.Simulation.Gameplay.Walls.Conditional;

namespace Celeste.Game.Gameplay.Walls.Conditional
{
    // Celeste/Level.cs:853-871. The original key has no entity class: Level builds an
    // EntityID out of the "conditionID" attribute and only adds an ExitBlock when the
    // named condition holds. Every branch below is the original expression.
    public sealed class ConditionBlockState
    {
        public readonly ConditionBlockMode Mode;
        public readonly string Level;
        public readonly int ID;
        public MapEntityId EntityId => new(Level, ID);

        private ConditionBlockState(ConditionBlockMode mode,
            string level, int id)
        {
            Mode = mode;
            Level = level;
            ID = id;
        }

        // conditionID is split on ':' and the id is Convert.ToInt32; the same text is
        // re-formatted through EntityID (int), so "d-04:07" and "d-04:7" are one id.
        public static ConditionBlockState FromSource(
            MapElement source)
        {
            var mode = ParseMode(source);
            var parts = source.Text("conditionID").Split(':');
            var level = parts[0];
            var id = Convert.ToInt32(parts[1]);
            return new(mode, level, id);
        }

        public static bool ShouldCreate(MapElement source, Func<string, bool> getFlag,
            Func<MapEntityId, bool> doNotLoad,
            Func<MapEntityId, bool> strawberry)
        {
            return FromSource(source).Exists(getFlag, doNotLoad, strawberry);
        }

        // EntityData.Enum("condition", ConditionBlockModes.Key): Enum.TryParse(ignoreCase: true).
        public static ConditionBlockMode ParseMode(
            MapElement source)
        {
            var text = source.Text("condition", "Key");
            return Enum.TryParse<ConditionBlockMode>(text, true, out var parsed) ? parsed : ConditionBlockMode.Key;
        }

        // Level.cs:860-866. GetFlag is Session.GetFlag, DoNotLoad is Session.DoNotLoad.Contains,
        // Strawberry is Session.Strawberries.Contains. Unsupported values throw like the original.
        public bool Exists(Func<string, bool> getFlag, Func<MapEntityId, bool> doNotLoad,
            Func<MapEntityId, bool> strawberry)
        {
            switch (Mode)
            {
                case ConditionBlockMode.Button:
                    return getFlag(DashFlagName(EntityId));
                case ConditionBlockMode.Key:
                    return doNotLoad(EntityId);
                case ConditionBlockMode.Strawberry:
                    return strawberry(EntityId);
                default: throw new("Condition type not supported!");
            }
        }

        // DashSwitch.GetFlagName(EntityID id) => "dashSwitch_" + id.Key
        public static string DashFlagName(MapEntityId id)
        {
            return "dashSwitch_" +
                   EntityIdCodec.Format(id);
        }
    }
}
