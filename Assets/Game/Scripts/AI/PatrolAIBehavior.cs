using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.ai;
using Game.Scripts.Tanks;
using UnityEngine;

public class PatrolAIBehavior : AIBehavior
{
    public PatrolPath patrolPath;

    [Range(0.1f, 2)] public float arriveDistance = 2f;

    public float waitTime = 0.5f;

    [SerializeField] private bool isWaiting = false;
    [SerializeField] Vector2 currentTargetPoint = Vector2.zero;

    public TankBehaviour enemyTank;

    private bool isInitialized = false;

    private int currentIndex = -1;

    private void Start()
    {
        if (!enemyTank)
            enemyTank = GetComponentInChildren<TankBehaviour>();

        if (!patrolPath)
            patrolPath = GetComponentInChildren<PatrolPath>();
    }

    public override void PerformAction(GameObject target)
    {
        if (!isWaiting)
        {
            if (patrolPath.pathPoints.Count < 2)
                return;
            if (!isInitialized)
            {
                var currentPathPoint = patrolPath.GetClosestPathPosition(enemyTank.transform.position);
                currentIndex = currentPathPoint.index;
                currentTargetPoint = currentPathPoint.position;
                isInitialized = true;
            }
        }

        if (Vector2.Distance(enemyTank.transform.position, currentTargetPoint) < arriveDistance)
        {
            isWaiting = true;
            StartCoroutine(WaitCoroutine());
            return;
        }

        Vector2 directionToGo = currentTargetPoint - (Vector2)enemyTank.transform.position;
        var dotProduct = Vector2.Dot(enemyTank.transform.up, directionToGo.normalized);
        if (dotProduct < 0.98f)
        {
            var crossProduct = Vector3.Cross(enemyTank.transform.up, directionToGo.normalized);
            int rotationResult = crossProduct.z >= 0 ? -1 : 1;
            enemyTank.RotateHull(rotationResult);
        }
        else
        {
            enemyTank.Forward(1);
        }
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        var nextPointPosition = patrolPath.GetNextPathPosition(currentIndex);
        currentIndex = nextPointPosition.index;
        currentTargetPoint = nextPointPosition.position;
        isWaiting = false;
    }
}