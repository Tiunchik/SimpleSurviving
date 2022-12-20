using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckToPlayerTank : MonoBehaviour
{

    public GameObject playerTank;
    public Vector3 offset = new Vector3(0, 0, -20);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTank.transform.position + offset;
    }
}
