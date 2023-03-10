using UnityEngine;
using Utils;

namespace Game.Scripts.Tanks
{
    /// Главный пульт управление от Игрока - все Inputs слушаются и обрабатываются на верхнем уровне здесь.
    public class PlayerController : MonoBehaviour
    {
        // обычно mainCamera - но если понадобится Менять камеры.
        // TODO - нарисовывается отдельный API-script для Высокоуровнего управление именно Camera и далее чисто дёргать их API
        // пока-что, в этом нет потребность - не усложняем без надобности
        public Camera activeCamera;
        public float
                activeCameraZoomSize = 8,
                activeCameraZoomStep = 0.5f,
                activeCameraZoomMin = 1f,
                activeCameraZoomMax = 30f;

        private TankBehaviour myTank { get => GetComponent<TankBehaviour>(); }
        public float verticalInput, horizontalInput;
        private Vector3 activeCameraAxisZOffset = new Vector3(0, 0, -10);

        private void Start()
        {
            // var obj = new PlayWorldAudio();
            // var interfaces = obj.GetType().GetInterfaces().ToList();
            // var interfacesString = String.Join(',', interfaces); 

            // // Game.Scripts.Tanks.PlayerController+Event
            // // Game.Scripts.Tanks.PlayerController+AudioEvent

            // Debug.Log($"LOG: GetType():{obj.GetType()}");
            // Debug.Log($"LOG: interfaces:{interfacesString}");
            // var one = Resources.Load<AudioClip>(Audio.Music.MAIN_MENU_1.clipPath);
            // var two = Resources.Load<AudioClip>(Audio.Lib.Music.MAIN_MENU_1.clipPath);
            // var two = Resources.LoadAsync<AudioClip>(Audio.Music.MAIN_MENU_1.clipPath);
            // two.completed += a => {
            //     a.
            // }
            // Debug.Log(one == two);
        }

        void FixedUpdate()
        {
            // myTank.DevMove(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

            // Tank - movement
            myTank.Forward((verticalInput = Input.GetAxis("Vertical")));

            // Tank - rotation
            myTank.RotateHull((horizontalInput = Input.GetAxis("Horizontal")));

            // Debug.Log($"vertical={verticalInput} # horizontal={horizontalInput}");

            // Tank - fire
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                myTank.Fire();
            }

            // Tank - turret
            // Индус: https://youtu.be/monYp9VlBy4?list=PLcRSafycjWFfIzbU5gqa6PSIsIVe-Acw5&t=1244
            myTank.RotateTurretIndus(GetMousePositionByActiveCamera());
            // CalculateTurretRotationMaks();

            // Active Camera - zoom
            var mouseScroll = Input.GetAxis("Mouse ScrollWheel");
            if (mouseScroll != 0) ActiveCameraZoom(mouseScroll);

            // Active Camera - update position
            ActiveCameraPosition();

        }

        // private void CalculateTurretRotationMaks()
        // {
        //     var mouseScreenPos = Util.Copy(Input.mousePosition, z: -Camera.main.transform.position.z);
        //     var mPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        //     var angle = Vector2.Angle(mPos - myTank.transform.position, Vector3.up);
        //     angle = Camera.main.ScreenToViewportPoint(Input.mousePosition).x < 0.5 ? angle : 360 - angle;
        //     myTank.RotateTurret(angle);
        // }


        private void ActiveCameraZoom(float mouseScroll)
        {
            if (mouseScroll < 0) activeCameraZoomSize += activeCameraZoomStep;
            if (mouseScroll > 0) activeCameraZoomSize -= activeCameraZoomStep;
            if (activeCameraZoomSize < activeCameraZoomMin) activeCameraZoomSize = activeCameraZoomMin;
            if (activeCameraZoomSize > activeCameraZoomMax) activeCameraZoomSize = activeCameraZoomMax;
            activeCamera.orthographicSize = activeCameraZoomSize;
        }

        private void ActiveCameraPosition()
        {
            activeCamera.transform.position = myTank.transform.position + activeCameraAxisZOffset;
            // activeCamera.transform.position = myTank.transform.position;
        }

        private Vector2 GetMousePositionByActiveCamera() =>
            activeCamera.ScreenToWorldPoint(Input.mousePosition.Copy(z: activeCamera.nearClipPlane));

    }
}
