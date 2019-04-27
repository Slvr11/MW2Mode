using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;

namespace MW2Mode
{
    public unsafe class MW2 : BaseScript
    {
        private int[] classOffsets = new int[10];
        private static HudElem[] scoreBars = new HudElem[2];
        private static HudElem[] scores = new HudElem[2];
        private static bool isTeamBased = true;

        public MW2()
                : base()
        {
            classOffsets[0] = 0x648111C;
            classOffsets[1] = 0x648117f;
            classOffsets[2] = 0x64811e2;
            classOffsets[3] = 0x6481245;
            classOffsets[4] = 0x64812a8;
            classOffsets[5] = 0x648136E;
            classOffsets[6] = 0x64813D1;
            classOffsets[7] = 0x6481434;
            classOffsets[8] = 0x6481497;
            classOffsets[9] = 0x64814fa;
            SetDvar("g_hardcore", "1");
            //Call("setDvar", "g_compassShowEnemies", "1");
            SetDvar("cg_drawCrosshair", "1");
            PreCacheShader("nightvision_overlay_goggles");
            PreCacheShader("hud_iw5_divider");
            PreCacheShader("ui_arrow_right");
            PreCacheShader("faction_128_ussr");
            PreCacheShader("faction_128_af");
            PreCacheShader("faction_128_ic");
            PreCacheShader("faction_128_pmc");
            PreCacheShader("faction_128_sas");
            PreCacheShader("faction_128_delta");
            PreCacheShader("faction_128_gign");
            PreCacheItem("killstreak_double_uav_mp");
            PreCacheItem("at4_mp");
            string gametype = GetDvar("g_gametype");
            if (gametype == "dm" || gametype == "gun" || gametype == "oic" || gametype == "jugg")
                isTeamBased = false;

            *(int*)classOffsets[0] = 0x5A;
            classOffsets[0] = classOffsets[0] + 0x02;
            *(int*)classOffsets[0] = 0x05;
            classOffsets[0] = classOffsets[0] + 0x02;
            *(int*)classOffsets[0] = 0x11;
            classOffsets[0] = classOffsets[0] + 0x02;
            *(int*)classOffsets[0] = 0x0A;
            classOffsets[0] = classOffsets[0] + 0x14;
            *(int*)classOffsets[0] = 0x39;
            classOffsets[0] = classOffsets[0] + 0x02;
            *(int*)classOffsets[0] = 0x09;
            classOffsets[0] = classOffsets[0] + 0x02;
            *(int*)classOffsets[0] = 0x08;
            classOffsets[0] = classOffsets[0] + 0x1F;
            *(int*)classOffsets[0] = 0x81;
            classOffsets[0] = classOffsets[0] + 0x02;
            *(int*)classOffsets[0] = 0x14;
            classOffsets[0] = classOffsets[0] + 0x02;
            *(int*)classOffsets[0] = 0x07;
            classOffsets[0] = classOffsets[0] + 0x02;
            *(int*)classOffsets[0] = 0x1B;
            classOffsets[1] = classOffsets[1] + 0x1C;
            *(int*)classOffsets[1] = 0x23;
            classOffsets[1] = classOffsets[1] + 0x02;
            *(int*)classOffsets[1] = 0x08;
            classOffsets[2] = classOffsets[2] + 0x1A;
            *(int*)classOffsets[2] = 0x39;
            classOffsets[2] = classOffsets[2] + 0x02;
            *(int*)classOffsets[2] = 0x46;
            classOffsets[2] = classOffsets[2] + 0x02;
            *(int*)classOffsets[2] = 0x0A;
            classOffsets[2] = classOffsets[2] + 0x1F;
            *(int*)classOffsets[2] = 0x81;
            classOffsets[2] = classOffsets[2] + 0x02;
            *(int*)classOffsets[2] = 0x05;
            classOffsets[2] = classOffsets[2] + 0x02;
            *(int*)classOffsets[2] = 0x08;
            classOffsets[2] = classOffsets[2] + 0x02;
            *(int*)classOffsets[2] = 0x0F;
            classOffsets[3] = classOffsets[3] + 0x18;
            *(int*)classOffsets[3] = 0x83;
            classOffsets[3] = classOffsets[3] + 0x02;
            *(int*)classOffsets[3] = 0x39;
            classOffsets[3] = classOffsets[3] + 0x02;
            *(int*)classOffsets[3] = 0x30;
            classOffsets[3] = classOffsets[3] + 0x02;
            *(int*)classOffsets[3] = 0x1E;
            classOffsets[3] = classOffsets[3] + 0x1F;
            *(int*)classOffsets[3] = 0x81;
            classOffsets[3] = classOffsets[3] + 0x02;
            *(int*)classOffsets[3] = 0x01;
            classOffsets[3] = classOffsets[3] + 0x02;
            *(int*)classOffsets[3] = 0x02;
            classOffsets[3] = classOffsets[3] + 0x02;
            *(int*)classOffsets[3] = 0x14;
            classOffsets[4] = classOffsets[4] + 0x18;
            *(int*)classOffsets[4] = 0x16;
            classOffsets[4] = classOffsets[4] + 0x02;
            *(int*)classOffsets[4] = 0x09;
            classOffsets[4] = classOffsets[4] + 0x02;
            *(int*)classOffsets[4] = 0x44;
            classOffsets[4] = classOffsets[4] + 0x02;
            *(int*)classOffsets[4] = 0x08;
            classOffsets[4] = classOffsets[4] + 0x1F;
            *(int*)classOffsets[4] = 0x82;
            classOffsets[4] = classOffsets[4] + 0x02;
            *(int*)classOffsets[4] = 0x01;
            classOffsets[4] = classOffsets[4] + 0x02;
            *(int*)classOffsets[4] = 0x02;
            classOffsets[4] = classOffsets[4] + 0x02;
            *(int*)classOffsets[4] = 0x03;
            *(int*)classOffsets[5] = 0x5A;
            classOffsets[5] = classOffsets[5] + 0x02;
            *(int*)classOffsets[5] = 0x05;
            classOffsets[5] = classOffsets[5] + 0x02;
            *(int*)classOffsets[5] = 0x11;
            classOffsets[5] = classOffsets[5] + 0x02;
            *(int*)classOffsets[5] = 0x0A;
            classOffsets[5] = classOffsets[5] + 0x14;
            *(int*)classOffsets[5] = 0x39;
            classOffsets[5] = classOffsets[5] + 0x02;
            *(int*)classOffsets[5] = 0x09;
            classOffsets[5] = classOffsets[5] + 0x02;
            *(int*)classOffsets[5] = 0x08;
            classOffsets[5] = classOffsets[5] + 0x1F;
            *(int*)classOffsets[5] = 0x81;
            classOffsets[5] = classOffsets[5] + 0x02;
            *(int*)classOffsets[5] = 0x14;
            classOffsets[5] = classOffsets[5] + 0x02;
            *(int*)classOffsets[5] = 0x07;
            classOffsets[5] = classOffsets[5] + 0x02;
            *(int*)classOffsets[5] = 0x1B;
            classOffsets[6] = classOffsets[6] + 0x1C;
            *(int*)classOffsets[6] = 0x23;
            classOffsets[6] = classOffsets[6] + 0x02;
            *(int*)classOffsets[6] = 0x08;
            classOffsets[7] = classOffsets[7] + 0x1A;
            *(int*)classOffsets[7] = 0x39;
            classOffsets[7] = classOffsets[7] + 0x02;
            *(int*)classOffsets[7] = 0x46;
            classOffsets[7] = classOffsets[7] + 0x02;
            *(int*)classOffsets[7] = 0x0A;
            classOffsets[7] = classOffsets[7] + 0x1F;
            *(int*)classOffsets[7] = 0x81;
            classOffsets[7] = classOffsets[7] + 0x02;
            *(int*)classOffsets[7] = 0x05;
            classOffsets[7] = classOffsets[7] + 0x02;
            *(int*)classOffsets[7] = 0x08;
            classOffsets[7] = classOffsets[7] + 0x02;
            *(int*)classOffsets[7] = 0x0F;
            classOffsets[8] = classOffsets[8] + 0x18;
            *(int*)classOffsets[8] = 0x83;
            classOffsets[8] = classOffsets[8] + 0x02;
            *(int*)classOffsets[8] = 0x39;
            classOffsets[8] = classOffsets[8] + 0x02;
            *(int*)classOffsets[8] = 0x30;
            classOffsets[8] = classOffsets[8] + 0x02;
            *(int*)classOffsets[8] = 0x1E;
            classOffsets[8] = classOffsets[8] + 0x1F;
            *(int*)classOffsets[8] = 0x81;
            classOffsets[8] = classOffsets[8] + 0x02;
            *(int*)classOffsets[8] = 0x01;
            classOffsets[8] = classOffsets[8] + 0x02;
            *(int*)classOffsets[8] = 0x02;
            classOffsets[8] = classOffsets[8] + 0x02;
            *(int*)classOffsets[8] = 0x14;
            classOffsets[9] = classOffsets[9] + 0x18;
            *(int*)classOffsets[9] = 0x16;
            classOffsets[9] = classOffsets[9] + 0x02;
            *(int*)classOffsets[9] = 0x09;
            classOffsets[9] = classOffsets[9] + 0x02;
            *(int*)classOffsets[9] = 0x44;
            classOffsets[9] = classOffsets[9] + 0x02;
            *(int*)classOffsets[9] = 0x08;
            classOffsets[9] = classOffsets[9] + 0x1F;
            *(int*)classOffsets[9] = 0x82;
            classOffsets[9] = classOffsets[9] + 0x02;
            *(int*)classOffsets[9] = 0x01;
            classOffsets[9] = classOffsets[9] + 0x02;
            *(int*)classOffsets[9] = 0x02;
            classOffsets[9] = classOffsets[9] + 0x02;
            *(int*)classOffsets[9] = 0x03;

            AfterDelay(100, createServerHud);

            PlayerConnected += onPlayerConnected;
        }

