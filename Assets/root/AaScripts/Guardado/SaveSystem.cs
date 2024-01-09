using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{
    public static void SaveGameManager(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameManager.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadGameManager()
    {
        string path = Application.persistentDataPath + "/gameManager.txt";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("FALLO DE FICHERO XD");
            return null;
        }
    }
}
