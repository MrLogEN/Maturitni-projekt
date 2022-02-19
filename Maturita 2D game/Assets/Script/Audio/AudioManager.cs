using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{ 
    public static AudioManager instance;
    public AudioMixer am;
    const string MASTER_NAME = "Master";
    const string MUSIC_NAME = "Music";
    const string SFX_NAME = "Sfx";
    public ButtonsActions ba;
    BindingObject bo;


    //
    public AudioSource movmentS, shootSource;
    //všechny audio clipy, které budeme používat
    public AudioClip jumpSfx, crouchSfx, shootSfx, walkSfx, bigshootSfx, playerhitSfx, tomatosplashSfx, cannonSfx, mortarSfx, melonsplashSfx,
                     rootgroundSfx, roothandSfx, tornadospinSfx, swordchargeSfx, swordslashSfx, lampionpopSfx, arrowshoot, multiplearrowshootSfx, molotovthrowSfx,
                     molotovsplashSfx, ak47shootSfx, hoverUISfx, clickUI, escUISfx;
    void Awake()
    {
        bo = ControlBinding.Load();
        
        am.SetFloat(MASTER_NAME, Mathf.Log10(bo.masterVolume)*20);
        am.SetFloat(MUSIC_NAME, Mathf.Log10(bo.musicVolume) * 20);
        am.SetFloat(SFX_NAME, Mathf.Log10(bo.sfxVolume) * 20);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if (ba != null)
        {
            ba.OnBindingChange += OnVolumeChanged;
        }

    }
    public void PlayJumpSfx()
    {
        movmentS.clip = jumpSfx;
        movmentS.Play();
    }
    public void PlayShootSfx()
    {
        shootSource.clip = shootSfx;
        shootSource.Play();
    }

    //Za tohle nelez Ivo
    void OnVolumeChanged(object sender, EventArgs e)
    {
        bo = ControlBinding.Load();
        am.SetFloat(MASTER_NAME, Mathf.Log10(bo.masterVolume) * 20);
        am.SetFloat(MUSIC_NAME, Mathf.Log10(bo.musicVolume) * 20);
        am.SetFloat(SFX_NAME, Mathf.Log10(bo.sfxVolume) * 20);

    }
}
