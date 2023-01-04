﻿using Game.Scripts.Enums;
using Game.Scripts.Tanks.Fire;
using UnityEngine;

namespace Game.Scripts.Tanks.Hull
{
    public class Health: MonoBehaviour, IDamageable
    {
        public int health = 100;
        public GameObject destroyAnimation;
        public void TakeDamage(int damage, DamageType type)
        {
            if (type == DamageType.KINETIC)
            {
                health -= (int)(damage * 1.5);
                Debug.Log($"TAKE KINETIC DAMAGE {health}");
            }
            else
            {
                health -= damage;
                Debug.Log($"TAKE ANY DAMAGE {health}");
            }
            if (health < 0)
            {
                Instantiate(destroyAnimation, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        public int GetHealth()
        {
            return health;
        }
    }
}