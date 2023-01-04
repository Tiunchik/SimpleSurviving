﻿using UnityEngine;

namespace Game.Scripts.Tanks.Hull
{
    public class Hull: MonoBehaviour
    {
      
        public float hullSpeed = 10f;
        public float hullRotationSpeed = 100f;
        public Vector3 turretPosition;
        public float HullSpeed
        {
            get => hullSpeed;
        }
        public float HullRotationSpeed
        {
            get => hullRotationSpeed;
        }

    }
}