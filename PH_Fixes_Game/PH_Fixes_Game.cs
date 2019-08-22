using Harmony;

namespace PH_Fixes {
    public class PH_Fixes_Game {
        //    FasterLoad    //
        [HarmonyPatch(typeof(CautionScene), "Start")]
        class Patch_CautionScene_Start {
            static void Prefix(CautionScene __instance) {
                __instance.fadeInTime = 0.1f; // 1s -> 0.1s
            }
        }

        //    FasterLoad    //
        [HarmonyPatch(typeof(CautionScene), "Update")]
        class Patch_CautionScene_Update {
            static void Prefix(CautionScene __instance) {
                __instance.fadeOutTime = 0.1f; // 1s -> 0.1s
            }
        }

        //    FasterLoad    //
        [HarmonyPatch(typeof(LogoScene), "Start")]
        class Patch_LogoScene_Start {
            static void Prefix(LogoScene __instance) {
                __instance.fadeInTime = 0.1f; // 1s -> 0.1s
            }
        }

        //    FasterLoad    //
        [HarmonyPatch(typeof(LogoScene), "Update")]
        class Patch_LogoScene_Update {
            static void Prefix(LogoScene __instance) {
                __instance.fadeOutTime = 0.1f; // 1s -> 0.1s
                __instance.endTime = 0.1f; // 3s -> 0.1s
            }
        }

        //    FasterLoad    //
        [HarmonyPatch(typeof(TitleScene), "Start")]
        class Patch_TitleScene_Start {
            static void Prefix(TitleScene __instance) {
                __instance.fadeInTime = 0.1f; // 1s -> 0.1s
            }
        }

        //    FasterLoad    //
        [HarmonyPatch(typeof(TitleScene), "Update")]
        class Patch_TitleScene_Update {
            static void Prefix(TitleScene __instance) {
                __instance.titleCallTime = 0.1f; // 2s -> 0.1s
            }
        }
    }
}