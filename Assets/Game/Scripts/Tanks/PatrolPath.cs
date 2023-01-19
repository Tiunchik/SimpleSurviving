using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PatrolPath : MonoBehaviour
{
    public List<Transform> pathPoints = new();

    [Header("Gizmo parameters")] public Color pointColor = Color.blue;
    public float pointSize = 1f;
    public Color lineColor = Color.red;

    public struct PathPoint
    {
        public int index;
        public Vector2 position;
    }
    
    private void OnDrawGizmos()
    {
        if (pathPoints.Count == 0) return;
        
        for (int i = 0; i < pathPoints.Count; i++)
        {
            Gizmos.color = pointColor;
            Gizmos.DrawSphere(pathPoints[i].position, pointSize);

            if (pathPoints.Count == 1 || i == pathPoints.Count - 1) return;

            Gizmos.color = lineColor;
            Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);

            if (pathPoints.Count > 2 && i == 0)
                Gizmos.DrawLine(pathPoints[0].position, pathPoints[pathPoints.Count - 1].position);
        }
    }

    public PathPoint GetClosestPathPosition(Vector3 tankPosition)
    {
        var minDistance = float.MaxValue;
        var index = -1;
        for (int i = 0; i < pathPoints.Count; i++)
        {
            var tempDistance = Vector2.Distance(pathPoints[i].position, tankPosition);
            if (tempDistance < minDistance)
            {
                index = i;
                minDistance = tempDistance;
            }
            
        }
        return new PathPoint { index = index, position = pathPoints[index].position };
    }

    public PathPoint GetNextPathPosition(int index)
    {
        var newIndex = index + 1 >= pathPoints.Count ? 0 : index + 1;
        return new PathPoint { index = newIndex, position = pathPoints[newIndex].position };
    }
}