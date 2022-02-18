using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class HandleInputsTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public event EventHandler<OnKeyPressedEventArgs> OnKeyPressed;
    public class OnKeyPressedEventArgs
    {
        public KeyCode keyCode;
    }
    public KeyCode left, right, up, crouch, jump, shoot, special;
    public GameObject gm;

    private Text stateText;
    private BindingObject bo;
    //private bool finished = false;
    void Start()
    {
        bo = ControlBinding.Load();
        left = bo.left;
        right = bo.right;
        up = bo.up;
        crouch = bo.crouch;
        jump = bo.jump;
        shoot = bo.shoot;
        special = bo.specialAbility;
        stateText = gameObject.GetComponent<Text>();
        stateText.text = "Go left and right by pressing " + left.ToString() + " and " + right.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeInstruction(GameManagerTutorial.instance.GetState);
    }
    private List<KeyCode> pressed = new List<KeyCode>();
    private async Task ChangeInstruction(GameManagerTutorial.TutorialState state)
    {
        int delay = 700;
        switch (state)
        {
            case GameManagerTutorial.TutorialState.Movement:
                //stateText.text = "Go left and right by pressing " + left.ToString() + " and " + right.ToString();
                if (Input.GetKey(left))
                {
                    pressed.Add(left);
                }
                if (Input.GetKey(right))
                {
                    pressed.Add(right);
                }
                if (pressed.Contains(left) && pressed.Contains(right))
                {
                    await Task.Delay(delay);
                    stateText.text = "Jump by pressing " + jump.ToString();
                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.Jump);
                }
                break;
            case GameManagerTutorial.TutorialState.Jump:
                //stateText.text = "Jump by pressing " + jump.ToString();
                if (Input.GetKey(jump))
                {
                    await Task.Delay(delay);
                    stateText.text = "Crouch up by pressing " + crouch.ToString();
                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.Crouch);

                }
                break;
            case GameManagerTutorial.TutorialState.Crouch:
                //stateText.text = "Jump by pressing " + jump.ToString();
                if (Input.GetKey(crouch))
                {
                    await Task.Delay(delay);
                    stateText.text = "Look up by pressing " + up.ToString();
                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.LookUp);

                }
                break;
            case GameManagerTutorial.TutorialState.LookUp:
                //stateText.text = "Look up by pressing " + up.ToString();
                if (Input.GetKey(up))
                {
                    await Task.Delay(delay);
                    stateText.text = "Look diagonal by pressing " + left.ToString() + " or " + right.ToString() + " and " + up.ToString();
                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.LookDiagonal);

                }
                break;
            case GameManagerTutorial.TutorialState.LookDiagonal:
                //stateText.text = "Look diagonal by pressing " + left.ToString() + " or " + right.ToString() + " and " + up.ToString();
                if ((Input.GetKey(left)||Input.GetKey(right))&&Input.GetKey(up))
                {
                    await Task.Delay(delay);
                    stateText.text = "Shoot by pressing " + shoot.ToString();
                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.Shoot);

                }
                break;
            case GameManagerTutorial.TutorialState.Shoot:
                //stateText.text = "Shoot by pressing " + shoot.ToString();
                if (Input.GetKey(shoot))
                {
                    await Task.Delay(delay);
                    stateText.text = "Shoot the target by pressing " +shoot.ToString()+ " until the blue bar is full. Then shoot special ability by pressing " + special.ToString();
                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.Special);

                }
                break;
            case GameManagerTutorial.TutorialState.Special:
                //stateText.text = "Shoot special ability by pressing " + special.ToString();
                if (Input.GetKey(special))
                {
                    
                        await Task.Delay(delay);
                        stateText.text = "";
                        await Task.Delay(delay);
                        //GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.End);
                        

                }
                break;
            case GameManagerTutorial.TutorialState.End:
                stateText.text = "";
                break;
            default:
                break;
        }
        //await Task.Yield();
    }
}
