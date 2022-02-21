using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonsActions : MonoBehaviour
{
    // Start is called before the first frame update
    #region public 
    public Button jumpButton;
    public Button rightButton;
    public Button leftButton;
    public Button crouchButton;
    public Button upButton;
    public Button shootButton;
    public Button specialAbilityButton;
    //level select

    public Button selectUpButton;
    public Button selectDownButton;
    public Button selectLeftButton;
    public Button selectRightButton;
    public Button selectSelectButton;

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;


    //fdsafdsafasfdsfdasfsda
    private KeyCode jump;
    private KeyCode right;
    private KeyCode left;
    private KeyCode crouch;
    private KeyCode up;
    private KeyCode shoot;
    private KeyCode specialAbility;
    #endregion

    //level select
    #region private
    private KeyCode selectUp;
    private KeyCode selectDown;
    private KeyCode selectLeft;
    private KeyCode selectRight;
    private KeyCode selectSelect;

    private float musicVolume;
    private float masterVolume;
    private float sfxVolume;

    private int screenMode;
    private int resolution;

    private bool isClickedJump = false;
    private bool isClickedRight = false;
    private bool isClickedLeft = false;
    private bool isClickedCrouch = false;
    private bool isClickedUp = false;
    private bool isClickedShoot = false;
    private bool isClickedSpecialAbility = false;
    private bool isClickedSelectUp = false;
    private bool isClickedSelectDown = false;
    private bool isClickedSelectLeft = false;
    private bool isClickedSelectRight = false;
    private bool isClickedSelectSelect = false;
    #endregion
    BindingObject bo;
    public event EventHandler OnBindingChange;
    public EscMenu escMenu;
    public Button backButton;
    public Button resumeButton;
    public Dropdown resolutionDropdown;
    public Dropdown screenModeDropdown;
    private int localeIndex;
    private void Start()
    {
        if (escMenu != null)
        {
            escMenu.OnSettingsEnter += SelectButton;
        }
        bo = ControlBinding.Load();
        Debug.Log(bo.masterVolume + " " + bo.musicVolume + " " + bo.sfxVolume);

        jump = bo.jump;
        right = bo.right;
        left = bo.left;
        selectDown = bo.selectDown;
        selectLeft = bo.selectLeft;
        selectRight = bo.selectRight;
        selectSelect = bo.selectSelect;
        selectUp = bo.selectUp;
        crouch = bo.crouch;
        up = bo.up;
        shoot = bo.shoot;
        specialAbility = bo.specialAbility;
        sfxVolume = bo.sfxVolume;
        musicVolume = bo.musicVolume;
        masterVolume = bo.masterVolume;
        screenMode = bo.screenMode;
        resolution = bo.quality;
        localeIndex = bo.localizationIndex;
        LanguageChange.instance.SetLocale(localeIndex);

        jumpButton.GetComponentInChildren<Text>().text = jump.ToString();
        rightButton.GetComponentInChildren<Text>().text = right.ToString();
        leftButton.GetComponentInChildren<Text>().text = left.ToString();
        crouchButton.GetComponentInChildren<Text>().text = crouch.ToString();
        upButton.GetComponentInChildren<Text>().text = up.ToString();
        shootButton.GetComponentInChildren<Text>().text = shoot.ToString();
        specialAbilityButton.GetComponentInChildren<Text>().text = specialAbility.ToString();
        selectUpButton.GetComponentInChildren<Text>().text = selectUp.ToString();
        selectDownButton.GetComponentInChildren<Text>().text = selectDown.ToString();
        selectLeftButton.GetComponentInChildren<Text>().text = selectLeft.ToString();
        selectRightButton.GetComponentInChildren<Text>().text = selectRight.ToString();
        selectSelectButton.GetComponentInChildren<Text>().text = selectSelect.ToString();


        masterVolumeSlider.value = masterVolume;
        sfxVolumeSlider.value = sfxVolume;
        musicVolumeSlider.value = musicVolume;

        screenModeDropdown.value = screenMode;
        resolutionDropdown.value = resolution;
        OnBindingChange?.Invoke(this, EventArgs.Empty);

    }
    private void Update()
    {
        //print(isClickedJump);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackPressed();
        }
    }
    private void OnGUI()
    {
        if (isClickedJump)
        {
            WaitongForKey(ref jump, jumpButton, ref isClickedJump);
            jumpButton.GetComponentInChildren<Text>().text = jump.ToString();
        }
        else if (isClickedRight)
        {

            WaitongForKey(ref right, rightButton, ref isClickedRight);
            rightButton.GetComponentInChildren<Text>().text = right.ToString();
        }
        else if (isClickedLeft)
        {

            WaitongForKey(ref left, leftButton, ref isClickedLeft);
            leftButton.GetComponentInChildren<Text>().text = left.ToString();
        }
        else if (isClickedCrouch)
        {

            WaitongForKey(ref crouch, crouchButton, ref isClickedCrouch);
            crouchButton.GetComponentInChildren<Text>().text = crouch.ToString();
        }
        else if (isClickedUp)
        {

            WaitongForKey(ref up, upButton, ref isClickedUp);
            upButton.GetComponentInChildren<Text>().text = up.ToString();
        }
        else if (isClickedShoot)
        {

            WaitongForKey(ref shoot, shootButton, ref isClickedShoot);
            shootButton.GetComponentInChildren<Text>().text = shoot.ToString();
        }
        else if (isClickedSpecialAbility)
        {

            WaitongForKey(ref specialAbility, specialAbilityButton, ref isClickedSpecialAbility);
            specialAbilityButton.GetComponentInChildren<Text>().text = specialAbility.ToString();
        }
        else if (isClickedSelectUp)
        {

            WaitongForKey(ref selectUp, selectUpButton, ref isClickedSelectUp);
            selectUpButton.GetComponentInChildren<Text>().text = selectUp.ToString();
        }
        else if (isClickedSelectDown)
        {

            WaitongForKey(ref selectDown, selectDownButton, ref isClickedSelectDown);
            selectDownButton.GetComponentInChildren<Text>().text = selectDown.ToString();
        }
        else if (isClickedSelectLeft)
        {
            WaitongForKey(ref selectLeft, selectLeftButton, ref isClickedSelectLeft);
            selectLeftButton.GetComponentInChildren<Text>().text = selectLeft.ToString();
        }
        else if (isClickedSelectRight)
        {

            WaitongForKey(ref selectRight, selectRightButton, ref isClickedSelectRight);
            selectRightButton.GetComponentInChildren<Text>().text = selectRight.ToString();
        }
        else if (isClickedSelectSelect)
        {

            WaitongForKey(ref selectSelect, selectSelectButton, ref isClickedSelectSelect);
            selectSelectButton.GetComponentInChildren<Text>().text = selectSelect.ToString();
        }

    }
    public void OnJumpButtonClick()
    {
        isClickedJump = true;
    }
    public void OnLookUpClick()
    {
        isClickedUp = true;
    }
    public void OnLeftClick()
    {
        isClickedLeft = true;
    }
    public void OnRightClick()
    {
        isClickedRight = true;
    }
    public void OnCrouchClick()
    {
        isClickedCrouch = true;
    }
    public void OnShootClick()
    {
        isClickedShoot = true;
    }
    public void OnSpecialAbilityClick()
    {
        isClickedSpecialAbility = true;
    }
    public void OnSelectUpClick()
    {
        isClickedSelectUp = true;
    }
    public void OnSelectDownClick()
    {
        isClickedSelectDown = true;
    }
    public void OnSelectLeftClick()
    {
        isClickedSelectLeft = true;
    }
    public void OnSelectRightClick()
    {
        isClickedSelectRight = true;
    }
    public void OnSelectSelectClick()
    {
        isClickedSelectSelect = true;
    }
    private void WaitongForKey(ref KeyCode key, Button but, ref bool isClicked)
    {
        if (Event.current.isKey)
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                key = Event.current.keyCode;
                print(key);
                isClicked = false;
            }
        }
    }
    public void SaveSettings()
    {
        if (jump != KeyCode.None) bo.jump = jump;
        if (shoot != KeyCode.None) bo.shoot = shoot;
        if (crouch != KeyCode.None) bo.crouch = crouch;
        if (left != KeyCode.None) bo.left = left;
        if (right != KeyCode.None) bo.right = right;
        if (up != KeyCode.None) bo.up = up;
        if (specialAbility != KeyCode.None) bo.specialAbility = specialAbility;
        if (selectDown != KeyCode.None) bo.selectDown = selectDown;
        if (selectUp != KeyCode.None) bo.selectUp = selectUp;
        if (selectLeft != KeyCode.None) bo.selectLeft = selectLeft;
        if (selectRight != KeyCode.None) bo.selectRight = selectRight;
        if (selectSelect != KeyCode.None) bo.selectSelect = selectSelect;
        bo.sfxVolume = sfxVolume;
        bo.musicVolume = musicVolume;
        bo.masterVolume = masterVolume;
        bo.screenMode = screenMode;
        bo.quality = resolution;
        bo.localizationIndex = localeIndex;
        ControlBinding.Save(bo);
        OnBindingChange?.Invoke(this, EventArgs.Empty);
    }
    public void OnMusicVolumeChanged()
    {
        musicVolume = musicVolumeSlider.value;
        //bo.musicVolume = musicVolume;
    }
    public void OnMasterVolumeChanged()
    {
        masterVolume = masterVolumeSlider.value;
        //bo.masterVolume = masterVolume;

    }
    public void OnSfxVolumeChanged()
    {
        sfxVolume = sfxVolumeSlider.value;
        //bo.sfxVolume = sfxVolume;
    }
    public void OnDefaultPressed()
    {
        //isClickedDefaul = true;
        bo.LoadDefault();
        jump = bo.jump;
        right = bo.right;
        left = bo.left;
        selectDown = bo.selectDown;
        selectLeft = bo.selectLeft;
        selectRight = bo.selectRight;
        selectSelect = bo.selectSelect;
        selectUp = bo.selectUp;
        crouch = bo.crouch;
        up = bo.up;
        shoot = bo.shoot;
        specialAbility = bo.specialAbility;
        sfxVolume = bo.sfxVolume;
        musicVolume = bo.musicVolume;
        masterVolume = bo.masterVolume;
        localeIndex = bo.localizationIndex;

        jumpButton.GetComponentInChildren<Text>().text = jump.ToString();
        rightButton.GetComponentInChildren<Text>().text = right.ToString();
        leftButton.GetComponentInChildren<Text>().text = left.ToString();
        crouchButton.GetComponentInChildren<Text>().text = crouch.ToString();
        upButton.GetComponentInChildren<Text>().text = up.ToString();
        shootButton.GetComponentInChildren<Text>().text = shoot.ToString();
        specialAbilityButton.GetComponentInChildren<Text>().text = specialAbility.ToString();
        selectUpButton.GetComponentInChildren<Text>().text = selectUp.ToString();
        selectDownButton.GetComponentInChildren<Text>().text = selectDown.ToString();
        selectLeftButton.GetComponentInChildren<Text>().text = selectLeft.ToString();
        selectRightButton.GetComponentInChildren<Text>().text = selectRight.ToString();
        selectSelectButton.GetComponentInChildren<Text>().text = selectSelect.ToString();


        masterVolumeSlider.value = masterVolume;
        sfxVolumeSlider.value = sfxVolume;
        musicVolumeSlider.value = musicVolume;

        screenModeDropdown.value = bo.screenMode;
        resolutionDropdown.value = bo.quality;
    }
    public void OnBackPressed()
    {
        jumpButton.GetComponentInChildren<Text>().text = bo.jump.ToString();
        rightButton.GetComponentInChildren<Text>().text = bo.right.ToString();
        leftButton.GetComponentInChildren<Text>().text = bo.left.ToString();
        crouchButton.GetComponentInChildren<Text>().text = bo.crouch.ToString();
        upButton.GetComponentInChildren<Text>().text = bo.up.ToString();
        shootButton.GetComponentInChildren<Text>().text = bo.shoot.ToString();
        specialAbilityButton.GetComponentInChildren<Text>().text = bo.specialAbility.ToString();
        selectUpButton.GetComponentInChildren<Text>().text = bo.selectUp.ToString();
        selectDownButton.GetComponentInChildren<Text>().text = bo.selectDown.ToString();
        selectLeftButton.GetComponentInChildren<Text>().text = bo.selectLeft.ToString();
        selectRightButton.GetComponentInChildren<Text>().text = bo.selectRight.ToString();
        selectSelectButton.GetComponentInChildren<Text>().text = bo.selectSelect.ToString();

        masterVolumeSlider.value = bo.masterVolume;
        sfxVolumeSlider.value = bo.sfxVolume;
        musicVolumeSlider.value = bo.musicVolume;
        screenModeDropdown.value = bo.screenMode;
        resolutionDropdown.value = bo.quality;
        if (resumeButton != null)
        {
            resumeButton.Select();

        }
    }
    private void SelectButton(object sender, EventArgs e)
    {
        backButton.Select();
    }
    public void OnscreenModeDropdownChanged()
    {
        screenMode = screenModeDropdown.value;
    }
    public void OnResolutionChanged()
    {
        resolution = resolutionDropdown.value;
    }
    public void OnLanguageClicked(int index)
    {
        localeIndex = index;
    }
}