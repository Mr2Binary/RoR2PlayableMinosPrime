using RoR2;
using RoR2.Projectile;
using UnityEngine;
using MinosMod.Modules;
using System;

namespace MinosMod.Survivors.Minos
{
    public static class MinosAssets
    {
        // particle effects
        public static GameObject swordSwingEffect;
        public static GameObject swordHitImpactEffect;

        public static GameObject bombExplosionEffect;

        // networked hit sounds
        public static NetworkSoundEventDef swordHitSoundEvent;

        //projectiles
        public static GameObject bombProjectilePrefab;

        private static AssetBundle _assetBundle;

        public static void Init(AssetBundle assetBundle)
        {

            _assetBundle = assetBundle;

            swordHitSoundEvent = Content.CreateAndAddNetworkSoundEventDef("MinosSwordHit");

            CreateEffects();

            CreateProjectiles();
        }

        #region effects
        private static void CreateEffects()
        {
            CreateBombExplosionEffect();

            swordSwingEffect = _assetBundle.LoadEffect("MinosSwordSwingEffect", true);
            swordHitImpactEffect = _assetBundle.LoadEffect("ImpactMinosSlash");
        }

        private static void CreateBombExplosionEffect()
        {
            bombExplosionEffect = _assetBundle.LoadEffect("BombExplosionEffect", "MinosBombExplosion");

            if (!bombExplosionEffect)
                return;

            ShakeEmitter shakeEmitter = bombExplosionEffect.AddComponent<ShakeEmitter>();
            shakeEmitter.amplitudeTimeDecay = true;
            shakeEmitter.duration = 0.5f;
            shakeEmitter.radius = 200f;
            shakeEmitter.scaleShakeRadiusWithLocalScale = false;

            shakeEmitter.wave = new Wave
            {
                amplitude = 1f,
                frequency = 40f,
                cycleOffset = 0f
            };

        }
        #endregion effects

        #region projectiles
        private static void CreateProjectiles()
        {
            CreateBombProjectile();
            Content.AddProjectilePrefab(bombProjectilePrefab);
        }

        private static void CreateBombProjectile()
        {
            //highly recommend setting up projectiles in editor, but this is a quick and dirty way to prototype if you want
            bombProjectilePrefab = Asset.CloneProjectilePrefab("DaggerProjectile", "MicroMissileProjectile"); //property, id
            //daggerprojectile is a placeholder for now. contains correct homing properties for Minos's Snake, tho it freezes for a few ticks before chasing an enemy.
            //TODO: override and fix behavior

            //remove their ProjectileImpactExplosion component and start from default values
            UnityEngine.Object.Destroy(bombProjectilePrefab.GetComponent<ProjectileImpactExplosion>());
            ProjectileImpactExplosion bombImpactExplosion = bombProjectilePrefab.AddComponent<ProjectileImpactExplosion>();

            bombProjectilePrefab.GetComponent<Rigidbody>().useGravity = false;

            bombImpactExplosion.blastRadius = 16f;
            bombImpactExplosion.blastDamageCoefficient = 1f;
            bombImpactExplosion.falloffModel = BlastAttack.FalloffModel.None;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.lifetime = 20f;
            bombImpactExplosion.impactEffect = bombExplosionEffect;
            bombImpactExplosion.lifetimeExpiredSound = Content.CreateAndAddNetworkSoundEventDef("MinosBombExplosion");
            bombImpactExplosion.timerAfterImpact = true;
            bombImpactExplosion.lifetimeAfterImpact = 1f;

            Debug.Log("MinosMod: Snake Projectile initialized using LunarNeedle base.");

            ProjectileController bombController = bombProjectilePrefab.GetComponent<ProjectileController>();

            string snakeModelName = "mdlMinosSwingSnake";
            if (_assetBundle.LoadAsset<GameObject>("mdlMinosProjectileSnake") != null)
            {
                bombController.ghostPrefab = _assetBundle.CreateProjectileGhostPrefab("mdlMinosProjectileSnake");
            }
            else
            {
                Debug.LogError("MinosPrimeMod: Hm, could not find " + snakeModelName + " in AssetBundle.");
            }
            
            bombController.startSound = "";
        }
        #endregion projectiles
    }
}
