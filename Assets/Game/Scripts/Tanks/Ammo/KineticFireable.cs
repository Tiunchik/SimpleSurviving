using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Tanks.Ammo
{
    public class KineticFireable : MonoBehaviour, IFireable
    {
        public float maxFireRatePerSec = 60;
        public GameObject shell;
        public AudioClip gunShootSound;
        public float posCorrections = 1;
    
        private Collider2D ignoreCreatorTankCollider;
        private Cooldown fireCooldown;

        private void Start() {
            fireCooldown = new(s: 60 / maxFireRatePerSec);
            // gunShootSound = AudioManager.INST.AddAudioToObject(Audio.WorldSound.SINGLE_GUN_SHOT, this.gameObject);
            // gunShootSound = AudioManager.INST.AddAudioToObject(Audio.Lib.Music.MAIN_MENU_1, this.gameObject);
        }
        private void FixedUpdate() {
            fireCooldown.Update(Time.fixedDeltaTime);
        }

        public void Fire()
        {
            if(fireCooldown.IsRun) return;

            var createdShell = Instantiate(shell, transform.position, transform.rotation);
            var ignoreList = createdShell.GetComponentsInChildren<Collider2D>();
            foreach (var children in ignoreList)
            {
                Physics2D.IgnoreCollision(children, ignoreCreatorTankCollider);
            }
            createdShell.transform.Translate(Vector3.up * posCorrections, Space.Self);

            fireCooldown.Run();
            // Debug.Log($"audio={gunShootSound.clip}");
            // gunShootSound.Play();
            Audio.Util.CreateLocalAudioObject(gunShootSound, createdShell.transform.position);
        }

        public void AddToIgnore(Collider2D rb)
        {
            ignoreCreatorTankCollider = rb;
        }
    }
}
