using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitTarget : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hiiit neeee");
        if (collision.gameObject.tag == "PlayerAttack")
        {
            Debug.Log("hiiit");
            //OnExitTargetFinished?.Invoke(instance, EventArgs.Empty);
            SaveObject so = SaveLoad.Load();
            so.tutorialCompleted = true;
            SaveLoad.Save(so);
            SceneManager.LoadScene(1);
        }
    }
}
