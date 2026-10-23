using System;
using System.Collections.Generic;
using System.IO;
using Celeste.Core.Framework.Loading;
using Celeste.Core.IO.Content;
using Celeste.Core.IO.Content.Manifests;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Threading;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Content.Loading
{
    public sealed class OriginalChapterPreparationProcess
    {
        private readonly ResidentContentSource source;
        private readonly OriginalGameThreadSession threads;
        private readonly IOriginalAreaDataResolver areas;
        private readonly OriginalGameGraphicsResources graphics;
        private readonly HashSet<string> prepared = new(StringComparer.Ordinal);
        private readonly HashSet<string> pending = new(StringComparer.Ordinal);

        public OriginalChapterPreparationProcess(ResidentContentSource source, OriginalGameThreadSession threads,
            IOriginalAreaDataResolver areas, OriginalGameGraphicsResources graphics)
        {
            this.source = source ?? throw new ArgumentNullException(nameof(source));
            this.threads = threads ?? throw new ArgumentNullException(nameof(threads));
            this.areas = areas ?? throw new ArgumentNullException(nameof(areas));
            this.graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            if (!threads.SupportsContentPreparation)
                throw new ArgumentException("Chapter preparation requires contextual owner loading.", nameof(threads));
        }

        public void PrepareArea(int areaId, int mode = 0)
            => Prepare(CreateContext(areaId, mode, areas.Get(areaId).GetOriginalMode(mode).Path));

        public void PrepareSession(ChapterCompletionSession session)
            => Prepare(CreateContext(session.AreaID, session.Mode, ((OriginalChapterMapData)session.MapData).Filename));

        private void Prepare(OriginalChapterPreparationContext context)
        {
            if (prepared.Contains(context.ChapterGroup) || !pending.Add(context.ChapterGroup)) return;
            threads.Start(() =>
            {
                prepared.Add(context.ChapterGroup);
                pending.Remove(context.ChapterGroup);
            }, new SourceLoadingWorkInfo("CHAPTER_PREPARATION", context, true), true);
        }

        public void RequirePreparedEntry(ChapterCompletionSession session)
        {
            var context = CreateContext(session.AreaID, session.Mode,
                ((OriginalChapterMapData)session.MapData).Filename);
            if (!prepared.Contains(context.ChapterGroup))
                throw new InvalidOperationException("Prepare the selected chapter before its original entry route: " +
                                                    context.MapPath);
        }

        public SourceLoadingWorkInfo CreateWorkInfo(ChapterCompletionSession session, string name)
            => new(name, CreateContext(session.AreaID, session.Mode,
                ((OriginalChapterMapData)session.MapData).Filename), true);

        private OriginalChapterPreparationContext CreateContext(int areaId, int mode, string mapFilename)
        {
            string mapPath = "Maps/" + mapFilename + ".bin";
            ContentGroupInfo selected = null;
            foreach (var group in source.Manifest.Groups)
            {
                if (!group.Id.StartsWith("chapters/", StringComparison.Ordinal)) continue;
                foreach (string file in group.Files)
                    if (file == mapPath)
                    {
                        if (selected != null)
                            throw new InvalidDataException("The original map belongs to multiple chapter groups: " +
                                                           mapPath);
                        selected = group;
                    }
            }

            if (selected == null)
                throw new InvalidDataException("The original map has no chapter content group: " + mapPath);
            string completionName = areas.Get(areaId).CompleteScreenName;
            string completionAtlas = completionName == null
                ? null
                : graphics.CompleteScreensXml["Screens"][completionName]?.GetAttribute("atlas");
            string[] groups = { "gameplay/common", "portraits", selected.Id };
            var required = new HashSet<string>(StringComparer.Ordinal);
            foreach (string group in groups)
            foreach (string file in source.Manifest.GetGroupFiles(group))
                required.Add(file);
            if (!string.IsNullOrEmpty(completionAtlas))
            {
                ContentAtlasInfo atlas = null;
                foreach (var candidate in source.Manifest.Atlases)
                    if (candidate.Name == completionAtlas)
                        atlas = candidate;
                if (atlas == null || !required.Contains(atlas.Metadata))
                    throw new InvalidDataException("Chapter content omits its original completion atlas: " +
                                                   completionAtlas);
                foreach (string page in atlas.Pages)
                    if (!required.Contains(page))
                        throw new InvalidDataException("Chapter content omits its completion page: " + page);
            }

            return new OriginalChapterPreparationContext(areaId, mode, mapPath, selected.Id, completionAtlas, groups);
        }
    }
}
