using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;
using StamppotDishes;

namespace StamppotDishes.Mains
{
    class StamppotDish : CustomDish
    {
        public override string UniqueNameID => "Stamppot";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Main.bundle.LoadAsset<GameObject>("StamppotIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        public override List<string> StartingNameSet => new List<string>
        {
            "Lick the Stamp and send it",
            "Stamp it"
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.hutspotPlated,
                Phase = MenuPhase.Main,
                Weight = 1,
            }
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            Main.Potato,
            Main.Carrot,
            Main.Onion,
            Main.Plate,
            Main.Pot
        };
    }
}
