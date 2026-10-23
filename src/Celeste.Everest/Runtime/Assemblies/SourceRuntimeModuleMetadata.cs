using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Mono.Cecil;

namespace Celeste.Everest.Runtime.Assemblies
{
    /// Owns authenticated physical CLR module readers until the owning process is disposed.
    public sealed class SourceRuntimeModuleMetadata : IDisposable
    {
        private readonly Func<Module, string> requirePath;

        private readonly Dictionary<Module, ModuleDefinition> modules = new();

        private readonly Dictionary<Module, MemoryStream> streams = new();

        private readonly DefaultAssemblyResolver resolver = new();

        private readonly object gate = new();

        private bool disposed;

        // ReSharper disable once ConvertToPrimaryConstructor
        public SourceRuntimeModuleMetadata(Func<Module, string> requirePath)
        {
            this.requirePath = requirePath ?? throw new ArgumentNullException(nameof(requirePath));
        }

        public ModuleDefinition RequireModule(Module actualModule)
        {
            if (actualModule == null) throw new ArgumentNullException(nameof(actualModule));
            lock (gate)
            {
                if (disposed) throw new ObjectDisposedException(nameof(SourceRuntimeModuleMetadata));
                if (modules.TryGetValue(actualModule, out var existing)) return existing;
                if (actualModule.Assembly.IsDynamic || actualModule.ModuleVersionId == Guid.Empty)
                    throw new NotSupportedException(
                        "Physical metadata requires a non-dynamic CLR module with an MVID.");
                var path = requirePath(actualModule);
                if (string.IsNullOrEmpty(path) || !Path.IsPathRooted(path) || !File.Exists(path))
                    throw new FileNotFoundException("The actual CLR module has no qualified physical PE file.", path);
                resolver.AddSearchDirectory(Path.GetDirectoryName(path));
                var stream = new MemoryStream(File.ReadAllBytes(path), false);
                ModuleDefinition definition = null;
                try
                {
                    definition = ModuleDefinition.ReadModule(stream, new()
                    {
                        ReadSymbols = false,
                        AssemblyResolver = resolver,
                        ReadingMode = ReadingMode.Deferred,
                    });
                    if (definition.Mvid != actualModule.ModuleVersionId || definition.Name != actualModule.ScopeName)
                        throw new BadImageFormatException(
                            "The physical PE does not match the actual CLR module MVID and scope.", path);
                    if (ReferenceEquals(actualModule, actualModule.Assembly.ManifestModule))
                    {
                        if (definition.Assembly == null ||
                            definition.Assembly.Name.FullName != actualModule.Assembly.GetName().FullName)
                            throw new BadImageFormatException(
                                "The physical PE does not match the actual CLR assembly identity.", path);
                    }
                    else
                    {
                        // Authenticate the actual owning manifest as well as this physical netmodule.
                        RequireModule(actualModule.Assembly.ManifestModule);
                    }

                    modules.Add(actualModule, definition);
                    streams.Add(actualModule, stream);
                    return definition;
                }
                catch
                {
                    definition?.Dispose();
                    stream.Dispose();
                    throw;
                }
            }
        }

        public TypeDefinition ResolveDefinition(Type actualType)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            if (actualType.IsGenericType && !actualType.IsGenericTypeDefinition)
                actualType = actualType.GetGenericTypeDefinition();
            if (RequireModule(actualType.Module)
                    .LookupToken(actualType.MetadataToken) is not TypeDefinition definition ||
                definition.FullName.Replace('/', '+') != actualType.FullName)
                throw new BadImageFormatException(
                    "The actual CLR type token does not identify its physical type declaration.");
            return definition;
        }

        public MethodDefinition ResolveDefinition(MethodBase actualMethod)
        {
            if (actualMethod == null) throw new ArgumentNullException(nameof(actualMethod));
            if (actualMethod is MethodInfo { IsGenericMethod: true, IsGenericMethodDefinition: false } info)
                actualMethod = info.GetGenericMethodDefinition();
            var declaringType = ResolveDefinition(actualMethod.DeclaringType ??
                                                  throw new NotSupportedException(
                                                      "Physical method metadata requires a declaring CLR type."));
            if (RequireModule(actualMethod.Module).LookupToken(actualMethod.MetadataToken) is not MethodDefinition
                    definition ||
                definition.Name != actualMethod.Name ||
                definition.IsStatic != actualMethod.IsStatic ||
                definition.Parameters.Count != actualMethod.GetParameters().Length ||
                definition.GenericParameters.Count !=
                (actualMethod.IsGenericMethod ? actualMethod.GetGenericArguments().Length : 0) ||
                definition.DeclaringType.MetadataToken != declaringType.MetadataToken ||
                !ReferenceEquals(definition.Module, declaringType.Module))
                throw new BadImageFormatException(
                    "The actual CLR method token does not identify its physical declaring method.");
            return definition;
        }

        public void Dispose()
        {
            lock (gate)
            {
                if (disposed) return;
                disposed = true;
                foreach (var module in modules.Values) module.Dispose();
                modules.Clear();
                foreach (var stream in streams.Values) stream.Dispose();
                streams.Clear();
                resolver.Dispose();
            }
        }
    }
}
