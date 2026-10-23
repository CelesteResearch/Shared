using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution;
using Celeste.Scene.Scenes;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private void PublishSourceEngineSceneMemberOwner()
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = SourceMembers.RequireDefinition(assembly, "Monocle.Engine", "Scene",
                SourceMemberKind.Property);
            if (!definition.IsStatic || !definition.IsPublic || !definition.CanRead || !definition.CanWrite
                || definition.IndexParameterCount != 0 || definition.ValueTypeIdentity != "Monocle.Scene")
                throw new InvalidOperationException(
                    "The original Engine.Scene declaration does not match its scene loan.");

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            var frame = typeof(GameApplication).GetProperty(nameof(Frame), flags)
                        ?? throw new MissingMemberException(typeof(GameApplication).FullName, nameof(Frame));
            var scenes = typeof(SourceEngineFrameState).GetField(nameof(SourceEngineFrameState.Scenes), flags)
                         ?? throw new MissingFieldException(typeof(SourceEngineFrameState).FullName,
                             nameof(SourceEngineFrameState.Scenes));
            var current = typeof(SourceEngineSceneState).GetProperty(nameof(SourceEngineSceneState.CurrentScene), flags)
                          ?? throw new MissingMemberException(typeof(SourceEngineSceneState).FullName,
                              nameof(SourceEngineSceneState.CurrentScene));
            var next = typeof(SourceEngineSceneState).GetField(nameof(SourceEngineSceneState.NextScene), flags)
                       ?? throw new MissingFieldException(typeof(SourceEngineSceneState).FullName,
                           nameof(SourceEngineSceneState.NextScene));

            // Original Engine.Scene reads the current scene, but assignment schedules nextScene.
            // End/Begin remain exclusively in the original engine's frame-tail transition.
            SourceMembers.RegisterBinding(new(definition, typeof(EngineRuntime),
                [frame, scenes, current], this,
                declaredActualValueType: typeof(SourceSceneState),
                actualWriteMemberPath: [frame, scenes, next]));
        }
    }
}
