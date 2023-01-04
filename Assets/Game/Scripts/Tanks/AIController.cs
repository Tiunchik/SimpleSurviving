using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Tanks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private TankController _enemyTank;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _enemyTank = GetComponent<TankController>();
        _player = GameObject.Find("PlayerTank").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player.IsDestroyed())
        {
            CalculateTurretRotation(_player.transform.position);
        }
    }

    private void CalculateTurretRotation(Vector3 position)
    {
        var angle = Vector2.Angle(position - _enemyTank.transform.position, Vector3.up);
        Debug.Log($"{angle}");
        angle = position.x < _enemyTank.transform.position.x ? angle : 360 - angle;
        _enemyTank.RotateTurret(angle);
    }
}