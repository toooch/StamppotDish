using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace StamppotDishes.Mains
{
    class uncookedHutspot : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Hutspot";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncookedHutspot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override Item DisposesTo => Main.Pot;
        public override string ColourBlindTag => "Hu";



        public override List<ItemSet> Sets => new List<ItemSet>()
        {   
            new ItemSet()
            { 
               Max = 2,
               Min = 2,
               IsMandatory = true,
               Items = new List<Item>()
               {
                   Main.Pot,
                   Main.Water
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
                Process = Main.Cook
            },
            new Item.ItemProcess()
            {
                Duration = 3,
                Process = Main.Knead,
                Result = Main.hutspotPot
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Metal"),
            };

            MaterialUtils.ApplyMaterial(Prefab, "Pot", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "PotHandles", materials)
        }
    }
}
