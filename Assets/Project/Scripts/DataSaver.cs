using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class TrophyList
{
    public List<int> list = new List<int>();
}

[Serializable]
public class DataSaver : MonoBehaviour
{
    private int levelOffset = 2;
    private TrophyList trophies;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void FirstLoad()
    {
        trophies.list.Add(1);
        GetComponent<FileManager>().Save(trophies.list);
        this.trophies.list = GetComponent<FileManager>().Load();
    }

    public void SaveLevel(int stars)
    {
        if(trophies.list[SceneManager.GetActiveScene().buildIndex - levelOffset] < stars)
        {
            trophies.list[SceneManager.GetActiveScene().buildIndex - levelOffset] = stars;
        }
    }

    public TrophyList GetTrophies() { return trophies; }

    private void OnApplicationQuit()
    {
        GetComponent<FileManager>().Save(trophies.list);
    }
}
