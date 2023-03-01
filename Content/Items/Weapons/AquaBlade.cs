using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplateMod.Content.Items.Weapons
{
    public class AquaBlade : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AquaBlade");
            DisplayName.AddTranslation(7, "水刃");
            Tooltip.AddTranslation(7, "可以发射出超高速锋利的水刃");
        }
        public override void SetDefaults()
        {
            // 伤害！想都不要想，后面这个值随便改吧，但是不要超过2147483647
            // 不然…… 你试试就知道了
            Item.damage = 50;
            Item.crit = 30;
            Item.mana = 5;

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
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;

            // 物品的碰撞体积大小，可以与贴图无关，但是建议设为跟贴图一样的大小
            // 不然鬼知道会不会发生奇怪的事情
            Item.width = 40;
            Item.height = 40;

            // 攻击速度和攻击动画持续时间！
            // 这个数值越低越快，因为TR游戏速度每秒是60帧，这里的20就是
            // 20.0 / 60.0 = 0.333 秒挥动一次！也就是一秒三次
            // 一般来说我们要把这两个值设成一样，但也有例外的时候，我们以后会讲
            Item.useTime = 10;
            Item.useAnimation = 10;

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

            // 把 Item.staff 那行注释前面的“//”删去并将 Item.useStyle = ItemUseStyleID.Swing 改为 Item.useStyle = ItemUseStyleID.Shoot 看看会发生什么？
            // 想一想这一般是什么武器的做法？
            //Item.staff[Item.type] = true;

            // 击退，你懂的，但是这个击退有个上限就是20，超过20击退效果跟20没什么区别
            // 后面的 'f' 表示这是个浮点数：8.25，但是这个'f'不可省略
            Item.knockBack = 3f;

            // 物品的价格，这里用sellPrice，也就是卖出物品的价格作为基准
            // 这件物品卖出时会获得 0白金 1金 60银 0铜 这么多的钱 （就这？
            // 直接写一个数字则为购买时的价格，出售的价格会在这个基础上/5
            // 例：Item.value = 1919810; 购买：1铂金 91金 98银 10铜、出售：38金 39银 62铜
            Item.value = Item.sellPrice(0, 1, 60, 0);

            // 物品的稀有度，由-1到11越来越高（还有-11、-12、-13三个特殊稀有度），具体参考维基百科
            //https://terraria.wiki.gg/zh/wiki/%E7%A8%80%E6%9C%89%E5%BA%A6 或者裙中世界的补充栏目
            // Item.rare = 1; 这种是魔法值写法，不推荐
            Item.rare = ItemRarityID.LightRed; //我相信您应该可以熟练的使用诸如度娘、鼓哥等翻译，这里我便不再多解释

            // 设置这个物品使用时发出的声音，以后会讲到怎么调出其他声音
            // 在这里我用的是普通的挥剑声音
            Item.UseSound = SoundID.Item87; //95 84 109 87

            // 射出泰拉剑气
            Item.shoot = ModContent.ProjectileType<Content.Projectiles.AquaBladeProjectile>();
            //这里是剑气的飞行速度，这里的意思是以 （7像素 / 帧） 的速度射出去
            Item.shootSpeed = 15f;

            // 决定了这个武器鼠标按住不放能不能一直攻击， true代表可以, false代表不行
            // （鼠标别按废了
            Item.autoReuse = true;
            Item.useTurn = true;
            
        }

    }
}
