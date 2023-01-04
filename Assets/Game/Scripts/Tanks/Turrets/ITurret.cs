using UnityEngine;

namespace Game.Scripts.Tanks.Turrets
{
    public interface ITurret
    {
        void Rotate(float input);

        void SetTurretPositionOnHull(Vector3 position);
    }
}