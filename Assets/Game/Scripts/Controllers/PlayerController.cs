using Game.Scripts.Utils;

using UnityEngine;

namespace Game.Scripts.Tanks
{
    /// Глвынй пульт управление от Игрока - все Inputs слушаются и обрабатываются на верхнем уровне здесь.
    public class PlayerController : MonoBehaviour
    {
        // обычно mainCamera - но если понадобится Менять камеры.
        // TODO - нарисовывается отдельный API-script для Высокоуровнего управление именно Camera и далее чисто дёргать их API
        // пока-что, в этом нет потребность - не усложняем без надобпности
        public Camera activeCamera;
        public float
                activeCameraZoomSize = 8,
                activeCameraZoomStep = 0.5f,
                activeCameraZoomMin = 1f,
                activeCameraZoomMax = 30f;

        private TankBehaviour myTank { get => GetComponent<TankBehaviour>(); }
        private float horizontalInput, verticalInput;
        private Vector3 activeCameraAxisxZOffset = new Vector3(0, 0, -100);

        void Update()
        {

            // Tank
            myTank.Forward(Input.GetAxis("Vertical"));
            myTank.RotateHull(Input.GetAxis("Horizontal"));

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                myTank.Fire();
            }
            CalculateTurretRotation();

            // Active Camera
            var mouseScroll = Input.GetAxis("Mouse ScrollWheel");
            if (mouseScroll != 0) activeCameraZoom(mouseScroll);
            activeCameraPosition();

        }

        private void CalculateTurretRotation()
        {
            var mouseScreenPos = Util.Copy(Input.mousePosition, z: -Camera.main.transform.position.z);
            var mPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            var angle = Vector2.Angle(mPos - myTank.transform.position, Vector3.up);
            angle = Camera.main.ScreenToViewportPoint(Input.mousePosition).x < 0.5 ? angle : 360 - angle;
            myTank.RotateTurret(angle);
        }

        private void activeCameraZoom(float mouseScroll)
        {
            if (mouseScroll < 0) activeCameraZoomSize += activeCameraZoomStep;
            if (mouseScroll > 0) activeCameraZoomSize -= activeCameraZoomStep;
            if(activeCameraZoomSize < activeCameraZoomMin) activeCameraZoomSize = activeCameraZoomMin; 
            if(activeCameraZoomSize > activeCameraZoomMax) activeCameraZoomSize = activeCameraZoomMax;
            activeCamera.orthographicSize = activeCameraZoomSize;
        }

        private void activeCameraPosition()
        {
            activeCamera.transform.position = myTank.transform.position + activeCameraAxisxZOffset;
        }
    }
}
