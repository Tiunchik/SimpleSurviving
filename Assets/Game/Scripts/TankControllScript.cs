using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllScript : MonoBehaviour
{

    public float hullSpeed = 10f;
    public float hullRotationSpeed = 10f;

    private float _horizontalInput;
    private float _verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        transform.Rotate(Vector3.back * (Time.deltaTime * hullRotationSpeed * _horizontalInput));
        transform.Translate(Vector3.up * (Time.deltaTime * hullSpeed * _verticalInput));
    }
}
