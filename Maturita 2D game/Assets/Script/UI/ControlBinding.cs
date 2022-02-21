using System.IO;
using UnityEngine;

public static class ControlBinding
{
    static string directoryPath = Application.dataPath + "/defaults";
    static string filePath = Application.dataPath + "/defaults/binding.json";
    public static BindingObject Load()
    {

        
        BindingObject bo;
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string str1 = sr.ReadLine();
            sr.Close();
            fs.Close();
            bo = JsonUtility.FromJson<BindingObject>(str1);
        }
        else
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
            bo = new BindingObject();
            bo.LoadDefault();
            Save(bo);
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string str1 = sr.ReadLine();
            sr.Close();
            fs.Close();
            bo = JsonUtility.FromJson<BindingObject>(str1);
        }
        

        //if (str1.Length > 0)
        //{
        //    bo = JsonUtility.FromJson<BindingObject>(str1);
        //}
        //else
        //{
        //    bo = new BindingObject();
        //    bo.LoadDefault();
        //}

       
        return bo;
    }
    public static void Save(BindingObject bo)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }


        FileStream fs = new FileStream(filePath,FileMode.OpenOrCreate);
        StreamWriter sw = new StreamWriter(fs);
        string js = JsonUtility.ToJson(bo);
        sw.WriteLine(js);
        sw.Close();
        fs.Close();
        //Debug.Log(js);
        //File.WriteAllText(filePath, js);
    }
}
public class BindingObject
{
    //boss room
    public KeyCode jump;
    public KeyCode right;
    public KeyCode left;
    public KeyCode crouch;
    public KeyCode up;
    public KeyCode shoot;
    public KeyCode specialAbility;

    //level select

    public KeyCode selectUp;
    public KeyCode selectDown;
    public KeyCode selectLeft;
    public KeyCode selectRight;
    public KeyCode selectSelect;

    //audio
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    //display
    public int screenMode;
    public int quality;

    public int localizationIndex;

    public void LoadDefault()
    {
        jump = KeyCode.Z;
        right = KeyCode.RightArrow;
        left = KeyCode.LeftArrow;
        crouch = KeyCode.C;
        up = KeyCode.UpArrow;
        shoot = KeyCode.X;
        specialAbility = KeyCode.V;

        selectDown = KeyCode.DownArrow;
        selectLeft = KeyCode.LeftArrow;
        selectRight = KeyCode.RightArrow;
        selectSelect = KeyCode.X;
        selectUp = KeyCode.UpArrow;


        //audio
        masterVolume = 1f;
        musicVolume = 1f;
        sfxVolume = 1f;

        //display
        screenMode = 0;
        quality = 0;

        localizationIndex = 0;
    }
}