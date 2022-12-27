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
        var middleLine = transform.position;
        middleLine.x += 0.1f;
        Instantiate(shell, middleLine + posCorrections, transform.rotation);
        middleLine.x -= 0.2f;
        Instantiate(shell, middleLine+ posCorrections, transform.rotation);
    }
}
