using RoR2;
using UnityEngine;

namespace MinosMod.Survivors.Minos
{
    public static class MinosBuffs
    {
        public static BuffDef enrageBuff; //name: Exponential Potential
        public static BuffDef enrageBuffEnhanced; //name: By The Will

        public static void Init(AssetBundle assetBundle)
        {
            //enrageBuff = Modules.Content.CreateAndAddBuff("MinosArmorBuff",
            //    LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite,
            //    Color.white,
            //    false,
            //    false);
            //this is from the template

            enrageBuff = Modules.Content.CreateAndAddBuff("Exponential Potential", null, Color.cyan, false, false);

            enrageBuffEnhanced = Modules.Content.CreateAndAddBuff("By The Will", null, Color.blue, false, false);
        
        }
    }
}
