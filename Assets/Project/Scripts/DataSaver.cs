using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}


[Serializable]
public class TrophyList
{
    public List<int> list = new List<int>();
}

[Serializable]
public class DataSaver : MonoBehaviour
{
    [SerializeField]
    private string fileName;

    public int levelOffset = 2;
    public TrophyList trophies;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void FirstLoad()
    {
        Load();

        if(trophies.list.Count == 0) 
        {
            trophies.list = new List<int>();
            trophies.list.Add(0);
        }
    }

    public void SaveLevel(int stars)
    {
        if(SceneManager.GetActiveScene().buildIndex - levelOffset > trophies.list.Count - 1)
        {
            trophies.list.Add(stars);
        }
        else if (trophies.list[SceneManager.GetActiveScene().buildIndex - levelOffset] < stars)
        {
            trophies.list[SceneManager.GetActiveScene().buildIndex - levelOffset] = stars;
        }
    }

    public TrophyList GetTrophies() { return trophies; }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonHelper.ToJson(trophies.list.ToArray());

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    public void Load()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, fileName);
        int[] readTrophies = new int[SceneManager.sceneCountInBuildSettings];

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                readTrophies = JsonHelper.FromJson<int>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }

        this.trophies.list = readTrophies.ToList<int>();
    }
}
