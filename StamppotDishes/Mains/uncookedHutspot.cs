using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

using StamppotDish;

namespace StamppotDishes.Mains.uncookedHutspot
{
    class UncookedChiliPot : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Hutspot";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncookedHutspot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override Item DisposesTo => Main.Pot;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.Pot
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 4,
                Min = 4,
                Items = new List<Item>()
                {
                    Main.TomatoSlice,
                    Main.TomatoSauce,
                    Main.OnionChopped,
                    Main.ChoppedPeppers
                }
            },
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 8,
                Process = Main.Cook,
                Result = Main.ChiliPot
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

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato/Liquid", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Tomato/Skin", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Soup");
            MaterialUtils.ApplyMaterial(Prefab, "Sauce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh 3");
            MaterialUtils.ApplyMaterial(Prefab, "Pepper", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Pepper 2", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Pepper 3", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Pepper 4", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh 2");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato/Inner", materials);

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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Sauce"),
                    Item = Main.TomatoSauce
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tomato"),
                    Item = Main.TomatoSlice
                },
                new()
                {
                    Objects = new()
                    {

                        GameObjectUtils.GetChildObject(prefab, "Pepper"),
                        GameObjectUtils.GetChildObject(prefab, "Pepper 2"),
                        GameObjectUtils.GetChildObject(prefab, "Pepper 3"),
                        GameObjectUtils.GetChildObject(prefab, "Pepper 4"),
                    },
                    Item = Main.ChoppedPeppers,
                    DrawAll = true
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onion"),
                    Item = Main.OnionChopped
                },
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
                    Item = Main.TomatoSauce,
                    Text = "Ts"
                },
                new()
                {
                    Item = Main.TomatoSlice,
                    Text = "T"
                },
                new()
                {
                    Item = Main.ChoppedPeppers,
                    Text = "P"
                },
                new()
                {
                    Item = Main.OnionChopped,
                    Text = "O"
                },
            };
        }
    }
}