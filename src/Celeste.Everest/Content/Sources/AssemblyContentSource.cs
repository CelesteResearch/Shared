using System;
using System.IO;
using System.Reflection;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;

namespace Celeste.Everest.Content.Sources
{
    public class AssemblyContentSource : EverestContentSource
    {
        public readonly Assembly Assembly;
        private readonly ISourceAssemblyContentResources resources;
        public override string DefaultName => resources.AssemblyName;

        public AssemblyContentSource(EverestContentRegistry registry, Assembly assembly)
            : this(registry, assembly, new ActualAssemblyResources(assembly))
        {
        }

        public AssemblyContentSource(EverestContentRegistry registry, Assembly assembly,
            ISourceAssemblyContentResources resources) : base(registry)
        {
            Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
            this.resources = resources ?? throw new ArgumentNullException(nameof(resources));
        }

        protected override void Crawl()
        {
            string[] names = resources.GetManifestResourceNames();
            for (int index = 0; index < names.Length; index++)
            {
                string text = names[index];
                int contentIndex = text.IndexOf("Content");
                if (contentIndex >= 0)
                {
                    text = text.Substring(contentIndex + 8);
                    Add(text, new AssemblyContentAsset(this, names[index]));
                }
            }
        }

        internal Stream OpenResource(string name) => resources.GetManifestResourceStream(name);

        private sealed class ActualAssemblyResources : ISourceAssemblyContentResources
        {
            private readonly Assembly assembly;
            public string AssemblyName => assembly.GetName().Name;

            internal ActualAssemblyResources(Assembly assembly)
                => this.assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));

            public string[] GetManifestResourceNames() => assembly.GetManifestResourceNames();

            public Stream GetManifestResourceStream(string resourceName) =>
                assembly.GetManifestResourceStream(resourceName);
        }
    }
}
