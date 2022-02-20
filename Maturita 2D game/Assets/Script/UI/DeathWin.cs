using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeathWin : MonoBehaviour
{
    public GameObject boss;
    public GameObject player;
    public Slider healthSlider;
    public Image winscreen;
    public Image deathscreen;
    public PlayerActions pa;
    private float bossHP;
    public IBoss bossS;
    private SaveObject so;


    void Start()
    {
        Time.timeScale = 1f;
        
        bossS = boss.GetComponent<IBoss>();
        pa = player.GetComponent<PlayerActions>();
        bossHP = bossS.Health;
        so = SaveLoad.Load();
    }
    void Update()
    {
        float bosshealth = bossS.Health;

        if (bosshealth <= 0  )
        {
            if (bossS is Boss5) return;
            Time.timeScale = 0f;
            winscreen.gameObject.SetActive(true);

           
        }
        if(pa.Health <= 0  )
        {
            
            Time.timeScale = 0f;
            deathscreen.gameObject.SetActive(true);
            healthSlider.maxValue = bossHP;
            healthSlider.value = bosshealth;
             
        }
    }
}
