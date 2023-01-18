﻿using Game.Scripts.Tanks.Ammo;
using UnityEngine;

namespace Game.Scripts.Tanks.Damages
{
    public class Health : MonoBehaviour, IDamageable
    {
        public int health = 100;
        public GameObject destroyAnimation;
        public AudioClip destroyAudio;

        public void TakeDamage(int damage, DamageType type)
        {
            if (type == DamageType.KINETIC)
                health -= (damage = (int)(damage * 1.5));
            else
                health -= damage;
            Debug.Log($"Health::TakeDamage # remainingHP={health} # incomeDMG={damage}, DMGType={type}");

            if (health < 0)
            {
                var destroyAnimationObj = Instantiate(destroyAnimation, transform.position, transform.rotation);
                Audio.Util.AddAudioToObject(destroyAudio, destroyAnimationObj);
                Destroy(gameObject);
            }
        }

        public int GetHealth() => health;
    }
}