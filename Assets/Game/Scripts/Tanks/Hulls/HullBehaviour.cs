using UnityEngine;

namespace Game.Scripts.Tanks.Hulls
{
    public class HullBehaviour : MonoBehaviour
    {
        public Vector3 turretPosition;

        private float hullSpeed = 10f;
        private float hullRotationSpeed = 100f;
        public float HullSpeed { get => hullSpeed; }
        public float HullRotationSpeed { get => hullRotationSpeed; }

    }
}