using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Entities.Birds.Tutorials;
using Celeste.Game.Controls.Source;
using Celeste.Input.Bindings;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestCustomBirdTutorialEnvironment
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly EverestCustomBirdTutorialEvents sourceCustomBirdTutorialEvents = new();

        public EverestCustomBirdTutorialEvents CustomBirdTutorialEvents => sourceCustomBirdTutorialEvents;

        public SourceVirtualButton ReadCustomBirdInputField(string name)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            SourceMemberDefinition definition = null;
            foreach (var member in SourceMembers.GetOriginalMemberDefinitions(assembly, "Celeste.Input", false))
            {
                if (member.Kind != SourceMemberKind.Field || !member.IsPublic || !member.IsStatic ||
                    member.Name != name)
                    continue;
                definition = member;
                break;
            }

            if (definition == null) return null;
            // Original static Input fields live on this same process input owner.
            var field = typeof(OriginalGameInputProcess).GetField(name, BindingFlags.Instance | BindingFlags.Public);
            if (field == null)
                throw new MissingFieldException("The actual Input field loan is not published: " +
                                                definition.QualifiedName);
            var value = field.GetValue(InputSource);
            if (value?.GetType() != SourceMembers.GetActualSourceType(assembly, "Monocle.VirtualButton")) return null;
            return (SourceVirtualButton)field.GetValue(InputSource);
        }
    }
}
