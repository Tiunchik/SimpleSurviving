using Game.Scripts.Tanks.Fire;
using Game.Scripts.Tanks.Turret;
using UnityEngine;

namespace Game.Scripts.Tanks
{
    public class TankController: MonoBehaviour, ITankController
    {
        
        private IFire _fire;
        private Collider2D _tankCollider2D;
        private Hull.Hull _hull;
        private ITurret _turret;

        private void Start()
        {
            _tankCollider2D = GetComponent<Collider2D>();
            _fire = Utils.Utils.findComponentInTree<IFire>(this);
            _fire.AddToIgnore(_tankCollider2D);
            _hull = GetComponent<Hull.Hull>();
            _turret = Utils.Utils.findComponentInTree<ITurret>(this);
        }

        public void Forward(float input)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * _hull.HullSpeed * input));
        }

        public void RotateHull(float input)
        {
            transform.Rotate(Vector3.back * (Time.deltaTime * _hull.HullRotationSpeed * input));
        }

        public void RotateTurret(float input)
        {
            _turret.Rotate(input);
        }

        public void Fire()
        {
            _fire.Fire();
        }
        
        
    }
}