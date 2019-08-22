using Harmony;

namespace PH_Fixes {
    public class PH_Fixes_PHSAddon {
        //    errorfix    //
        [HarmonyPatch(typeof(PHSAddon.MMD_VmdCameraLoad), "getAnimationFrame")]
        class Patch_PHSAddon_MMD_VmdCameraLoad_getAnimationFrame {
            static bool Prefix(PHSAddon.MMD_VmdCameraLoad __instance, float __result) {
                if (__instance.hsvmdanimationController == null) {
                    __result = 0f;
                    return false;
                }

                return true;
            }
        }
    }
}