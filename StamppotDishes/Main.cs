using StamppotDishes.Mains;

using KitchenLib.References;
using KitchenLib;
using KitchenMods;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;

using UnityEngine;

using System.Linq;
using System.Reflection;




namespace StamppotDishes
{
    public class Main : BaseMod, IModSystem
    {
        // GUID must be unique and is recommended to be in reverse domain name notation
        // Mod Name is displayed to the player and listed in the mods menu
        // Mod Version must follow semver notation e.g. "1.2.3"
        public const string MOD_GUID = "Tooch.PlateUp.StamppotDishes";
        public const string MOD_NAME = "Stamppot Dishes";
        public const string MOD_VERSION = "0.0.3";
        public const string MOD_AUTHOR = "Tooch";
        public const string MOD_GAMEVERSION = ">=1.1.4";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.3" current and all future
        // e.g. ">=1.1.3 <=1.2.3" for all from/until

        public Main() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        public static AssetBundle bundle;

        // Processes
        internal static Process Cook => GetExistingGDO<Process>(ProcessReferences.Cook);
        internal static Process Chop => GetExistingGDO<Process>(ProcessReferences.Chop);
        internal static Process Knead => GetExistingGDO<Process>(ProcessReferences.Knead);
        internal static Process Oven => GetExistingGDO<Process>(ProcessReferences.RequireOven);

        // Base game stuff
        internal static Item Pot => GetExistingGDO<Item>(ItemReferences.Pot);
        internal static Item Water => GetExistingGDO<Item>(ItemReferences.Water);
        internal static Item Plate => GetExistingGDO<Item>(ItemReferences.Plate);
        internal static Item DirtyPlate => GetExistingGDO<Item>(ItemReferences.PlateDirty);


        internal static Item Potato => GetExistingGDO<Item>(ItemReferences.Potato);
        internal static Item ChoppedPotato => GetExistingGDO<Item>(ItemReferences.PotatoChopped);
        internal static Item Carrot => GetExistingGDO<Item>(ItemReferences.Carrot);
        internal static Item ChoppedCarrot => GetExistingGDO<Item>(ItemReferences.CarrotChopped);
        internal static Item Onion => GetExistingGDO<Item>(ItemReferences.Onion);
        internal static Item ChoppedOnion => GetExistingGDO<Item>(ItemReferences.OnionChopped);

        // Custom stuff
        internal static Dish StamppotDish => GetModdedGDO<Dish, StamppotDish>();
        internal static Item hutspotPot => GetModdedGDO<Item, hutspotPot>();
        internal static Item hutspotPortion => GetModdedGDO<Item, hutspotPortion>();
        internal static Item hutspotPlated => GetModdedGDO<Item, hutspotPlated>();
        internal static Item uncookedHutspot => GetModdedGDO<Item, uncookedHutspot>();

        new void OnPostActivate(Mod mod)
        {
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

            //Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            //{
            //
            //}

            
            AddGameDataObject<hutspotPlated>();
            AddGameDataObject<hutspotPortion>();
            AddGameDataObject<hutspotPot>();
            AddGameDataObject<StamppotDish>();
            AddGameDataObject<uncookedHutspot>();

        }








        private static T1 GetModdedGDO<T1, T2>() where T1 : GameDataObject
        {
            return (T1)GDOUtils.GetCustomGameDataObject<T2>().GameDataObject;
        }
        private static T GetExistingGDO<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }
        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }
        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }
    }
}
