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
using System;

namespace StamppotDishes
{
    public class Mod : BaseMod, IModSystem
    {
        // GUID must be unique and is recommended to be in reverse domain name notation
        // Mod Name is displayed to the player and listed in the mods menu
        // Mod Version must follow semver notation e.g. "1.2.3"
        public const string MOD_GUID = "Tooch.PlateUp.StamppotDishes";
        public const string MOD_NAME = "Stamppot Dishes";
        public const string MOD_VERSION = "0.0.3";
        public const string MOD_AUTHOR = "Tooch#4004, Dirk.#4004";
        public const string MOD_GAMEVERSION = ">=1.1.4";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.3" current and all future
        // e.g. ">=1.1.3 <=1.2.3" for all from/until

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        public static AssetBundle bundle;

#if DEBUG
        public const bool DEBUG_MODE = true;
#else
        public const bool DEBUG_MODE = false;
#endif

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

        protected void AddGameData()
        {
            LogInfo("Attempting to register game data...");
            
            AddGameDataObject<hutspotPlated>();
            AddGameDataObject<hutspotPortion>();
            AddGameDataObject<hutspotPot>();
            AddGameDataObject<StamppotDish>();
            AddGameDataObject<uncookedHutspot>();

            LogInfo("Done loading game data.");
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

            AddGameData();

            // Add event to hutspotPot to knead, disabled for ease
            // !!! vgm is dit voor het aanpassen van bestaande dingen, zal wss überhaupt niet nodig zijn!
            /*Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                hutspotPot.DerivedProcesses.Add(new Item.ItemProcess()
                {
                    Process = Knead,
                    Result = hutspotPot,
                    Duration = 2f
                });
            };*/

        }






        // stuff to easily get data from mod or base game

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

        // Stuff for logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }

    }
}
