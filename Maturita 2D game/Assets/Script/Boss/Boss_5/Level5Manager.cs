using System;
using System.Threading.Tasks;
using UnityEngine;

public class Level5Manager : MonoBehaviour
{
    public static Level5Manager instance;
    public event EventHandler<OnStateChangedEventArgsL5> OnStateChaged;
    // Start is called before the first frame update
    public class OnStateChangedEventArgsL5 : EventArgs
    {
        public Level5State state;
    }

    public GameObject titleCanvas;
    public Animator titleAnimator;
    public GameObject groundFlamesPrefab;
    public Transform playerHandTransform;
    public enum Level5State
    {
        Start,
        Phase1,
        Phase2,
        End,
        End2
    }
    public Level5State GetState { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        instance.ChangeState(Level5State.Start);
        //titleCanvas.SetActive(true);

    }

    public void ChangeState(Level5State newState)
    {
        OnStateChaged?.Invoke(this, new OnStateChangedEventArgsL5 { state = newState });
        GetState = newState;
        //Debug.Log(GetState);
        switch (newState)
        {
            case Level5State.Start:
                AudioManager.instance.PlayMusicL5();
                titleCanvas.SetActive(false);
                instance.ChangeState(Level5State.Phase1);
                break;
            case Level5State.Phase1:
                break;
            case Level5State.Phase2:
                break;
            case Level5State.End:
                titleCanvas.SetActive(true);
                PlayTitles();
                break;
            case Level5State.End2:
                break;
            default:
                break;
        }
    }

    async void PlayTitles()
    {
        await Task.Delay(60000);
        LoadingManager.instance.LoadScene("main_menu");
    }
    // Update is called once per frame
    void Update()
    {
        //if (titleCanvas.activeInHierarchy)
        //{
        //    Time.timeScale = 1f;
        //}
    }
}
