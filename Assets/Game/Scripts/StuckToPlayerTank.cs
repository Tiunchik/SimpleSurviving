using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("Not used any more. Use PlayerController for main camera")]
public class StuckToPlayerTank : MonoBehaviour
{

    public GameObject playerTank;
    public Vector3 offset = new Vector3(0, 0, -20);
    
    void LateUpdate()
    {
        transform.position = playerTank.transform.position + offset;
    }
}
