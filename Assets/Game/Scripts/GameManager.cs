using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Game.Scripts.Tanks.Ammo;
using Game.Scripts.Tanks.Hulls;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public GameObject stopScreen;

    private bool _isGameActive = true;
    private GameObject _player;

    private void Start()
    {
        _isGameActive = true;
        Time.timeScale = 1;
        _player = GameObject.Find("PlayerTank");
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameActive && _player.IsDestroyed())
        {
            _isGameActive = false;
            stopScreen.SetActive(true);
        }
        if (!_isGameActive)
        {
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
