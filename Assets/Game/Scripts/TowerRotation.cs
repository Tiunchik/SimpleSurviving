using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject tankHull;
    public float towerRotationSpeed = 1;

    private float towerCounter = 0;

    void Update()
    {
        // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
        var direction = Input.mousePosition - gameCamera.WorldToScreenPoint(tankHull.transform.position);
        // Нахождение тангенса угла и перевод его в градусы.
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Вращение объекта на полученное значение градусов. (-90 т.к. 2D)
        var rotation = Quaternion.AngleAxis((angle - 90), Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * towerRotationSpeed * Time.deltaTime);
    }
}

/*
 *
 *        // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
        var direction = Input.mousePosition - gameCamera.WorldToScreenPoint(tankHull.transform.position);
        
        // Нахождение тангенса угла и перевод его в градусы.
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Вращение объекта на полученное значение градусов. (-90 т.к. 2D)
        var rotation = Quaternion.AngleAxis((angle - 90), Vector3.forward);
        transform.Rotate(0,0,rotation.z, Space.World);
        transform.LookAt(direction);
 *
 *
 * 
*/