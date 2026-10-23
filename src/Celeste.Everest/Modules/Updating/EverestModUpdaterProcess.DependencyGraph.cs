using System;
using System.Collections.Generic;
using System.Net.Http;
using Celeste.Core.Text;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Updating
{
    public partial class EverestModUpdaterProcess
    {
        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;

        private sealed class DependencyGraphEntry
        {
            public List<EverestModUpdateInfo> Dependencies { get; set; }
            public List<EverestModUpdateInfo> OptionalDependencies { get; set; }
        }

        public Dictionary<string, EverestModuleMetadata> DownloadModDependencyGraph()
        {
            try
            {
                string modUpdaterDatabaseUrl = GetModUpdaterDatabaseUrl("modgraph");
                string text = "ModUpdaterHelper";
                string tag = text;
                SourceDefaultInterpolatedStringHandler str;
                bool shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                str = shouldLog ? new SourceDefaultInterpolatedStringHandler(38, 1) : default;
                if (shouldLog)
                {
                    str.AppendLiteral("Downloading mod dependency graph from ");
                    str.AppendFormatted(modUpdaterDatabaseUrl);
                }

                if (shouldLog) Logger.Log(EverestLogLevel.Verbose, tag, str.ToStringAndClear());
                Dictionary<string, EverestModuleMetadata> dictionary = new Dictionary<string, EverestModuleMetadata>();
                using HttpClient httpClient = ((IEverestCompressedHttpEnvironment)engine).CompressedHttp.CreateClient();
                string result = httpClient.GetStringAsync(modUpdaterDatabaseUrl).Result;
                foreach (KeyValuePair<string, DependencyGraphEntry> item in ((IEverestYamlEnvironment)engine).Yaml
                         .Deserializer.Deserialize<Dictionary<string, DependencyGraphEntry>>(result))
                {
                    EverestModuleMetadata everestModuleMetadata = new EverestModuleMetadata
                    {
                        Name = item.Key
                    };
                    foreach (EverestModUpdateInfo dependency in item.Value.Dependencies)
                    {
                        try
                        {
                            everestModuleMetadata.Dependencies.Add(new EverestModuleMetadata
                            {
                                Name = dependency.Name,
                                VersionString = dependency.Version
                            });
                        }
                        catch (ArgumentException)
                        {
                        }
                    }

                    foreach (EverestModUpdateInfo optionalDependency in item.Value.OptionalDependencies)
                    {
                        try
                        {
                            everestModuleMetadata.OptionalDependencies.Add(new EverestModuleMetadata
                            {
                                Name = optionalDependency.Name,
                                VersionString = optionalDependency.Version
                            });
                        }
                        catch (ArgumentException)
                        {
                        }
                    }

                    dictionary[item.Key] = everestModuleMetadata;
                }

                text = "ModUpdaterHelper";
                string tag2 = text;
                shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                str = shouldLog ? new SourceDefaultInterpolatedStringHandler(19, 1) : default;
                if (shouldLog)
                {
                    str.AppendLiteral("Downloaded ");
                    str.AppendFormatted(dictionary.Count);
                    str.AppendLiteral(" item(s)");
                }

                if (shouldLog) Logger.Log(EverestLogLevel.Verbose, tag2, str.ToStringAndClear());
                return dictionary;
            }
            catch (Exception e)
            {
                Logger.Log(EverestLogLevel.Warn, "ModUpdaterHelper", "Downloading dependency graph failed!");
                Logger.LogDetailed(e);
                return null;
            }
        }
    }
}
