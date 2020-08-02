using Harmony;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;

namespace NoPerformanceStats
{

    public static class BuildInfo
    {
        public const string Name = "NoPerformanceStats";
        public const string Author = "ImTiara";
        public const string Company = null;
        public const string Version = "1.0.0";
        public const string DownloadLink = null;
    }

    public class NoPerformanceStats : MelonMod
    {

        private HarmonyInstance harmonyInstance;
        private static bool allowPerformanceScanner;

        public override void OnApplicationStart()
        {
            ModPrefs.RegisterCategory("NoPerformanceStats", "No Performance Stats");
            ModPrefs.RegisterPrefBool("NoPerformanceStats", "Disable Performance Stats", true, "");

            LoadModPrefs();

            harmonyInstance = HarmonyInstance.Create("NoPerformanceStatsPatcher");

            try
            {
                MethodInfo[] methods = typeof(ObjectPublicAbstractSealedInObInObObObObUnique).GetMethods(BindingFlags.Public | BindingFlags.Static);
                for (int i = 0; i < methods.Length; i++)
                    if (methods[i].Name == "Method_Public_Static_IEnumerator_String_GameObject_AvatarPerformanceStats_0" || methods[i].Name == "Method_Public_Static_IEnumerator_GameObject_AvatarPerformanceStats_EnumPublicSealedvaNoExGoMePoVe7vUnique_MulticastDelegateNPublicSealedVoUnique_0" || methods[i].Name == "Method_Public_Static_Void_String_GameObject_AvatarPerformanceStats_0")
                        harmonyInstance.Patch(methods[i], new HarmonyMethod(typeof(NoPerformanceStats).GetMethod("CalculatePerformance", BindingFlags.Static | BindingFlags.NonPublic)), null, null);
            }
            catch(Exception e)
            {
                MelonModLogger.Log(ConsoleColor.Red, "Failed to patch Performance Scanners: " + e);
            }
        }

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.P))
            {
                ModPrefs.SetBool("NoPerformanceStats", "Disable Performance Stats", allowPerformanceScanner);
                LoadModPrefs();
                MelonModLogger.Log("Avatar Performance Stats is now " + (allowPerformanceScanner ? "ENABLED" : "DISABLED"));
            }
        }

        public override void OnModSettingsApplied() => LoadModPrefs();

        private void LoadModPrefs() => allowPerformanceScanner = !ModPrefs.GetBool("NoPerformanceStats", "Disable Performance Stats");

        private static bool CalculatePerformance() => allowPerformanceScanner;

    }

}