using UnityEngine;

namespace Game.Scripts.Tanks
{
    public interface ITankBehaviour
    {

        void Forward(float input);

        void RotateHull(float input);

        // void RotateTurret(float input);

        void RotateTurretIndus(Vector2 positionInWorld);

        void Fire();

    }
}