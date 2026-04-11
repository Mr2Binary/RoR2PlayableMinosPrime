using BepInEx;
using MinosMod.Survivors.Minos;
using R2API.Utils;
using RoR2;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace MinosMod
{
    //[BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class MinosPlugin : BaseUnityPlugin
    {
        
        public const string MODUID = "com.mrbinary.MinosMod";
        public const string MODNAME = "Playable Minos Prime";
        public const string MODVERSION = "1.0.0";

        // a prefix for name tokens to prevent conflicts- please capitalize all name tokens for convention
        public const string DEVELOPER_PREFIX = "MRBINARY";

        public static MinosPlugin instance;

        void Awake()
        {
            instance = this;

            //easy to use logger
            Log.Init(Logger);

            // used when you want to properly set up language folders
            Modules.Language.Init();

            // character initialization
            new MinosSurvivor().Initialize();

            // make a content pack and add it. this has to be last
            new Modules.ContentPacks().Initialize();
        }
    }
}
