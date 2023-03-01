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
        public override GameObject Prefab => Mod.bundle.LoadAsset<GameObject>("UncookedHutspot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override Item DisposesTo => Mod.Pot;
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
                   Mod.Pot,
                   Mod.Water
               }
            },            
            
            new ItemSet()
            {
                Max = 3,
                Min = 3,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.ChoppedCarrot,
                    Mod.ChoppedPotato,
                    Mod.ChoppedOnion
                }
            },
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess()
            {
                Duration = 5,
                Process = Mod.Cook,
                Result = Mod.hutspotPot
            }/*,
            new Item.ItemProcess()
            {
                Duration = 3,
                Process = Mod.Knead,
                Result = Mod.hutspotPot
            }*/
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
                    Item = Mod.ChoppedCarrot
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Potato"),
                    Item = Mod.ChoppedPotato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onion"),
                    Item = Mod.ChoppedOnion
                }
            };
            ComponentLabels = new()
            {
                new()
                {
                    Item = Mod.Pot,
                    Text = ""
                },
                new()
                {
                    Item = Mod.ChoppedCarrot,
                    Text = "C"
                },
                new()
                {
                    Item = Mod.ChoppedPotato,
                    Text = "P"
                },
                new()
                {
                    Item = Mod.ChoppedOnion,
                    Text = "O"
                },
            };
        }
    }
}
