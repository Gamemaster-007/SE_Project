using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(camera_movement info)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data8.se";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavingData data = new SavingData(info);

        formatter.Serialize(stream , data);
        stream.Close();
    }

    public static SavingData LoadData()
    {
        string path = Application.persistentDataPath + "/data8.se";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavingData data = formatter.Deserialize(stream) as SavingData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Saved File not found");
            return null;
        }
    }
}