        public static void onPlayerConnected(Entity player)
        {
            player.SetClientDvar("g_hardcore", "1");
            player.SetField("blastShieldEquipped", false);
            //entity.SetClientDvar("g_compassShowEnemies", "1");

            createHUD(player);
            player.NotifyOnPlayerCommand("stun", "+smoke");
            player.NotifyOnPlayerCommand("blastShield", "+frag");
            player.OnNotify("stun", (p) =>
            {
                if (player.GetAmmoCount("concussion_grenade_mp") > 0 && player.HasWeapon("concussion_grenade_mp"))
                {
                    player.SetPerk("specialty_fastoffhand", true, true);
                    AfterDelay(1000, () =>
                        player.UnSetPerk("specialty_fastoffhand", true));
                }
            });
            player.OnNotify("blastShield", (p) =>
            {
                //Log.Debug(player.GetCurrentOffhand());
                if (player.HasPerk("specialty_blastshield") && !player.GetField<bool>("blastShieldEquipped"))
                {
                    player.VisionSetNakedForPlayer("black_bw", 0.2f);
                    AfterDelay(250, () =>
                    {
                        player.VisionSetNakedForPlayer("", 0.2f);
                        HudElem overlay = createBlastShieldOverlay(player);
                        overlay.Alpha = 0;
                        player.SetPerk("_specialty_blastshield", true, true);
                        player.PlayLocalSound("item_blast_shield_on");
                        player.SetField("blastShieldEquipped", true);
                    });
                }
                else if (player.HasPerk("specialty_blastshield") && player.GetField<bool>("blastShieldEquipped"))
                {
                    player.VisionSetNakedForPlayer("black_bw", 0.2f);
                    AfterDelay(250, () =>
                    {
                        player.VisionSetNakedForPlayer("", 0.2f);
                        destroyBlastShieldOverlay(player);
                        player.UnSetPerk("_specialty_blastshield", true);
                        player.PlayLocalSound("item_blast_shield_off");
                        player.SetField("blastShieldEquipped", false);
                    });
                }
            });

            player.OnNotify("weapon_change", (p, newWeap) =>
            {
                if (mayDropWeapon((string)newWeap))
                    player.SetField("lastDroppableWeapon", (string)newWeap);
                killstreakSwitcher(player);
                updateHUDAmmo(player, false, (string)newWeap);
            });

            player.OnNotify("weapon_switch_started", (p, newWeap) =>
            {
                //killstreakSwitcher(player);
                updateHUDAmmo(player, true, (string)newWeap);
            });

            player.OnNotify("weapon_fired", (p, weapon) =>
                updateHUDAmmo(player));
            player.OnNotify("reload", (p) => updateHUDAmmo(player));

            OnInterval(1000, () => { updateHUDAmmo(player); if (player.IsPlayer) return true; return false; });

            player.SpawnedPlayer += () => onPlayerSpawned(player);
        }

