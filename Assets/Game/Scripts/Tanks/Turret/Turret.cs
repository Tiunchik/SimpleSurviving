using UnityEngine;

namespace Game.Scripts.Tanks.Turret
{
    public class Turret : MonoBehaviour, ITurret
    {
        public float towerRotationSpeed = 10f;

        private float _currentZAngle;
        
        public void Rotate(float input)
        {
            _currentZAngle = transform.eulerAngles.z;
            if (input < _currentZAngle)
            {
                if (input - _currentZAngle < -180)
                {
                    transform.Rotate(Vector3.forward * (Time.deltaTime * towerRotationSpeed));
                } 
                else
                {
                    transform.Rotate(Vector3.back * (Time.deltaTime * towerRotationSpeed));
                }
            }
            else
            {
                if (input - _currentZAngle > 180)
                {
                    transform.Rotate(Vector3.back * (Time.deltaTime * towerRotationSpeed));
                }
                else
                {
                    transform.Rotate(Vector3.forward * (Time.deltaTime * towerRotationSpeed));
                }
            }
        }


        public void SetTurretPositionOnHull(Vector3 position)
        {
            transform.localPosition = position;
        }
    }
}


  // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
  //       var direction = Input.mousePosition - gameCamera.WorldToScreenPoint(tankHull.transform.position);
  //       // Нахождение тангенса угла и перевод его в градусы.
  //       var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
  //       // Вращение объекта на полученное значение градусов. (-90 т.к. 2D)
  //       var rotation = Quaternion.AngleAxis((angle - 90), Vector3.forward);
  //       transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * towerRotationSpeed * Time.deltaTime);
