using Celeste.Core.Rendering.Renderers;
using System;
using System.Collections.Generic;

namespace Celeste.Scene.Rendering
{
    public class SceneRendererList
    {
        public List<ISceneRenderer> Renderers;

        private List<ISceneRenderer> adding;

        private List<ISceneRenderer> removing;

        private object scene;
        private Action<ISceneRenderer> rendererSelected;

        public SceneRendererList(object scene, Action<ISceneRenderer> rendererSelected = null)
        {
            this.scene = scene;
            this.rendererSelected = rendererSelected;
            Renderers = new List<ISceneRenderer>();
            adding = new List<ISceneRenderer>();
            removing = new List<ISceneRenderer>();
        }

        public void UpdateLists()
        {
            if (adding.Count > 0)
            {
                foreach (ISceneRenderer item in adding)
                {
                    Renderers.Add(item);
                }
            }

            adding.Clear();
            if (removing.Count > 0)
            {
                foreach (ISceneRenderer item2 in removing)
                {
                    Renderers.Remove(item2);
                }
            }

            removing.Clear();
        }

        public void Update()
        {
            foreach (ISceneRenderer renderer in Renderers)
            {
                renderer.Update(scene);
            }
        }

        public void BeforeRender()
        {
            for (int i = 0; i < Renderers.Count; i++)
            {
                if (Renderers[i].Visible)
                {
                    rendererSelected?.Invoke(Renderers[i]);
                    Renderers[i].BeforeRender(scene);
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < Renderers.Count; i++)
            {
                if (Renderers[i].Visible)
                {
                    rendererSelected?.Invoke(Renderers[i]);
                    Renderers[i].Render(scene);
                }
            }
        }

        public void AfterRender()
        {
            for (int i = 0; i < Renderers.Count; i++)
            {
                if (Renderers[i].Visible)
                {
                    rendererSelected?.Invoke(Renderers[i]);
                    Renderers[i].AfterRender(scene);
                }
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
