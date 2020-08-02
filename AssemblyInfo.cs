using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(NoPerformanceStats.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(NoPerformanceStats.BuildInfo.Company)]
[assembly: AssemblyProduct(NoPerformanceStats.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + NoPerformanceStats.BuildInfo.Author)]
[assembly: AssemblyTrademark(NoPerformanceStats.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(NoPerformanceStats.BuildInfo.Version)]
[assembly: AssemblyFileVersion(NoPerformanceStats.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonModInfo(typeof(NoPerformanceStats.NoPerformanceStats), NoPerformanceStats.BuildInfo.Name, NoPerformanceStats.BuildInfo.Version, NoPerformanceStats.BuildInfo.Author, NoPerformanceStats.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonModGame("VRChat", "VRChat")]