        public static void onPlayerSpawned(Entity player)
        {
            updateHUDAmmo(player, true);
            player.GiveWeapon("killstreak_double_uav_mp");
            if (player.HasWeapon("smoke_grenade_mp") && player.HasPerk("specialty_tacticalinsertion"))
                player.SetOffhandPrimaryClass("flash");
            if (player.HasWeapon("iw5_smaw_mp"))
            {
                player.TakeWeapon("iw5_smaw_mp");
                player.GiveWeapon("at4_mp");
            }

            if (player.HasField("scoreArrow"))
            {
                HudElem arrow = player.GetField<HudElem>("scoreArrow");
                int y = -24;
                if (isTeamBased && player.SessionTeam == "axis") y = -38;
                arrow.SetPoint("BOTTOMLEFT", "BOTTOMLEFT", 82, y);
                arrow.Alpha = 1;
                arrow.Children[0].Alpha = 1;
            }
        }

        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
            if (player.GetField<bool>("blastShieldEquipped"))
            {
                if (mod == "MOD_EXPLOSIVE")
                {
                    //player.SetField("health", 100);
                    damage = damage / 2;
                    player.Health += damage;
                }
            }
        }
        public override void OnPlayerDisconnect(Entity player)
        {
            destroyPlayerHud(player);
        }

