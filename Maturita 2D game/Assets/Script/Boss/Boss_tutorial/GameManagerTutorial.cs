using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameManagerTutorial : MonoBehaviour
{
    public Animator animator;
    public GameObject background;

    public static GameManagerTutorial instance;
    public event EventHandler<OnStateChangedEventArgs> OnStateChaged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public TutorialState state;
    }
    public TutorialState GetState { get; private set; }
    public enum TutorialState
    {
        Starting,
        Movement,
        Jump,
        Crouch,
        LookUp,
        LookDiagonal,
        Shoot,
        Special,
        End
    }
    // private bool canInstantiate = false;
    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        background.SetActive(false);
        //canInstantiate = false;
        instance.ChangeState(TutorialState.Starting);
    }

    public void ChangeState(TutorialState newState)
    {
        OnStateChaged?.Invoke(this, new OnStateChangedEventArgs { state = newState });
        GetState = newState;
        //Debug.Log(GetState);
        switch (newState)
        {
            case TutorialState.Starting:
                HandleStart();
                break;
            case TutorialState.Movement:
                break;
            case TutorialState.Jump:
                break;
            case TutorialState.Crouch:
                break;
            case TutorialState.LookUp:
                break;
            case TutorialState.LookDiagonal:
                break;
            case TutorialState.Shoot:
                break;
            case TutorialState.Special:
                break;
            case TutorialState.End:
                break;
            default:
                break;
        }
    }

    private async void HandleStart()
    {
        //smth on start
        background.SetActive(true);

        animator.SetTrigger("playStory");
        await Task.Delay(45000);
        ChangeState(TutorialState.Movement);
        background.SetActive(false);
    }
    private void HandleEnd()
    {
        //Instantiate(targetPrefab, new Vector3(7.32f, -2.12f, 0), Quaternion.identity);
        //ChangeState(TutorialState.Exit);
    }

    void Update()
    {
    }
}
