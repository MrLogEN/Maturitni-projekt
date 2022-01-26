using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTarget : MonoBehaviour
{
    public GameObject prefab;
    bool isInstantiated = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerTutorial.instance.OnStateChaged += Spawn;
    }
    
    private void Spawn(object sender, GameManagerTutorial.OnStateChangedEventArgs e)
    {
        if (e.state == GameManagerTutorial.TutorialState.End && !isInstantiated)
        {
            Instantiate(prefab, new Vector3(7.32f, -2.12f, 0), Quaternion.identity);
            isInstantiated = true;
        }
    }
       
}
