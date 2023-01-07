using Game.Scripts.Tanks.Ammo;
using Game.Scripts.Tanks.Hulls;
using Game.Scripts.Tanks.Turrets;
using UnityEngine;

namespace Game.Scripts.Tanks
{
    public class TankBehaviour : MonoBehaviour, ITankBehaviour
    {

        private TreeComponentStore tcs = new();
        private BoxCollider2D tankCollider2D { get => tcs.Get<BoxCollider2D>(); }
        private HullBehaviour hull { get => tcs.Get<HullBehaviour>(); }
        private TurretBehaviour turret { get => tcs.Get<TurretBehaviour>(); }
        private IFireable fire { get => tcs.Get<IFireable>(); }

        private Rigidbody2D hullRB;

        private void Start()
        {
            Debug.Log("TankController:Start() # RUN");
            tcs.Start(this.gameObject);
            fire.AddToIgnore(tankCollider2D);

            hullRB = hull.transform.GetComponent<Rigidbody2D>();
            Debug.Log("TankController:Start() # END");
        }

        public void Forward(float input)
        {
            // transform.Translate(Vector3.up * (Time.deltaTime * hull.HullSpeed * input));

            hullRB.velocity = (Vector2)transform.up * input *( hull.moveSpeed)* Time.fixedDeltaTime;
        }

        public void RotateHull(float input)
        {
            // transform.Rotate(Vector3.back * (Time.deltaTime * hull.HullRotationSpeed * input));

            hullRB.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -input * hull.rotationSpeed * Time.fixedDeltaTime));
        }



        // public void RotateTurret(float input)
        // {
        //     // turret.Rotate(input);
        // }
        public void RotateTurretIndus(Vector2 positionInWorld) => turret.RotateIndus(positionInWorld);

        public void Fire()
        {
            fire.Fire();
        }

    }
}