using System.IO;
using System.Numerics;
using System.Xml;
using Celeste.Core.IO;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Core.Serialization.Xml;
using Celeste.Game.Execution.Session;
using Celeste.Graphics.Geometry.ThreeD.Camera;

namespace Celeste.Game.Presentation.Mountain.Views
{
    public sealed class OriginalMountainViewsProcess
    {
        private readonly ISourceEngineContext engine;
        public OriginalMountainViewsProcess(ISourceEngineContext engine) => this.engine = engine;

        public void ReloadMountainViews()
        {
            string path = Path.Combine(((ISourceContentDirectoryEnvironment)engine).ContentDirectory,
                "Overworld", "AreaViews.xml");
            XmlDocument document = engine is ISourceXmlDocumentLoadingEnvironment environment
                                   && environment.XmlDocumentLoading is OriginalXmlDocumentLoadingPolicy policy
                ? policy.Load(path)
                : SourceXmlDocuments.LoadXml(path);
            foreach (XmlElement item in document["Views"])
            {
                int index = item.AttrInt("id");
                if (index >= 0 && index < ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas.Count)
                {
                    Vector3 position = item["Idle"].AttrVector3("position");
                    Vector3 target = item["Idle"].AttrVector3("target");
                    ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[index].MountainIdle =
                        new MountainCameraState(position, target, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                    position = item["Select"].AttrVector3("position");
                    target = item["Select"].AttrVector3("target");
                    ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[index].MountainSelect =
                        new MountainCameraState(position, target, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                    position = item["Zoom"].AttrVector3("position");
                    target = item["Zoom"].AttrVector3("target");
                    ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[index].MountainZoom =
                        new MountainCameraState(position, target, ((ISourceVectorEnvironment)engine).VectorArithmetic);
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
