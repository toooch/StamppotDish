using KitchenData;
using KitchenLib.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace StamppotDishes.Mains
{
    class hutspotPlated : CustomItemGroup
    {
        public override string UniqueNameID => "Uncooked Hutspot";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncookedHutspot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => Main.Pot;
        public override string ColourBlindTag => "Hu";

        public override ItemStorage ItemStorageFlags => new ItemStorage.Dish;


        public override List<ItemSet> Sets => new List<ItemSet>()
        {   
            new ItemSet()
            { 
               Max = 1,
               Min = 1,
               IsMandatory = true,
               Items = new List<Item>()
               {
                   Main.Pot
               }
            },            
            
            new ItemSet()
            {
                Max = 3,
                Min = 3,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.ChoppedCarrot,
                    Main.ChoppedPotato,
                    Main.ChoppedOnion
                }
            },
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess()
            {
                Duration = 5,
                Process = Main.Cook,
                Result = Main.hutspotPot
            }
        }
    }
}
