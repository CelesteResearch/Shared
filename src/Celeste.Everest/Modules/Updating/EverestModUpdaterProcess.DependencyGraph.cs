using System;
using System.Collections.Generic;
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
                var modUpdaterDatabaseUrl = GetModUpdaterDatabaseUrl("modgraph");
                var text = "ModUpdaterHelper";
                var tag = text;
                SourceDefaultInterpolatedStringHandler str;
                var shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                str = shouldLog ? new SourceDefaultInterpolatedStringHandler(38, 1) : default;
                if (shouldLog)
                {
                    str.AppendLiteral("Downloading mod dependency graph from ");
                    str.AppendFormatted(modUpdaterDatabaseUrl);
                }

                if (shouldLog) Logger.Log(EverestLogLevel.Verbose, tag, str.ToStringAndClear());
                var dictionary = new Dictionary<string, EverestModuleMetadata>();
                using var httpClient = ((IEverestCompressedHttpEnvironment)engine).CompressedHttp.CreateClient();
                var result = httpClient.GetStringAsync(modUpdaterDatabaseUrl).Result;
                foreach (var item in ((IEverestYamlEnvironment)engine).Yaml
                         .Deserializer.Deserialize<Dictionary<string, DependencyGraphEntry>>(result))
                {
                    var everestModuleMetadata = new EverestModuleMetadata
                    {
                        Name = item.Key,
                    };
                    foreach (var dependency in item.Value.Dependencies)
                        try
                        {
                            everestModuleMetadata.Dependencies.Add(new()
                            {
                                Name = dependency.Name,
                                VersionString = dependency.Version,
                            });
                        }
                        catch (ArgumentException)
                        {
                        }

                    foreach (var optionalDependency in item.Value.OptionalDependencies)
                        try
                        {
                            everestModuleMetadata.OptionalDependencies.Add(new()
                            {
                                Name = optionalDependency.Name,
                                VersionString = optionalDependency.Version,
                            });
                        }
                        catch (ArgumentException)
                        {
                        }

                    dictionary[item.Key] = everestModuleMetadata;
                }

                text = "ModUpdaterHelper";
                var tag2 = text;
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
