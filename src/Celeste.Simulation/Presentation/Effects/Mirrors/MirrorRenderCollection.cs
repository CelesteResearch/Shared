using System;
using System.Collections.Generic;

namespace Celeste.Simulation.Presentation.Effects.Mirrors
{
    // 对应 Tracker 的两份组件列表。由实际 Added/Removed 接线维护，不能按实体类型逐帧重建。
    public sealed class MirrorRenderCollection
    {
        public sealed class Reflection
        {
            public Func<int> Depth;
            public Func<bool> OwnerVisible, Visible, IgnoreEntityVisible;
            public Action<bool> SetIsRendering;
            public Func<IEnumerable<global::Celeste.Graphics.Display.ImagePlacement>> RenderImages;
        }

        public sealed class Surface
        {
            public Func<bool> Visible;
            public Func<IEnumerable<global::Celeste.Graphics.Display.ImagePlacement>> RenderImages;
        }

        readonly List<Reflection> reflections = new List<Reflection>();
        readonly List<Surface> surfaces = new List<Surface>();
        public IReadOnlyList<Reflection> Reflections => reflections;
        public IReadOnlyList<Surface> Surfaces => surfaces;
        public bool HasReflections => reflections.Count > 0 && surfaces.Count > 0;
        public void Add(Reflection component) => reflections.Add(component);
        public void Add(Surface component) => surfaces.Add(component);
        public bool Remove(Reflection component) => reflections.Remove(component);
        public bool Remove(Surface component) => surfaces.Remove(component);

        public void Clear()
        {
            reflections.Clear();
            surfaces.Clear();
        }

        public IEnumerable<global::Celeste.Graphics.Display.ImagePlacement> SourceImages()
        {
            // 原 BeforeRender 原地排序；保留上次排序后的同深度组件顺序作为下次输入。
            reflections.Sort((a, b) => unchecked(b.Depth() - a.Depth()));
            foreach (var component in reflections)
            {
                if (!(component.OwnerVisible() || component.IgnoreEntityVisible()) || !component.Visible()) continue;
                component.SetIsRendering(true);
                foreach (var image in component.RenderImages()) yield return image;
                component.SetIsRendering(false);
            }
        }

        public IEnumerable<global::Celeste.Graphics.Display.ImagePlacement> MaskImages()
        {
            // 原版只判断组件 Visible，与镜子实体自身 Visible 无关。
            foreach (var component in surfaces)
                if (component.Visible() && component.RenderImages != null)
                    foreach (var image in component.RenderImages())
                        yield return image;
        }
    }
}
