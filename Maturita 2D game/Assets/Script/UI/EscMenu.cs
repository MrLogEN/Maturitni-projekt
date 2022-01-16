using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EscMenu : MonoBehaviour
{
    public bool paused = false;
    public GameObject escapeMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == false)
            {
                escapeMenu.SetActive(true);
                Time.timeScale = 0f;
                paused = true;
            }
            else if(paused == true)
            {
                escapeMenu.SetActive(false);
                Time.timeScale = 1f;
                paused = false;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        escapeMenu.SetActive(false);
        paused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main_menu");
    }
}
