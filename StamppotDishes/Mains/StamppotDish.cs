using KitchenData;
using KitchenLib.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StamppotDishes.Mains
{
    class StamppotDish : CustomDish
    {
        public override string UniqueNameID => "Stamppot";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("StamppotIcon");
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
                
            }
        }
    }
}
