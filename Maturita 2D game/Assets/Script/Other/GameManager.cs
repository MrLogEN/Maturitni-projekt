using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    SaveLoad sv;
    void Start()
    {
        sv = new SaveLoad();
        SaveObject so = sv.Load();
        player.position = so.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            sv.Save(player);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveObject so = sv.Load();
            player.position = so.position;
        }
    }
}
