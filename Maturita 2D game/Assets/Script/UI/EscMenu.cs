using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class EscMenu : MonoBehaviour
{
    public Image winscreen;
    public Image deathscreen;
    public bool paused = false;
    public GameObject escapeMenu;
    public Button resumeBut;
    public GameObject settings;
    public event EventHandler OnSettingsEnter;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false && winscreen != true && deathscreen != true)
            {
                escapeMenu.SetActive(true);
                settings.SetActive(false);
                resumeBut.Select();
                Time.timeScale = 0f;
                paused = true;
            }
            else if(paused == true && winscreen != true && deathscreen != true)
            {
                escapeMenu.SetActive(false);
                settings.SetActive(false);
                Time.timeScale = 1f;
                paused = false;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        escapeMenu.SetActive(false);
        settings.SetActive(false);
        paused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main_menu");
    }
    public void Settings()
    {
        OnSettingsEnter?.Invoke(this, EventArgs.Empty);
    }
    public void LoadLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("level_select");
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Time.timeScale = 1f;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
