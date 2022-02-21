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
    int rand;
    System.Random rn = new System.Random();
    //
    public AudioSource movementS, shootS, playerhitS, splashS, bossshootS, bossattackS, UIS,musicS;
    //všechny audio clipy, které budeme používat
    public AudioClip jumpSfx, crouchSfx, shootSfx, walkSfx, bigshootSfx, playerhitSfx, tomatosplashSfx, cannonSfx, mortarSfx, melonsplashSfx,
                     rootgroundSfx, roothandSfx, tornadospinSfx, swordchargeSfx, lampionpopSfx, arrowshootSfx, multiplearrowshootSfx, molotovthrowSfx,
                     molotovsplashSfx, ak47singleshootSfx, hoverUISfx, clickUISfx, escUISfx, carrotmissileSfx, coconutfall1Sfx, coconutfall2Sfx, coconutfall3Sfx,
                     coconutspawn1Sfx, coconutspawn2Sfx, coconutspawn3Sfx, drinkwaterSfx, fireballlandSfx, fireballshoot1Sfx, fireballshoot2Sfx, fireballshoot3Sfx,
                     groundslamSfx, groundwaveSfx, jumpbossSfx, swordslash1Sfx, swordslash2Sfx, swordslash3Sfx, whoosh1Sfx, whoosh2Sfx, whoosh3Sfx,level5Music,level4Music,level3Music,level2Music,
                     level1Music,mainMenuMusic,levelSelectMusic;
    void Awake()
    {
        ba = FindObjectOfType<ButtonsActions>();
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
    #region soundMethods
    public void PlayJumpSfx()
    {
        movementS.clip = jumpSfx;
        movementS.Play();
    }
    public void PlayShootSfx()
    {
        shootS.clip = shootSfx;
        shootS.Play();
    }
    public void PlayCrouchSfx()
    {
        movementS.clip = crouchSfx;
        movementS.Play();
    }
    public void PlayWalkSfx()
    {
        movementS.clip = walkSfx;
        movementS.Play();
    }
    public void PlayBigShootSfx()
    {
        shootS.clip = bigshootSfx;
        shootS.Play();
    }
    public void PlayPlayerHitSfx()
    {
        playerhitS.clip = playerhitSfx;
        playerhitS.Play();
    }
    public void PlayTomatoSplashSfx()
    {
        splashS.clip = tomatosplashSfx;
        splashS.Play();
    }
    public void PlayMortarSfx()
    {
        bossshootS.clip = mortarSfx;
        bossshootS.Play();
    }
    public void PlayCannonSfx()
    {
        bossshootS.clip = cannonSfx;
        bossshootS.Play();
    }
    public void PlayMelonSplashSfx()
    {
        splashS.clip = melonsplashSfx;
        splashS.Play();
    }
    public void PlayRootGroundSfx()
    {
        bossattackS.clip = rootgroundSfx;
        bossattackS.Play();
    }
    public void StopRootGroundSfx()
    {
        bossattackS.Stop();
    }
    public void PlayRootHandSfx()
    {
        bossattackS.clip = roothandSfx;
        bossattackS.Play();
    }
    public void PlayTornadoSpinSfx()
    {
        bossattackS.clip = tornadospinSfx;
        bossattackS.Play();
    }
    public void PlaySwordChargeSfx()
    {
        bossattackS.clip = swordchargeSfx;
        bossattackS.Play();
    }
    public void StopSwordCharge()
    {
        bossattackS.Stop();
    }
    public void PlaySwordSlashSfx()
    {
        rand = rn.Next(0, 2);
        switch (rand)
        {
            case 0:
                bossshootS.clip = swordslash1Sfx;
                bossshootS.Play();
                break;
            case 1:
                bossshootS.clip = swordslash2Sfx;
                bossshootS.Play();
                break;
            case 2:
                bossshootS.clip = swordslash3Sfx;
                bossshootS.Play();
                break;
            default:
                break;
        }
    }//RANDOM
    public void PlayLampionPopSfx()
    {
        splashS.clip = lampionpopSfx;
        splashS.Play();
    }
    public void PlayArrowShootSfx()
    {
        bossshootS.clip = arrowshootSfx;
        bossshootS.Play();
    }
    public void PlayMultipleArrowShootSfx()
    {
        bossshootS.clip = multiplearrowshootSfx;
        bossshootS.Play();
    }
    public void PlayMolotovThrowSfx()
    {
        bossshootS.clip = molotovthrowSfx;
        bossshootS.Play();
    }
    public void PlayMolotovSplashSfx()
    {
        splashS.clip = molotovsplashSfx;
        splashS.Play();
    }
    public void PlayAK47SingleShootSfx()
    {
        bossshootS.clip = ak47singleshootSfx;
        bossshootS.Play();
    }
    public void PlayHoverUISfx()
    {
        UIS.clip = hoverUISfx;
        UIS.Play();
    }
    public void PlayClickUISfx()
    {
        UIS.clip = clickUISfx;
        UIS.Play();
    }
    public void PlayEscUISfx()
    {
        UIS.clip = escUISfx;
        UIS.Play();
    }
    public void PlayCarrotMissileSfx()
    {
        bossshootS.clip = carrotmissileSfx;
        bossshootS.Play();
    }
    public void PlayCoconutSpawnSfx()
    {
        rand = rn.Next(0, 2);
        switch (rand)
        {
            case 0:
                bossattackS.clip = coconutspawn1Sfx;
                bossattackS.Play();
                break;
            case 1:
                bossattackS.clip = coconutspawn2Sfx;
                bossattackS.Play();
                break;
            case 2:
                bossattackS.clip = coconutspawn3Sfx;
                bossattackS.Play();
                break;
            default:
                break;
        }
    }//RANDOM
    public void PlayCoconutFallSfx()
    {
        rand = rn.Next(0, 2);
        switch (rand)
        {
            case 0:
                splashS.clip = coconutfall1Sfx;
                splashS.Play();
                break;
            case 1:
                splashS.clip = coconutfall2Sfx;
                splashS.Play();
                break;
            case 2:
                splashS.clip = coconutfall3Sfx;
                splashS.Play();
                break;
            default:
                break;
        }

    }//RANDOM
    public void PlayDrinkWaterSfx()
    {
        bossshootS.clip = drinkwaterSfx;
        bossshootS.Play();
    }
    public void PlayFireballLandSfx()
    {
        splashS.clip = fireballlandSfx;
        splashS.Play();
    }
    public void PlayFireballShootSfx()
    {
        rand = rn.Next(0, 2);
        switch (rand)
        {
            case 0:
                bossattackS.clip = fireballshoot1Sfx;
                bossattackS.Play();
                break;
            case 1:
                bossattackS.clip = fireballshoot2Sfx;
                bossattackS.Play();
                break;
            case 2:
                bossattackS.clip = fireballshoot3Sfx;
                bossattackS.Play();
                break;
            default:
                break;
        }
    }//RANDOM
    public void PlayGroundSlamSfx()
    {
        splashS.clip = groundslamSfx;
        splashS.Play();
    }
    public void PlayGroundWaveSfx()
    {
        bossattackS.clip = groundwaveSfx;
        bossattackS.Play();
    }
    public void PlayJumpBossSfx()
    {
        bossshootS.clip = jumpbossSfx;
        bossshootS.Play();
    }
    public void PlayWhooshSfx()
    {
        rand = rn.Next(0, 2);
        switch (rand)
        {
            case 0:
                bossattackS.clip = whoosh1Sfx;
                bossattackS.Play();
                break;
            case 1:
                bossattackS.clip = whoosh2Sfx;
                bossattackS.Play();
                break;
            case 2:
                bossattackS.clip = whoosh3Sfx;
                bossattackS.Play();
                break;
            default:
                break;
        }
    }
    public void PlayMusicL1()
    {
        musicS.clip = level1Music;
        musicS.Play();
    }
    public void PlayMusicL2()
    {
        musicS.clip = level2Music;
        musicS.Play();
    }
    public void PlayMusicL3()
    {
        musicS.clip = level3Music;
        musicS.Play();
    }
    public void PlayMusicL4()
    {
        musicS.clip = level4Music;
        musicS.Play();
    }
    public void PlayMusicL5()
    {
        musicS.clip = level5Music;
        musicS.Play();
    }
    public void PlayMusicLevelSelect()
    {
        musicS.clip = levelSelectMusic;
        musicS.Play();
    }
    public void PlayMusicMainMenu()
    {
        musicS.clip = mainMenuMusic;
        musicS.Play();
    }

    #endregion

    //Za tohle nelez Ivo
    void OnVolumeChanged(object sender, EventArgs e)
    {
        bo = ControlBinding.Load();
        print("kunda fdsfasdf");
        am.SetFloat(MASTER_NAME, Mathf.Log10(bo.masterVolume) * 20);
        am.SetFloat(MUSIC_NAME, Mathf.Log10(bo.musicVolume) * 20);
        am.SetFloat(SFX_NAME, Mathf.Log10(bo.sfxVolume) * 20);

    }
}
