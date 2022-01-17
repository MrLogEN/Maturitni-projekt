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

        }
        else if (isClickedLeft)
        {

        }
        else if (isClickedCrouch)
        {

        }
        else if (isClickedUp)
        {

        }
        else if (isClickedShoot)
        {

        }
        else if (isClickedSpecialAbility)
        {

        }
        else if (isClickedSelectUp)
        {

        }
        else if (isClickedSelectDown)
        {

        }
        else if (isClickedSelectLeft)
        {

        }
        else if (isClickedSelectRight)
        {

        }
        else if (isClickedSelectSelect)
        {

        }

    }
    public void OnJumpButtonClick()
    {
        isClickedJump = true;
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
