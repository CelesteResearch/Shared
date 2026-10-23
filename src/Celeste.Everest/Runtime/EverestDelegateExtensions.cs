using System;

namespace Celeste.Everest.Runtime
{
    public static class EverestDelegateExtensions
    {
        public static T InvokeWhileNull<T>(this MulticastDelegate handlers, params object[] args) where T : class
        {
            if ((object)handlers == null) return null;
            var invocationList = handlers.GetInvocationList();
            for (var i = 0; i < invocationList.Length; i++)
            {
                var value = (T)invocationList[i].DynamicInvoke(args);
                if (value != null) return value;
            }

            return null;
        }
    }
}
