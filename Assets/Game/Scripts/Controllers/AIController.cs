using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.ai;
using Game.Scripts.Tanks;
using TMPro;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public AIBehavior patrolBehavior;
    public AIBehavior turretBehavior;
    public AIDetector detector;
    public GameObject enemyTank;
    private void Start()
    {
        detector = GetComponentInChildren<AIDetector>();
    }

    void Update()
    {
        if (detector.TargetVisible)
        {
            turretBehavior.PerformAction(detector.Target.gameObject);
        }
        else if (!detector.TargetVisible)
        {
            patrolBehavior.PerformAction(gameObject);
            turretBehavior.PerformAction(null);
        }

    }
}