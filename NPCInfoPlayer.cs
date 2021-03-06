﻿using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace NPCInfo
{
    class NPCInfoPlayer : ModPlayer
    {
        private TagCompound npcInfoData;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (NPCInfo.instance.ToggleHotKeyNPCInfo.JustPressed)
            {
                NPCInfoUI.instance.ShowNPCInfo = !NPCInfoUI.instance.ShowNPCInfo;
            }
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                ["NPCInfoUI"] = NPCInfoUI.instance.Save(),
            };
        }

        public override void Load(TagCompound tag)
        {
            if (tag.ContainsKey("NPCInfoUI"))
            {
                if (tag.Get<object>("NPCInfoUI").GetType().Equals(typeof(TagCompound)))
                {
                    npcInfoData = tag.Get<TagCompound>("NPCInfoUI");
                }
            }
        }

        public override void OnEnterWorld(Player player)
        {
            NPCInfoUI.instance.InitializeUI();
            if (npcInfoData != null)
            {
                NPCInfoUI.instance.Load(npcInfoData);
            }
        }
    }
}
