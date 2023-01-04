using Game.Scripts.Tanks.Ammo;
using Game.Scripts.Tanks.Hulls;
using Game.Scripts.Tanks.Turrets;
using UnityEngine;

namespace Game.Scripts.Tanks
{
    public class TankBehaviour : MonoBehaviour, ITankController
    {

        private TreeComponentStore tcs = new();
        private BoxCollider2D tankCollider2D { get => tcs.Get<BoxCollider2D>(); }
        private HullBehaviour hull { get => tcs.Get<HullBehaviour>(); }
        private TurretBehaviour turret { get => tcs.Get<TurretBehaviour>(); }
        private IFireable fire { get => tcs.Get<IFireable>(); }

        private void Start()
        {
            Debug.Log("TankController:Start() # RUN");
            tcs.Start(this.gameObject);
            fire.AddToIgnore(tankCollider2D);
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