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
        var scene = SceneManager.LoadSceneAsync(sceneName);

        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);
        do
        {
            //await Task.Delay(100);
            _target = scene.progress;
        } while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }
    void Update()
    {
        _progressBar.value = Mathf.MoveTowards(_progressBar.value, _target, 3 * Time.deltaTime);
    }
}
