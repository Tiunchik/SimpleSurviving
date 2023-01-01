using System;
using UnityEditor;
using UnityEngine;

namespace Game.Scripts
{
    public class TankController: MonoBehaviour, ITankController
    {
        
        private IFire _fire;
        private Collider2D _tankCollider2D;
        private Hull _hull;
        private Turret _turret;

        private void Start()
        {
            _tankCollider2D = GetComponent<Collider2D>();
            _fire = Utils.findComponentInTree<IFire>(this);
            _fire?.AddToIgnore(_tankCollider2D);
            _hull = GetComponent<Hull>();
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
            
        }

        public void Fire()
        {
            _fire.Fire();
        }
        
        
    }
}