using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckToPlayerTank : MonoBehaviour
{

    public GameObject playerTank;
    public Vector3 offset = new Vector3(0, 0, -20);
    
    void LateUpdate()
    {
        transform.position = playerTank.transform.position + offset;
    }
}
