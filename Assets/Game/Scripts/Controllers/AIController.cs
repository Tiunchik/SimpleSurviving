using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Tanks;
using TMPro;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private TankBehaviour enemyTank { get => GetComponent<TankBehaviour>(); }
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("PlayerTank").gameObject;
    }

    void Update()
    {
        CalculateTurretRotation(player.transform.position);
    }

    private void CalculateTurretRotation(Vector3 position)
    {
        var angle = Vector2.Angle(position - enemyTank.transform.position, Vector3.up);
        Debug.Log($"AIController::CalculateTurretRotation() # angle={angle}");
        angle = position.x < enemyTank.transform.position.x ? angle : 360 - angle;
        enemyTank.RotateTurret(angle);
    }
}