        private static bool mayDropWeapon(string weapon)
        {
            if (weapon == "none")
                return false;

            if (weapon.Contains("ac130"))
                return false;

            string invType = WeaponInventoryType(weapon);
            if (invType != "primary")
                return false;

            return true;
        }

        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {
            if (player.GetField<bool>("blastShieldEquipped"))
            {
                player.SetField("blastShieldEquipped", false);
                destroyBlastShieldOverlay(player);
            }

            // update all players' ranking
            AfterDelay(100, () =>
            {
                if (isTeamBased) updateScores_teamBased();
                else if (!isTeamBased) updateScores_ffa();
            });
        }

        private static void updateScores_teamBased()
        {
            float alliesScore = GetTeamScore("allies");
            float axisScore = GetTeamScore("axis");
            string gametype = GetDvar("g_gametype");
            float scoreLimit = GetDvarInt("scr_" + gametype + "_scorelimit");
            scores[0].SetValue((int)alliesScore);
            scores[1].SetValue((int)axisScore);
            float alliesBarScale = alliesScore / scoreLimit;
            float axisBarScale = axisScore / scoreLimit;
            scoreBars[0].SetShader("white", (int)(140 * alliesBarScale) + 2, 5);
            scoreBars[1].SetShader("white", (int)(140 * axisBarScale) + 2, 5);
        }
        private static void updateScores_ffa()
        {
            var scoreList = (from p in Players
                             orderby p.Score descending, p.Deaths ascending
                             select p).ToList();

            scores[0].SetValue(scoreList[0].Score);
            if (Players.Count > 1) scores[1].SetValue(scoreList[1].Score);
            else scores[1].SetValue(0);
        }

        public static string createHudShaderString(string shader, bool flipped = false, int width = 64, int height = 64)
        {
            byte[] str;
            byte flip;
            flip = (byte)(flipped ? 2 : 1);
            byte w = (byte)width;
            byte h = (byte)height;
            byte length = (byte)shader.Length;
            str = new byte[4] { flip, w, h, length };
            string ret = "^" + Encoding.UTF8.GetString(str);
            return ret + shader;
        }

