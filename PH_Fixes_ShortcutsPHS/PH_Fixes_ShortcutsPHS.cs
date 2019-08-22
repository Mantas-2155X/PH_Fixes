using Harmony;
using System.IO;

namespace PH_Fixes {
    public class PH_Fixes_ShortcutsPHS {
        //    errorfix    //
        [HarmonyPatch(typeof(ShortcutsPHS.BaseSettingsGo), "GetCusFemListFile")]
        class Patch_ShortcutsPHS_BaseSettingsGo_GetCusFemListFile {
            static bool Prefix(ShortcutsPHS.BaseSettingsGo __instance) {
                Traverse traverse = Traverse.Create(__instance);

                FileInfo file = new FileInfo(@"Plugins/ShortcutsPHS/Settings/" + traverse.Field("cusFemListFileName").GetValue<string>());
                if (!file.Exists) {
                    traverse.Method("resetCusFemList").GetValue();
                    return false;
                }

                return true;
            }
        }
    }
}