using Game.Scripts.Tanks.Ammo;
using UnityEngine;

namespace Game.Scripts.Tanks.Damages
{
    public class Health : MonoBehaviour, IDamageable
    {
        public int health = 100;
        public GameObject destroyAnimation;
        public AudioClip destroyAudio;
        // public GameObject deadObjectPrefab; // todo - impl

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
                // if (destroyAudio != null) 
                // Audio.Util.AddAudioToObject(destroyAudio, destroyAnimationObj);
                Audio.Util.CreateLocalAudioObject(destroyAudio, transform.position);
                Destroy(gameObject);

                // // var t = new Audio.Event().PlayMainMenuTheme = new UnityEvent<WorldAudioAssetDefinition>();
                // var listener = (temp) =>{};
                // Audio.Event.PlayMainMenuTheme.AddListener(listener);
                // // Audio.Event.PlayMainMenuTheme.AddListener((temp) =>{});
                // Audio.Event.PlayMainMenuTheme.RemoveListener(listener);

                // Audio.Event.PlayMainMenuTheme.Invoke(null);

                // Audio.Event.MainTheme.Play.Invoke(null);
            }
        }

        public int GetHealth() => health;
    }
}