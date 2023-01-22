using Game.Scripts.Tanks;
using UnityEngine;

namespace Game.Scripts.ai
{
    public class TurretAIBehavior : AIBehavior
    {
        public TankBehaviour enemyTank;
        public Transform turret;

        public override void PerformAction(GameObject target)
        {
            if (target)
            {
                enemyTank.RotateTurretIndus(target.transform.position);
                var directionToFire = (Vector2)target.transform.position - (Vector2)turret.transform.position;
                if (Vector2.Dot(turret.transform.up, directionToFire.normalized) >= 0.9f)
                {
                    enemyTank.Fire();
                }
            }
            else
            {
                enemyTank.RotateTurretIndus(enemyTank.transform.position);
            }

        }
    }
}