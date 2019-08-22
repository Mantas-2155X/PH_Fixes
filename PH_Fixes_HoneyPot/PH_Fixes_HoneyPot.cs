using System;
using Studio;
using Harmony;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PH_Fixes {
    public class PH_Fixes_HoneyPot {
        //      lagfix      //
        [HarmonyPatch(typeof(ClassLibrary4.Class1), "OnLevelWasInitialized")]
        class Patch_ClassLibrary4_Class1_OnLevelWasInitialized {
            static bool Prefix(ClassLibrary4.Class1 __instance) {
                string sceneName = SceneManager.GetActiveScene().name;

                if (sceneName == "StartUpScene" || sceneName == "LogoScene" || sceneName == "CautionScene" || sceneName == "TitleScene" || sceneName == "UpDownLoader")
                    return false;

                return true;
            }
        }

        //      errorfix      //
        [HarmonyPatch(typeof(ClassLibrary4.HoneyPot), "setAccsShaders")]
        class Patch_ClassLibrary4_Class1_setAccsShaders {
            static bool Prefix(ClassLibrary4.HoneyPot __instance) {
                string scene = SceneManager.GetActiveScene().name;

                if (scene == "StartUpScene" || scene == "CautionScene" || scene == "LogoScene" || scene == "TitleScene" || scene == "UpDownLoader")
                    return false;

                return true;
            }
        }

        //      errorfix      //
        [HarmonyPatch(typeof(ClassLibrary4.HoneyPot), "setHairShaders", new Type[] { })]
        class Patch_ClassLibrary4_Class1_setHairShaders {
            static bool Prefix(ClassLibrary4.HoneyPot __instance) {
                string scene = SceneManager.GetActiveScene().name;

                if (scene == "StartUpScene" || scene == "CautionScene" || scene == "LogoScene" || scene == "TitleScene" || scene == "UpDownLoader")
                    return false;

                return true;
            }
        }

        //      errorfix      //
        [HarmonyPatch(typeof(ClassLibrary4.HoneyPot), "setItemShaders")]
        class Patch_ClassLibrary4_Class1_setItemShaders {
            static bool Prefix(ClassLibrary4.HoneyPot __instance) {
                var instance = Singleton<Studio.Studio>.Instance;

                if (instance != null)
                    return true;

                return false;
            }
        }

        //      errorfix      //
        [HarmonyPatch(typeof(ClassLibrary4.HoneyPot), "createCatecory")]
        class Patch_ClassLibrary4_Class1_createCatecory {
            static bool Prefix(ClassLibrary4.HoneyPot __instance) {
                var instance = Singleton<Info>.Instance;

                if (instance != null)
                    return true;

                return false;
            }
        }

        //      errorfix      //
        [HarmonyPatch(typeof(MaterialCustoms), "Setup")]
        class Patch_ClassLibrary4_Class1_Setup {
            static bool Prefix(MaterialCustoms __instance) {
                if (__instance == null)
                    return false;

                if (__instance.parameters == null)
                    return false;

                Renderer[] componentsInChildren = __instance.GetComponentsInChildren<Renderer>(true);

                if (componentsInChildren == null)
                    return false;

                __instance.datas = new MaterialCustoms.Data_Base[__instance.parameters.Length];

                if (__instance.datas == null)
                    return false;

                for (int i = 0; i < __instance.parameters.Length; i++) {
                    MaterialCustoms.Parameter parameter = __instance.parameters[i];

                    if (parameter == null)
                        return false;

                    if (parameter.type == MaterialCustoms.Parameter.TYPE.FLOAT01) {
                        __instance.datas[i] = new MaterialCustoms.Data_Float(parameter, componentsInChildren, 0f, 1f);
                    } else if (parameter.type == MaterialCustoms.Parameter.TYPE.FLOAT11) {
                        __instance.datas[i] = new MaterialCustoms.Data_Float(parameter, componentsInChildren, -1f, 1f);
                    } else if (parameter.type == MaterialCustoms.Parameter.TYPE.COLOR) {
                        __instance.datas[i] = new MaterialCustoms.Data_Color(parameter, componentsInChildren);
                    } else if (parameter.type == MaterialCustoms.Parameter.TYPE.ALPHA) {
                        __instance.datas[i] = new MaterialCustoms.Data_Alpha(parameter, componentsInChildren);
                    }
                }

                return false;
            }
        }
    }
}