using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager = new GameManager();
    public Transform player;
    // Start is called before the first frame update
    //SaveLoad sv;
    void Start()
    {
        //sv = new SaveLoad();
        SaveObject so = SaveLoad.Load();
        player.position = so.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveLoad.Save(player);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveObject so = SaveLoad.Load();
            player.position = so.position;
        }
    }
}
