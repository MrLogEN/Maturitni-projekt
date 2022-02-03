using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour
{
	public Dropdown dropDownQuality;
    public Dropdown dropDownScreenMode;
    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(dropDownQuality.value);
        Debug.Log(dropDownQuality.value);
    }

    public void ValueChanged()
    {
        int screenValue = dropDownScreenMode.value;
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
 
