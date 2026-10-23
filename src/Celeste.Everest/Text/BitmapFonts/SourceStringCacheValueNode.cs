using System.Collections.Generic;

namespace Celeste.Everest.Text.BitmapFonts
{
    internal readonly struct SourceStringCacheValueNode
    {
        internal LinkedListNode<string> Node { get; }
        internal string Value { get; }

        internal SourceStringCacheValueNode(LinkedListNode<string> node, string value)
        {
            Node = node;
            Value = value;
        }
    }
}
