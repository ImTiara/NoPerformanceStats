using Harmony;
using MelonLoader;
using System;
using System.Reflection;
using VRCSDK2.Validation.Performance;

namespace NoPerformanceStats
{
    public static class BuildInfo
    {
        public const string Name = "NoPerformanceStats";
        public const string Author = "ImTiara";
        public const string Company = null;
        public const string Version = "1.0.3";
        public const string DownloadLink = "https://github.com/ImTiara/NoPerformanceStats/releases";
    }

    public class NoPerformanceStats : MelonMod
    {

        private HarmonyInstance _harmonyInstance;

        private static bool allowPerformanceScanner;

        public override void OnApplicationStart()
        {
            _harmonyInstance = HarmonyInstance.Create("NoPerformanceStatsPatcher");

            MelonPreferences.CreateCategory(GetType().Name, "No Performance Stats");
            MelonPreferences.CreateEntry(GetType().Name, "DisablePerformanceStats", true, "Disable Performance Stats");

            LoadModPrefs();

            try
            {
                _harmonyInstance.Patch(
                    typeof(AvatarPerformance).GetMethod(nameof(AvatarPerformance.Method_Public_Static_IEnumerator_String_GameObject_AvatarPerformanceStats_0), BindingFlags.Public | BindingFlags.Static),
                    new HarmonyMethod(typeof(NoPerformanceStats).GetMethod(nameof(NoPerformanceStats.CalculatePerformance), BindingFlags.Static | BindingFlags.NonPublic)), null, null
                );
            }
            catch(Exception e) { MelonLogger.Error("Failed to patch Performance Scanner: " + e); }
        }
        
        public override void OnPreferencesSaved()
            => LoadModPrefs();

        private void LoadModPrefs()
            => allowPerformanceScanner = !MelonPreferences.GetEntryValue<bool>(GetType().Name, "DisablePerformanceStats");

        private static bool CalculatePerformance()
            => allowPerformanceScanner;

    }

}
