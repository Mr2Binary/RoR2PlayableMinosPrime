using MinosMod.Modules.BaseStates;
using RoR2;
using UnityEngine;

namespace MinosMod.Survivors.Minos.SkillStates
{
    public class PunchCombo : BaseMeleeAttack
    {
        public override void  OnEnter()
        {
            hitboxGroupName = "PunchGroup";

            damageType = DamageTypeCombo.GenericPrimary;
            damageCoefficient = MinosStaticValues.punchDamageCoefficient;
            procCoefficient = 1f;
            pushForce = 300f;
            bonusForce = Vector3.zero;
            baseDuration = 1f;

            //0-1 multiplier of baseduration, used to time when the hitbox is out (usually based on the run time of the animation)
            //for example, if attackStartPercentTime is 0.5, the attack will start hitting halfway through the ability. if baseduration is 3 seconds, the attack will start happening at 1.5 seconds
            attackStartPercentTime = 0.2f;
            attackEndPercentTime = 0.4f;

            //this is the point at which the attack can be interrupted by itself, continuing a combo
            earlyExitPercentTime = 1f;

            hitStopDuration = 0.012f;
            attackRecoil = 0.5f;
            hitHopVelocity = 4f;

            swingSoundString = "";
            hitSoundString = "";
            muzzleString = "";
            playbackRateParam = "Punch.playbackRate";
            swingEffectPrefab = MinosAssets.swordSwingEffect;
            hitEffectPrefab = MinosAssets.swordHitImpactEffect;

            impactSound = MinosAssets.swordHitSoundEvent.index;

            base.OnEnter();
        }

        protected override void PlayAttackAnimation()
        {
            string animationName = "Box" + (swingIndex + 1); //cycles thru animations Box1, 2 and 3

            PlayCrossfade("Combat, Override", animationName, playbackRateParam, duration, 0.05f);
            if (swingIndex == 0) Util.PlaySound("mp_thyend", gameObject);

            Debug.Log("PlayableMinosPrime: Playing" + animationName + " at index " + swingIndex);
        }

        protected override void PlaySwingEffect()
        {
            base.PlaySwingEffect();
        }

        protected override void OnHitEnemyAuthority()
        {
            base.OnHitEnemyAuthority();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}