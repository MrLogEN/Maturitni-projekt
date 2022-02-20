using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudiSources : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource movementSfxSource, shootSfxSource, playerhitsSfxSource, splashSfxSource, bossshootSfxSource, bossattackSfxSource, UISfxSource;
    void Start()
    {
        AudioManager.instance.movementS = movementSfxSource;
        AudioManager.instance.shootS  = shootSfxSource;
        AudioManager.instance.playerhitS = playerhitsSfxSource;
        AudioManager.instance.splashS = splashSfxSource;
        AudioManager.instance.bossshootS = bossshootSfxSource;
        AudioManager.instance.bossattackS = bossattackSfxSource;
        AudioManager.instance.UIS = UISfxSource;
    }

}
