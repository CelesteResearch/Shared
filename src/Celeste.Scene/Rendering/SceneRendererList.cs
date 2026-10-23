using System;
using System.Collections.Generic;
using Celeste.Core.Rendering.Renderers;

namespace Celeste.Scene.Rendering
{
    public class SceneRendererList
    {
        public List<ISceneRenderer> Renderers;

        private readonly List<ISceneRenderer> adding;

        private readonly List<ISceneRenderer> removing;

        private readonly object scene;
        private readonly Action<ISceneRenderer> rendererSelected;

        public SceneRendererList(object scene, Action<ISceneRenderer> rendererSelected = null)
        {
            this.scene = scene;
            this.rendererSelected = rendererSelected;
            Renderers = [];
            adding = [];
            removing = [];
        }

        public void UpdateLists()
        {
            if (adding.Count > 0)
                foreach (var item in adding)
                    Renderers.Add(item);

            adding.Clear();
            if (removing.Count > 0)
                foreach (var item2 in removing)
                    Renderers.Remove(item2);

            removing.Clear();
        }

        public void Update()
        {
            foreach (var renderer in Renderers) renderer.Update(scene);
        }

        public void BeforeRender()
        {
            for (var i = 0; i < Renderers.Count; i++)
                if (Renderers[i].Visible)
                {
                    rendererSelected?.Invoke(Renderers[i]);
                    Renderers[i].BeforeRender(scene);
                }
        }

        public void Render()
        {
            for (var i = 0; i < Renderers.Count; i++)
                if (Renderers[i].Visible)
                {
                    rendererSelected?.Invoke(Renderers[i]);
                    Renderers[i].Render(scene);
                }
        }

        public void AfterRender()
        {
            for (var i = 0; i < Renderers.Count; i++)
                if (Renderers[i].Visible)
                {
                    rendererSelected?.Invoke(Renderers[i]);
                    Renderers[i].AfterRender(scene);
                }
        }

        public void MoveToFront(ISceneRenderer renderer)
        {
            Renderers.Remove(renderer);
            Renderers.Add(renderer);
        }

        public void Add(ISceneRenderer renderer)
        {
            adding.Add(renderer);
        }

        public void Remove(ISceneRenderer renderer)
        {
            removing.Add(renderer);
        }
    }
}
