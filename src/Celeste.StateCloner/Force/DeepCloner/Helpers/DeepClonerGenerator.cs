namespace Force.DeepCloner.Helpers
{
    internal static class DeepClonerGenerator
    {
        public static T CloneObject<T>(T obj, DeepCloneState state = null)
        {
            state ??= new();

            if (obj is not ValueType) return (T)CloneClassRoot(obj, state);

            var type = obj.GetType();
            if (typeof(T) == type)
                return DeepClonerSafeTypes.CanReturnSameObject(type) ? obj : CloneStructInternal(obj, state);


            return (T)CloneClassRoot(obj, state);
        }

        private static object CloneClassRoot(object obj, DeepCloneState state = null)
        {
            if (obj == null) return null;

            var type = obj.GetType();

            // this implementation is slightly faster than getoradd
            if (!DeepClonerCache.TypeCache.TryGetValue(type, out var value))
                lock (type)
                {
                    DeepClonerCache.TypeCache.TryAdd(type, value = GenerateCloner(type, true));
                }

            // null -> should return same type
            if (value == null) return obj;

            var cloner = (Func<object, DeepCloneState, object>)value;

            state ??= new();

            var knownRef = state.GetKnownRef(obj);
            if (knownRef != null) return knownRef;

            var preProcessObj = DeepCloner.InvokePreCloneProcessor(obj, state);
            if (preProcessObj != null) return preProcessObj;

            var clonedObj = cloner(obj, state);

            return DeepCloner.InvokePostCloneProcessor(obj, clonedObj, state);
        }

        internal static object CloneClassInternal(object obj, DeepCloneState state)
        {
            if (obj == null) return null;

            var type = obj.GetType();

            // this implementation is slightly faster than getoradd
            if (!DeepClonerCache.TypeCache.TryGetValue(type, out var value))
                lock (type)
                {
                    DeepClonerCache.TypeCache.TryAdd(type, value = GenerateCloner(type, true));
                }

            // safe ojbect
            if (value == null) return obj;

            var cloner = (Func<object, DeepCloneState, object>)value;

            // loop
            var knownRef = state.GetKnownRef(obj);
            if (knownRef != null) return knownRef;

            var preProcessObj = DeepCloner.InvokePreCloneProcessor(obj, state);
            if (preProcessObj != null) return preProcessObj;

            var clonedObj = cloner(obj, state);

            return DeepCloner.InvokePostCloneProcessor(obj, clonedObj, state);
        }

        private static T CloneStructInternal<T>(T obj, DeepCloneState state) // where T : struct
        {
            // no loops, no nulls, no inheritance
            var cloner = GetClonerForValueType<T>();

            // safe ojbect
            if (cloner == null) return obj;

            var preProcessObj = DeepCloner.InvokePreCloneProcessor(obj, state);
            if (preProcessObj != null) return (T)preProcessObj;

            object clonedObj = cloner(obj, state);

            return (T)DeepCloner.InvokePostCloneProcessor(obj, clonedObj, state);
        }

        // when we can't use code generation, we can use these methods
        internal static T[] Clone1DimArraySafeInternal<T>(T[] obj, DeepCloneState state)
        {
            var l = obj.Length;
            var outArray = new T[l];
            state.AddKnownRef(obj, outArray);
            Array.Copy(obj, outArray, obj.Length);
            return outArray;
        }

        internal static T[] Clone1DimArrayStructInternal<T>(T[] obj, DeepCloneState state)
        {
            // not null from called method, but will check it anyway
            if (obj == null) return null;

            var l = obj.Length;
            var outArray = new T[l];
            state.AddKnownRef(obj, outArray);
            var cloner = GetClonerForValueType<T>();
            for (var i = 0; i < l; i++) outArray[i] = cloner(obj[i], state);

            return outArray;
        }

        internal static T[] Clone1DimArrayClassInternal<T>(T[] obj, DeepCloneState state)
        {
            // not null from called method, but will check it anyway
            if (obj == null) return null;

            var l = obj.Length;
            var outArray = new T[l];
            state.AddKnownRef(obj, outArray);
            for (var i = 0; i < l; i++) outArray[i] = (T)CloneClassInternal(obj[i], state);

            return outArray;
        }

        // relatively frequent case. specially handled
        internal static T[,] Clone2DimArrayInternal<T>(T[,] obj, DeepCloneState state)
        {
            // not null from called method, but will check it anyway
            if (obj == null) return null;

            // we cannot determine by type multidim arrays (one dimension is possible)
            // so, will check for index here
            var lb1 = obj.GetLowerBound(0);
            var lb2 = obj.GetLowerBound(1);
            if (lb1 != 0 || lb2 != 0) return (T[,])CloneAbstractArrayInternal(obj, state);

            var l1 = obj.GetLength(0);
            var l2 = obj.GetLength(1);
            var outArray = new T[l1, l2];
            state.AddKnownRef(obj, outArray);
            if (DeepClonerSafeTypes.CanReturnSameObject(typeof(T)))
            {
                Array.Copy(obj, outArray, obj.Length);
                return outArray;
            }

            if (typeof(T).IsValueType())
            {
                var cloner = GetClonerForValueType<T>();
                for (var i = 0; i < l1; i++)
                for (var k = 0; k < l2; k++)
                    outArray[i, k] = cloner(obj[i, k], state);
            }
            else
            {
                for (var i = 0; i < l1; i++)
                for (var k = 0; k < l2; k++)
                    outArray[i, k] = (T)CloneClassInternal(obj[i, k], state);
            }

            return outArray;
        }

        // rare cases, very slow cloning. currently it's ok
        internal static Array CloneAbstractArrayInternal(Array obj, DeepCloneState state)
        {
            // not null from called method, but will check it anyway
            if (obj == null) return null;

            var rank = obj.Rank;

            var lowerBounds = Enumerable.Range(0, rank).Select(obj.GetLowerBound).ToArray();
            var lengths = Enumerable.Range(0, rank).Select(obj.GetLength).ToArray();
            var idxes = Enumerable.Range(0, rank).Select(obj.GetLowerBound).ToArray();

            var elementType = obj.GetType().GetElementType()!;
            var outArray = Array.CreateInstance(elementType, lengths, lowerBounds);
            state.AddKnownRef(obj, outArray);

            // we're unable to set any value to this array, so, just return it
            if (lengths.Any(length => length == 0)) return outArray;

            if (DeepClonerSafeTypes.CanReturnSameObject(elementType))
            {
                Array.Copy(obj, outArray, obj.Length);
                return outArray;
            }

            var ofs = rank - 1;
            while (true)
            {
                outArray.SetValue(CloneClassInternal(obj.GetValue(idxes), state), idxes);
                idxes[ofs]++;

                if (!(idxes[ofs] >= lowerBounds[ofs] + lengths[ofs])) continue;

                do
                {
                    if (ofs == 0) return outArray;

                    idxes[ofs] = lowerBounds[ofs];
                    ofs--;
                    idxes[ofs]++;
                } while (idxes[ofs] >= lowerBounds[ofs] + lengths[ofs]);

                ofs = rank - 1;
            }
        }

        internal static Func<T, DeepCloneState, T> GetClonerForValueType<T>()
        {
            var type = typeof(T);
            if (DeepClonerCache.StructAsObjectCache.TryGetValue(type, out var value))
                return (Func<T, DeepCloneState, T>)value;

            lock (type)
            {
                DeepClonerCache.StructAsObjectCache.TryAdd(type, value = GenerateCloner(type, false));
            }

            return (Func<T, DeepCloneState, T>)value;
        }

        private static object GenerateCloner(Type t, bool asObject)
        {
            if (DeepClonerSafeTypes.CanReturnSameObject(t) && asObject && !t.IsValueType()) return null;

#if !NETCORE
            return ShallowObjectCloner.IsSafeVariant()
                ? DeepClonerExprGenerator.GenerateClonerInternal(t, asObject)
                : DeepClonerMsilGenerator.GenerateClonerInternal(t, asObject);
#else
            return DeepClonerExprGenerator.GenerateClonerInternal(t, asObject);
#endif
        }

        public static object CloneObjectTo(object objFrom, object objTo, bool isDeep, DeepCloneState state = null)
        {
            if (objTo == null) return null;

            if (objFrom == null) throw new ArgumentNullException(nameof(objFrom), "Cannot copy null object to another");

            var type = objFrom.GetType();
            if (!type.IsInstanceOfType(objTo))
                throw new InvalidOperationException(
                    "From object should be derived from From object, but From object has type " +
                    objFrom.GetType().FullName + " and to " + objTo.GetType().FullName);

            if (objFrom is string) throw new InvalidOperationException("It is forbidden to clone strings");

            if (!DeepClonerCache.TypeCacheDeepTo.TryGetValue(type, out var deepToValue))
                lock (type)
                {
                    DeepClonerCache.TypeCacheDeepTo.TryAdd(type,
                        deepToValue = ClonerToExprGenerator.GenerateClonerInternal(type, true));
                }

            if (!DeepClonerCache.TypeCacheShallowTo.TryGetValue(type, out var shallowToValue))
                lock (type)
                {
                    DeepClonerCache.TypeCacheShallowTo.TryAdd(type,
                        shallowToValue = ClonerToExprGenerator.GenerateClonerInternal(type, false));
                }

            var cloner =
                (Func<object, object, DeepCloneState, object>)(isDeep ? deepToValue : shallowToValue);
            if (cloner == null) return objTo;

            state ??= new();

            return cloner(objFrom, objTo, state);
        }
    }
}
