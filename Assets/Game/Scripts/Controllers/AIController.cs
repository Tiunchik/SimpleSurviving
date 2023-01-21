using System.Collections;
using System.Collections.Generic;
using Game.Scripts.ai;
using Game.Scripts.Tanks;
using TMPro;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField]
    private AIBehavior behavior;

    void Update()
    {
        behavior.PerformAction(gameObject);
    }
}
