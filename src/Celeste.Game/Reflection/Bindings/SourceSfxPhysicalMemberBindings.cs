using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Audio;

namespace Celeste.Game.Reflection.Bindings
{
    public static class SourceSfxPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog, OriginalSfxProcess source, string assemblyIdentity)
        {
            if (catalog == null) throw new ArgumentNullException(nameof(catalog));
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (!catalog.ContainsSourceType(typeof(OriginalSfxProcess)))
                catalog.RegisterSourceType(typeof(OriginalSfxProcess), assemblyIdentity, "Celeste.SFX");
            var definition = catalog.GetOriginalTypeDefinition(typeof(OriginalSfxProcess));
            if (definition.AssemblyIdentity != assemblyIdentity || definition.Identity != "Celeste.SFX")
                throw new InvalidOperationException("The actual SFX owner has a different original type identity.");
            RegisterFields0(catalog, source, assemblyIdentity);
            RegisterFields1(catalog, source, assemblyIdentity);
            RegisterFields2(catalog, source, assemblyIdentity);
            RegisterFields3(catalog, source, assemblyIdentity);
            RegisterFields4(catalog, source, assemblyIdentity);
            RegisterFields5(catalog, source, assemblyIdentity);
            RegisterFields6(catalog, source, assemblyIdentity);
            RegisterFields7(catalog, source, assemblyIdentity);
            RegisterFields8(catalog, source, assemblyIdentity);
            RegisterFields9(catalog, source, assemblyIdentity);
            RegisterFields10(catalog, source, assemblyIdentity);
            RegisterFields11(catalog, source, assemblyIdentity);
            RegisterFields12(catalog, source, assemblyIdentity);
        }

        private static void RegisterFields0(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "NONE");
            RegisterField(catalog, source, assemblyIdentity, "music_levelselect");
            RegisterField(catalog, source, assemblyIdentity, "music_credits");
            RegisterField(catalog, source, assemblyIdentity, "music_complete_area");
            RegisterField(catalog, source, assemblyIdentity, "music_complete_summit");
            RegisterField(catalog, source, assemblyIdentity, "music_complete_bside");
            RegisterField(catalog, source, assemblyIdentity, "music_prologue_intro_vignette");
            RegisterField(catalog, source, assemblyIdentity, "music_prologue_beginning");
            RegisterField(catalog, source, assemblyIdentity, "music_prologue_collapse");
            RegisterField(catalog, source, assemblyIdentity, "music_prologue_title_ping");
            RegisterField(catalog, source, assemblyIdentity, "music_city");
            RegisterField(catalog, source, assemblyIdentity, "music_city_theo");
            RegisterField(catalog, source, assemblyIdentity, "music_oldsite_beginning");
            RegisterField(catalog, source, assemblyIdentity, "music_oldsite_mirror");
            RegisterField(catalog, source, assemblyIdentity, "music_oldsite_dreamblock_sting_pt1");
            RegisterField(catalog, source, assemblyIdentity, "music_oldsite_dreamblock_sting_pt2");
            RegisterField(catalog, source, assemblyIdentity, "music_oldsite_evil_maddy");
            RegisterField(catalog, source, assemblyIdentity, "music_oldsite_chase");
            RegisterField(catalog, source, assemblyIdentity, "music_oldsite_payphone_loop");
            RegisterField(catalog, source, assemblyIdentity, "music_oldsite_payphone_end");
            RegisterField(catalog, source, assemblyIdentity, "music_oldsite_awake");
            RegisterField(catalog, source, assemblyIdentity, "music_resort_intro");
            RegisterField(catalog, source, assemblyIdentity, "music_resort_explore");
            RegisterField(catalog, source, assemblyIdentity, "music_resort_clean");
            RegisterField(catalog, source, assemblyIdentity, "music_resort_clean_extended");
            RegisterField(catalog, source, assemblyIdentity, "music_resort_oshiro_theme");
            RegisterField(catalog, source, assemblyIdentity, "music_resort_oshiro_chase");
            RegisterField(catalog, source, assemblyIdentity, "music_cliffside_main");
            RegisterField(catalog, source, assemblyIdentity, "music_cliffside_heavywinds");
            RegisterField(catalog, source, assemblyIdentity, "music_cliffside_panicattack");
            RegisterField(catalog, source, assemblyIdentity, "music_temple_normal");
            RegisterField(catalog, source, assemblyIdentity, "music_temple_middle");
            RegisterField(catalog, source, assemblyIdentity, "music_temple_mirror");
            RegisterField(catalog, source, assemblyIdentity, "music_temple_mirrorcutscene");
            RegisterField(catalog, source, assemblyIdentity, "music_reflection_maddietheo");
            RegisterField(catalog, source, assemblyIdentity, "music_reflection_starjump");
            RegisterField(catalog, source, assemblyIdentity, "music_reflection_fall");
            RegisterField(catalog, source, assemblyIdentity, "music_reflection_fight");
            RegisterField(catalog, source, assemblyIdentity, "music_reflection_fight_glitch");
            RegisterField(catalog, source, assemblyIdentity, "music_reflection_fight_finish");
            RegisterField(catalog, source, assemblyIdentity, "music_reflection_main");
            RegisterField(catalog, source, assemblyIdentity, "music_reflection_secretroom");
            RegisterField(catalog, source, assemblyIdentity, "music_summit_main");
            RegisterField(catalog, source, assemblyIdentity, "music_summit_finalascent");
            RegisterField(catalog, source, assemblyIdentity, "music_epilogue_main");
            RegisterField(catalog, source, assemblyIdentity, "music_core_main");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_part01");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_part02");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_part03");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_intermission_heartgroove");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_intermission_powerpoint");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_reconciliation");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_cassette");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_final_run");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_end_cinematic");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_end_cinematic_intro");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_firstbirdcrash_cinematic");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_secondbirdcrash_cinematic");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_granny");
            RegisterField(catalog, source, assemblyIdentity, "music_farewell_golden_room");
            RegisterField(catalog, source, assemblyIdentity, "music_pico8_title");
            RegisterField(catalog, source, assemblyIdentity, "music_pico8_area1");
            RegisterField(catalog, source, assemblyIdentity, "music_pico8_area2");
            RegisterField(catalog, source, assemblyIdentity, "music_pico8_area3");
        }

        private static void RegisterFields1(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "music_pico8_wind");
            RegisterField(catalog, source, assemblyIdentity, "music_pico8_end");
            RegisterField(catalog, source, assemblyIdentity, "music_pico8_boot");
            RegisterField(catalog, source, assemblyIdentity, "music_rmx_01_forsaken_city");
            RegisterField(catalog, source, assemblyIdentity, "music_rmx_02_old_site");
            RegisterField(catalog, source, assemblyIdentity, "music_rmx_03_resort");
            RegisterField(catalog, source, assemblyIdentity, "music_rmx_04_cliffside");
            RegisterField(catalog, source, assemblyIdentity, "music_rmx_05_mirror_temple");
            RegisterField(catalog, source, assemblyIdentity, "music_rmx_06_reflection");
            RegisterField(catalog, source, assemblyIdentity, "music_rmx_07_summit");
            RegisterField(catalog, source, assemblyIdentity, "music_rmx_09_core");
            RegisterField(catalog, source, assemblyIdentity, "cas_01_forsaken_city");
            RegisterField(catalog, source, assemblyIdentity, "cas_02_old_site");
            RegisterField(catalog, source, assemblyIdentity, "cas_03_resort");
            RegisterField(catalog, source, assemblyIdentity, "cas_04_cliffside");
            RegisterField(catalog, source, assemblyIdentity, "cas_05_mirror_temple");
            RegisterField(catalog, source, assemblyIdentity, "cas_06_reflection");
            RegisterField(catalog, source, assemblyIdentity, "cas_07_summit");
            RegisterField(catalog, source, assemblyIdentity, "cas_08_core");
            RegisterField(catalog, source, assemblyIdentity, "dialog_prefix");
            RegisterField(catalog, source, assemblyIdentity, "dialog_phone_static_ex");
            RegisterField(catalog, source, assemblyIdentity, "dialog_phone_static_mom");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_footstep");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_land");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_assisted");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_wall_right");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_wall_left");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_climb_left");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_climb_right");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_super");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_superwall");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_superslide");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_special");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_jump_dreamblock");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_grab");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_grab_letgo");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_handhold");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_wallslide");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_duck");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_stand");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_climb_loop");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_climb_ledge");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_dash_red_left");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_dash_red_right");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_dash_pink_left");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_dash_pink_right");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_core_haircharged");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_predeath");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_death");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_death_golden");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_revive");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_campfire_sit");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_campfire_stand");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_dreamblock_enter");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_dreamblock_travel");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_dreamblock_exit");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_mirrortemple_landing");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_crystaltheo_lift");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_crystaltheo_throw");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_theo_collapse");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_summit_flytonext");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_summit_areastart");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_summit_sit");
        }

        private static void RegisterFields2(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "char_mad_idle_scratch");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_idle_sneeze");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_idle_crackknuckles");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_backpack_drop");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_screenentry_lowgrav");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_screenentry_stubborn");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_screenentry_golden");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_screenentry_gran");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_screenentry_gran_landing");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_glider_drop");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_bounce_boost");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_water_in");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_water_out");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_water_dash_in");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_water_dash_out");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_water_dash_gen");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_water_move_shallow");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_water_move_general");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_energy_out_loop");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_energy_recharged");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_hiccup_standing");
            RegisterField(catalog, source, assemblyIdentity, "char_mad_hiccup_ducking");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_yolofist");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_phonetaps_loop");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_vent_tug");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_vent_grab");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_vent_rip");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_vent_tumble");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_standtocrawl");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_crawl");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_ceilingvent_shake");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_ceilingvent_popoff");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_ceilingvent_hey");
            RegisterField(catalog, source, assemblyIdentity, "char_theo_resort_ceilingvent_seeya");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_appear");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_disappear");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_level_entry");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_footstep");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_land");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_grab");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_handhold");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_wallslide");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_grab_letgo");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_assisted");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_wall_left");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_wall_right");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_climb_left");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_climb_right");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_duck");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_stand");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_climb_ledge");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_dash_red_left");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_dash_red_right");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_dreamblock");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_dreamblock_enter");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_dreamblock_travel");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_dreamblock_exit");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_super");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_superwall");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_superslide");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_jump_special");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_temple_move_first");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_temple_move_chats");
        }

        private static void RegisterFields3(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "char_bad_boss_prefightgetup");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_boss_hug");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_boss_idle_air");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_boss_idle_ground_loop");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_boss_bullet");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_boss_laser_charge");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_boss_laser_fire");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_booster_begin");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_booster_throw");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_booster_relocate");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_booster_reappear");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_booster_final");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_maddy_join");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_maddy_split");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_maddy_join_quick");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_booster_first_appear");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_booster_relocate_slow");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_booster_finalfinal_part1");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_booster_finalfinal_part2");
            RegisterField(catalog, source, assemblyIdentity, "char_bad_birdscene_float");
            RegisterField(catalog, source, assemblyIdentity, "char_gran_laugh_firstphrase");
            RegisterField(catalog, source, assemblyIdentity, "char_gran_laugh_oneha");
            RegisterField(catalog, source, assemblyIdentity, "char_gran_cane_tap");
            RegisterField(catalog, source, assemblyIdentity, "char_gran_dissipate");
            RegisterField(catalog, source, assemblyIdentity, "char_gran_cane_tap_ending");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_chat_turn_right");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_chat_turn_left");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_chat_collapse");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_chat_getup");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_boss_transform_begin");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_boss_transform_burst");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_boss_enterscreen");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_boss_reform");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_boss_precharge");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_boss_charge");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_boss_slam_first");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_boss_slam_final");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_move_01_0xa_exit");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_move_02_03a_exit");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_move_03_08a_exit");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_move_04_pace_right");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_move_04_pace_left");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_move_05_09b_exit");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_move_06_04d_exit");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_move_07_roof00_enter");
            RegisterField(catalog, source, assemblyIdentity, "char_oshiro_move_08_roof07_exit");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_appear");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_disappear");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_jump");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_jump_super");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_dash_left");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_dash_right");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_dreamblock_sequence");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_land");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_grab");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_footstep");
            RegisterField(catalog, source, assemblyIdentity, "char_tutghost_handhold");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_diamond_touch");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_diamond_return");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_strawberry_touch");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_strawberry_blue_touch");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_strawberry_pulse");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_strawberry_blue_pulse");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_strawberry_get");
        }

        private static void RegisterFields4(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "game_gen_strawberry_flyaway");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_strawberry_laugh");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_strawberry_wingflap");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_seed_pulse");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_seed_touch");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_seed_poof");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_seed_reappear");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_seed_complete_main");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_seed_complete_berry");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_key_get");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_lookout_use");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_lookout_move");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_touchswitch_any");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_touchswitch_last_oneshot");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_touchswitch_last_cutoff");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_touchswitch_gate_open");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_touchswitch_gate_finish");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_crystalheart_bounce");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_crystalheart_pulse");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_crystalheart_red_get");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_crystalheart_blue_get");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_crystalheart_gold_get");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_thing_booped");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_cassette_bubblereturn");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_cassette_get");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_cassette_preview");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_spring");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_platform_disintegrate");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_platform_unit_return");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_secret_revealed");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_passageclosedbehind");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_bird_squawk");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_bird_startle");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_bird_in");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_bird_land_dirt");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_bird_peck");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_birdbaby_hop");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_birdbaby_flyaway");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_birdbaby_tweet_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_wallbreak_dirt");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_wallbreak_stone");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_wallbreak_ice");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_wallbreak_wood");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_fallblock_shake");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_fallblock_impact");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_debris_stone");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_debris_wood");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_debris_dirt");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_spotlight_intro");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_spotlight_outro");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_cassetteblock_switch_1");
            RegisterField(catalog, source, assemblyIdentity, "game_gen_cassetteblock_switch_2");
            RegisterField(catalog, source, assemblyIdentity, "game_assist_screenbottom");
            RegisterField(catalog, source, assemblyIdentity, "game_assist_dreamblockbounce");
            RegisterField(catalog, source, assemblyIdentity, "game_assist_nonsolidblock_in");
            RegisterField(catalog, source, assemblyIdentity, "game_assist_nonsolidblock_out");
            RegisterField(catalog, source, assemblyIdentity, "game_assist_dash_aim");
            RegisterField(catalog, source, assemblyIdentity, "game_00_car_down");
            RegisterField(catalog, source, assemblyIdentity, "game_00_car_up");
            RegisterField(catalog, source, assemblyIdentity, "game_00_fallingblock_prologue_shake");
            RegisterField(catalog, source, assemblyIdentity, "game_00_fallingblock_prologue_impact");
            RegisterField(catalog, source, assemblyIdentity, "game_00_bridge_rumble_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_00_bridge_supportbreak");
            RegisterField(catalog, source, assemblyIdentity, "game_01_zipmover");
        }

        private static void RegisterFields5(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "game_01_fallingblock_ice_shake");
            RegisterField(catalog, source, assemblyIdentity, "game_01_fallingblock_ice_impact");
            RegisterField(catalog, source, assemblyIdentity, "game_01_birdbros_fly_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_01_birdbros_thrust");
            RegisterField(catalog, source, assemblyIdentity, "game_01_birdbros_finish");
            RegisterField(catalog, source, assemblyIdentity, "game_01_console_static_short");
            RegisterField(catalog, source, assemblyIdentity, "game_01_console_static_long");
            RegisterField(catalog, source, assemblyIdentity, "game_01_console_static_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_01_console_white");
            RegisterField(catalog, source, assemblyIdentity, "game_01_console_purple");
            RegisterField(catalog, source, assemblyIdentity, "game_01_console_yellow");
            RegisterField(catalog, source, assemblyIdentity, "game_01_console_red");
            RegisterField(catalog, source, assemblyIdentity, "game_01_console_blue");
            RegisterField(catalog, source, assemblyIdentity, "game_02_sequence_mirror");
            RegisterField(catalog, source, assemblyIdentity, "game_02_sequence_badeline_intro");
            RegisterField(catalog, source, assemblyIdentity, "game_02_sequence_phone_pickup");
            RegisterField(catalog, source, assemblyIdentity, "game_02_sequence_phone_transform");
            RegisterField(catalog, source, assemblyIdentity, "game_02_sequence_phone_ring_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_02_sequence_phone_ringtone_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_02_theoselfie_foley");
            RegisterField(catalog, source, assemblyIdentity, "game_02_theoselfie_photo_in");
            RegisterField(catalog, source, assemblyIdentity, "game_02_theoselfie_photo_out");
            RegisterField(catalog, source, assemblyIdentity, "game_02_theoselfie_photo_filter");
            RegisterField(catalog, source, assemblyIdentity, "game_02_lantern_hit");
            RegisterField(catalog, source, assemblyIdentity, "game_03_door_wood_open");
            RegisterField(catalog, source, assemblyIdentity, "game_03_door_wood_close");
            RegisterField(catalog, source, assemblyIdentity, "game_03_fallingblock_wood_shake");
            RegisterField(catalog, source, assemblyIdentity, "game_03_fallingblock_wood_impact");
            RegisterField(catalog, source, assemblyIdentity, "game_03_fallingblock_wood_distantimpact");
            RegisterField(catalog, source, assemblyIdentity, "game_03_door_metal_open");
            RegisterField(catalog, source, assemblyIdentity, "game_03_door_metal_close");
            RegisterField(catalog, source, assemblyIdentity, "game_03_door_trapdoor_fromtop");
            RegisterField(catalog, source, assemblyIdentity, "game_03_door_trapdoor_frombottom");
            RegisterField(catalog, source, assemblyIdentity, "game_03_key_unlock");
            RegisterField(catalog, source, assemblyIdentity, "game_03_forcefield_vanish");
            RegisterField(catalog, source, assemblyIdentity, "game_03_forcefield_bump");
            RegisterField(catalog, source, assemblyIdentity, "game_03_platform_horiz_left");
            RegisterField(catalog, source, assemblyIdentity, "game_03_platform_horiz_right");
            RegisterField(catalog, source, assemblyIdentity, "game_03_lantern_bump");
            RegisterField(catalog, source, assemblyIdentity, "game_03_deskbell_again");
            RegisterField(catalog, source, assemblyIdentity, "game_03_clutterswitch_return");
            RegisterField(catalog, source, assemblyIdentity, "game_03_clutterswitch_squish");
            RegisterField(catalog, source, assemblyIdentity, "game_03_clutterswitch_press_books");
            RegisterField(catalog, source, assemblyIdentity, "game_03_clutterswitch_press_boxes");
            RegisterField(catalog, source, assemblyIdentity, "game_03_clutterswitch_press_linens");
            RegisterField(catalog, source, assemblyIdentity, "game_03_clutterswitch_press_finish");
            RegisterField(catalog, source, assemblyIdentity, "game_03_fluff_tendril_emerge");
            RegisterField(catalog, source, assemblyIdentity, "game_03_fluff_tendril_recede");
            RegisterField(catalog, source, assemblyIdentity, "game_03_fluff_tendril_touch");
            RegisterField(catalog, source, assemblyIdentity, "game_03_platform_vert_start");
            RegisterField(catalog, source, assemblyIdentity, "game_03_platform_vert_down_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_03_platform_vert_up_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_03_platform_vert_end");
            RegisterField(catalog, source, assemblyIdentity, "game_03_memo_in");
            RegisterField(catalog, source, assemblyIdentity, "game_03_memo_out");
            RegisterField(catalog, source, assemblyIdentity, "game_03_suite_badintro");
            RegisterField(catalog, source, assemblyIdentity, "game_03_suite_badmirrorbreak");
            RegisterField(catalog, source, assemblyIdentity, "game_03_suite_badmovestageleft");
            RegisterField(catalog, source, assemblyIdentity, "game_03_suite_badceilingbreak");
            RegisterField(catalog, source, assemblyIdentity, "game_03_suite_badexittop");
            RegisterField(catalog, source, assemblyIdentity, "game_03_suite_badmoveroof");
            RegisterField(catalog, source, assemblyIdentity, "game_03_sequence_oshiro_intro");
            RegisterField(catalog, source, assemblyIdentity, "game_03_sequence_oshirofluff_pt1");
            RegisterField(catalog, source, assemblyIdentity, "game_03_sequence_oshirofluff_pt2");
        }

        private static void RegisterFields6(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "game_04_arrowblock_activate");
            RegisterField(catalog, source, assemblyIdentity, "game_04_arrowblock_move_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_04_arrowblock_side_depress");
            RegisterField(catalog, source, assemblyIdentity, "game_04_arrowblock_side_release");
            RegisterField(catalog, source, assemblyIdentity, "game_04_arrowblock_break");
            RegisterField(catalog, source, assemblyIdentity, "game_04_arrowblock_debris");
            RegisterField(catalog, source, assemblyIdentity, "game_04_arrowblock_reform_begin");
            RegisterField(catalog, source, assemblyIdentity, "game_04_arrowblock_reappear");
            RegisterField(catalog, source, assemblyIdentity, "game_04_greenbooster_enter");
            RegisterField(catalog, source, assemblyIdentity, "game_04_greenbooster_dash");
            RegisterField(catalog, source, assemblyIdentity, "game_04_greenbooster_end");
            RegisterField(catalog, source, assemblyIdentity, "game_04_greenbooster_reappear");
            RegisterField(catalog, source, assemblyIdentity, "game_04_cloud_blue_boost");
            RegisterField(catalog, source, assemblyIdentity, "game_04_cloud_pink_boost");
            RegisterField(catalog, source, assemblyIdentity, "game_04_cloud_pink_reappear");
            RegisterField(catalog, source, assemblyIdentity, "game_04_snowball_spawn");
            RegisterField(catalog, source, assemblyIdentity, "game_04_snowball_impact");
            RegisterField(catalog, source, assemblyIdentity, "game_04_stone_blockade");
            RegisterField(catalog, source, assemblyIdentity, "game_04_whiteblock_fallthru");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_theo_fall");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_theo_recover");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_theo_lever_start");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_cliffmechanism_start");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_movement_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_theoselfie_halt");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_halted_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_theo_lever_fail");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_scaryhair_01");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_scaryhair_02");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_scaryhair_03");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_restart");
            RegisterField(catalog, source, assemblyIdentity, "game_04_gondola_finish");
            RegisterField(catalog, source, assemblyIdentity, "game_05_key_unlock_light");
            RegisterField(catalog, source, assemblyIdentity, "game_05_key_unlock_dark");
            RegisterField(catalog, source, assemblyIdentity, "game_05_redbooster_enter");
            RegisterField(catalog, source, assemblyIdentity, "game_05_redbooster_dash");
            RegisterField(catalog, source, assemblyIdentity, "game_05_redbooster_move_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_05_redbooster_end");
            RegisterField(catalog, source, assemblyIdentity, "game_05_redbooster_reappear");
            RegisterField(catalog, source, assemblyIdentity, "game_05_torch_activate");
            RegisterField(catalog, source, assemblyIdentity, "game_05_bladespinner_spin");
            RegisterField(catalog, source, assemblyIdentity, "game_05_room_lightlevel_down");
            RegisterField(catalog, source, assemblyIdentity, "game_05_room_lightlevel_up");
            RegisterField(catalog, source, assemblyIdentity, "game_05_swapblock_move");
            RegisterField(catalog, source, assemblyIdentity, "game_05_swapblock_move_end");
            RegisterField(catalog, source, assemblyIdentity, "game_05_swapblock_return");
            RegisterField(catalog, source, assemblyIdentity, "game_05_swapblock_return_end");
            RegisterField(catalog, source, assemblyIdentity, "game_05_gatebutton_depress");
            RegisterField(catalog, source, assemblyIdentity, "game_05_gatebutton_return");
            RegisterField(catalog, source, assemblyIdentity, "game_05_gatebutton_activate");
            RegisterField(catalog, source, assemblyIdentity, "game_05_gate_main_open");
            RegisterField(catalog, source, assemblyIdentity, "game_05_gate_main_close");
            RegisterField(catalog, source, assemblyIdentity, "game_05_gate_theo_open");
            RegisterField(catalog, source, assemblyIdentity, "game_05_gate_theo_close");
            RegisterField(catalog, source, assemblyIdentity, "game_05_sequence_mainmirror_torch_1");
            RegisterField(catalog, source, assemblyIdentity, "game_05_sequence_mainmirror_torch_2");
            RegisterField(catalog, source, assemblyIdentity, "game_05_sequence_mainmirror_torch_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_05_sequence_mainmirror_reveal");
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_playercontrolstart");
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_statuebreak");
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_aggro");
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_dash");
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_dash_turn");
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_impact_normal");
        }

        private static void RegisterFields7(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_impact_lightwall");
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_booped");
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_death");
            RegisterField(catalog, source, assemblyIdentity, "game_05_seeker_revive");
            RegisterField(catalog, source, assemblyIdentity, "game_05_crackedwall_vanish");
            RegisterField(catalog, source, assemblyIdentity, "game_05_crystaltheo_breakfree");
            RegisterField(catalog, source, assemblyIdentity, "game_05_crystaltheo_impact_ground");
            RegisterField(catalog, source, assemblyIdentity, "game_05_crystaltheo_impact_side");
            RegisterField(catalog, source, assemblyIdentity, "game_05_eyewall_idle_eyemove");
            RegisterField(catalog, source, assemblyIdentity, "game_05_eyewall_pulse");
            RegisterField(catalog, source, assemblyIdentity, "game_05_eyewall_destroy");
            RegisterField(catalog, source, assemblyIdentity, "game_05_eyewall_bounce");
            RegisterField(catalog, source, assemblyIdentity, "game_06_fallingblock_boss_shake");
            RegisterField(catalog, source, assemblyIdentity, "game_06_fallingblock_boss_impact");
            RegisterField(catalog, source, assemblyIdentity, "game_06_crushblock_activate");
            RegisterField(catalog, source, assemblyIdentity, "game_06_crushblock_move_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_06_crushblock_move_loop_covert");
            RegisterField(catalog, source, assemblyIdentity, "game_06_crushblock_impact");
            RegisterField(catalog, source, assemblyIdentity, "game_06_crushblock_return_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_06_crushblock_rest");
            RegisterField(catalog, source, assemblyIdentity, "game_06_crushblock_rest_waypoint");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badeline_freakout_1");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badeline_freakout_2");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badeline_freakout_3");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badeline_freakout_4");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badeline_freakout_5");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badeline_featherslice");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badelinepull_whooshdown");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badelinepull_impact");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badelinepull_rumble_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_06_badelinepull_cliffbreak");
            RegisterField(catalog, source, assemblyIdentity, "game_06_fall_spike_smash");
            RegisterField(catalog, source, assemblyIdentity, "game_06_supersecret_torch_1");
            RegisterField(catalog, source, assemblyIdentity, "game_06_supersecret_torch_2");
            RegisterField(catalog, source, assemblyIdentity, "game_06_supersecret_torch_3");
            RegisterField(catalog, source, assemblyIdentity, "game_06_supersecret_torch_4");
            RegisterField(catalog, source, assemblyIdentity, "game_06_supersecret_dashflavour");
            RegisterField(catalog, source, assemblyIdentity, "game_06_supersecret_heartappear");
            RegisterField(catalog, source, assemblyIdentity, "game_06_pinballbumper_hit");
            RegisterField(catalog, source, assemblyIdentity, "game_06_pinballbumper_reset");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_get");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_renew");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_reappear");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_state_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_state_warning");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_state_end");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_state_bump");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_bubble_get");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_bubble_renew");
            RegisterField(catalog, source, assemblyIdentity, "game_06_feather_bubble_bounce");
            RegisterField(catalog, source, assemblyIdentity, "game_06_scaryhair_move");
            RegisterField(catalog, source, assemblyIdentity, "game_06_scaryhair_whoosh");
            RegisterField(catalog, source, assemblyIdentity, "game_06_boss_spikes_burst");
            RegisterField(catalog, source, assemblyIdentity, "game_06_hug_image_1");
            RegisterField(catalog, source, assemblyIdentity, "game_06_hug_image_2");
            RegisterField(catalog, source, assemblyIdentity, "game_06_hug_image_3");
            RegisterField(catalog, source, assemblyIdentity, "game_06_hug_badelineglow");
            RegisterField(catalog, source, assemblyIdentity, "game_06_hug_levelup_text_in");
            RegisterField(catalog, source, assemblyIdentity, "game_06_hug_levelup_text_out");
            RegisterField(catalog, source, assemblyIdentity, "game_07_altitudecount");
            RegisterField(catalog, source, assemblyIdentity, "game_07_checkpointconfetti");
            RegisterField(catalog, source, assemblyIdentity, "game_07_gem_get");
            RegisterField(catalog, source, assemblyIdentity, "game_07_gem_unlock_1");
            RegisterField(catalog, source, assemblyIdentity, "game_07_gem_unlock_2");
        }

        private static void RegisterFields8(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "game_07_gem_unlock_3");
            RegisterField(catalog, source, assemblyIdentity, "game_07_gem_unlock_4");
            RegisterField(catalog, source, assemblyIdentity, "game_07_gem_unlock_5");
            RegisterField(catalog, source, assemblyIdentity, "game_07_gem_unlock_6");
            RegisterField(catalog, source, assemblyIdentity, "game_07_gem_unlock_complete");
            RegisterField(catalog, source, assemblyIdentity, "game_09_frontdoor_heartfill");
            RegisterField(catalog, source, assemblyIdentity, "game_09_frontdoor_unlock");
            RegisterField(catalog, source, assemblyIdentity, "game_09_conveyor_activate");
            RegisterField(catalog, source, assemblyIdentity, "game_09_hotpinball_activate");
            RegisterField(catalog, source, assemblyIdentity, "game_09_bounceblock_touch");
            RegisterField(catalog, source, assemblyIdentity, "game_09_bounceblock_break");
            RegisterField(catalog, source, assemblyIdentity, "game_09_bounceblock_reappear");
            RegisterField(catalog, source, assemblyIdentity, "game_09_iceblock_touch");
            RegisterField(catalog, source, assemblyIdentity, "game_09_iceblock_reappear");
            RegisterField(catalog, source, assemblyIdentity, "game_09_switch_to_cold");
            RegisterField(catalog, source, assemblyIdentity, "game_09_switch_to_hot");
            RegisterField(catalog, source, assemblyIdentity, "game_09_switch_shutdown");
            RegisterField(catalog, source, assemblyIdentity, "game_09_iceball_break");
            RegisterField(catalog, source, assemblyIdentity, "game_09_pinballbumper_hit");
            RegisterField(catalog, source, assemblyIdentity, "game_09_risingthreat_loop");
            RegisterField(catalog, source, assemblyIdentity, "game_10_lightning_strike");
            RegisterField(catalog, source, assemblyIdentity, "game_10_heart_door");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_camera_pan_up");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_fly_uptonext");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_startle");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_relocate");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_wingflap");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_flyuproll");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_throw");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_flappyscene_entry");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_flappyscene");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_crashscene_start");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_crashscene_twitch_1");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_crashscene_twitch_2");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_crashscene_twitch_3");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_crashscene_recover");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_crashscene_relocate");
            RegisterField(catalog, source, assemblyIdentity, "game_10_bird_crashscene_leave");
            RegisterField(catalog, source, assemblyIdentity, "game_10_pinkdiamond_touch");
            RegisterField(catalog, source, assemblyIdentity, "game_10_pinkdiamond_return");
            RegisterField(catalog, source, assemblyIdentity, "game_10_puffer_shrink");
            RegisterField(catalog, source, assemblyIdentity, "game_10_puffer_expand");
            RegisterField(catalog, source, assemblyIdentity, "game_10_puffer_boop");
            RegisterField(catalog, source, assemblyIdentity, "game_10_puffer_splode");
            RegisterField(catalog, source, assemblyIdentity, "game_10_puffer_reform");
            RegisterField(catalog, source, assemblyIdentity, "game_10_puffer_return");
            RegisterField(catalog, source, assemblyIdentity, "game_10_quake_onset");
            RegisterField(catalog, source, assemblyIdentity, "game_10_quake_rockbreak");
            RegisterField(catalog, source, assemblyIdentity, "game_10_locked_door_appear_1");
            RegisterField(catalog, source, assemblyIdentity, "game_10_locked_door_appear_2");
            RegisterField(catalog, source, assemblyIdentity, "game_10_locked_door_appear_3");
            RegisterField(catalog, source, assemblyIdentity, "game_10_locked_door_appear_4");
            RegisterField(catalog, source, assemblyIdentity, "game_10_locked_door_appear_5");
            RegisterField(catalog, source, assemblyIdentity, "game_10_key_unlock_1");
            RegisterField(catalog, source, assemblyIdentity, "game_10_key_unlock_2");
            RegisterField(catalog, source, assemblyIdentity, "game_10_key_unlock_3");
            RegisterField(catalog, source, assemblyIdentity, "game_10_key_unlock_4");
            RegisterField(catalog, source, assemblyIdentity, "game_10_key_unlock_5");
            RegisterField(catalog, source, assemblyIdentity, "game_10_glider_platform_dissipate");
            RegisterField(catalog, source, assemblyIdentity, "game_10_glider_wallbounce_left");
            RegisterField(catalog, source, assemblyIdentity, "game_10_glider_wallbounce_right");
            RegisterField(catalog, source, assemblyIdentity, "game_10_glider_land");
            RegisterField(catalog, source, assemblyIdentity, "game_10_glider_engage");
            RegisterField(catalog, source, assemblyIdentity, "game_10_glider_movement");
        }

        private static void RegisterFields9(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "game_10_glider_emancipate");
            RegisterField(catalog, source, assemblyIdentity, "game_10_fusebox_hit_1");
            RegisterField(catalog, source, assemblyIdentity, "game_10_fusebox_hit_2");
            RegisterField(catalog, source, assemblyIdentity, "game_10_fakeheart_get");
            RegisterField(catalog, source, assemblyIdentity, "game_10_fakeheart_pulse");
            RegisterField(catalog, source, assemblyIdentity, "game_10_fakeheart_bounce");
            RegisterField(catalog, source, assemblyIdentity, "game_10_glitch_short");
            RegisterField(catalog, source, assemblyIdentity, "game_10_glitch_medium");
            RegisterField(catalog, source, assemblyIdentity, "game_10_glitch_long");
            RegisterField(catalog, source, assemblyIdentity, "game_10_zip_mover");
            RegisterField(catalog, source, assemblyIdentity, "game_10_pico8_flag");
            RegisterField(catalog, source, assemblyIdentity, "game_10_strawberry_gold_detach");
            RegisterField(catalog, source, assemblyIdentity, "game_10_cafe_computer_on");
            RegisterField(catalog, source, assemblyIdentity, "game_10_cafe_computer_startupsfx");
            RegisterField(catalog, source, assemblyIdentity, "game_10_cafe_computer_off");
            RegisterField(catalog, source, assemblyIdentity, "game_10_ppt_mouseclick");
            RegisterField(catalog, source, assemblyIdentity, "game_10_ppt_doubleclick");
            RegisterField(catalog, source, assemblyIdentity, "game_10_ppt_cube_transition");
            RegisterField(catalog, source, assemblyIdentity, "game_10_ppt_dissolve_transition");
            RegisterField(catalog, source, assemblyIdentity, "game_10_ppt_happy_wavedashing");
            RegisterField(catalog, source, assemblyIdentity, "game_10_ppt_impossible");
            RegisterField(catalog, source, assemblyIdentity, "game_10_ppt_its_easy");
            RegisterField(catalog, source, assemblyIdentity, "game_10_ppt_spinning_transition");
            RegisterField(catalog, source, assemblyIdentity, "game_10_ppt_wavedash_whoosh");
            RegisterField(catalog, source, assemblyIdentity, "game_10_endscene_dial_theo");
            RegisterField(catalog, source, assemblyIdentity, "game_10_endscene_attachment_notify");
            RegisterField(catalog, source, assemblyIdentity, "game_10_endscene_attachment_click");
            RegisterField(catalog, source, assemblyIdentity, "game_10_endscene_photozoom");
            RegisterField(catalog, source, assemblyIdentity, "game_10_endscene_final_input");
            RegisterField(catalog, source, assemblyIdentity, "game_10_timeline_bubble_to_remembered");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_worldmap");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_00_main");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_01_main");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_02_dream");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_02_awake");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_03_exterior");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_03_interior");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_03_pico8_closeup");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_04_main");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_05_interior_main");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_05_interior_dark");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_05_mirror_sequence");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_06_lake");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_06_main");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_06_prehug");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_09_main");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_10_rain");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_10_electricity");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_10_endscene");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_10_rushingvoid");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_10_space_underwater");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_10_voidspiral");
            RegisterField(catalog, source, assemblyIdentity, "env_amb_10_grannyclouds");
            RegisterField(catalog, source, assemblyIdentity, "env_state_underwater");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_campfire_start");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_campfire_loop");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_waterfall_big_main");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_waterfall_big_in");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_waterfall_small_main");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_waterfall_small_in_deep");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_waterfall_small_in_shallow");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_02_lamp");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_03_pico8machine_loop");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_03_brokenwindow_large_loop");
        }

        private static void RegisterFields10(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "env_loc_03_brokenwindow_small_loop");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_07_flag_flap");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_09_conveyer_idle");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_09_lavagate_idle");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_09_fireball_idle");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_10_cafe_computer");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_10_cafe_sign");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_10_tutorial_static_left");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_10_tutorial_static_right");
            RegisterField(catalog, source, assemblyIdentity, "env_loc_10_kevinpc");
            RegisterField(catalog, source, assemblyIdentity, "state_cafe_computer_active");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch1_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch1_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch2_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch2_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch3_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch3_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch4_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch4_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch5_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch5_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch6_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_ch6_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_csides_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_csides_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_variants_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_postcard_variants_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_title_firstinput");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_roll_down");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_roll_up");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_button_select");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_button_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_button_climb");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_button_toggle_on");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_button_toggle_off");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_button_invalid");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_button_lowkey");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_whoosh_large_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_whoosh_large_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_whoosh_list_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_whoosh_list_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_whoosh_savefile_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_whoosh_savefile_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_savefile_roll_down");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_savefile_roll_up");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_savefile_roll_first");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_savefile_rename_start");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_savefile_delete");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_savefile_begin");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_message_confirm");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_rename_entry_roll");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_rename_entry_char");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_rename_entry_space");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_rename_entry_backspace");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_rename_entry_accept");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_rename_entry_accept_locked");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_assist_button_info");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_assist_info_whistle");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_assist_button_yes");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_assist_button_no");
            RegisterField(catalog, source, assemblyIdentity, "ui_main_bside_intro_text");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_pause");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_unpause");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_tutorialnote_flip_back");
        }

        private static void RegisterFields11(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "ui_game_tutorialnote_flip_front");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_hotspot_main_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_hotspot_main_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_hotspot_note_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_hotspot_note_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_general_text_loop");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_memorial_text_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_memorial_text_loop");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_memorial_text_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_memorialdream_text_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_memorialdream_text_loop");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_memorialdream_text_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_memorialdream_loop");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_lookout_on");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_lookout_off");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_chatoptions_roll_up");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_chatoptions_roll_down");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_chatoptions_appear");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_chatoptions_select");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_textbox_madeline_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_textbox_madeline_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_textbox_other_in");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_textbox_other_out");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_textadvance_madeline");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_textadvance_other");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_increment_strawberry");
            RegisterField(catalog, source, assemblyIdentity, "ui_game_increment_dashcount");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_icon_roll_right");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_icon_roll_left");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_icon_select");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_icon_flip_right");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_icon_flip_left");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_icon_assistskip");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_400ms_forward");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_400ms_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_600ms_forward");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_600ms_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_700ms_forward");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_700ms_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_1000ms_forward");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_1000ms_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_900ms_forward");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_whoosh_900ms_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_pane_expand");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_pane_contract");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_tab_roll_right");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_tab_roll_left");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_level_select");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_checkpoint_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_checkpoint_photo_add");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_checkpoint_photo_remove");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_chapter_checkpoint_start");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_select");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_page_cover_forward");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_page_cover_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_page_main_forward");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_page_main_back");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_heart_roll");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_heart_grab");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_heart_release");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_heart_shift_up");
            RegisterField(catalog, source, assemblyIdentity, "ui_world_journal_heart_shift_down");
        }

        private static void RegisterFields12(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity)
        {
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_crystalheart");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_strawberry_count");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_goldberry_count");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_strawberry_total");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_strawberry_total_all");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_death_appear");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_death_count");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_death_final");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_unlock_newchapter");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_unlock_newchapter_icon");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_unlock_bside");
            RegisterField(catalog, source, assemblyIdentity, "ui_postgame_skip_all");
            RegisterField(catalog, source, assemblyIdentity, "byHandle");
            RegisterField(catalog, source, assemblyIdentity, "MadelineToBadelineSound");
        }

        private static void RegisterField(SourceMemberCatalog catalog, OriginalSfxProcess source,
            string assemblyIdentity, string name)
        {
            var definition = catalog.RequireDefinition(assemblyIdentity, "Celeste.SFX", name, SourceMemberKind.Field);
            var field = typeof(OriginalSfxProcess).GetField(name,
                            BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
                            BindingFlags.Static |
                            BindingFlags.Instance)
                        ?? throw new MissingFieldException(typeof(OriginalSfxProcess).FullName, name);
            if (definition.IsLiteral)
            {
                if (!field.IsLiteral || !field.IsStatic || field.FieldType != typeof(string)
                    || !string.Equals((string)field.GetRawConstantValue(), (string)definition.ConstantValue,
                        StringComparison.Ordinal))
                    throw new InvalidOperationException(
                        "The actual SFX literal differs from the original PE field: " + name);
            }
            else if (field.IsStatic || field.IsLiteral ||
                     field.FieldType != typeof(Dictionary<string, string>))
            {
                throw new InvalidOperationException(
                    "The migrated SFX field must belong to the same actual process owner: " + name);
            }

            catalog.RegisterBinding(new(definition, typeof(OriginalSfxProcess), field,
                field.IsStatic ? null : source));
        }
    }
}
