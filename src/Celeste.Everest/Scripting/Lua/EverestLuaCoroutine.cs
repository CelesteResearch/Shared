using System;
using System.Collections;
using System.Linq;
using NLua;

namespace Celeste.Everest.Scripting.Lua
{
    public class EverestLuaCoroutine : IEnumerator
    {
        public readonly LuaTable Proxy;

        private object _Current;

        private bool _Valid;

        public object Current => !_Valid ? throw new InvalidOperationException() : _Current;

        public EverestLuaCoroutine(LuaTable proxy)
        {
            Proxy = proxy;
        }

        public bool MoveNext()
        {
            var array = (Proxy["resume"] as LuaFunction)?.Call(Proxy);
            var num = (bool)array[0];
            var flag = num;
            _Valid = num;
            if (flag)
            {
                _Current = array.ElementAtOrDefault(1);
                return true;
            }

            _Current = null;
            if (array.Length == 2 && array[1] is Exception ex) throw ex;

            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}
