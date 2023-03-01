/*
 * 这是一个基本枪械类武器的例子
 */

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

// 注意这里命名空间变了，多了个.Items
// 因为这个文件在Items文件夹，而读取图片的时候是根据命名空间读取的，如果写错了可能图片就读不到了
// 跟那把剑一样，后面我就不说了
namespace TemplateMod.Content.Items.Weapons
{
    // 保证类名跟文件名一致，这样也方便查找
    public class TemplateGun : ModItem 
    {


        // 设置物品名字，描述的地方
        public override void SetStaticDefaults() 
        {
            base.SetStaticDefaults();

            // 这个是物品名字，也就是忽略游戏语言的情况下显示的文字
            DisplayName.SetDefault("Pistol");
            // 推荐通过AddTranslation的方式添加其在切换到中文的时候显示中文名字
            // 这里的7代指中文，你也可以用 (int)GameCulture.CultureName.Chinese，就是长了点......
            // 还有个更长的：GameCulture.FromCultureName(GameCulture.CultureName.Chinese)
            DisplayName.AddTranslation(7, "手枪");

            // 物品的描述，加入换行符 '\n' 可以多行显示哦
            Tooltip.SetDefault("Nothing more...");
            // 同理，我们加一个中文的翻译（？？？我们不本来就是中国人？
            Tooltip.AddTranslation(7, "没什么特别的");
        }

