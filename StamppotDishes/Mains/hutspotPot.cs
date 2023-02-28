using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using static StamppotDishes.Mains.StamppotDish;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using Unity.Transforms;
using UnityEngine;

using IngredientLib.Util;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using StamppotDishes;

namespace StamppotDishes.Mains.Hutspot
{
    class hutspotPot : CustomItem
    {
        public override string UniqueNameID => "Hutspot";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("HutspotPot");
        public override Item DisposesTo => Main.Pot;
        public override int SplitCount => 5;
        public override float SplitSpeed => 2f;
        public override Item SplitSubItem => Main.hutspotPortion;
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            Main.Pot
        };
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Metal"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "Pot", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "PotHandles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Sauce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomatoes", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh 3");
            MaterialUtils.ApplyMaterial(Prefab, "Pepper", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);

        }
    }
}