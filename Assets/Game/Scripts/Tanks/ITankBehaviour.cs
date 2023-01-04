using UnityEngine;

namespace Game.Scripts.Tanks
{
    public interface ITankController
    {

        void Forward(float input);

        void RotateHull(float input);

        void RotateTurret(float input);

        void Fire();

    }
}