using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class OnStartVideoDecider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]RawImage videoBackground;
    [SerializeField] Image LoadingBar;
    VideoPlayer vp;
    BindingObject bo;
    void Start()
    {
        bo = ControlBinding.Load();
        vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += EndOfVideo;
        print(1);
        if (!PlayerPrefs.HasKey("hasPlayed"))
        {
            videoBackground.gameObject.SetActive(true);
            vp.Play();
            print(2);
            PlayerPrefs.SetInt("hasPlayed", 1);
        }
        else
        {
            print(PlayerPrefs.GetInt("hasPlayed") + " je to ono");
            if (PlayerPrefs.GetInt("hasPlayed") == 1) return;
            videoBackground.gameObject.SetActive(true);
            vp.Play();
            print(3);
            PlayerPrefs.SetInt("hasPlayed", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(bo.selectSelect))
        {
            LoadingBar.fillAmount += 0.5f*Time.deltaTime;
            if (LoadingBar.fillAmount == 1)
            {
                PlayerPrefs.SetInt("hasPlayed", 1);
                vp.Stop();
                videoBackground.gameObject.SetActive(false);
            }
        }
        else
        {
            LoadingBar.fillAmount -= 0.5f * Time.deltaTime;
        }
    }
    private void EndOfVideo(VideoPlayer vp)
    {
        videoBackground.gameObject.SetActive(false);

    }
}
