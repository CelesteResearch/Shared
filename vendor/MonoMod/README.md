# MonoMod.Utils

Source: MonoMod 25.0.14, commit a74a1cf0d15c5e82dfa6ef8bbe7a131b60bed3fd.
Upstream: https://github.com/MonoMod/MonoMod
License: LICENSE in this directory.

Only the Utils project, its internal source generator, shared sources and required build files are included. Utils targets the same netstandard2.1 asset as the previously referenced NuGet package. Core, RuntimeDetour, Backports, ILHelpers and Cecil remain at their existing package versions.

Local changes:

- ILGeneratorProxy is loaded in the actual MonoMod.Utils assembly's CoreCLR context, keeping its generic constraint and target type identities equal. Mono preserves the original loader.
- First proxy generation is synchronized; cached calls do not take the lock.
- Public ReflectionHelper.Load methods retain their original independent assembly loading semantics.
- Utils project version is fixed at 25.0.14 so all consumers resolve this single project instead of another package copy.
- The internal source generator is a Roslyn compiler component. It stays in the solution but is excluded from engine runtime publication with its compiler dependencies.

Build through CelesteShared.slnx. The engines consume the resulting DLL through their existing shared assembly synchronization tools.
