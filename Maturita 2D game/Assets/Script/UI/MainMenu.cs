using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    //public event EventHandler OnSettingsEnterMenu;
    public GameObject ContinueBut;
    public GameObject WarningPanel;
    public void PlayGame()
    {
        //SceneManager.LoadScene("level_select");
        SaveObject so = SaveLoad.Load();
        if (so.tutorialCompleted == false)
        {
            ContinueBut.SetActive(false);
        }
        else
        {
            ContinueBut.SetActive(true);

        }
    }
    public void NewGame()
    {
        //SaveLoad.SaveDefault();
        SaveObject so = SaveLoad.Load();
        if (ContinueBut.activeInHierarchy == false)
        {

            SaveLoad.SaveDefault();
            //SceneManager.LoadScene("level_tutorial");
            LoadingManager.instance.LoadScene("level_tutorial");
        }
        else
        {
            WarningPanel.SetActive(true);
        }
    }
    public void Yes()
    {
        SaveLoad.SaveDefault();
        //SceneManager.LoadScene("level_tutorial");
        LoadingManager.instance.LoadScene("level_tutorial");
    }
    public void Continue()
    {
        //SceneManager.LoadScene("level_select");
        LoadingManager.instance.LoadScene("level_select");
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
