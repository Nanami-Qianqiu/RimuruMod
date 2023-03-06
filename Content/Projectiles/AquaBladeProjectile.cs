using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TemplateMod.Content.IDs;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace TemplateMod.Content.Projectiles
{
    public class AquaBladeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AquaBlade's projectile"); // The English name of the projectile
        }

        public override void SetDefaults()
        {
            Projectile.width = 18; // The width of projectile hitbox
            Projectile.height = 18; // The height of projectile hitbox
            Projectile.scale = 1f;
            Projectile.aiStyle = -1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 10; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 0; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            Projectile.light = 0.5f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0; // Set to above 0 if you want the projectile to update multiple time in a frame
            DrawOffsetX = -6;
            DrawOriginOffsetY = -6;
        }

        public override void AI()
        {

            //Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, MyDustId.BlueMagic, 0f, 0f, 100, default(Color), 1.3f);
            // 粒子特效不受重力
            //dust.noGravity = true;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2; // projectile sprite faces up
            Projectile.ai[0] += 1;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            //Vector2 position = target.Center;
            //dust = Main.dust[Terraria.Dust.NewDust(position, 1      , 13, 172, 5.1162796f, 0.23255825f, 0, new Color(255, 255, 255), 0.87209296f)];
            //dust.noGravity = true;
            //dust.shader = GameShaders.Armor.GetSecondaryShader(85, Main.LocalPlayer);
            //dust.fadeIn = 0.41860467f;
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.Center, 1, 1
                , 172, (int)Projectile.velocity.X * 0.3f, (int)Projectile.velocity.Y * 0.3f, 0, default(Color), 1.1f);
                // 粒子特效不受重力
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(85, Main.LocalPlayer);
                dust.fadeIn = 0.57f;  
            }
        }
    }


}