using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Core.Reflection.Runtime
{
    public static class PortableReflection
    {
        public static ReflectedMember GetField(SourceMemberCatalog members, Type type, string name, BindingFlags flags)
            => GetMember(members, type, name, flags, false);

        public static ReflectedMember GetProperty(SourceMemberCatalog members, Type type, string name,
            BindingFlags flags)
            => GetMember(members, type, name, flags, true);

        private static ReflectedMember GetMember(SourceMemberCatalog members, Type type, string name,
            BindingFlags flags, bool property)
        {
            for (var current = type; current != null; current = current.BaseType)
            {
                if (members.UsesOriginalDeclarationMetadata(current))
                {
                    var binding = property
                        ? members.GetPropertyInfo(current, name, flags, logFailure: false)
                        : members.GetFieldInfo(current, name, flags, logFailure: false);
                    return binding == null ? null : new ReflectedMember(binding);
                }

                MemberInfo actual = property
                    ? current.GetProperty(name, flags | BindingFlags.DeclaredOnly)
                    : current.GetField(name, flags | BindingFlags.DeclaredOnly);
                if (actual != null) return new ReflectedMember(actual);
                if ((flags & BindingFlags.DeclaredOnly) != 0) break;
            }

            return null;
        }

        public static IEnumerable<ReflectedMethod> GetMethods(SourceMemberCatalog members,
            SourceAssemblyMethodCatalog methods, Type type, BindingFlags flags)
        {
            for (var current = type; current != null && current != typeof(object); current = current.BaseType)
            {
                if (members.UsesOriginalDeclarationMetadata(current))
                {
                    var sourceType = members.GetOriginalTypeDefinition(current);
                    do
                    {
                        var actualType = members.GetActualSourceType(sourceType.AssemblyIdentity, sourceType.Identity);
                        foreach (var binding in methods.GetMethods(members, actualType,
                                     flags | BindingFlags.DeclaredOnly))
                        {
                            var definition = methods.RequireDefinition(binding.SourceAssemblyIdentity,
                                binding.SourceMethodDefinitionToken);
                            yield return new ReflectedMethod(binding, definition.Name, actualType);
                        }

                        if ((flags & BindingFlags.DeclaredOnly) != 0 || sourceType.BaseTypeIdentity == null) break;
                        sourceType = members.GetOriginalBaseTypeDefinition(sourceType);
                    } while (sourceType != null && sourceType.Identity != "System.Object");

                    yield break;
                }

                foreach (var method in current.GetMethods(flags | BindingFlags.DeclaredOnly)
                             .OrderBy(method => method.MetadataToken))
                    yield return new ReflectedMethod(method);
                if ((flags & BindingFlags.DeclaredOnly) != 0) yield break;
            }
        }

        private static IEnumerable<ReflectedMethod> GetMethodCandidates(SourceMemberCatalog members,
            SourceAssemblyMethodCatalog methods, Type type, string name, Type[] parameterTypes, BindingFlags flags)
        {
            for (var current = type; current != null && current != typeof(object); current = current.BaseType)
            {
                if (members.UsesOriginalDeclarationMetadata(current))
                {
                    var sourceType = members.GetOriginalTypeDefinition(current);
                    do
                    {
                        var actualType = members.GetActualSourceType(sourceType.AssemblyIdentity, sourceType.Identity);
                        bool found = false;
                        foreach (var binding in methods.GetMethods(members, actualType,
                                     flags | BindingFlags.DeclaredOnly, name, parameterTypes))
                        {
                            found = true;
                            yield return new ReflectedMethod(binding, name, actualType);
                        }

                        if (found) yield break;
                        if ((flags & BindingFlags.DeclaredOnly) != 0 || sourceType.BaseTypeIdentity == null) break;
                        sourceType = members.GetOriginalBaseTypeDefinition(sourceType);
                    } while (sourceType != null && sourceType.Identity != "System.Object");

                    yield break;
                }

                bool actualFound = false;
                foreach (var method in current.GetMethods(flags | BindingFlags.DeclaredOnly)
                             .Where(method => method.Name == name).OrderBy(method => method.MetadataToken))
                {
                    if (parameterTypes != null)
                    {
                        var parameters = method.GetParameters();
                        if (parameters.Length != parameterTypes.Length || parameters.Where((parameter, index) =>
                                    parameterTypes[index] != null && parameter.ParameterType != parameterTypes[index])
                                .Any())
                            continue;
                    }

                    actualFound = true;
                    yield return new ReflectedMethod(method);
                }

                if (actualFound) yield break;
                if ((flags & BindingFlags.DeclaredOnly) != 0) yield break;
            }
        }

        public static ReflectedMethod GetMethod(SourceMemberCatalog members, SourceAssemblyMethodCatalog methods,
            Type type, string name, Type[] parameterTypes, BindingFlags flags)
        {
            ReflectedMethod result = null;
            foreach (var candidate in GetMethodCandidates(members, methods, type, name, parameterTypes, flags))
            {
                if (candidate.Name != name) continue;
                if (parameterTypes != null)
                {
                    if (candidate.OriginalBinding != null)
                    {
                        var binding = candidate.OriginalBinding;
                        var parameters = methods
                            .RequireDefinition(binding.SourceAssemblyIdentity, binding.SourceMethodDefinitionToken)
                            .ParameterTypeIdentities;
                        if (parameters == null)
                            throw new InvalidOperationException("Original method parameter metadata is not published.");
                        if (parameters.Count != parameterTypes.Length) continue;
                        if (parameters.Where((parameter, index) => parameterTypes[index] != null
                                                                   && parameter != TypeReflectionIdentity
                                                                       .Resolve(members, parameterTypes[index])
                                                                       .TypeIdentity).Any()) continue;
                    }
                    else
                    {
                        var parameters = candidate.ActualMethod.GetParameters();
                        if (parameters.Length != parameterTypes.Length) continue;
                        if (parameters.Where((parameter, index) => parameterTypes[index] != null
                                                                   && parameter.ParameterType != parameterTypes[index])
                            .Any()) continue;
                    }
                }

                if (result == null) result = candidate;
                else if (candidate.DeclaringType == result.DeclaringType) throw new AmbiguousMatchException();
                else if (candidate.DeclaringType.IsSubclassOf(result.DeclaringType)) result = candidate;
            }

            return result;
        }
    }
}
