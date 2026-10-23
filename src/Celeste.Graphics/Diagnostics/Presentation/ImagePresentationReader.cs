using System;
using System.Reflection;
using Celeste.Core.Components;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    public static class ImagePresentationReader
    {
        // Classify once per concrete CLR type, outside the per-frame snapshot loop.
        public static bool UsesStandardRender(Type imageType)
        {
            if (imageType == null) throw new ArgumentNullException(nameof(imageType));
            if (!typeof(SpriteImage).IsAssignableFrom(imageType)) return false;
            var slot = typeof(SourceComponentState).GetMethod(nameof(SourceComponentState.Render));
            for (var current = imageType; current != null; current = current.BaseType)
                foreach (var method in current.GetMethods(BindingFlags.Instance | BindingFlags.Public |
                                                          BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
                    if (method.IsVirtual && method.GetBaseDefinition().Equals(slot))
                        return method.DeclaringType == typeof(SpriteImage);
            return false;
        }

        // Reads the standard image fields; it never invokes an entity/component Render or Update.
        // Owner custom rendering remains a separate coverage decision.
        public static bool TryCapture(SpriteImage image, out AtlasTextureDraw draw)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            var texture = image.Texture;
            if (!image.Visible || texture == null)
            {
                draw = default;
                return false;
            }

            draw = new(texture, image.RenderPosition, image.Origin, image.Color,
                image.Scale, image.Rotation, image.FlipX, image.FlipY);
            return true;
        }
    }
}
