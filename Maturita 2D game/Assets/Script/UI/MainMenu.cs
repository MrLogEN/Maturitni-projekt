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
    private void Start()
    {
        AudioManager.instance.PlayMusicMainMenu();
    }
    public void PlayGame()
    {
        //SceneManager.LoadScene("level_select");
        AudioManager.instance.PlayClickUISfx();
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
        AudioManager.instance.PlayClickUISfx();
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
        AudioManager.instance.PlayClickUISfx();
        SaveLoad.SaveDefault();
        //SceneManager.LoadScene("level_tutorial");
        LoadingManager.instance.LoadScene("level_tutorial");
    }
    public void Continue()
    {
        //SceneManager.LoadScene("level_select");
        AudioManager.instance.PlayClickUISfx();
        LoadingManager.instance.LoadScene("level_select");
        
    }
    public void QuitGame()
    {
        AudioManager.instance.PlayClickUISfx();
        if (PlayerPrefs.HasKey("hasPlayed"))
        {
            PlayerPrefs.SetInt("hasPlayed", 0);
        }
        Application.Quit();
    }
    Button[] buttons;
    public void OnSettingsEnter()
    {
        //OnSettingsEnterMenu?.Invoke(this,EventArgs.Empty);
    }
    public void PlayClickSound()
    {
        AudioManager.instance.PlayClickUISfx();
    }
     
}
