using Harmony;
using System.Linq;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace PH_Fixes {
    public class PH_Fixes_ProjectHighHeel {
        //     errorfix     // BAD, NEED TO INSERT NULLCHECK INSTEAD!! //
        [HarmonyPatch(typeof(ProjectHighHeel.HighHeelRuntime), "UIinputs")]
        class Patch_HighHeelRuntime_UIinputs {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
                var il = instructions.ToList();

                var targetIndex = il.FindIndex(instruction => instruction.opcode == OpCodes.Ret);

                if (targetIndex > 0) {
                    il[targetIndex - 1].opcode = OpCodes.Nop;
                    il[targetIndex - 2].opcode = OpCodes.Nop;
                    il[targetIndex - 3].opcode = OpCodes.Nop;
                    il[targetIndex - 4].opcode = OpCodes.Nop;
                    il[targetIndex - 5].opcode = OpCodes.Nop;
                    il[targetIndex - 6].opcode = OpCodes.Nop;
                    il[targetIndex - 7].opcode = OpCodes.Nop;
                    il[targetIndex - 8].opcode = OpCodes.Nop;
                    il[targetIndex - 9].opcode = OpCodes.Nop;
                    il[targetIndex - 10].opcode = OpCodes.Nop;
                    il[targetIndex - 11].opcode = OpCodes.Nop;
                    il[targetIndex - 12].opcode = OpCodes.Nop;
                }

                return il;
            }
        }
    }
}