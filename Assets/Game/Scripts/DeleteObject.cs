using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public int deleteSeconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteSeconds);
    }
}
