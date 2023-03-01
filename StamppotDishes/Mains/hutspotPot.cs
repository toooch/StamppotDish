using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;


namespace StamppotDishes.Mains
{
    class hutspotPot : CustomItem
    {
        public override string UniqueNameID => "Hutspot";
        public override GameObject Prefab => Mod.bundle.LoadAsset<GameObject>("HutspotPot");
        public override Item DisposesTo => Mod.Pot;
        public override int SplitCount => 5;
        public override float SplitSpeed => 2f;
        public override Item SplitSubItem => Mod.hutspotPortion;
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            Mod.Pot
        };
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Metal"),
                   MaterialUtils.GetExistingMaterial("Carrot - Cooked")
             };
            MaterialUtils.ApplyMaterial(Prefab, "Pot", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "PotHandles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Carrot - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Carrot - Cooked", materials);

        }
    }
}