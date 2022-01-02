using System.IO;
using UnityEngine;

public class SaveLoad
{
    string filePath = Application.dataPath + "/saves/save.json";
    string directoryPath = Application.dataPath + "/saves";
    public void Save(Transform player)
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
    public SaveObject Load()
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
}
public class SaveObject
{
    public Vector3 position;
}
