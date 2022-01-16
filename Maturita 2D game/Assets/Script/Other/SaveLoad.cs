using System.IO;
using UnityEngine;

public static class SaveLoad
{
    private static string filePath = Application.dataPath + "/saves/save.json";
    private static string directoryPath = Application.dataPath + "/saves";
    public static void Save(Transform player)
    {

        SaveObject so = new SaveObject
        {
            position = player.position
        };
        string json;

        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }

        json = JsonUtility.ToJson(so);
        File.WriteAllText(filePath, json);


    }
    public static SaveObject Load()
    {
        SaveObject so;
        if (File.Exists(filePath))
        {
            string objData = File.ReadAllText(filePath);
            so = JsonUtility.FromJson<SaveObject>(objData);
        }
        else
        {
            so = new SaveObject { position = new Vector3(0, 0, 0) };
        }
        return so;
    }
    public static void SaveDefault()
    {
        SaveObject so = new SaveObject
        {
            position = new Vector3(0, 0, 0),
            tutorialCompleted = false,
            lvl1IsCompleted = false,
            lvl2IsCompleted = false,
            lvl3IsCompleted = false,
            lvl4IsCompleted = false,
            lvl5IsCompleted = false,

            damage = 1,
            speed = 5f,
            hasDoubleJump = false

        };
        string json;

        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }

        json = JsonUtility.ToJson(so);
        File.WriteAllText(filePath, json);
    }
}
public class SaveObject
{
    public Vector3 position; // For position save in lvlSelect - stores the actual position when exiting the level select or fixed positions when entering a level.
    public bool tutorialCompleted;
    public bool lvl1IsCompleted; //Storing the status of level 1
    public bool lvl2IsCompleted; //Storing the status of level 2
    public bool lvl3IsCompleted; //Storing the status of level 3
    public bool lvl4IsCompleted; //Storing the status of level 4
    public bool lvl5IsCompleted; //Storing the status of level 5

    public int damage; //damage of player from skill tree or default
    public float speed; //speed of the player from skill tree or default
    public bool hasDoubleJump; //bool saying if the player has double jump or not - also skill tree
    /*
     * All of these variables will be stored on exit of a scene
     * and loaded when entering a scene
     */
}
