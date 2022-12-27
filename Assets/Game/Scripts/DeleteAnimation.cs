using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAnimation : MonoBehaviour
{
    public int deleteSeconds = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deleteSeconds); 
    }
}
