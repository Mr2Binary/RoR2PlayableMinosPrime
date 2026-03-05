using RoR2;
using MinosMod.Modules.Achievements;

namespace MinosMod.Survivors.Minos.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, 10, null)]
    public class MinosMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = MinosSurvivor.MINOS_PREFIX + "masteryAchievement";
        public const string unlockableIdentifier = MinosSurvivor.MINOS_PREFIX + "masteryUnlockable";

        public override string RequiredCharacterBody => MinosSurvivor.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3;
    }
}