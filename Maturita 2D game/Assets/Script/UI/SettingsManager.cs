using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    //boss room
    public KeyCode jump;
    public KeyCode right;
    public KeyCode left;
    public KeyCode crouch;
    public KeyCode up;
    public KeyCode shoot;
    public KeyCode specialAbility;



    //level select

    public KeyCode selectUp;
    public KeyCode selectDown;
    public KeyCode selectLeft;
    public KeyCode selectRight;
    public KeyCode selectSelect;

    //audio
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider sfxVolume;

    //display
    public Dropdown screenMode;
    public Dropdown quality;
    // Start is called before the first frame update
    void Start()
    {
        BindingObject bo = ControlBinding.Load();
        jump = bo.jump;
        right = bo.right;
        left = bo.left;
        crouch = bo.crouch;
        up = bo.up;
        shoot = bo.shoot;
        specialAbility = bo.specialAbility;

        //level select

        selectUp = bo.selectUp;
        selectDown = bo.selectDown;
        selectLeft = bo.selectLeft;
        selectRight = bo.selectRight;
        selectSelect = bo.selectSelect;

        //audio
        masterVolume.value = bo.masterVolume;
        musicVolume.value = bo.musicVolume;
        sfxVolume.value = bo.sfxVolume;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
