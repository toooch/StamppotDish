using StamppotDishes.Customs;

using Kitchen;
using KitchenLib.References;
using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenLib.Colorblind;

using UnityEngine;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

using IngredientLib.Util;

using static KitchenData.ItemGroup;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.KitchenPropertiesUtils;
using TMPro;
using Object = UnityEngine.Object;

namespace StamppotDishes
{
    public class Main : BaseMod, IModSystem
    {
        // GUID must be unique and is recommended to be in reverse domain name notation
        // Mod Name is displayed to the player and listed in the mods menu
        // Mod Version must follow semver notation e.g. "1.2.3"
        public const string MOD_GUID = "Tooch.PlateUp.StamppotDishes";
        public const string MOD_NAME = "Stamppot Dishes";
        public const string MOD_VERSION = "0.0.1";
        public const string MOD_AUTHOR = "Tooch";
        public const string MOD_GAMEVERSION = ">=1.1.4";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.3" current and all future
        // e.g. ">=1.1.3 <=1.2.3" for all from/until

        public static AssetBundle Bundle;

        public Main() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        private void AddGameData()
        {
            // Hutspot
            AddGameDataObject<>();

        }
    }
}
