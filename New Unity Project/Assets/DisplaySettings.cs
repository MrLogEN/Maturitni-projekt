using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySettings : MonoBehaviour
{

    public void screenMode()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = true;
    }
    
    

   
}
public class ScreenMode
{
    public ScreenMode fullscreen;
   
    public ScreenMode windowed ;
    public ScreenMode borderless;

}
