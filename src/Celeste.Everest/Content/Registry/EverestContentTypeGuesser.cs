using System;

namespace Celeste.Everest.Content.Registry
{
    public delegate string EverestContentTypeGuesser(string file, out Type type, out string format);
}
