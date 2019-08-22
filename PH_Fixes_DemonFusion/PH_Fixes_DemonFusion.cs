using Harmony;
using UnityEngine;

namespace PH_Fixes {
    public class PH_Fixes_DemonFusion {
        //     errorfix     //
        public static bool DemonFusion_Initialize_Patch() {
            var scene = GameObject.Find("Scene");

            if (scene == null)
                return false;

            if (scene.GetComponent<H_Scene>() == null)
                return false;

            return true;
        }

        public static void LoadPatch() {
            var type = typeof(DemonFusion.DemonFusionPlugin).Assembly.GetType("DemonFusion.Utility");

            var original = type.GetMethod("Initialize");
            var prefix = typeof(PH_Fixes_DemonFusion).GetMethod("DemonFusion_Initialize_Patch");

            var harmony = HarmonyInstance.Create("DemonFusion.Utility");
            harmony.Patch(original, new HarmonyMethod(prefix), null);
        }
    }
}