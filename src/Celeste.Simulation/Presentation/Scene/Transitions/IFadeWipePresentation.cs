using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

// PURE PORTS OF the two remaining CS06 cutscenes:
//   Artifacts/Reference/Original/Celeste/CS06_Campfire.cs   (540 lines)
//   Artifacts/Reference/Original/Celeste/CS06_StarJumpEnd.cs (523 lines)
//
// ============================ WHY THESE ARE ONE UNIT ============================
// CS06_StarJumpEnd's ONLY construction site is CS06_Campfire.OnEnd (CS06_Campfire.cs:484):
// a grep of CS06_StarJumpEnd over the whole reference tree returns exactly three lines - the
// class declaration (:9), its own ctor (:59) and that one `level.Add(...)`. It has no map id, no
// trigger and no Level.cs dispatch case. It overrides `Added` WITHOUT calling `base.Added`
// (CS06_StarJumpEnd.cs:69-74), so `CutsceneEntity.Start()` never fires from the add; its
// `OnBegin` is reached only from its own `Update` once
// `player.Y <= Level.Bounds.Top + 160` (CS06_StarJumpEnd.cs:79-83) - a threshold the player can
// only cross by riding the `FlyFeather` that the SAME `Campfire.OnEnd` adds at :485.
//
// A "Campfire-only" port would therefore be WORSE than the status quo: it would leave the player
// standing at the campfire with Session.Dreaming = true, a live StarJumpController and an orphan
// feather, and no cutscene to carry them out. So both live in this file and the host wires them
// through one request plus one internal construction.
//
// Original -> here:
//   CS06_Campfire.cs:215-258  ctor (theo, player) + 16 Questions + 2 nodes -> CS06CampfireChat
//   CS06_Campfire.cs:260-289  OnBegin                                    -> CS06CampfireSequence.Added()
//   CS06_Campfire.cs:291-298  PlayerLightApproach                        -> PlayerLightApproach()
//   CS06_Campfire.cs:300-417  Cutscene                                   -> Cutscene()
//   CS06_Campfire.cs:419-422  WaitABit                                   -> WaitABit()
//   CS06_Campfire.cs:424-455  SelfieSequence                             -> SelfieSequence()
//   CS06_Campfire.cs:457-460  BeerSequence                               -> BeerSequence()
//   CS06_Campfire.cs:462-505  OnEnd                                      -> OnEnd()
//   CS06_Campfire.cs:507-511  SetBloom                                   -> SetBloom()
//   CS06_StarJumpEnd.cs:59-67  ctor                                      -> CS06StarJumpEndSequence ctor
//   CS06_StarJumpEnd.cs:69-74  Added (NO base call)                       -> Added()
//   CS06_StarJumpEnd.cs:76-98  Update (the waiting gate)                  -> Update()
//   CS06_StarJumpEnd.cs:100-103 OnBegin                                   -> OnBegin()
//   CS06_StarJumpEnd.cs:105-276 Cutscene                                  -> Cutscene()
//   CS06_StarJumpEnd.cs:278-285 SetMusicLayer                             -> SetMusicLayer()
//   CS06_StarJumpEnd.cs:287-467 the eight Say callbacks + SpinCharacters   -> as named
//   CS06_StarJumpEnd.cs:469-516 OnEnd                                     -> OnEnd()
//   CS06_StarJumpEnd.cs:518-522 SetBloom                                  -> SetBloom()
namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    // CS06_Campfire.cs:324-329,:341,:342,:413-415,:467-473 and CS06_StarJumpEnd.cs:256-265.
    // The original's FadeWipe is a Scene entity that updates itself and runs an OnComplete; the
    // port's FadeWipePresentation (PortalWipePresentation.cs:6) is the same object, so this
    // interface is the thin view CS06 needs: the two timers, the progress, Wait(), and the
    // OnUpdate hook CS06_Campfire.OnEnd uses to drive its zoom-back coroutine.
    public interface IFadeWipePresentation
    {
        float Duration { get; set; }
        float EndTimer { get; set; }
        float Percent { get; }

        IEnumerator Wait();

        // CS06_Campfire.cs:470-473 `fadeWipe.OnUpdate = () => zoom.Update()`.
        // FadeWipePresentation.OnUpdate is `Action<float>` (PortalWipePresentation.cs:8) and is
        // invoked with Percent each update; the parameter is ignored by the original's lambda.
        Action<float> OnUpdate { get; set; }
    }
}