        // 最最最重要的物品基本属性部分
        public override void SetDefaults() {
            // 伤害！知道该做什么了吧，后面这个值随便改吧，但是不要超过2147483647
            // 不然…… 你试试就知道了
            Item.damage = 10;

            // 击退，你懂的，但是这个击退有个上限就是20.0f，超过20击退效果跟20没什么区别
            // 后面的 'f' 表示这是个小数，0.25
            Item.knockBack = 0.25f;

            // 物品的基础暴击几率，比正常物品少了 4% 呢（注意：玩家默认拥有4%暴击率）
            Item.crit = 96;

            // 物品的稀有度，由-1到11越来越高（还有-11、-12、-13三个特殊稀有度），具体参考维基百科或者我的博客
            // Item.rare = 1; 这种是魔法值写法，不推荐
            Item.rare = ItemRarityID.Green;

            // 攻击速度和攻击动画持续时间！
            // 这个数值越低越快，因为TR游戏速度每秒是60帧，这里的10就是
            // 10.0 / 60.0 = 0.1666... 秒使用1次！也就是一秒6次
            // 一般来说我们要把这两个值设成一样，但也有例外的时候，我们以后会讲
            Item.useTime = 20;
            Item.useAnimation = 20;

            // 使用方式，这个值决定了武器使用时到底是按什么样的动画播放
            // 0 或 None 代表......字面意思，就是啥都没有！你写了之后甚至无法使用！
            // 1 或 Swing 代表挥动，也就是剑类武器！
            // 2 或 EatFood 代表像食物一样，拥有物品，手持，放在盘子上三帧的贴图，具体可见exmod里头的🥧（派）
            // 3 或 Thrust 代表像1.3的同志短剑一样刺x 出去（也就是朝左或右刺出）（如果你想要写全方位刺出的剑，那你还是得看exmod）
            // 4 或 HoldUp 唔，这个一般不是用在武器上的，想象一下生命水晶使用的时候的动作
            // 5 或 Shoot 手持，枪、弓、法杖类武器的动作，用途最广
            // 6 或 DrinkLong 代表直接猛喝，感兴趣可以自己看看，挺好玩的（
            // 7 或 DrinkOld 代表1.3的喝药水动作，这个用在剑上不太好吧？
            // 8 或 GolfPlay 代表高尔夫球杆的动作
            // 9 或 DrinkLiquid 代表1.4的喝药水动作，相比1.3的来说，这个动作的手臂更加流畅，持握位置会在瓶口
            // 10 或 HiddenAnimation 代表使用时无动画
            // 11 或 MowTheLawn 代表割草机的动作，神奇，这玩意还有单独的动作
            // 12 或 Guitar 代表常春藤、雨之歌等物品的动作，对这玩意也是单独的动作（爱抚剑ing
            // 13 或 Rapier 代表标尺、星光等武器的动作
            // 14 或 RaiseLamp 代表夜光的动作，好吧这也单独写一个动作的吗？话说这玩意翻译过来叫吊灯......夜光大吊灯（bushi
            // Item.useStyle = 1; 这种是魔法值写法，不推荐
            Item.useStyle = ItemUseStyleID.Shoot;

            // 决定了这个武器鼠标按住不放能不能一直攻击， true代表可以
            // （我就是要按废你的鼠标！
            Item.autoReuse = true;

            // 决定了这个武器的伤害属性，
            // Default 代表无属性（也就是不吃任何加成）
            // Generic 代表全属性（也就是全部加成都吃）
            // MagicSummonHybrid 代表什么我不知道，但是可以同时吃到魔法和召唤加成
            // MeleeNoSpeed 代表近战，但是不吃攻速加成
            // Melee 代表近战
            // Ranged 代表远程
            // Magic 代表膜法，不，魔法
            // Summon 代表召唤
            // SummonMeleeSpeed 代表额......看看鞭子吧，可以吃到近战和召唤加成
            // Throwing 代表投掷（没错虽然1.4没了投掷武器，但是这个类型还在！）
            Item.DamageType = DamageClass.Ranged;

            // 物品的价格，这里用sellPrice，也就是卖出物品的价格作为基准
            // 这件物品卖出时会获得 0白金 1金 60银 0铜 这么多的钱 （就这？
            // 直接写一个数字则为购买时的价格，出售的价格会在这个基础上/5
            // 例：Item.value = 1919810; 购买：1铂金 91金 98银 10铜、出售：38金 39银 62铜
            Item.value = Item.sellPrice(0, 1, 0, 0);

            // 设置这个物品使用时发出的声音，以后会讲到怎么调出其他声音
            // 在这里我用的是开枪的声音
            Item.UseSound = SoundID.Item36;

            // 物品的碰撞体积大小，可以与贴图无关，但是建议设为跟贴图一样的大小
            // 不然鬼知道会不会发生奇怪的事情（无所谓的）
            Item.width = 24;
            Item.height = 24;

            // 让它变小一点
            Item.scale = 0.85f;

            // 最大堆叠数量，唔，对于一般武器来说，即使你堆了99个，使用的时候还是只有一个的效果
            Item.maxStack = 1;

            //-------------------------------------------------------------------------
            // 接下来就是枪械武器独特的属性

            // noMelee代表这个武器使用的时候贴图会不会造成伤害
            // 如果你希望开枪的时候你的手枪还能敲在敌人头上就把它设为false
            // 反正我不希望：（，就当枪本身没有伤害吧
            Item.noMelee = true;

            // 决定枪射出点什么和射出的速度的量
            // 这里我让枪射出子弹，并且以 （7像素 / 帧） 的速度射出去
            //Item.shoot = ModContent.ProjectileType<Content.Projectiles.TestProjectile>();
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 100f;
            Item.useAmmo = AmmoID.Bullet;

            // 选择这个枪射出（的时候消耗什么作为弹药，这里选择子弹
            // 你也可以删（或者注释）掉这一句，这样枪就什么都不消耗了
            //【重要】如果设置了消耗什么弹药，那么之前shoot设置的值就会被弹药物品的属性所覆盖
            // 也就是说，你到底射出的是什么就由弹药决定了！
            //Item.useAmmo = AmmoID.Bullet;

            // 好了，到这里差不多就是一个普通的枪需要填写的属性了
            // 至于更高级的枪怎么制作，嘿嘿，往后看吧。
        }


        // 控制这把枪使用时候的重写函数
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return true;
        }

        //控制这把枪是否可以发射的重写函数
        public override bool CanShoot(Player player)
        {
            return true;
        }

        //控制这把枪所射出去的弹幕的一些属性
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            base.ModifyShootStats(player, ref position, ref velocity, ref type, ref damage, ref knockback);
        }

        // 物品合成表的设置部分
        // 我没有写，这部分由你写
        public override void AddRecipes() 
        {
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 1)
                .Register();
        }

    }
}
