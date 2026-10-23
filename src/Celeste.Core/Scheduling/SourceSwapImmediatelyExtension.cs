using System;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Core.Scheduling
{
    public static class SourceSwapImmediatelyExtension
    {
        public struct Flattened : IEnumerator
        {
            private readonly Stack<IEnumerator> enums = new Stack<IEnumerator>();

            private object current = null;

            public readonly object Current => current;

            public Flattened(IEnumerator from)
            {
                enums.Push(from);
            }

            public bool MoveNext()
            {
                while (enums.Count > 0)
                {
                    IEnumerator enumerator = enums.Peek();
                    if (enumerator.MoveNext())
                    {
                        object obj = enumerator.Current;
                        if (!(obj is SourceSwapImmediately swapImmediately))
                        {
                            current = obj;
                            return true;
                        }

                        enums.Push(swapImmediately.Inner);
                    }
                    else
                    {
                        enums.Pop();
                    }
                }

                current = null;
                return false;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        ///         Flattens all <see cref="T:Celeste.Mod.SourceSwapImmediately" /> returned by the source IEnumerator.
        ///         When writing hooks on Coroutine-style methods,
        ///         this method is needed if you want to access values returned from the orig Coroutine,
        ///         for instance, if it were to return the following sequence `{1, 2, SourceSwapImmediately({1, 2}), 3}`
        ///         a simple enumeration of it would not pass properly the values inside the <see cref="T:Celeste.Mod.SourceSwapImmediately" />.
        ///         This method makes it so the returned values become the sequence `{1, 2, 1, 2, 3}`.
        ///         (Behaviour mimicks <see cref="T:Monocle.Coroutine" />'s handling of <see cref="T:Celeste.Mod.SourceSwapImmediately" />.)
        ///       </summary>
        /// <returns>
        ///         A new enumerator which flattens the sequence once <see cref="T:Celeste.Mod.SourceSwapImmediately" />s are received.
        ///       </returns>
        /// <example>
        ///       The most common use would be hooking a Coroutine method:
        ///       <code>
        ///         private static IEnumerator DashCoroutine(On.Celeste.Player.orig_DashCoroutine orig, Player self) {
        ///           IEnumerator origEnum = orig(self).SafeEnumerate();
        ///           while (origEnum.MoveNext()) {
        ///             yield return origEnum.Current;
        ///             // Do anything here
        ///           }
        ///         }
        ///       </code></example>
        public static Flattened SafeEnumerate(this IEnumerator self)
        {
            if (self is Flattened)
            {
                return (Flattened)(object)self;
            }

            return new Flattened(self);
        }
    }
}
