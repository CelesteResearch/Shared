#nullable enable annotations

using System.Collections.Generic;

namespace Celeste.Core.Reflection.Types
{
    public sealed class SourceTypeReferenceEqualityComparer : IEqualityComparer<SourceTypeReference>
    {
        public static SourceTypeReferenceEqualityComparer Instance { get; } = new();

        public bool Equals(SourceTypeReference? x, SourceTypeReference? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null || x.Kind != y.Kind) return false;
            switch (x.Kind)
            {
                case SourceTypeReferenceKind.Named:
                    return x.AssemblyIdentity == y.AssemblyIdentity && x.TypeIdentity == y.TypeIdentity;
                case SourceTypeReferenceKind.GenericParameter:
                    return x.GenericParameterPosition == y.GenericParameterPosition &&
                           x.GenericParameterOwnerKind == y.GenericParameterOwnerKind &&
                           x.OwnerAssemblyIdentity == y.OwnerAssemblyIdentity &&
                           x.OwnerTypeIdentity == y.OwnerTypeIdentity &&
                           x.OwnerMethodDefinitionToken == y.OwnerMethodDefinitionToken;
                case SourceTypeReferenceKind.Array:
                    if (x.ArrayRank != y.ArrayRank || x.ArrayDimensions.Count != y.ArrayDimensions.Count) return false;
                    for (var i = 0; i < x.ArrayDimensions.Count; i++)
                        if (x.ArrayDimensions[i].LowerBound != y.ArrayDimensions[i].LowerBound ||
                            x.ArrayDimensions[i].UpperBound != y.ArrayDimensions[i].UpperBound)
                            return false;
                    return Equals(x.ElementType, y.ElementType);
                case SourceTypeReferenceKind.GenericInstance:
                    return Equals(x.ElementType, y.ElementType) &&
                           SequenceEquals(x.GenericArguments, y.GenericArguments);
                case SourceTypeReferenceKind.RequiredModifier:
                case SourceTypeReferenceKind.OptionalModifier:
                    return Equals(x.ElementType, y.ElementType) && Equals(x.ModifierType, y.ModifierType);
                case SourceTypeReferenceKind.FunctionPointer:
                    return x.CallingConvention == y.CallingConvention && x.HasThis == y.HasThis &&
                           x.ExplicitThis == y.ExplicitThis &&
                           Equals(x.ReturnType, y.ReturnType) && SequenceEquals(x.ParameterTypes, y.ParameterTypes);
                default:
                    return Equals(x.ElementType, y.ElementType);
            }
        }

        private bool SequenceEquals(IReadOnlyList<SourceTypeReference> x, IReadOnlyList<SourceTypeReference> y)
        {
            if (x.Count != y.Count) return false;
            for (var i = 0; i < x.Count; i++)
                if (!Equals(x[i], y[i]))
                    return false;
            return true;
        }

        public int GetHashCode(SourceTypeReference? value)
        {
            if (value == null) return 0;
            unchecked
            {
                var hash = (int)value.Kind + 1;
                switch (value.Kind)
                {
                    case SourceTypeReferenceKind.Named:
                        hash = hash * 31 + value.AssemblyIdentity.GetHashCode();
                        return hash * 31 + value.TypeIdentity.GetHashCode();
                    case SourceTypeReferenceKind.GenericParameter:
                        hash = hash * 31 + value.GenericParameterPosition;
                        hash = hash * 31 + (int)value.GenericParameterOwnerKind;
                        hash = hash * 31 + value.OwnerAssemblyIdentity.GetHashCode();
                        hash = hash * 31 + value.OwnerTypeIdentity.GetHashCode();
                        return hash * 31 + value.OwnerMethodDefinitionToken;
                    case SourceTypeReferenceKind.Array:
                        hash = hash * 31 + value.ArrayRank;
                        foreach (var dimension in value.ArrayDimensions)
                        {
                            hash = hash * 31 + dimension.LowerBound.GetHashCode();
                            hash = hash * 31 + dimension.UpperBound.GetHashCode();
                        }

                        return hash * 31 + GetHashCode(value.ElementType);
                    case SourceTypeReferenceKind.GenericInstance:
                        hash = hash * 31 + GetHashCode(value.ElementType);
                        foreach (var argument in value.GenericArguments) hash = hash * 31 + GetHashCode(argument);
                        return hash;
                    case SourceTypeReferenceKind.RequiredModifier:
                    case SourceTypeReferenceKind.OptionalModifier:
                        hash = hash * 31 + GetHashCode(value.ModifierType);
                        return hash * 31 + GetHashCode(value.ElementType);
                    case SourceTypeReferenceKind.FunctionPointer:
                        hash = hash * 31 + value.CallingConvention;
                        hash = hash * 31 + value.HasThis.GetHashCode();
                        hash = hash * 31 + value.ExplicitThis.GetHashCode();
                        hash = hash * 31 + GetHashCode(value.ReturnType);
                        foreach (var parameter in value.ParameterTypes) hash = hash * 31 + GetHashCode(parameter);
                        return hash;
                    default:
                        return hash * 31 + GetHashCode(value.ElementType);
                }
            }
        }
    }
}
