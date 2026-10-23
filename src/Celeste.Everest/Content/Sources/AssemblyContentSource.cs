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
            var names = resources.GetManifestResourceNames();
            for (var index = 0; index < names.Length; index++)
            {
                var text = names[index];
                var contentIndex = text.IndexOf("Content");
                if (contentIndex >= 0)
                {
                    text = text.Substring(contentIndex + 8);
                    Add(text, new AssemblyContentAsset(this, names[index]));
                }
            }
        }

        internal Stream OpenResource(string name)
        {
            return resources.GetManifestResourceStream(name);
        }

        private sealed class ActualAssemblyResources : ISourceAssemblyContentResources
        {
            private readonly Assembly assembly;
            public string AssemblyName => assembly.GetName().Name;

            internal ActualAssemblyResources(Assembly assembly)
            {
                this.assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
            }

            public string[] GetManifestResourceNames()
            {
                return assembly.GetManifestResourceNames();
            }

            public Stream GetManifestResourceStream(string resourceName)
            {
                return assembly.GetManifestResourceStream(resourceName);
            }
        }
    }
}