        private static void createServerHud()
        {
            HudElem divider = NewHudElem();
            divider.X = -10;
            divider.Y = 67;
            divider.AlignX = HudElem.XAlignments.Left;
            divider.AlignY = HudElem.YAlignments.Bottom;
            divider.HorzAlign = HudElem.HorzAlignments.Left;
            divider.VertAlign = HudElem.VertAlignments.Bottom;
            divider.Alpha = 1;
            divider.HideWhenInMenu = true;
            divider.Foreground = false;
            divider.LowResBackground = true;
            divider.Sort = 4;
            divider.Font = HudElem.Fonts.HudBig;
            divider.FontScale = 6;
            //divider.SetShader("hud_iw5_divider", -200, 24);
            divider.SetText(createHudShaderString("hud_iw5_divider", true, 255, 24));

            for (int i = 0; i < 2; i++)
            {
                var bar = NewHudElem();
                bar.X = 45;
                if (i == 0) bar.Y = 7;
                else bar.Y = -2;
                bar.AlignX = HudElem.XAlignments.Left;
                bar.AlignY = HudElem.YAlignments.Bottom;
                bar.HorzAlign = HudElem.HorzAlignments.Left;
                bar.VertAlign = HudElem.VertAlignments.Bottom;
                bar.SetShader("white", 2, 5);
                bar.Alpha = .9f;
                bar.HideWhenInMenu = true;
                bar.Foreground = false;
                if (i == 0) bar.Color = new Vector3(1, .2f, .2f);
                else bar.Color = new Vector3(.2f, 1, .2f);

                scoreBars[i] = bar;
            }

            for (int i = 0; i < 2; i++)
            {
                var text = NewHudElem();
                text.X = 30;
                if (i == 0) text.Y = 14;
                else text.Y = 0;
                text.AlignX = HudElem.XAlignments.Left;
                text.AlignY = HudElem.YAlignments.Bottom;
                text.HorzAlign = HudElem.HorzAlignments.Left;
                text.VertAlign = HudElem.VertAlignments.Bottom;
                text.FontScale = 1f;
                text.Font = HudElem.Fonts.HudSmall;
                text.Alpha = 1f;
                text.HideWhenInMenu = true;
                text.Sort = 5;
                text.SetValue(0);

                scores[i] = text;
            }

            for (string s = "Allies"; ; s = "Axis")
            {
                var icon = NewTeamHudElem(s.ToLower());
                icon.X = -40;
                icon.Y = 24;
                icon.AlignX = HudElem.XAlignments.Left;
                icon.AlignY = HudElem.YAlignments.Bottom;
                icon.HorzAlign = HudElem.HorzAlignments.Left;
                icon.VertAlign = HudElem.VertAlignments.Bottom;
                icon.FontScale = 5;
                icon.Sort = 3;
                icon.HideWhenInMenu = true;
                string shader = GetDvar("g_teamIcon_" + s);
                icon.SetShader(shader, 48, 48);

                if (s == "Axis") break;
            }
        }

        private static void createHUD(Entity player)
        {
            if (player.HasField("hud_created"))
                return;

            HudElem divider = HudElem.CreateIcon(player, "hud_iw5_divider", 200, 24);
            divider.SetPoint("BOTTOMRIGHT", "BOTTOMRIGHT", -67, -20);
            divider.HideWhenInMenu = true;
            divider.Alpha = 1;
            divider.Archived = true;
            player.SetField("hud_divider", divider);
            divider.Sort = 1;

            // ammo stuff
            HudElem ammoSlash = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 1f);
            ammoSlash.SetPoint("bottom right", "bottom right", -150, -28);
            ammoSlash.HideWhenInMenu = true;
            ammoSlash.Archived = true;
            ammoSlash.LowResBackground = true;
            ammoSlash.AlignX = HudElem.XAlignments.Left;
            ammoSlash.Alpha = 1;
            ammoSlash.SetText("");
            ammoSlash.Sort = 0;

