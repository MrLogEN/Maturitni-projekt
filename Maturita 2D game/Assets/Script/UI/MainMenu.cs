using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    //public event EventHandler OnSettingsEnterMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene("level_select");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    Button[] buttons;
    public void OnSettingsEnter()
    {
        //OnSettingsEnterMenu?.Invoke(this,EventArgs.Empty);
    }
}
