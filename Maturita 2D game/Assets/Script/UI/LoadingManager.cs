using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Slider _progressBar;
    private float _target;
    [SerializeField] private GameObject _transitionCanvas;
    [SerializeField] private Animator _animator;
    void Awake()
    {
        if (instance ==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public async void LoadScene(string sceneName)
    {
        _target = 0;
        _progressBar.value = 0;
        _transitionCanvas.SetActive(true);
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);
        
        do
        {
            //await Task.Delay(100);
            _target = scene.progress;
        } while (scene.progress < 0.9f);
        await Task.Delay(200);
        scene.allowSceneActivation = true;

        _animator.SetTrigger("Start");
        await Task.Delay(1000);
        _loaderCanvas.SetActive(false);
        _animator.SetTrigger("End");
        await Task.Delay(1000);
        _transitionCanvas.SetActive(false);
    }
    void Update()
    {
        _progressBar.value = Mathf.MoveTowards(_progressBar.value, _target, 3 * Time.deltaTime);
    }
}
