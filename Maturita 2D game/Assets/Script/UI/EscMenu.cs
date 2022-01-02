using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public bool paused;
    public void Escape()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if(paused == false)
            {
                Time.timeScale = 0f;
            }
            else if(paused == true)
            {
                Time.timeScale = 1f;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
