using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
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
            MaterialUtils.ApplyMaterial(Prefab, "PotHandles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Carrot");
            MaterialUtils.ApplyMaterial(Prefab, "Carrot", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Raw Potato");
            MaterialUtils.ApplyMaterial(Prefab, "Potato", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Onion/Ring 1", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Onion/Ring 2", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Onion/Ring 3", materials);

            Prefab.GetComponent<MyItemGroupView>()?.Setup(Prefab);
            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);

            }
        }
    }

    public class MyItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Carrot"),
                    Item = Main.ChoppedCarrot
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Potato"),
                    Item = Main.ChoppedPotato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onion"),
                    Item = Main.ChoppedOnion
                }
            };
            ComponentLabels = new()
            {
                new()
                {
                    Item = Main.Pot,
                    Text = ""
                },
                new()
                {
                    Item = Main.ChoppedCarrot,
                    Text = "C"
                },
                new()
                {
                    Item = Main.ChoppedPotato,
                    Text = "P"
                },
                new()
                {
                    Item = Main.ChoppedOnion,
                    Text = "O"
                },
            };
        }
    }
}
