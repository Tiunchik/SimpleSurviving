using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;

public class FireScipt : MonoBehaviour, IFire
{
    public GameObject shell;
    public Vector3 posCorrections = new Vector3();

    public void Fire()
    {
        var newObject = Instantiate(shell, transform.position + posCorrections, transform.rotation);
        newObject.transform.Translate(Vector3.up * 0.1f);
    }
}
