using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;
using KitchenLib.Utils;
using IngredientLib.Util;

namespace StamppotDishes.Mains
{
    class StamppotDish : CustomDish
    {
        // Basic Dish properties
        public override string UniqueNameID => "Stamppot";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.bundle.LoadAsset<GameObject>("Prutje");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        // List of default restaurant names
        public override List<string> StartingNameSet => new List<string>
        {
            "Stamp it"
        };

        // default items corresponding with Dish
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.hutspotPlated,
                Phase = MenuPhase.Main,
                Weight = 1,
            }
        };

        // List of items necessary for menu
        public override HashSet<Item> MinimumIngredients => new()
        {
            Mod.Potato,
            Mod.Carrot,
            Mod.Onion,
            Mod.Plate,
            Mod.Pot
        };

        // List of processes necessary for menu
        public override HashSet<Process> RequiredProcesses => new()
        {
            Mod.Chop,
            Mod.Cook
        };

        // Text and properties of the menu recipe description
        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Grab a pot and add water. Combine chopped carrot, chopped potato and chopped onion and add to pot and cook. Makes several servings" }
        };

        // Text and properties of the menu card
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Hutspot", "Adds Hutspot as a Main", "Nothing better than a hotchpotch on a winter day") )
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            // References to Hutspot.fbx
            var hutspot = DisplayPrefab.GetChildFromPath("Prutje");
            var plate = DisplayPrefab.GetChildFromPath("Plate/Plate.001");

            // Visuals??
            
        }
    }
}

