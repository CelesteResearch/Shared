using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Scene.Scenes;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Geometry.ThreeD.Billboards;
using Celeste.Graphics.Geometry.ThreeD.Camera;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Game.Presentation.Mountain.Model
{
    public class MountainState
    {
        public MountainSkybox Skybox;

        public VirtualTexture TerrainTexture;

        public VirtualTexture BuildingsTexture;

        public PackedColor FogColor;

        public MountainState(ISourceEngineContext engine, VirtualTexture terrainTexture,
            VirtualTexture buildingsTexture,
            VirtualTexture skyboxTexture, PackedColor fogColor)
        {
            TerrainTexture = terrainTexture;
            BuildingsTexture = buildingsTexture;
            Skybox = new MountainSkybox(engine, skyboxTexture);
            FogColor = fogColor;
        }
    }
}
