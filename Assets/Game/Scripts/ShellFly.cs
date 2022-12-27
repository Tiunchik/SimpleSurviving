using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFly : MonoBehaviour
{
    public float power = 1;
    public GameObject boom;
    private Rigidbody2D shellRB;

    // Start is called before the first frame update
    void Start()
    {
        shellRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (power * Time.deltaTime));
        StartCoroutine(deleteBullet());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(boom, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator deleteBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
