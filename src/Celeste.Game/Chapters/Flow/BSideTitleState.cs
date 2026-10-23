using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Credits;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Gui;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text;
using Celeste.Scene.Entities;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public sealed class BSideTitleState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly string title;
        private readonly string musicBy;
        private readonly string artist;
        private readonly AtlasEntry artistImage;
        private readonly string album;
        private readonly float musicByWidth;
        private readonly float[] fade;
        private readonly float[] offsets;
        private float offset;
        private IOriginalAreaKeyPolicy Areas => ((IOriginalAreaKeyEnvironment)engine).AreaKeys;
        private ActiveBitmapFont Font => ((IOriginalGameTextEnvironment)engine).Text.ActiveFont;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public BSideTitleState(ChapterCompletionSession session, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            this.engine = engine;
            var dialog = ((IOriginalGameTextEnvironment)engine).Text.Dialog;
            var installed =
                ((IGameProfileEnvironment)engine)
                .SourceProfile == GameProfile
                    .InstalledEverest;
            IOriginalAreaData area = null;
            if (installed)
            {
                area = Areas.GetArea(Areas.GetSessionArea(session));
                artist = dialog.Get(area.Name + "_remix_artist");
            }

            fade = new float[3];
            offsets = new float[3];
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            switch (session.AreaID)
            {
                case 1: artist = ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess.Remixers[0]; break;
                case 2: artist = ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess.Remixers[1]; break;
                case 3: artist = ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess.Remixers[2]; break;
                case 4: artist = ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess.Remixers[3]; break;
                case 5: artist = ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess.Remixers[4]; break;
                case 6: artist = ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess.Remixers[5]; break;
                case 7: artist = ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess.Remixers[6]; break;
                case 9: artist = ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess.Remixers[7]; break;
            }

            if (artist.StartsWith("image:"))
                artistImage = ((ISourceGuiAtlasResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .GuiAtlas.Entries[artist.Substring(6)];
            title = dialog.Get(Areas.GetArea(Areas.GetSessionArea(session)).Name) + " " +
                    dialog.Get(Areas.GetArea(Areas.GetSessionArea(session)).Name + "_remix");
            musicBy = dialog.Get("remix_by") + " ";
            musicByWidth = Font.Measure(musicBy).X;
            album = dialog.Get("remix_album");
            if (installed && (string.IsNullOrEmpty(album) || dialog.Has(area.Name + "_remix_album")))
                album = dialog.Get(area.Name + "_remix_album");
        }

        public IEnumerator EaseIn()
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0, 1f, 1f)));
            yield return .2f;
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(1, 1f, 1f)));
            yield return .2f;
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(2, 1f, 1f)));
            yield return 1.8f;
        }

        public IEnumerator EaseOut()
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0, 0f, 1f)));
            yield return .2f;
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(1, 0f, 1f)));
            yield return .2f;
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(2, 0f, 1f)));
            yield return 1f;
        }

        private IEnumerator FadeTo(int index, float target, float duration)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while ((fade[index] = ScalarMath.Approach(fade[index], target, engine.DeltaTime / duration,
                       ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)) != target)
            {
                if (target == 0f) offsets[index] = Easing.CubeIn(1f - fade[index]) * 32f;
                else offsets[index] = (0f - Easing.CubeIn(1f - fade[index])) * 32f;
                yield return null;
            }
        }

        public override void Update()
        {
            base.Update();
            offset += engine.DeltaTime * 32f;
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = new Vector2(60f + offset, 800f);
            Font.Draw(context, this, title, position + new Vector2(offsets[0], 0f), Vector2.Zero, Vector2.One,
                PackedColor.White * fade[0]);
            Font.Draw(context, this, musicBy, position + new Vector2(offsets[1], 60f), Vector2.Zero, Vector2.One,
                PackedColor.White * fade[1]);
            if (artistImage != null)
            {
                var draw = new AtlasTextureDraw(artistImage, position + new Vector2(musicByWidth + offsets[1], 68f),
                    Vector2.Zero, PackedColor.White * fade[1], Vector2.One);
                ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, this);
            }
            else
            {
                Font.Draw(context, this, artist, position + new Vector2(musicByWidth + offsets[1], 60f), Vector2.Zero,
                    Vector2.One, PackedColor.White * fade[1]);
            }

            Font.Draw(context, this, album, position + new Vector2(offsets[2], 120f), Vector2.Zero, Vector2.One,
                PackedColor.White * fade[2]);
        }
    }
}
