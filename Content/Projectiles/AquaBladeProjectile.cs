using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TemplateMod.Content.IDs;
using Microsoft.Xna.Framework;

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
            Projectile.width = 12; // The width of projectile hitbox
            Projectile.height = 12; // The height of projectile hitbox
            Projectile.scale = 1.5f;
            Projectile.aiStyle = -1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 10   ; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 0; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            Projectile.light = 0.5f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0; // Set to above 0 if you want the projectile to update multiple time in a frame
            
        }

        public override void AI()
        {

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, MyDustId.BlueMagic, 0f, 0f, 100, default(Color), 1.2f);
            // 粒子特效不受重力
            dust.noGravity = true;
            Projectile.rotation = Projectile.velocity.ToRotation(); // projectile faces sprite right
        }   


    }
}