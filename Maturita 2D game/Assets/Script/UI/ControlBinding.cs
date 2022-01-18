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
            string str = File.ReadAllText(filePath);
            if (str.Length > 0)
            {
                Debug.Log(File.ReadAllText(filePath));
                bo = JsonUtility.FromJson<BindingObject>(str);
                Debug.Log("Loaded from file");
            }
            else
            {
                bo = new BindingObject();
                bo.LoadDefault();
            }
        }
        else
        {
            bo = new BindingObject();
            bo.LoadDefault();
            Debug.Log("Loaded default");
        }
        Debug.Log(bo.left);
        return bo;
    }
    public static void Save(BindingObject bo)
    {
        if (!Directory.Exists(directoryPath))
        {
            Debug.Log("doesn't exist");
            Directory.CreateDirectory(directoryPath);
            Debug.Log("exists");
        }
        if (!File.Exists(filePath)) File.Create(filePath);

        string js = JsonUtility.ToJson(bo);
        Debug.Log(js);
        File.WriteAllText(filePath, js);
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
}
}