using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace MinosMod.Survivors.Minos.Components
{
    internal class MinosPassiveComponent : MonoBehaviour, IOnIncomingDamageServerReceiver, IOnKilledServerReceiver
    {
        private CharacterBody body;
        private HealthComponent healthComponent;
        private void Awake()
        {
            body = GetComponent<CharacterBody>();
            healthComponent = GetComponent<HealthComponent>();
            
            if (body)
            {
                body.bodyFlags |= CharacterBody.BodyFlags.IgnoreFallDamage;
            }
        }

        private void FixedUpdate()
        {
            if (!NetworkServer.active) return;

            float hpPercent = healthComponent.combinedHealthFraction;

            HandleBuffRequirement(hpPercent < 0.5f, MinosBuffs.enrageBuff);
            HandleBuffRequirement(hpPercent < 0.2f, MinosBuffs.enrageBuffEnhanced);
        }

        private void HandleBuffRequirement(bool condition, BuffDef buff)
        {
            if (condition && !body.HasBuff(buff))
            {
                body.AddBuff(buff);
                if (buff == MinosBuffs.enrageBuff) Util.PlaySound("mp_useless", gameObject);
                if (buff == MinosBuffs.enrageBuffEnhanced) Util.PlaySound("mp_weak", gameObject);
            }
            else if (!condition && body.HasBuff(buff))
            {
                body.RemoveBuff(buff);
            }
        }

        public void OnIncomingDamageServer(DamageInfo damageInfo)
        {
            if ((damageInfo.damageType.damageType & DamageType.FallDamage) != 0)
            {
                damageInfo.damage = 0;
                damageInfo.rejected = true;
            }
        }

        //death sound.
        public void OnKilledServer(DamageReport damageReport)
        {
            Util.PlaySound("mp_preparethyself", gameObject);
        }

        public static BuffDef enrageBuff;
        public static BuffDef enrageBuffEnhanced;
    }
}