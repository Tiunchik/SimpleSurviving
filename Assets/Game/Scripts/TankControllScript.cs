using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class TankControllScript : MonoBehaviour
{

    public float hullSpeed = 10f;
    public float hullRotationSpeed = 10f;

    private float _horizontalInput;
    private float _verticalInput;

    private IFire fire;

    private Collider2D tankCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        tankCollider2D = GetComponent<Collider2D>();
        fire = findFire();
        fire?.AddToIgnore(tankCollider2D);
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        transform.Rotate(Vector3.back * (Time.deltaTime * hullRotationSpeed * _horizontalInput));
        transform.Translate(Vector3.up * (Time.deltaTime * hullSpeed * _verticalInput));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fire?.Fire();
        }
    }

    [CanBeNull]
    private IFire findFire()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var currentChild = transform.GetChild(i);
            var fire = currentChild.GetComponentInChildren<IFire>();
            if (fire != null)
            {
                return fire;
            }
        }
        return null;
    }
}
