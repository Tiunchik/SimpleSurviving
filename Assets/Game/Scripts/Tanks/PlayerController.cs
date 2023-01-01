using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using Unity.VisualScripting;
using UnityEngine;

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
    }
}
