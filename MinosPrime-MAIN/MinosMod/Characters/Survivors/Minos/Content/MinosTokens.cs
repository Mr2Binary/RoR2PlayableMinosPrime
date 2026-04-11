using System;
using MinosMod.Modules;
using MinosMod.Survivors.Minos.Achievements;

namespace MinosMod.Survivors.Minos
{
    public static class MinosTokens
    {
        public static void Init()
        {
            AddMinosTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("Minos.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
        }

        public static void AddMinosTokens()
        {
            string prefix = MinosSurvivor.MINOS_PREFIX;

            string desc = "When Minos Prime bellows \"DIE!\", this alludes to the fact that he will kill you. This effect is best observed on Brutal Difficulty.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > His passive is great for players who love to take risks. Take advantage of the reward and be careful." + Environment.NewLine + Environment.NewLine
             + "< ! > His boxing combo can be chained thrice in succession, which will increase the damage of the Hold Version. Hold the skill to charge up an uppercut." + Environment.NewLine + Environment.NewLine
             + "< ! > The snake Minos throws travels fast and deals high damage." + Environment.NewLine + Environment.NewLine
             + "< ! > Judgement is a devastatingly powerful utility with a high base cooldown. Feel the power at the press of a key. Have fun!" + Environment.NewLine + Environment.NewLine
             + "< ! > His Rider Kick / Ground Slam is a great way to ground yourself quickly (as long as you're within range) whilst also dealing good damage to enemies around you." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left this godforsakened land, looking to rebuild the City of Lust anew.";
            string outroFailure = "...The King could only ask for forgiveness from his children, as he failed to bring them salvation from this cold, dark world.";

            Language.Add(prefix + "NAME", "Minos Prime");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "King of Lust");
            Language.Add(prefix + "LORE", "sample lore");
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            Language.Add(prefix + "MASTERY_SKIN_NAME", "The Corpse of King Minos");
            #endregion

            #region Passive
            Language.Add(prefix + "PASSIVENAME", "Exponential Potential");
            Language.Add(prefix + "PASSIVEDESC", $"<style=cIsUtility>Semicorporeal Acrobatics</style>: Minos Prime takes <style=cIsHealth>no fall damage</style>. \n<style=cIsUtility>Exponential Potential</style>: While below <style=cIsHealth>50% health</style>, gain <style=cIsDamage>35% increased stats</style>. Below <style=cIsHealth>20% health</style>, cooldowns are reduced.");
            #endregion

            #region Primary
            Language.Add(prefix + "PRIMARYNAME", "Prepare Thyself!");
            Language.Add(prefix + "PRIMARYDESC", Tokens.agilePrefix + $"Minos Punches for <style=cIsDamage>{100f * MinosStaticValues.punchDamageCoefficient}% damage</style>.");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARYNAME", "Thy End Is Now!");
            Language.Add(prefix + "SECONDARYDESC", $"Minos rears his fist backwards and launches a snake for <style=cIsDamage>{460f * MinosStaticValues.gunDamageCoefficient}% damage</style>. When held, he kicks twice for 2x420% damage and then throws a snake.");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITYNAME", "JUDGEMENT!");
            Language.Add(prefix + "UTILITYDESC", Tokens.agilePrefix + $" Minos Prime tucks himself and then blitzes across the battlefield, landing a devastating dropkick that deals <style=cIsDamage>{1000f * MinosStaticValues.gunDamageCoefficient}% damage</style> " +
                $"in a large explosion through sheer force of will.");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIALNAME", "Rider Kick | Ground Slam");
            Language.Add(prefix + "SPECIALDESC", Tokens.agilePrefix + $" While in midair, Minos slams either downwards or towards the location of the crosshair for <style=cIsDamage>{100f * MinosStaticValues.bombDamageCoefficient}% damage</style>.");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(MinosMasteryAchievement.identifier), "Minos Prime: Ascended");
            Language.Add(Tokens.GetAchievementDescriptionToken(MinosMasteryAchievement.identifier), "Beat the game or obliterate on Monsoon as Minos Prime.");
            #endregion
        }
    }
}
