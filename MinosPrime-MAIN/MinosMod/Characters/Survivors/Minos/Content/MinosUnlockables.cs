using MinosMod.Survivors.Minos.Achievements;
using RoR2;
using UnityEngine;

namespace MinosMod.Survivors.Minos
{
    public static class MinosUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;

        public static void Init()
        {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                MinosMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(MinosMasteryAchievement.identifier),
                MinosSurvivor.instance.assetBundle.LoadAsset<Sprite>("texMasteryAchievement"));
        }
    }
}
