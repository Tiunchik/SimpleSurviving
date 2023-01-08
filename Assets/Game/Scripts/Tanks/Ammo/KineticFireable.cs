using UnityEngine;

namespace Game.Scripts.Tanks.Ammo
{
    public class KineticFireable : MonoBehaviour, IFireable
    {
        public float maxFireRatePerSec = 60;
        public GameObject shell;
        public float posCorrections = 1;
    
        private Collider2D ignoreCreatorTankCollider;
        private Utils.Cooldown fireCooldown;
        // private Utils.CooldownCorotune fireCooldown;

        private void Start() {
            fireCooldown = new(s: 60 / maxFireRatePerSec);
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
        }

        public void AddToIgnore(Collider2D rb)
        {
            ignoreCreatorTankCollider = rb;
        }
    }
}
