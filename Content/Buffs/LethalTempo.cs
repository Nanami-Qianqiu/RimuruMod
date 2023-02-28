using rail;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplateMod.Content.Buffs
{
    public class LethalTempo : ModBuff
    {
        int maxBuffTime = 60 * 3;
        public override void SetStaticDefaults()
        {
            DisplayName.AddTranslation(7, "致命节奏");
            Description.AddTranslation(7, "攻速增加");

            // 因为buff严格意义上不是一个TR里面自定义的数据类型，所以没有像buff.XXXX这样的设置属性方式了
            // 我们需要用另外一种方式设置属性
            // 这个属性决定buff在游戏退出再进来后会不会仍然持续，true就是不会，false就是会
            Main.buffNoSave[Type] = true;
            // 用来判定这个buff算不算一个debuff，如果设置为true会得到TR里对于debuff的限制，比如无法取消
            Main.debuff[Type] = false;
            // 决定这个buff能不能被被护士治疗给干掉，true是不可以，false则可以取消
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            // 决定这个buff是不是照明宠物的buff，以后讲宠物和召唤物的时候会用到的，现在先设为false
            Main.lightPet[Type] = false;
            // 决定这个buff会不会显示持续时间，false就是会显示，true就是不会显示，一般宠物buff都不会显示
            Main.buffNoTimeDisplay[Type] = false;
            // 决定这个buff在专家模式会不会持续时间加长，false是不会，true是会
            // 这个持续时间，专家翻倍，大师三倍
            //BuffID.Sets.LongerExpertDebuff[Type] = false;
            // 如果这个属性为true，pvp的时候就可以给对手加上这个debuff/buff
            Main.pvpBuff[Type] = false;
            // 决定这个buff是不是一个装饰性宠物，用来判定的，比如消除buff的时候不会消除它
            Main.vanityPet[Type] = false;
        }

        int BuffLayers = 1;
        public override void Update(Player player, ref int buffIndex)
        {
            if (BuffLayers <= 5) player.GetAttackSpeed(DamageClass.Melee) += 0.1f * BuffLayers;
            else player.GetAttackSpeed(DamageClass.Melee) += 0.5f + 0.05f * (BuffLayers - 5);
            if (player.buffTime[buffIndex] == 0) BuffLayers = 1;    
        }

        public override bool ReApply(Player player, int time, int buffIndex)
        {
            player.buffTime[buffIndex] = maxBuffTime;
            if (BuffLayers < 10) BuffLayers += 1;
            return true;
        }

    }
}
