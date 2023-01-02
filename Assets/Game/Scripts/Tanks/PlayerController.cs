using System;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Tanks
{
    public class PlayerController : MonoBehaviour
    {

        private TankController _myTank;
        private float _horizontalInput;
        private float _verticalInput;

        // Start is called before the first frame update
        void Start()
        {
            _myTank = GetComponent<TankController>();
        }

        // Update is called once per frame
        void Update()
        {
            _myTank.Forward(Input.GetAxis("Vertical"));
            _myTank.RotateHull(Input.GetAxis("Horizontal"));
            
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                _myTank.Fire();
            }
            CalculateTurretRotation();
            
        }

        private void CalculateTurretRotation()
        {
            var mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                -Camera.main.transform.position.z);
            var mPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            var angle = Vector2.Angle(mPos - _myTank.transform.position, Vector3.up);
            angle = Camera.main.ScreenToViewportPoint(Input.mousePosition).x < 0.5 ?  angle  : 360 - angle;
            _myTank.RotateTurret(angle);
        }
    }
}
