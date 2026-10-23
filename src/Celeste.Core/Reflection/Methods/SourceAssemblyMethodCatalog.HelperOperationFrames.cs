using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Methods
{
    public sealed partial class SourceAssemblyMethodCatalog
    {
        private readonly Dictionary<MethodBase, SourceMethodDefinition> actualHelperOperationFrameOrigins = new();

        private readonly Dictionary<MethodBase, SourceTypeDefinition> actualHelperMethodFrameOrigins = new();

        public void RegisterActualHelperMethodFrameOwnership(SourceMemberCatalog members,
            MethodBase actualBridge, Type qualifiedSourceOwnerType)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            if (actualBridge == null) throw new ArgumentNullException(nameof(actualBridge));
            var type = actualBridge.DeclaringType;
            if (type == null || type.Assembly.IsDynamic || actualBridge.Module != type.Module
                || (actualBridge.MetadataToken & unchecked((int)0xff000000)) != 0x06000000)
                throw new InvalidOperationException(
                    "The exact source coordination bridge has no genuine physical method metadata.");
            var owner = members.GetOriginalTypeDefinition(qualifiedSourceOwnerType);
            if (actualHelperMethodFrameOrigins.TryGetValue(actualBridge, out var existing))
            {
                if (!ReferenceEquals(existing, owner))
                    throw new InvalidOperationException(
                        "The exact coordination frame already has a different source assembly owner.");
                return;
            }

            actualHelperMethodFrameOrigins.Add(actualBridge, owner);
        }

        // This qualifies an exact portable bridge frame's source operation. It does not
        // create a TypeDef/MethodDef or claim its adapted ABI is the original callable ABI.
        public void RegisterActualHelperOperationFrameOwnership(SourceMemberCatalog members,
            MethodBase actualBridge, SourceMethodDefinition originalOperation)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            if (actualBridge == null) throw new ArgumentNullException(nameof(actualBridge));
            if (originalOperation == null) throw new ArgumentNullException(nameof(originalOperation));
            var type = actualBridge.DeclaringType;
            if (type == null || type.Assembly.IsDynamic || actualBridge.Module != type.Module
                || (actualBridge.MetadataToken & unchecked((int)0xff000000)) != 0x06000000)
                throw new InvalidOperationException(
                    "The actual operation bridge has no genuine physical declaring method metadata.");
            if (!ReferenceEquals(RequireDefinition(originalOperation.AssemblyIdentity,
                    originalOperation.MethodDefinitionToken), originalOperation))
                throw new InvalidOperationException(
                    "The bridge source operation does not belong to the selected actual source method catalog.");
            var owner = members.GetOriginalTypeDefinition(originalOperation.AssemblyIdentity,
                originalOperation.DeclaringType);
            if (owner.MetadataToken != originalOperation.TypeDefinitionToken)
                throw new InvalidOperationException("The bridge operation has no matching original source TypeDef.");
            if (actualHelperOperationFrameOrigins.TryGetValue(actualBridge, out var existing))
            {
                if (!ReferenceEquals(existing, originalOperation))
                    throw new InvalidOperationException(
                        "The same actual bridge frame already has a different original operation owner.");
                return;
            }

            actualHelperOperationFrameOrigins.Add(actualBridge, originalOperation);
        }
    }
}
