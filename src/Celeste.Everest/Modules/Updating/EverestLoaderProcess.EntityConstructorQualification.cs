using System;
using System.Numerics;
using System.Reflection;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Content.Maps.Entities;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        // These are physical constructor adaptations, not original MethodDef ABI bindings.
        // Keep the source constructor preference: data+offset+id, data+offset, offset, empty.
        private bool TryQualifySourceEntityConstructor(Type actualType,
            out ConstructorInfo constructor,
            out Func<OriginalLevelEntityData, Vector2, MapEntityId, object[]> createArguments,
            out bool sourceIdIsConstructorArgument)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            constructor = null;
            createArguments = null;
            sourceIdIsConstructorArgument = false;
            for (var shape = 0; shape < 4; shape++)
            {
                var dataForms = shape < 2 ? 2 : 1;
                for (var dataForm = 0; dataForm < dataForms; dataForm++)
                {
                    var dataType = dataForm == 0 ? typeof(OriginalLevelEntityData) : typeof(EntityData);
                    var payloadTypes = shape switch
                    {
                        0 => [dataType, typeof(Vector2), typeof(MapEntityId)],
                        1 => [dataType, typeof(Vector2)],
                        2 => [typeof(Vector2)],
                        _ => Type.EmptyTypes,
                    };
                    // A shared constructor can receive its existing process explicitly at
                    // either end. Plain constructors retain the original mod entry shape.
                    ConstructorInfo qualifiedCandidate = null;
                    var qualifiedInjection = -1;
                    for (var injection = 0; injection < 3; injection++)
                    {
                        var injectEngine = injection != 2;
                        var parameters = new Type[payloadTypes.Length + (injectEngine ? 1 : 0)];
                        var payloadStart = injection == 0 ? 1 : 0;
                        Array.Copy(payloadTypes, 0, parameters, payloadStart, payloadTypes.Length);
                        if (injectEngine)
                            parameters[injection == 0 ? 0 : payloadTypes.Length] = typeof(ISourceEngineContext);
                        var candidate = actualType.GetConstructor(parameters);
                        if (candidate == null) continue;
                        var actualParameters = candidate.GetParameters();
                        var exactSignature = actualParameters.Length == parameters.Length;
                        for (var index = 0; exactSignature && index < parameters.Length; index++)
                            exactSignature = actualParameters[index].ParameterType == parameters[index];
                        if (!exactSignature) continue;
                        if (candidate.DeclaringType != actualType || !candidate.IsPublic || candidate.IsStatic
                            || actualType.ContainsGenericParameters || actualType.Assembly.IsDynamic
                            || candidate.Module != actualType.Module
                            || (candidate.MetadataToken & unchecked((int)0xff000000)) != 0x06000000)
                            throw new InvalidOperationException(
                                "The source entity constructor has no qualified actual physical metadata.");
                        // Engine-first and engine-last are the same signature for an
                        // empty payload. Deduplicate that actual method, never pick
                        // between distinct physical constructor implementations.
                        if (qualifiedCandidate != null && qualifiedCandidate.MetadataToken != candidate.MetadataToken)
                            throw new AmbiguousMatchException(
                                "Multiple actual constructor adaptations qualify the same source entity shape.");
                        if (qualifiedCandidate == null)
                        {
                            qualifiedCandidate = candidate;
                            qualifiedInjection = injection;
                        }
                    }

                    if (qualifiedCandidate != null)
                    {
                        constructor = qualifiedCandidate;
                        sourceIdIsConstructorArgument = shape == 0;
                        var selectedShape = shape;
                        var selectedInjection = qualifiedInjection;
                        var selectedPayloadLength = payloadTypes.Length;
                        createArguments = (data, offset, id) =>
                        {
                            var hasEngine = selectedInjection != 2;
                            if (!hasEngine && selectedShape == 3) return null;
                            var arguments = new object[selectedPayloadLength + (hasEngine ? 1 : 0)];
                            var start = selectedInjection == 0 ? 1 : 0;
                            if (selectedShape < 2)
                            {
                                // OriginalLevelEntityData inherits OriginalMapEntityData;
                                // preserve the exact source record, including values/nodes.
                                arguments[start] = data;
                                arguments[start + 1] = offset;
                                if (selectedShape == 0) arguments[start + 2] = id;
                            }
                            else if (selectedShape == 2)
                            {
                                arguments[start] = offset;
                            }

                            if (hasEngine) arguments[selectedInjection == 0 ? 0 : selectedPayloadLength] = sourceEngine;
                            return arguments;
                        };
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
