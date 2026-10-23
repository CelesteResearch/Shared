using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Force.DeepCloner.Helpers
{
    internal static class DeepClonerExprGenerator
    {
        private static readonly ConcurrentDictionary<FieldInfo, bool> ReadonlyFields = new();

        internal static object GenerateClonerInternal(Type realType, bool asObject)
        {
            return GenerateProcessMethod(realType, asObject && realType.IsValueType());
        }


        // slow, but hardcore method to set readonly field
        internal static void ForceSetField(FieldInfo field, object obj, object value)
        {
            // Instance readonly fields can be assigned by reflection on both Unity's
            // Mono and .NET. Runtime-private m_fieldAttributes is not portable; the
            // upstream fallback silently retained live references when it was absent.
            field.SetValue(obj, value);
        }

        private static object GenerateProcessMethod(Type type, bool unboxStruct)
        {
            if (type.IsArray) return GenerateProcessArrayMethod(type);

            if (type.FullName != null && type.FullName.StartsWith("System.Tuple`"))
            {
                // if not safe type it is no guarantee that some type will contain reference to
                // this tuple. In usual way, we're creating new object, setting reference for it
                // and filling data. For tuple, we will fill data before creating object
                // (in constructor arguments)
                var genericArguments = type.GenericArguments();
                // current tuples contain only 8 arguments, but may be in future...
                // we'll write code that works with it
                if (genericArguments.Length < 10 && genericArguments.All(DeepClonerSafeTypes.CanReturnSameObject))
                    return GenerateProcessTupleMethod(type);
            }

            var methodType = unboxStruct || type.IsClass() ? typeof(object) : type;

            var expressionList = new List<Expression>();

            var from = Expression.Parameter(methodType);
            var fromLocal = from;
            var toLocal = Expression.Variable(type);
            var state = Expression.Parameter(typeof(DeepCloneState));

            if (!type.IsValueType())
            {
                var methodInfo = typeof(object).GetPrivateMethod("MemberwiseClone");

                // to = (T)from.MemberwiseClone()
                expressionList.Add(Expression.Assign(toLocal,
                    Expression.Convert(Expression.Call(from, methodInfo), type)));

                fromLocal = Expression.Variable(type);
                // fromLocal = (T)from
                expressionList.Add(Expression.Assign(fromLocal, Expression.Convert(from, type)));

                // added from -> to binding to ensure reference loop handling
                // structs cannot loop here
                // state.AddKnownRef(from, to)
                expressionList.Add(Expression.Call(state, typeof(DeepCloneState).GetMethod("AddKnownRef")!, from,
                    toLocal));
            }
            else
            {
                if (unboxStruct)
                {
                    // toLocal = (T)from;
                    expressionList.Add(Expression.Assign(toLocal, Expression.Unbox(from, type)));
                    fromLocal = Expression.Variable(type);
                    // fromLocal = toLocal; // structs, it is ok to copy
                    expressionList.Add(Expression.Assign(fromLocal, toLocal));
                }
                else
                {
                    // toLocal = from
                    expressionList.Add(Expression.Assign(toLocal, from));
                }
            }

            var fi = new List<FieldInfo>();
            var tp = type;
            do
            {
#if !NETCORE
                // don't do anything with this dark magic!
                if (tp == typeof(ContextBoundObject)) break;
#else
                if (tp.Name == "ContextBoundObject") break;
#endif

                fi.AddRange(tp.GetDeclaredFields());
                tp = tp.BaseType();
            } while (tp != null);

            foreach (var fieldInfo in fi)
                if (!DeepClonerSafeTypes.CanReturnSameObject(fieldInfo.FieldType))
                {
                    var methodInfo = fieldInfo.FieldType.IsValueType()
                        ? typeof(DeepClonerGenerator).GetPrivateStaticMethod("CloneStructInternal")
                            .MakeGenericMethod(fieldInfo.FieldType)
                        : typeof(DeepClonerGenerator).GetPrivateStaticMethod("CloneClassInternal");

                    var get = Expression.Field(fromLocal, fieldInfo);

                    // toLocal.Field = Clone...Internal(fromLocal.Field)
                    Expression call = Expression.Call(methodInfo, get, state);
                    if (!fieldInfo.FieldType.IsValueType()) call = Expression.Convert(call, fieldInfo.FieldType);

                    // should handle specially
                    // todo: think about optimization, but it rare case
                    var isReadonly = ReadonlyFields.GetOrAdd(fieldInfo, f => f.IsInitOnly);
                    if (isReadonly)
                    {
                        // var setMethod = fieldInfo.GetType().GetMethod("SetValue", new[] { typeof(object), typeof(object) });
                        // expressionList.Add(Expression.Call(Expression.Constant(fieldInfo), setMethod, toLocal, call));
                        var setMethod = typeof(DeepClonerExprGenerator).GetPrivateStaticMethod("ForceSetField");
                        expressionList.Add(Expression.Call(setMethod, Expression.Constant(fieldInfo),
                            Expression.Convert(toLocal, typeof(object)),
                            Expression.Convert(call, typeof(object))));
                    }
                    else
                    {
                        expressionList.Add(Expression.Assign(Expression.Field(toLocal, fieldInfo), call));
                    }
                }

            expressionList.Add(Expression.Convert(toLocal, methodType));

            var funcType = typeof(Func<,,>).MakeGenericType(methodType, typeof(DeepCloneState), methodType);

            var blockParams = new List<ParameterExpression>();
            if (from != fromLocal) blockParams.Add(fromLocal);

            blockParams.Add(toLocal);

            return Expression.Lambda(funcType, Expression.Block(blockParams, expressionList), from, state).Compile();
        }

        private static object GenerateProcessArrayMethod(Type type)
        {
            var elementType = type.GetElementType()!;
            var rank = type.GetArrayRank();

            MethodInfo methodInfo;

            // multidim or not zero-based arrays
            if (rank != 1 || type != elementType.MakeArrayType())
            {
                if (rank == 2 && type == elementType.MakeArrayType(2))
                    // small optimization for 2 dim arrays
                    methodInfo = typeof(DeepClonerGenerator).GetPrivateStaticMethod("Clone2DimArrayInternal")
                        .MakeGenericMethod(elementType);
                else
                    methodInfo = typeof(DeepClonerGenerator).GetPrivateStaticMethod("CloneAbstractArrayInternal");
            }
            else
            {
                var methodName = "Clone1DimArrayClassInternal";
                if (DeepClonerSafeTypes.CanReturnSameObject(elementType))
                    methodName = "Clone1DimArraySafeInternal";
                else if (elementType.IsValueType()) methodName = "Clone1DimArrayStructInternal";

                methodInfo = typeof(DeepClonerGenerator).GetPrivateStaticMethod(methodName)
                    .MakeGenericMethod(elementType);
            }

            var from = Expression.Parameter(typeof(object));
            var state = Expression.Parameter(typeof(DeepCloneState));
            var call = Expression.Call(methodInfo, Expression.Convert(from, type), state);

            var funcType = typeof(Func<,,>).MakeGenericType(typeof(object), typeof(DeepCloneState), typeof(object));

            return Expression.Lambda(funcType, call, from, state).Compile();
        }

        private static object GenerateProcessTupleMethod(Type type)
        {
            var from = Expression.Parameter(typeof(object));
            var state = Expression.Parameter(typeof(DeepCloneState));

            var local = Expression.Variable(type);
            var assign = Expression.Assign(local, Expression.Convert(from, type));

            var funcType = typeof(Func<object, DeepCloneState, object>);

            var tupleLength = type.GenericArguments().Length;

            var constructor = Expression.Assign(local,
                Expression.New(type.GetPublicConstructors().First(x => x.GetParameters().Length == tupleLength),
                    type.GetPublicProperties().OrderBy(x => x.Name)
                        .Where(x => x.CanRead && x.Name.StartsWith("Item") && char.IsDigit(x.Name[4]))
                        .Select(x => Expression.Property(local, x.Name))));

            return Expression.Lambda(funcType, Expression.Block([local],
                    assign, constructor,
                    Expression.Call(state, typeof(DeepCloneState).GetMethod("AddKnownRef")!, from, local),
                    from),
                from, state).Compile();
        }
    }
}
