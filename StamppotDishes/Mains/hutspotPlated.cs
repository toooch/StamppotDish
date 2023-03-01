using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using KitchenLib.Utils;
using UnityEngine;
using static KitchenData.ItemGroup;

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
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.hutspotPortion,
                    Mod.Plate
                }
            },
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                  MaterialUtils.GetExistingMaterial("Plate"),
                  MaterialUtils.GetExistingMaterial("Plate - Ring")
        };
            MaterialUtils.ApplyMaterial(Prefab, "Carrot - Cooked", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Carrot - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Carrot - Cooked", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);
        }
    }
}
