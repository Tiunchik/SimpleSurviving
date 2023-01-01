using System;
using UnityEngine;

namespace Game.Scripts
{
    public class Hull: MonoBehaviour
    {
        public float hullSpeed = 10f;
        public float hullRotationSpeed = 100f;

        public float HullSpeed
        {
            get => hullSpeed;
        }
        public float HullRotationSpeed
        {
            get => hullRotationSpeed;
        }
        // Место для логики перерасчёта параметров танка по скорости движения и т.п.
        private void Start()
        {

        }
    }
}