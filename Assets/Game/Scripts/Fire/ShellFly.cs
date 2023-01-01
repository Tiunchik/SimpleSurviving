using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFly : MonoBehaviour
{
    public float power = 1;
    public GameObject boom;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ShellFly::START");
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (power * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(boom, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
