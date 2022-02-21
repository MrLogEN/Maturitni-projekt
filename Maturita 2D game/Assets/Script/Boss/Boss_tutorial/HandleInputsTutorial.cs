using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class HandleInputsTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public event EventHandler<OnKeyPressedEventArgs> OnKeyPressed;
    public LocalizedString myStr;
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

        switch (LocalizationSettings.SelectedLocale.Identifier.Code)
        {
            case "en":
                stateText.text = "Go left and right by pressing " + left.ToString() + " and " + right.ToString();
                break;
            case "cs":
                stateText.text = "Jděte doleva a doprava stisknutím " + left.ToString() + " a " + right.ToString();
                break;
            case "ru":
                stateText.text = "Двигайтесь влево и вправо, нажимая " + left.ToString() + " и " + right.ToString();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    async void Update()
    {
        await ChangeInstruction(GameManagerTutorial.instance.GetState);
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

                    switch (LocalizationSettings.SelectedLocale.Identifier.Code)
                    {
                        case "en":
                            stateText.text = "Jump by pressing " + jump.ToString();
                            break;
                        case "cs":
                            stateText.text = "Skočte stisknutím " + jump.ToString();
                            break;
                        case "ru":
                            stateText.text = "Прыгайте, нажимая " + jump.ToString();
                            break;
                        default:
                            break;
                    }

                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.Jump);
                }
                break;
            case GameManagerTutorial.TutorialState.Jump:
                //stateText.text = "Jump by pressing " + jump.ToString();
                if (Input.GetKey(jump))
                {
                    await Task.Delay(delay);

                    switch (LocalizationSettings.SelectedLocale.Identifier.Code)
                    {
                        case "en":
                            stateText.text = "Crouch up by pressing " + crouch.ToString();
                            break;
                        case "cs":
                            stateText.text = "Přikrčte se stisknutím " + crouch.ToString();
                            break;
                        case "ru":
                            stateText.text = "Присядьте, нажав " + crouch.ToString();
                            break;
                        default:
                            break;
                    }

                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.Crouch);

                }
                break;
            case GameManagerTutorial.TutorialState.Crouch:
                //stateText.text = "Jump by pressing " + jump.ToString();
                if (Input.GetKey(crouch))
                {
                    await Task.Delay(delay);

                    switch (LocalizationSettings.SelectedLocale.Identifier.Code)
                    {
                        case "en":
                            stateText.text = "Look up by pressing " + up.ToString();
                            break;
                        case "cs":
                            stateText.text = "Podívejte se nahoru stisknutím " + up.ToString();
                            break;
                        case "ru":
                            stateText.text = "Посмотрите вверх, нажав " + up.ToString();
                            break;
                        default:
                            break;
                    }

                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.LookUp);

                }
                break;
            case GameManagerTutorial.TutorialState.LookUp:
                //stateText.text = "Look up by pressing " + up.ToString();
                if (Input.GetKey(up))
                {
                    await Task.Delay(delay);

                    switch (LocalizationSettings.SelectedLocale.Identifier.Code)
                    {
                        case "en":
                            stateText.text = "Look diagonal by pressing " + left.ToString() + " or " + right.ToString() + " and " + up.ToString();
                            break;
                        case "cs":
                            stateText.text = "Podívejte se diagonálně stisknutím " + left.ToString() + " nebo " + right.ToString() + " a " + up.ToString();
                            break;
                        case "ru":
                            stateText.text = "Посмотрите по диагонали, нажав " + left.ToString() + " или " + right.ToString() + " и " + up.ToString();
                            break;
                        default:
                            break;
                    }

                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.LookDiagonal);

                }
                break;
            case GameManagerTutorial.TutorialState.LookDiagonal:
                //stateText.text = "Look diagonal by pressing " + left.ToString() + " or " + right.ToString() + " and " + up.ToString();
                if ((Input.GetKey(left) || Input.GetKey(right)) && Input.GetKey(up))
                {
                    await Task.Delay(delay);

                    switch (LocalizationSettings.SelectedLocale.Identifier.Code)
                    {
                        case "en":
                            stateText.text = "Shoot by pressing " + shoot.ToString();
                            break;
                        case "cs":
                            stateText.text = "Střílejte stisknutím " + shoot.ToString();
                            break;
                        case "ru":
                            stateText.text = "Стреляйте, нажав " + shoot.ToString();
                            break;
                        default:
                            break;
                    }

                    await Task.Delay(delay);
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.Shoot);

                }
                break;
            case GameManagerTutorial.TutorialState.Shoot:
                //stateText.text = "Shoot by pressing " + shoot.ToString();
                if (Input.GetKey(shoot))
                {
                    await Task.Delay(delay);

                    switch (LocalizationSettings.SelectedLocale.Identifier.Code)
                    {
                        case "en":
                            stateText.text = "Shoot the target by pressing " + shoot.ToString() + " until the blue bar is full. Then shoot special ability by pressing " + special.ToString();
                            break;
                        case "cs":
                            stateText.text = "Střílejte na cíl stisknutím " + shoot.ToString() + " dokud se modrý pruh nezaplní. Poté vystřelte speciální schopnost stisknutím " + special.ToString();
                            break;
                        case "ru":
                            stateText.text = "Стреляйте в цель, нажимая " + shoot.ToString() + " пока синяя полоса не заполнится. Затем выстрелите специальной способностью, нажав " + special.ToString();
                            break;
                        default:
                            break;
                    }

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