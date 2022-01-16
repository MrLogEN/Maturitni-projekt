using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum State
    {
        start,
        normal,
        end
    }
    public State state;
    void Awake()
    {
        state = State.start;
    }
    [SerializeField]private GameObject player;
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.start:
                HandleStart();
                break;
            case State.normal:
                break;
            case State.end:
                break;
            default:
                break;
        }
    }
    private void HandleStart()
    {
        SaveObject so = SaveLoad.Load();
        player.transform.position = so.position;
    }
}