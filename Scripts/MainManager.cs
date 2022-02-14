using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int saveMoney;
    public int saveBales;
    public Vector3 savePos;
    public Quaternion saveRot;

    public bool loaded = false;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    
    [System.Serializable]
    class SaveData
    {
        public int saveMoney;
        public int saveBales;
        public Vector3 savePos;
        public Quaternion saveRot;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.saveMoney = saveMoney;
        data.saveBales = saveBales;
        data.savePos = savePos;
        data.saveRot = saveRot;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Saved");
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            saveMoney = data.saveMoney;
            saveBales = data.saveBales;
            savePos = data.savePos;
            saveRot = data.saveRot;

            loaded = true;

            Debug.Log("Loaded");
        }
        
    }

}
