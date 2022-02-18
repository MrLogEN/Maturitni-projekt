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
    public GameObject SkillPointMenu;
    public event EventHandler OnSettingsEnter;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (winscreen != null && deathscreen != null)
            {
                if (paused == false && winscreen.IsActive() != true && deathscreen.IsActive() != true)
                {
                    escapeMenu.SetActive(true);
                    settings.SetActive(false);
                    resumeBut.Select();
                    Time.timeScale = 0f;
                    paused = true;
                }
                else if (paused == true && winscreen.IsActive() != true && deathscreen.IsActive() != true)
                {
                    escapeMenu.SetActive(false);
                    settings.SetActive(false);
                    Time.timeScale = 1f;
                    paused = false;
                }
            }
            else
            {
                if (SkillPointMenu != null)
                {
                    if (SkillPointMenu.activeInHierarchy == true)
                    {
                        SkillPointMenu.SetActive(false);
                    }
                    else
                    {
                        if (paused == false)
                        {
                            escapeMenu.SetActive(true);
                            settings.SetActive(false);
                            resumeBut.Select();
                            Time.timeScale = 0f;
                            paused = true;
                        }
                        else if (paused == true)
                        {
                            escapeMenu.SetActive(false);
                            settings.SetActive(false);
                            Time.timeScale = 1f;
                            paused = false;
                        }
                    }
                }
                else
                {
                    if (paused == false)
                    {
                        escapeMenu.SetActive(true);
                        settings.SetActive(false);
                        resumeBut.Select();
                        Time.timeScale = 0f;
                        paused = true;
                    }
                    else if (paused == true)
                    {
                        escapeMenu.SetActive(false);
                        settings.SetActive(false);
                        Time.timeScale = 1f;
                        paused = false;
                    }
                }
                
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
        LoadingManager.instance.LoadScene("main_menu");
    }
    public void Settings()
    {
        OnSettingsEnter?.Invoke(this, EventArgs.Empty);
    }
    public void LoadLevelSelect()
    {
        Time.timeScale = 1f;
        LoadingManager.instance.LoadScene("level_select");
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Time.timeScale = 1f;
        Time.timeScale = 1f;
        LoadingManager.instance.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
