using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Tanks.Fire
{
    public class SimpleFire : MonoBehaviour, IFire
    {
        public GameObject shell;
        public float posCorrections = 1;
    
        private Collider2D tankCollider2D;

        public void Fire()
        {
            var createdShell = Instantiate(shell, transform.position, transform.rotation);
            var ignoreList = createdShell.GetComponentsInChildren<Collider2D>();
            foreach (var children in ignoreList)
            {
                Physics2D.IgnoreCollision(children, tankCollider2D);
            }
            createdShell.transform.Translate(Vector3.up * posCorrections, Space.Self);
        }

        public void AddToIgnore(Collider2D rb)
        {
            tankCollider2D = rb;
        }
    }
}
