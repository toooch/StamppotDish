using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;
using IngredientLib.Util;
using static UnityEngine.UIElements.UxmlAttributeDescription;

namespace StamppotDishes.Mains
{
    class hutspotPlated : CustomItemGroup
    {
        public override string UniqueNameID => "Plated Hutspot";
        public override GameObject Prefab => Mod.bundle.LoadAsset<GameObject>("PlatedHutspot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Item DisposesTo => Mod.Plate;
        public override Item DirtiesTo => Mod.DirtyPlate;
        public override string ColourBlindTag => "Hu";
        public override bool CanContainSide => true;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.Plate
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.hutspotPortion
                }
            }
        };
        public override void OnRegister(ItemGroup hutspotPlated)
        {
            GameObject hutspot = Prefab.GetChildFromPath("/UnityProject/Assets/Assets/Models/Prutje.fbx" );
            GameObject plate = Prefab.GetChildFromPath("Plate/Plate.001");

            
        }
           
        
    }
}
