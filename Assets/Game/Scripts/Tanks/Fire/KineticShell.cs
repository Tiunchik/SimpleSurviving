using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Tanks.Fire
{
    public class KineticShell : MonoBehaviour
    {
        public int power = 1;
        public GameObject boom;

        private DamageType _damageType = DamageType.KINETIC;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 5);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.up * (power * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out IDamageable damage))
            {
                damage.TakeDamage(power, _damageType);
            }
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
