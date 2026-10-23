using System.IO;
using System.Xml;
using Celeste.Core.IO;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Core.Serialization.Xml;
using Celeste.Game.Execution.Session;

namespace Celeste.Game.Presentation.Mountain.Views
{
    public sealed class OriginalMountainViewsProcess
    {
        private readonly ISourceEngineContext engine;

        public OriginalMountainViewsProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public void ReloadMountainViews()
        {
            var path = Path.Combine(((ISourceContentDirectoryEnvironment)engine).ContentDirectory,
                "Overworld", "AreaViews.xml");
            var document = engine is ISourceXmlDocumentLoadingEnvironment environment
                           && environment.XmlDocumentLoading is OriginalXmlDocumentLoadingPolicy policy
                ? policy.Load(path)
                : SourceXmlDocuments.LoadXml(path);
            foreach (XmlElement item in document["Views"])
            {
                var index = item.AttrInt("id");
                if (index >= 0 && index < ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Count)
                {
                    var position = item["Idle"].AttrVector3("position");
                    var target = item["Idle"].AttrVector3("target");
                    ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[index].MountainIdle =
                        new(position, target, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                    position = item["Select"].AttrVector3("position");
                    target = item["Select"].AttrVector3("target");
                    ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[index].MountainSelect =
                        new(position, target, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                    position = item["Zoom"].AttrVector3("position");
                    target = item["Zoom"].AttrVector3("target");
                    ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[index].MountainZoom =
                        new(position, target, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                    if (item["Cursor"] != null)
                        ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[index].MountainCursor =
                            item["Cursor"].AttrVector3("position");
                    ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[index].MountainState =
                        item.AttrInt("state", 0);
                }
            }
        }
    }
}
