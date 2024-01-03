using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public bool random = true;

    private List<int> usedLevels = new List<int>();

    private static LevelManager instance;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("LevelManager");
                    instance = obj.AddComponent<LevelManager>();
                }
            }

            return instance;
        }
    }

    public void StartGame()
    {
        if (!random)
            SceneManager.LoadScene("Level 1");
        else
            LoadRandomNextLevel();
    }

    public void LoadRandomNextLevel()
    {
        int highestSceneID = SceneManager.sceneCountInBuildSettings - 1;

        if(usedLevels.Count == highestSceneID- 1)
            usedLevels.Clear();

        int nextSceneID;
        do
        {
            nextSceneID = Random.Range(1, highestSceneID);
        } while (usedLevels.Contains(nextSceneID));

        usedLevels.Add(nextSceneID);

        SceneManager.LoadScene(nextSceneID);
    }

    public void ChangeRandom()
    {
        random = !random;

    }
}
