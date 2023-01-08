using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Obsolete("Not used any more. Use PlayerController for main camera")]
public class StuckToPlayerTank : MonoBehaviour
{

    private GameObject _playerTank;
    public Vector3 offset = new Vector3(0, 0, -20);


    private void Start()
    {
        _playerTank = GameObject.Find("PlayerTank").gameObject;
    }

    void LateUpdate()
    {
        if (!_playerTank.IsDestroyed())
        {
            transform.position = _playerTank.transform.position + offset;
        }

    }
}
