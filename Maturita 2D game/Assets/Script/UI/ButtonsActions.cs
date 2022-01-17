using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ButtonsActions : MonoBehaviour
{
    // Start is called before the first frame update
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




    //fdsafdsafasfdsfdasfsda
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

    private void Update()
    {
        //print(isClickedJump);
        
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
}
