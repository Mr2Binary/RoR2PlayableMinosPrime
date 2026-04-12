using EntityStates;
using MinosMod.Survivors.Minos;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace MinosMod.Survivors.Minos.SkillStates
{
    public class Dropkick : BaseSkillState
    {
        public static float duration = 2f;
        public static float delayPercent = 0.6f; //animation threshold to start the dash
        public static float brakePercent = 0.8f; //stopping midair
        public static float blinkSpeed = 240f; //speed of blink

        private bool hasBlinked;
        private bool hasBraked;
        private Vector3 blinkDirection;

        public static string dropkickSoundString = "mp_dropkick";
        public static float dodgeFOV = global::EntityStates.Commando.DodgeState.dodgeFOV;

        //soon to be deprecated variables, part of template logic
        private Animator animator;

        public override void OnEnter()
        {
            base.OnEnter();
            animator = GetModelAnimator();

            PlayAnimation("Combat, Override", "Dropkick", "Dropkick.playbackRate", duration);
            Util.PlaySound(dropkickSoundString, gameObject);

            if (isAuthority && inputBank)
            {
                blinkDirection = inputBank.aimDirection;
                blinkDirection.y = 0;
                blinkDirection.Normalize();
            }

            if (NetworkServer.active)
            {
                characterBody.AddTimedBuff(RoR2Content.Buffs.HiddenInvincibility, 0.5f * duration);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (fixedAge < duration * delayPercent)
            {
                if (characterMotor) characterMotor.velocity = Vector3.zero;
            }
            else if (fixedAge < duration * brakePercent)
            {
                if (!hasBlinked)
                {
                    hasBlinked = true;
                    if (isAuthority && inputBank) blinkDirection = inputBank.aimDirection.normalized;
                }

                if (isAuthority && characterMotor) characterMotor.velocity = blinkDirection * blinkSpeed;
            }
            else
            {
                if (!hasBraked)
                {
                    hasBraked = true;
                    if (isAuthority && characterMotor) characterMotor.velocity = Vector3.zero;
                }
            }

            if (isAuthority && fixedAge >= duration)
            {
                outer.SetNextStateToMain();
            }
        }

        public override void OnExit()
        {
            if (cameraTargetParams) cameraTargetParams.fovOverride = -1f;
            base.OnExit();

            characterMotor.disableAirControlUntilCollision = false;
        }

        public override void OnSerialize(NetworkWriter writer)
        {
            base.OnSerialize(writer);
        }

        public override void OnDeserialize(NetworkReader reader)
        {
            base.OnDeserialize(reader);
        }
    }
}