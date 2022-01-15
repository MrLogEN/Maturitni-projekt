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
    public int jump;
    public int right;
    public int left;
    public int crouch;
    public int up;
    public int shoot;
    public int specialAbility;

    //level select

    public int selectUp;
    public int selectDown;
    public int selectLeft;
    public int selectRight;
    public int selectSelect;

    public void LoadDefault()
    {
        jump = (int)KeyCode.Z;
        right = (int)KeyCode.RightArrow;
        left = (int)KeyCode.LeftArrow;
        crouch = (int)KeyCode.DownArrow;
        up = (int)KeyCode.UpArrow;
        shoot = (int)KeyCode.X;
        specialAbility = (int)KeyCode.V;

        selectDown = (int)KeyCode.DownArrow;
        selectLeft = (int)KeyCode.LeftArrow;
        selectRight = (int)KeyCode.RightArrow;
        selectSelect = (int)KeyCode.X;
        selectUp = (int)KeyCode.UpArrow;
    }
}