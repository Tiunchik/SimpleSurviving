using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Tanks.Ammo;
using Game.Scripts.Tanks.Hulls;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public GameObject stopScreen;

    private bool isGameActive = true;

    // Update is called once per frame
    void Update()
    {
        if (isGameActive && !GameObject.Find("PlayerTank"))
        {
            isGameActive = false;
            stopScreen.SetActive(true);
        }
        if (!isGameActive)
        {
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
