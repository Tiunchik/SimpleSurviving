using Game.Scripts.Tanks.Damages;
using UnityEngine;

namespace Game.Scripts.Tanks.Ammo
{
    public class KineticShellBehavior : MonoBehaviour
    {
        public int power = 1;
        public GameObject boom;
        public DamageType damageType = DamageType.KINETIC;


        void Start()
        {
            Destroy(gameObject, 5);
        }

        void Update()
        {
            transform.Translate(Vector3.up * (power * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out IDamageable damage))
            {
                damage.TakeDamage(power, damageType);
            }
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
