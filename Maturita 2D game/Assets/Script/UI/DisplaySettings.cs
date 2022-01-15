using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour
{
	public Dropdown dropDown;
    
    public void SetQuality(int qualityValue)
    {
        QualitySettings.SetQualityLevel(qualityValue);
        Debug.Log(qualityValue);
    }

    public void ValueChanged(int screenValue)
    {
         
        screenValue = dropDown.value;
        switch (screenValue)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                Debug.Log(screenValue);
                break;
                
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Debug.Log(screenValue);
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                Debug.Log(screenValue);
                break;

            default:
                break;


        }
        
       
    }
     










}
 
