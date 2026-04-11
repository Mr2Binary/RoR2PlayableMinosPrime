//
//
//





//devnote: THIS IS UNUSED RIGHT NOW AS IM STILL FIGURING OUT THE TEMPLATE LOGIC. monkey brain.






//
//
//


using EntityStates;
using MinosMod.Modules.BaseStates;
using RoR2;
using UnityEngine;

namespace MinosMod.Modules.BaseStates
{
    public abstract class BaseCombo : BaseSkillState
    {
        //this class serves as the superclass for Minos Prime's punch and kick combos.
        //(if i can figure it out 30 minutes from now) this class will be referrenced in Punch and KickCombo.

        //static vars will persist across all instances of this state.
        protected static int comboIndex = 0;
        protected float comboResetTime = 3f; //combo resets after float seconds of not attacking.
        protected static float lastAttackTime;

        protected float duration;
        protected float baseDuration = 1.0f;

        public override void OnEnter()
        {
            base.OnEnter();
            duration = baseDuration / attackSpeedStat;

            //check if combo should reset based on time
            if (Time.time - lastAttackTime > comboResetTime) comboIndex = 0;
            
            PlayComboAnimation();

            //preparing for the next hit
            lastAttackTime = Time.time;
            IncrementCombo();
        }

        //all children (e.g PunchCombo and KickCombo) will implement this to play their respective animations. epic.
        protected abstract void PlayComboAnimation();
        protected void IncrementCombo()
        {
            comboIndex++;
            if (comboIndex > 2) comboIndex = 0; //loops box1, box2, box3
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (fixedAge >= duration && isAuthority)
            {
                outer.SetNextStateToMain();
            }
        }
    }
}

//recycled from previous change
//protected override void PlayAttackAnimation()
//        //holy mother of god how do you reference two classes
//        protected override void PlayComboAnimation()
//{
//    PlayAnimation("Combat, Override", "Box1" + (1 + swingIndex), playbackRateParam, duration, 0.1f * duration);
//    string animationName = "Box" + (comboIndex + 1);

//    PlayAnimation("Combat, Override", animationName, "Punch.playbackRate", duration);

//    Debug.Log("PlayableMinosPrime: Playing combo step" + (comboIndex + 1));

//    IncrementCombo();
//}