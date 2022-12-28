using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;

public class FireScipt : MonoBehaviour, IFire
{
    public GameObject shell;
    public float posCorrections = 1;

    public void Fire()
    {
        var newObject = Instantiate(shell, transform.position, transform.rotation);
        newObject.transform.Translate(Vector3.up * posCorrections, Space.Self);
    }
}
