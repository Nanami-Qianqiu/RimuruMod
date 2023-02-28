using IL.Terraria.Localization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplateMod.Content.Items.Weapons
{
    public class TemplateSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TemplateSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            DisplayName.AddTranslation(7, "ģ�彣");
            Tooltip.SetDefault("This is a basic modded sword.");
        }

        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.Register();
        }
    }
}