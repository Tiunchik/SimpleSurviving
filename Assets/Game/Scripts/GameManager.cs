using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Tanks.Fire;
using Game.Scripts.Tanks.Hull;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public GameObject stopScreen;

    private bool _isGameActive = true;
    
    // Update is called once per frame
    void Update()
    {
        if (_isGameActive && !GameObject.Find("PlayerTank"))
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
