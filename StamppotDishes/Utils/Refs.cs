using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamppotDishes.Utils
{
    internal class Refs
    {
        public static Item Potato => Find<Item>(ItemReferences.Potato);
        public static Item ChoppedPotato => Find<Item>(ItemReferences.PotatoChopped);
        public static Item Carrot => Find<Item>(ItemReferences.Carrot);
        public static Item ChoppedCarrot => Find<Item>(ItemReferences.CarrotChopped);
        public static Item Onion => Find<Item>(ItemReferences.Onion);
        public static Item ChoppedOnion => Find<Item>(ItemReferences.OnionChopped);


        // Stuff to handle finding items
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

        private static Appliance.ApplianceProcesses FindApplianceProcess<C>() where C : CustomSubProcess
        {
            ((CustomApplianceProccess)CustomSubProcess.GetSubProcess<C>()).Convert(out var process);
            return process;
        }
    }
}