            HudElem ammoStock = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 1f);
            ammoStock.Parent = ammoSlash;
            ammoStock.SetPoint("bottom left", "bottom left", 8, 0);
            ammoStock.HideWhenInMenu = true;
            ammoStock.Archived = true;
            ammoStock.SetValue(0);
            ammoStock.Sort = 0;

            HudElem ammoClip = HudElem.CreateFontString(player, HudElem.Fonts.HudBig, 1f);
            ammoClip.Parent = ammoSlash;
            ammoClip.SetPoint("right", "right", -5, -4);
            ammoClip.HideWhenInMenu = true;
            ammoClip.Archived = true;
            ammoClip.SetValue(0);
            ammoClip.Sort = 0;

            HudElem weaponName = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 1f);
            weaponName.SetPoint("bottom right", "bottom right", -140, -8);
            weaponName.HideWhenInMenu = true;
            weaponName.Archived = true;
            weaponName.Alpha = 1;
            weaponName.SetText("Test");
            weaponName.Sort = 0;

            HudElem scoreArrow = HudElem.CreateIcon(player, "ui_arrow_right", 12, 12);
            scoreArrow.SetPoint("BOTTOMLEFT", "BOTTOMLEFT", 82, -38);//-24
            scoreArrow.HideWhenInMenu = true;
            scoreArrow.Alpha = 0;
            scoreArrow.Archived = true;
            scoreArrow.Color = new Vector3(.3f, 1, .3f);
            scoreArrow.Sort = 1;
            HudElem scoreArrowShadow = HudElem.CreateIcon(player, "ui_arrow_right", 16, 16);
            scoreArrowShadow.SetPoint("CENTER", "CENTER", -6, 0);
            scoreArrowShadow.HideWhenInMenu = true;
            scoreArrowShadow.Alpha = 0;
            scoreArrowShadow.Archived = true;
            scoreArrowShadow.Color = new Vector3(0, 0, 0);
            scoreArrowShadow.Sort = 0;
            scoreArrowShadow.Parent = scoreArrow;
            player.SetField("scoreArrow", scoreArrow);

            updateHUDAmmo(player);

            player.SetField("hud_weaponName", new Parameter(weaponName));
            player.SetField("hud_ammoClip", new Parameter(ammoClip));
            player.SetField("hud_ammoStock", new Parameter(ammoStock));
            player.SetField("hud_ammoSlash", new Parameter(ammoSlash));

            player.SetField("hud_created", true);
        }

        private static void destroyPlayerHud(Entity player)
        {
            HudElem[] hud = new HudElem[6] { player.GetField<HudElem>("hud_weaponName"),
            player.GetField<HudElem>("hud_ammoClip"),
            player.GetField<HudElem>("hud_ammoStock"),
            player.GetField<HudElem>("hud_ammoSlash"),
            player.GetField<HudElem>("hud_divider"),
            player.GetField<HudElem>("scoreArrow")};

            foreach (HudElem playerHud in hud)
            {
                if (playerHud.Children.Count != 0)
                {
                    foreach (HudElem child in playerHud.Children)
                        child.Destroy();
                }
                playerHud.Destroy();
            }
        }

        private static HudElem createBlastShieldOverlay(Entity player)
        {
            HudElem combatHighOverlay = NewClientHudElem(player);
            combatHighOverlay.X = 0;
            combatHighOverlay.Y = 0;
            combatHighOverlay.AlignX = HudElem.XAlignments.Left;
            combatHighOverlay.AlignY = HudElem.YAlignments.Top;
            combatHighOverlay.HorzAlign = HudElem.HorzAlignments.Fullscreen;
            combatHighOverlay.VertAlign = HudElem.VertAlignments.Fullscreen;
            combatHighOverlay.SetShader("nightvision_overlay_goggles", 640, 480);
            combatHighOverlay.Sort = -10;
            combatHighOverlay.Archived = true;
            combatHighOverlay.Alpha = 0;
            player.SetField("hud_overlay", combatHighOverlay);

            return combatHighOverlay;
        }
        private static void destroyBlastShieldOverlay(Entity player)
        {
            HudElem overlay = player.GetField<HudElem>("hud_overlay");
            overlay.Destroy();
            player.ClearField("hud_overlay");
        }

        private static void updateWeaponName(Entity player, string weapon)
        {
            HudElem weaponName = player.GetField<HudElem>("hud_weaponName");
            weaponName.Alpha = 1;
            weaponName.SetText(getWeaponName(player, weapon));
            AfterDelay(1000, () =>
            {
                weaponName.FadeOverTime(1);
                weaponName.Alpha = 0;
            });
        }

        private static void updateHUDAmmo(Entity player, bool updateName = false, string name = "")
        {
            if (!player.HasField("hud_created"))
                return;

            if (!player.IsAlive)
                return;

            var ammoStock = player.GetField<HudElem>("hud_ammoStock");
            var ammoClip = player.GetField<HudElem>("hud_ammoClip");
            var ammoSlash = player.GetField<HudElem>("hud_ammoSlash");
            var weaponName = player.GetField<HudElem>("hud_weaponName");
            var currentWeapon = player.CurrentWeapon;
            if (name != "") currentWeapon = name;


            if (currentWeapon == "riotshield_mp" || currentWeapon == "airdrop_marker_mp" || currentWeapon == "airdrop_sentry_marker_mp" || currentWeapon.Contains("killstreak") || currentWeapon == "none")
                ammoStock.Alpha = 0;
            else
            {
                ammoStock.Alpha = 1;
                ammoStock.SetValue(player.GetWeaponAmmoStock(currentWeapon));
            }
            if (currentWeapon == "riotshield_mp" || currentWeapon == "airdrop_marker_mp" || currentWeapon == "airdrop_sentry_marker_mp" || currentWeapon.Contains("killstreak") || currentWeapon == "none")
                ammoClip.Alpha = 0;
            else
            {
                ammoClip.Alpha = 1;
                ammoClip.SetValue(player.GetWeaponAmmoClip(currentWeapon));
            }
            if (currentWeapon == "riotshield_mp" || currentWeapon == "airdrop_marker_mp" || currentWeapon == "airdrop_sentry_marker_mp" || currentWeapon.Contains("killstreak") || currentWeapon == "none")
                ammoSlash.SetText("");
            else
                ammoSlash.SetText("/");

            if (updateName) updateWeaponName(player, currentWeapon);
        }
        private static string getWeaponName(Entity player, string name)
        {
            string baseName = "";
            string weapon = name;

            if (weapon.Contains("iw5_usp45_"))
                baseName = "USP .45";
            else if (weapon.Contains("iw5_44magnum_"))
                baseName = ".44 Magnum";
            else if (weapon.Contains("iw5_deserteagle_"))
                baseName = "Desert Eagle";
            else if (weapon.Contains("iw5_acr_"))
                baseName = "ACR";
            else if (weapon.Contains("iw5_type95_"))
                baseName = "FAMAS";
            else if (weapon.Contains("iw5_m4_"))
                baseName = "M4A1";
            else if (weapon.Contains("iw5_ak47_"))
                baseName = "AK-47";
            else if (weapon.Contains("iw5_m16_"))
                baseName = "M16A4";
            else if (weapon.Contains("iw5_mk14_"))
                baseName = "FAL";//M14 EBR
            else if (weapon.Contains("iw5_scar_"))
                baseName = "SCAR-H";
            else if (weapon.Contains("iw5_fad_"))
                baseName = "TAR-21";
            else if (weapon.Contains("iw5_mp5_"))
                baseName = "MP5K";
            else if (weapon.Contains("iw5_m9_"))
                baseName = "Mini-Uzi";
            else if (weapon.Contains("iw5_p90_"))
                baseName = "P90";
            else if (weapon.Contains("iw5_ump45_"))
                baseName = "UMP45";
            else if (weapon.Contains("iw5_g18_"))
                baseName = "G18";
            else if (weapon.Contains("iw5_mp9_"))
                baseName = "TMP";
            else if (weapon.Contains("iw5_skorpion_"))
                baseName = "PP2000";
            else if (weapon.Contains("iw5_spas12_"))
                baseName = "SPAS-12";
            else if (weapon.Contains("iw5_aa12_"))
                baseName = "AA-12";
            else if (weapon.Contains("iw5_striker_"))
                baseName = "Striker";
            else if (weapon.Contains("iw5_1887_"))
                baseName = "Model 1887";
            else if (weapon.Contains("iw5_sa80_"))
                baseName = "L86 LSW";
            else if (weapon.Contains("iw5_barrett_"))
                baseName = "Barrett 50.cal";
            else if (weapon.Contains("iw5_msr_"))
                baseName = "Intervention";
            else if (weapon == "rpg_mp")
                baseName = "RPG-7";
            else if (weapon == "javelin_mp")
                baseName = "Javelin";
            else if (weapon == "stinger_mp")
                baseName = "Stinger";
            else if (weapon == "iw5_smaw_mp")
                baseName = "AT4-HS";
            else if (weapon == "at4_mp")
                baseName = "AT4-HS";
            else if (weapon == "m320_mp")
                baseName = "Thumper";
            else if (weapon == "riotshield_mp")
                baseName = "Riot Shield";
            else if (weapon.Contains("iw5_usp45jugg_"))
                baseName = "USP.45";
            else if (weapon.Contains("iw5_mp412jugg_"))
                baseName = "44. Magnum";
            else if (weapon.Contains("iw5_m60jugg_") && weapon.Contains("_camo"))
                baseName = "AUG HBAR";
            else if (weapon.Contains("iw5_m60jugg_") && !weapon.Contains("_camo"))
                baseName = "MG4";
            else if (weapon.Contains("iw5_m60_"))
                baseName = "MG4";
            else if (weapon == "iw5_riotshieldjugg_mp")
                baseName = "Riot Shield";
            else if (weapon == "airdrop_marker_mp")
                baseName = "Care Package Marker";
            else if (weapon == "airdrop_sentry_marker_mp")
                baseName = "Sentry Airdrop Marker";

            string attachment = "";
            if (weapon.Split('_').Length > 3 && (weapon.StartsWith("iw5_") || weapon.StartsWith("alt_iw5_")))
            {
                if (player.HasPerk("specialty_bling"))
                    attachment = " Bling";
                else
                {
                    if (weapon.Contains("_reflex"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Red Dot Sight";
                    }
                    if (weapon.Contains("_acog"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " ACOG Sight";
                    }
                    if (weapon.Contains("_grip"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Grip";
                    }
                    if (weapon.Contains("_akimbo"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Akimbo";
                    }
                    if (weapon.Contains("_thermal"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Thermal Sight";
                    }
                    if (weapon.Contains("_shotgun"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " w/ Shotgun";
                    }
                    if (weapon.Contains("_heartbeat"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Heartbeat Sensor";
                    }
                    if (weapon.Contains("_xmags"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Extended Mags";
                    }
                    if (weapon.Contains("_rof"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Rapid Fire";
                    }
                    if (weapon.Contains("_eotech"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Holographic";
                    }
                    if (weapon.Contains("_tactical"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Tactical Knife";
                    }
                    if (weapon.Contains("_gl") || weapon.Contains("_gp25") || weapon.Contains("_m320"))
                    {
                        if (weapon.Contains("iw5_mk14_mp"))
                        {
                            if (attachment != "") attachment = " Bling";
                            else attachment = " Grenade Laucher";
                        }
                        else
                        {
                            if (attachment != "") attachment = " Bling";
                            else attachment = " Grenade Launcher";
                        }
                    }
                    if (weapon.Contains("_silencer"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " Silenced";
                    }
                    if (player.HasPerk("specialty_bulletpenetration"))
                    {
                        if (attachment != "") attachment = " Bling";
                        else attachment = " FMJ";
                    }
                }
            }
            return baseName + attachment;
        }
        private static void killstreakSwitcher(Entity player)
        {
            string weapon = player.CurrentWeapon;
            if (weapon.Contains("killstreak_") && !weapon.Contains("predator_missile") && !weapon.Contains("airstrike") && !weapon.Contains("ac130") && !weapon.Contains("osprey") && !weapon.Contains("bomber") && !weapon.Contains("mortar") && !weapon.Contains("tank") && !weapon.Contains("turret"))
            {
                AfterDelay(100, () =>
                player.SwitchToWeaponImmediate("killstreak_double_uav_mp"));
                AfterDelay(850, () =>
                  player.SwitchToWeapon(player.GetField<string>("lastDroppableWeapon")));
            }
        }
    }
}
