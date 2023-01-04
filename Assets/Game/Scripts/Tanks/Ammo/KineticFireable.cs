using UnityEngine;

namespace Game.Scripts.Tanks.Ammo
{
    public class KineticFireable : MonoBehaviour, IFireable
    {
        public GameObject shell;
        public float posCorrections = 1;
    
        private Collider2D ignoreCreatorTankCollider;

        public void Fire()
        {
            var createdShell = Instantiate(shell, transform.position, transform.rotation);
            var ignoreList = createdShell.GetComponentsInChildren<Collider2D>();
            foreach (var children in ignoreList)
            {
                Physics2D.IgnoreCollision(children, ignoreCreatorTankCollider);
            }
            createdShell.transform.Translate(Vector3.up * posCorrections, Space.Self);
        }

        public void AddToIgnore(Collider2D rb)
        {
            ignoreCreatorTankCollider = rb;
        }
    }
}
