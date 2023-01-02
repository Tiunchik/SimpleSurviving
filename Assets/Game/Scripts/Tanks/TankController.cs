using Game.Scripts.Tanks.Fire;
using Game.Scripts.Tanks.Turret;
using UnityEngine;

namespace Game.Scripts.Tanks
{
    public class TankController : MonoBehaviour, ITankController
    {
        
        private TreeComponentStore tcs = new();
        private BoxCollider2D tankCollider2D{get => tcs.Get<BoxCollider2D>();}
        private Hull hull {get => tcs.Get<Hull>();}
        private Turret turret{get => tcs.Get<Turret>();}
        private IFire fire{get => tcs.Get<IFire>();}

        private void Start()
        {
            Debug.Log("TankController:Start() # RUN");

            tcs.Start(this.gameObject);

            // tankCollider2D = tcs.Get<BoxCollider2D>();
            // turret = tcs.Get<Turret>();
            // fire = tcs.Get<IFire>();
            // hull = tcs.Get<Hull>();
            fire.AddToIgnore(tankCollider2D);


            // _tankCollider2D = GetComponent<Collider2D>();
            // _hull = GetComponent<Hull>();
            // _turret =  Utils.findComponentInTree<Turret>(this);
            // _fire = Utils.findComponentInTree<IFire>(this);
            // _fire?.AddToIgnore(_tankCollider2D);

            Debug.Log("TankController:Start() # END");
        }

        public void Forward(float input)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * hull.HullSpeed * input));
        }

        public void RotateHull(float input)
        {
            transform.Rotate(Vector3.back * (Time.deltaTime * hull.HullRotationSpeed * input));
        }

        public void RotateTurret(float input)
        {
            turret.Rotate(input);
        }

        public void Fire()
        {
            fire.Fire();
        }


    }
}