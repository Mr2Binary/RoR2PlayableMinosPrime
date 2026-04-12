using EntityStates;
using MinosMod.Survivors.Minos;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace MinosMod.Survivors.Minos.SkillStates
{
    public class Dropkick : BaseSkillState
    {
        public static float duration = 0.7f;
        public static float delayPercent = 0.4f; //animation threshold to start the dash
        public static float blitzSpeedCoefficient = 12f; //speed of dash

        private bool hasBlitzed;
        private Vector3 blitzDirection;

        public static string dropkickSoundString = "mp_dropkick";
        public static float dodgeFOV = global::EntityStates.Commando.DodgeState.dodgeFOV;

        //soon to be deprecated variables, part of template logic
        private float rollSpeed;
        private Vector3 forwardDirection;
        private Vector3 previousPosition;
        private Animator animator;

        public override void OnEnter()
        {
            base.OnEnter();
            animator = GetModelAnimator();

            //if (isAuthority && inputBank && characterDirection)
            //{
            //    forwardDirection = (inputBank.moveVector == Vector3.zero ? characterDirection.forward : inputBank.moveVector).normalized;
            //}

            //Vector3 rhs = characterDirection ? characterDirection.forward : forwardDirection;
            //Vector3 rhs2 = Vector3.Cross(Vector3.up, rhs);

            //float num = Vector3.Dot(forwardDirection, rhs);
            //float num2 = Vector3.Dot(forwardDirection, rhs2);

            //RecalculateRollSpeed();

            //if (characterMotor && characterDirection)
            //{
            //    characterMotor.velocity.y = 0f;
            //    characterMotor.velocity = forwardDirection * rollSpeed;
            //}

            //Vector3 b = characterMotor ? characterMotor.velocity : Vector3.zero;
            //previousPosition = transform.position - b;

            PlayAnimation("Combat, Override", "Dropkick", "Dropkick.playbackRate", duration);
            Util.PlaySound(dropkickSoundString, gameObject);

            if (isAuthority && inputBank)
            {
                blitzDirection = inputBank.aimDirection;
                blitzDirection.y = 0;
                blitzDirection.Normalize();
            }

            if (NetworkServer.active)
            {
                characterBody.AddTimedBuff(RoR2Content.Buffs.HiddenInvincibility, 0.5f * duration);
            }
        }

        //private void RecalculateRollSpeed()
        //{
        //    rollSpeed = moveSpeedStat * Mathf.Lerp(initialSpeedCoefficient, finalSpeedCoefficient, fixedAge / duration);
        //}

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            //crouching. freezes minos in place.
            if (fixedAge < duration * delayPercent)
            {
                if (characterMotor) characterMotor.velocity = Vector3.zero;
            }
            else
            {
                if (!hasBlitzed)
                {
                    hasBlitzed = true;
                    Util.PlaySound("mp_dropkick_launch", gameObject);
                    if (isAuthority && characterDirection) characterDirection.forward = blitzDirection;
                }

                //blitz towards mouse/aim direction
                if (characterMotor && isAuthority)
                {
                    characterMotor.velocity = blitzDirection * (moveSpeedStat * blitzSpeedCoefficient);
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
            writer.Write(forwardDirection);
        }

        public override void OnDeserialize(NetworkReader reader)
        {
            base.OnDeserialize(reader);
            forwardDirection = reader.ReadVector3();
        }
    }
}