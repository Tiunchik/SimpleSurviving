using Game.Scripts.Utils;

using UnityEngine;

namespace Game.Scripts.Tanks
{
    public class PlayerController : MonoBehaviour
    {

        private TankBehaviour myTank { get => GetComponent<TankBehaviour>(); }
        private float horizontalInput;
        private float verticalInput;

        void Update()
        {
            myTank.Forward(Input.GetAxis("Vertical"));
            myTank.RotateHull(Input.GetAxis("Horizontal"));

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                myTank.Fire();
            }
            CalculateTurretRotation();

        }

        private void CalculateTurretRotation()
        {
            var mouseScreenPos = Util.Copy(Input.mousePosition, z: -Camera.main.transform.position.z);
            var mPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            var angle = Vector2.Angle(mPos - myTank.transform.position, Vector3.up);
            angle = Camera.main.ScreenToViewportPoint(Input.mousePosition).x < 0.5 ? angle : 360 - angle;
            myTank.RotateTurret(angle);
        }
    }
}
