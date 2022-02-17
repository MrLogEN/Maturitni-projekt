using System.IO;
using UnityEngine;

public static class SaveLoad
{
    private static string filePath = Application.dataPath + "/saves/save.json";
    private static string directoryPath = Application.dataPath + "/saves";
    public static void Save(SaveObject so)
    {
        string json;

        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        //if (!File.Exists(filePath))
        //{
        //    File.Create(filePath);
        //}
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        StreamWriter sw = new StreamWriter(fs);

        json = JsonUtility.ToJson(so);
        //File.WriteAllText(filePath, json);
        sw.WriteLine(json);
        sw.Close();
        fs.Close();

    }
    public static SaveObject Load()
    {
        SaveObject so;
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath,FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string objData;// = File.ReadAllText(filePath);
            objData = sr.ReadLine();
            sr.Close();
            fs.Close();
            so = JsonUtility.FromJson<SaveObject>(objData);
        }
        else
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
            //so = new SaveObject { position = new Vector3(0, 0, 0) };
            //FileStream fs = new FileStream(filePath, FileMode.Create);
            SaveDefault();
            //string objData = File.ReadAllText(filePath);
            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string objData = sr.ReadLine();
            sr.Close();
            fs.Close();
            so = JsonUtility.FromJson<SaveObject>(objData);
            //Save(so);
        }
        return so;
    }
    public static void SaveDefault()
    {
        SaveObject so = new SaveObject
        {
            position = new Vector3(-2f, 2f, 0),
            tutorialCompleted = false,
            lvl1IsCompleted = false,
            lvl2IsCompleted = false,
            lvl3IsCompleted = false,
            lvl4IsCompleted = false,
            lvl5IsCompleted = false,

            damage = 1,
            speed = 5f,
            hasDoubleJump = false,
            skillPoints = 0,
            hasDamage = false,
            hasSwiftness = false

        };
        string json;
        json = JsonUtility.ToJson(so);
        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(json);
        sw.Close();
        fs.Close();

        //if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        //if (!File.Exists(filePath))
        //{
        //    //File.Create(filePath);
        //    FileStream fs = new FileStream(filePath, FileMode.Create);
        //    StreamWriter sw = new StreamWriter(fs);
        //    sw.Write(json);
        //    sw.Close();
        //    fs.Close();
        //}
        //else
        //{
        //    FileStream fs = new FileStream(filePath, FileMode.Open);
        //    StreamWriter sw = new StreamWriter(fs);
        //    sw.Write(json);
        //    sw.Close();
        //    fs.Close();
        //}

        
        
        //File.WriteAllText(filePath, json);
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
    public bool hasSwiftness;
    public bool hasDamage;
    public int skillPoints;
    /*
     * All of these variables will be stored on exit of a scene
     * and loaded when entering a scene
     */
    //public void LoadDefault()
    //{
    //    position = new Vector3(-4.3f, -1.6f, 0);
    //    tutorialCompleted = false;
    //    lvl1IsCompleted = false;
    //    lvl2IsCompleted = false;
    //    lvl3IsCompleted = false;
    //    lvl4IsCompleted = false;
    //    lvl5IsCompleted = false;
    //    damage = 1;
    //    speed = 5f;
    //    hasDoubleJump = false;
    //}
}
