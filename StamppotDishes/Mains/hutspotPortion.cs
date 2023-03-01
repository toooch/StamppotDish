using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StamppotDishes.Mains
{
    class hutspotPortion : CustomItem
    {
        public override string UniqueNameID => "Hutspot Portion";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("HutspotPortion");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Plate"),
            };
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Sauce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Tomato 2", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Onion 2", materials);
        }
    }
}
