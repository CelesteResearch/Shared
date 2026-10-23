#if !NETCORE
using System.Reflection;

namespace Force.DeepCloner.Helpers
{
    internal static class DeepClonerMsilHelper
    {
        public static bool IsConstructorDoNothing(Type type, ConstructorInfo constructor)
        {
            if (constructor == null) return false;

            try
            {
                // will not try to determine body for this types
                if (type.IsGenericType || type.IsContextful || type.IsCOMObject || type.Assembly.IsDynamic)
                    return false;

                var methodBody = constructor.GetMethodBody();

                // this situation can be for com
                if (methodBody == null) return false;

                var ilAsByteArray = methodBody.GetILAsByteArray();
                return ilAsByteArray switch
                {
                    [0x02, 0x28, _, _, _, _, 0x2a] => // Ldarg_0, newobj, ret
                        type.Module.ResolveMethod(BitConverter.ToInt32(ilAsByteArray, 2)) ==
                        typeof(object).GetConstructor(Type.EmptyTypes),
                    [0x2a] => true, // ret
                    _ => false,
                };
            }
            catch (Exception)
            {
                // no permissions or something similar
                return false;
            }
        }
    }
}
#endif
