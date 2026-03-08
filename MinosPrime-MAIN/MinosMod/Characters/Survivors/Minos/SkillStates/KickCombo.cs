using MinosMod.Modules.BaseStates;
using RoR2;
using UnityEngine;

namespace MinosMod.Survivors.Minos.SkillStates
{
    public class KickCombo : BaseMeleeAttack
    {
        public override void  OnEnter()
        {
            hitboxGroupName = "KickGroup";

            damageType = DamageTypeCombo.GenericPrimary;
            damageCoefficient = MinosStaticValues.punchDamageCoefficient;
            procCoefficient = 1f;
            pushForce = 300f;
            bonusForce = Vector3.zero;
            baseDuration = 1f;

            attackStartPercentTime = 0.2f;
            attackEndPercentTime = 0.4f;

            earlyExitPercentTime = 0.9f;

            hitStopDuration = 0.012f;
            attackRecoil = 0.5f;
            hitHopVelocity = 4f;

            swingSoundString = "";
            hitSoundString = "";
            muzzleString = "";
            playbackRateParam = "Kick.playbackRate";
            swingEffectPrefab = MinosAssets.swordSwingEffect; //TODO: change
            hitEffectPrefab = MinosAssets.swordHitImpactEffect; //TODO: change

            impactSound = MinosAssets.swordHitSoundEvent.index; //TODO: change

            base.OnEnter();
            Blink(100f); //prepare thyself skdoosh
        }

        protected override void PlayAttackAnimation()
        {
            string animationName = "Kick" + (swingIndex + 1); //cycles thru animations Kick1 and 2

            PlayCrossfade("Combat, Override", animationName, playbackRateParam, duration, 0.05f);

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