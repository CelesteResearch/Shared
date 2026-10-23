using System;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Game.Entities.Hazards.Spinners.Crystal;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        private ILHook crystalSpinnerConnectionHook;

        private void InstallSourceCrystalSpinnerConnectionHook()
        {
            crystalSpinnerConnectionHook = new ILHook(typeof(OriginalCrystalStaticSpinner).GetMethod("CreateSprites",
                BindingFlags.Instance | BindingFlags.NonPublic), PatchSourceCrystalSpinnerConnections);
        }

        private void PatchSourceCrystalSpinnerConnections(ILContext il)
        {
            var cursor = new ILCursor(il);
            int entityLocal = -1;
            cursor.GotoNext(MoveType.After,
                instruction => instruction.MatchCastclass<OriginalCrystalStaticSpinner>(),
                instruction => instruction.MatchStloc(out entityLocal));
            var conditionCursor = new ILCursor(il) { Index = cursor.Index };
            conditionCursor.GotoNext(MoveType.Before,
                instruction => instruction.MatchLdcR4(24f),
                instruction => instruction.OpCode == OpCodes.Bge_Un || instruction.OpCode == OpCodes.Bge_Un_S);
            var skipConnection = (ILLabel)conditionCursor.Next.Next.Operand;
            var addConnection = il.DefineLabel(conditionCursor.Next.Next.Next);
            cursor.Emit(OpCodes.Ldarg_0);
            cursor.Emit(OpCodes.Ldloc, entityLocal);
            cursor.EmitDelegate<Func<OriginalCrystalStaticSpinner, OriginalCrystalStaticSpinner, int>>(
                SelectSourceCrystalSpinnerConnection);
            // -1 leaves the original condition intact; 0 skips, 1 enters the original AddSprite body.
            cursor.Emit(OpCodes.Switch, new[] { skipConnection, addConnection });
        }

        private int SelectSourceCrystalSpinnerConnection(OriginalCrystalStaticSpinner spinner,
            OriginalCrystalStaticSpinner entity)
        {
            if (!ReferenceEquals(((ISourceEngineContextEntity)spinner).EngineContext, SourceEngine)) return -1;
            return entity.ID > spinner.ID && entity.AttachToSolid == spinner.AttachToSolid &&
                   ((ISourceVectorEnvironment)SourceEngine).VectorArithmetic.LengthSquared(entity.Position -
                       spinner.Position)
                   < 576f
                ? 1
                : 0;
        }
    }
}
