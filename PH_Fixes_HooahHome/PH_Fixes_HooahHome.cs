using Harmony;

namespace PH_Fixes {
    public class PH_Fixes_HooahHome {
        //     errorfix     //
        public static bool HooahHome_PostReadLineRegex_Patch() {
            Studio.Info instance = Singleton<Studio.Info>.Instance;

            if (instance == null)
                return false;

            if (instance.dicItemGroup == null)
                return false;

            return true;
        }

        public static void LoadPatch() {
            var type = typeof(HooahHome.Hooah).Assembly.GetType("HooahHome.CategoryReader");

            var original = type.GetMethod("PostReadLineRegex");
            var prefix = typeof(PH_Fixes_HooahHome).GetMethod("HooahHome_PostReadLineRegex_Patch");

            var harmony = HarmonyInstance.Create("HooahHome.CategoryReader");
            harmony.Patch(original, new HarmonyMethod(prefix), null);
        }
    }
}