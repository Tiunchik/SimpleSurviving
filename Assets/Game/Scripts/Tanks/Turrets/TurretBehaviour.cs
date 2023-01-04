using UnityEngine;

namespace Game.Scripts.Tanks.Turrets
{
    public class TurretBehaviour : MonoBehaviour, ITurret
    {
        public float towerRotationSpeed = 10f;

        private float currentZAngle;
        
        
        public void Rotate(float input)
        {
            currentZAngle = transform.eulerAngles.z;
            if (input < currentZAngle)
            {
                if (input - currentZAngle < -180)
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
                if (input - currentZAngle > 180)
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
