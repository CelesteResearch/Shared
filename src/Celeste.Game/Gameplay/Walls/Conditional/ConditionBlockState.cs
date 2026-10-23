using System;
using System.Globalization;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Walls.Conditional
{
    // Celeste/Level.cs:853-871. The original key has no entity class: Level builds an
    // EntityID out of the "conditionID" attribute and only adds an ExitBlock when the
    // named condition holds. Every branch below is the original expression.
    public sealed class ConditionBlockState
    {
        public readonly global::Celeste.Simulation.Gameplay.Walls.Conditional.ConditionBlockMode Mode;
        public readonly string Level;
        public readonly int ID;
        public global::Celeste.Core.Maps.MapEntityId EntityId => new global::Celeste.Core.Maps.MapEntityId(Level, ID);

        private ConditionBlockState(global::Celeste.Simulation.Gameplay.Walls.Conditional.ConditionBlockMode mode,
            string level, int id)
        {
            Mode = mode;
            Level = level;
            ID = id;
        }

        // conditionID is split on ':' and the id is Convert.ToInt32; the same text is
        // re-formatted through EntityID (int), so "d-04:07" and "d-04:7" are one id.
        public static global::Celeste.Game.Gameplay.Walls.Conditional.ConditionBlockState FromSource(
            global::Celeste.Core.Maps.MapElement source)
        {
            var mode = ParseMode(source);
            string[] parts = source.Text("conditionID").Split(':');
            string level = parts[0];
            int id = Convert.ToInt32(parts[1]);
            return new global::Celeste.Game.Gameplay.Walls.Conditional.ConditionBlockState(mode, level, id);
        }

        public static bool ShouldCreate(global::Celeste.Core.Maps.MapElement source, Func<string, bool> getFlag,
            Func<global::Celeste.Core.Maps.MapEntityId, bool> doNotLoad,
            Func<global::Celeste.Core.Maps.MapEntityId, bool> strawberry)
            => FromSource(source).Exists(getFlag, doNotLoad, strawberry);

        // EntityData.Enum("condition", ConditionBlockModes.Key): Enum.TryParse(ignoreCase: true).
        public static global::Celeste.Simulation.Gameplay.Walls.Conditional.ConditionBlockMode ParseMode(
            global::Celeste.Core.Maps.MapElement source)
        {
            string text = source.Text("condition", "Key");
            if (Enum.TryParse<global::Celeste.Simulation.Gameplay.Walls.Conditional.ConditionBlockMode>(text, true,
                    out var parsed)) return parsed;
            return global::Celeste.Simulation.Gameplay.Walls.Conditional.ConditionBlockMode.Key;
        }

        // Level.cs:860-866. GetFlag is Session.GetFlag, DoNotLoad is Session.DoNotLoad.Contains,
        // Strawberry is Session.Strawberries.Contains. Unsupported values throw like the original.
        public bool Exists(Func<string, bool> getFlag, Func<global::Celeste.Core.Maps.MapEntityId, bool> doNotLoad,
            Func<global::Celeste.Core.Maps.MapEntityId, bool> strawberry)
        {
            switch (Mode)
            {
                case global::Celeste.Simulation.Gameplay.Walls.Conditional.ConditionBlockMode.Button:
                    return getFlag(DashFlagName(EntityId));
                case global::Celeste.Simulation.Gameplay.Walls.Conditional.ConditionBlockMode.Key:
                    return doNotLoad(EntityId);
                case global::Celeste.Simulation.Gameplay.Walls.Conditional.ConditionBlockMode.Strawberry:
                    return strawberry(EntityId);
                default: throw new Exception("Condition type not supported!");
            }
        }

        // DashSwitch.GetFlagName(EntityID id) => "dashSwitch_" + id.Key
        public static string DashFlagName(global::Celeste.Core.Maps.MapEntityId id) => "dashSwitch_" +
            global::Celeste.Formats.Map.Identifiers.EntityIdCodec.Format(id);
    }
}
