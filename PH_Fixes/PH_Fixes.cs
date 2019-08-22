using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Harmony;
using IllusionPlugin;

namespace PH_Fixes {
    public class PH_Fixes : IPlugin {
        public string Name {
            get {
                return "Playhome Fixes";
            }
        }

        public string Version {
            get {
                return "1.0";
            }
        }

        public void OnFixedUpdate() {
        }

        public void OnLevelWasInitialized(int level) {
        }

        public void OnLevelWasLoaded(int level) {
        }

        public void OnUpdate() {
        }

        public void OnApplicationQuit() {
        }

        public string[] unique = { 
            "DemonFusion.dll",
            "HooahHome.dll"
        };

        public void OnApplicationStart() {
            Console.WriteLine($"PH_Fixes: Loading fixes..");

            HarmonyInstance harmony = HarmonyInstance.Create("PH_Fixes.PH_Fixes");

            int totalFixes = 0;
            int appliedFixes = 0;

            DirectoryInfo fixesDirInfo = new DirectoryInfo(@"Plugins\PH_Fixes\");
            DirectoryInfo pluginsDirInfo = new DirectoryInfo(@"Plugins\");

            foreach (FileInfo fileF in fixesDirInfo.GetFiles()) {
                totalFixes += 1;

                if (fileF.Name == "PH_Fixes_Game.dll") {
                    Assembly assembly = Assembly.LoadFrom(fileF.FullName);
                    harmony.PatchAll(assembly);

                    appliedFixes += 1;
                    continue;
                }

                foreach (FileInfo fileP in pluginsDirInfo.GetFiles()) { 
                    if (fileP.Name == fileF.Name.Substring(9)) {
                        Assembly assembly = Assembly.LoadFrom(fileF.FullName);
                        harmony.PatchAll(assembly);

                        if (unique.Contains(fileP.Name)) {
                            Type t = assembly.GetType("PH_Fixes." + fileF.Name.Substring(0, fileF.Name.Length - 4));
                            MethodInfo m = t.GetMethod("LoadPatch");
                            m.Invoke(null, new object[] { });
                        }

                        appliedFixes += 1;
                    }
                }
            }
            Console.WriteLine($"PH_Fixes: Applied {appliedFixes} / {totalFixes} fixes!");
        }
    }
}