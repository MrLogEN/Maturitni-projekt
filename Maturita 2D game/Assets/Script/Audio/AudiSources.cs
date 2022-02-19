using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudiSources : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource movementSfxSource, shootSfxSource;
    void Start()
    {
        AudioManager.instance.movmentS = movementSfxSource;
        AudioManager.instance.shootSource = shootSfxSource;
    }

}
