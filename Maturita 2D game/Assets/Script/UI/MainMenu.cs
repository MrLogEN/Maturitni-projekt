using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
     
    public void PlayGame()
    {
        SceneManager.LoadScene("level_select");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    Button[] buttons;
    
}
