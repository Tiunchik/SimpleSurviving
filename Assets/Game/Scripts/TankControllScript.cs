using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
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
        // fire = findFire();
        fire = Utils.findComponentInTree<IFire>(this);
        fire?.AddToIgnore(tankCollider2D);
    }

    // Update is called once per frame
    void Update()
    {
        ControllMove();
        ControllShoot();
    }

    private void ControllMove()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.back * (Time.deltaTime * hullRotationSpeed * _horizontalInput));
        transform.Translate(Vector3.up * (Time.deltaTime * hullSpeed * _verticalInput));
    }
    
    private void ControllShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            fire?.Fire();
        }
    }

    // [CanBeNull]
    // private IFire findFire()
    // {
    //     for (int i = 0; i < transform.childCount; i++)
    //     {
    //         var fire = transform.GetChild(i).GetComponentInChildren<IFire>();
    //         if (fire != null) return fire;
    //     }
    //     return null;
    // }
}
