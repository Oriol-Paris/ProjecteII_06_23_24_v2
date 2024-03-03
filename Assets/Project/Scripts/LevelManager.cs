using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]

    public bool random;
    private int counter = 0;

    int currentLevel1_1Index = 2;

    HashSet<int> levels = new HashSet<int>();
    private List<int> nextLevels = new List<int>();

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

    public void Awake()
    {
        PlayerPrefs.SetInt("LevelsCompleted", 1);
    }

    public void NextScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void NextScene(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }

    public void StartTower()
    {
        LoadRandomNextLevel();
        int highestSceneID = SceneManager.sceneCountInBuildSettings - 2; ;

        random = true;

        levels.Clear();
        levels = new HashSet<int>(Enumerable.Range(1, highestSceneID));
        nextLevels = levels.ToList();
        nextLevels = nextLevels.OrderBy(x => Random.value).ToList();

        ShuffleLevels();
    }

    public void Return()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex-1);
    }

    public void LoadWorld()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        if (button != null)
        {
            string buttonNumberString = button.name.Replace("ButtonWorld", "");

            if (int.TryParse(buttonNumberString, out int buttonIndex))
            {
                if (buttonIndex >= 1 && buttonIndex <= SceneManager.sceneCountInBuildSettings)
                    SceneManager.LoadScene(buttonIndex + 1);
                else
                    Debug.Log("Index not found");
            }
        }
        else
            Debug.Log("Name not valid");
    }

    public void LoadLevel()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        if (button != null)
        {
            string buttonNumberString = button.name.Replace("ButtonLevel", "");
            if(int.TryParse(buttonNumberString,out int buttonIndex))
            {
                if (buttonIndex >= 1 && buttonIndex <= SceneManager.sceneCountInBuildSettings)
                    SceneManager.LoadScene(currentLevel1_1Index - 1 + buttonIndex);
                else
                    Debug.Log("Index not found");
            }
        }
        else
            Debug.Log("Name not valid");
    }

    public void LoadRandomNextLevel()
    {
        int nextSceneID = nextLevels[counter];

        SceneManager.LoadScene(nextSceneID);

        counter++;
    }

    private void ShuffleLevels()
    {
        int n = nextLevels.Count;

        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int value = nextLevels[k];
            nextLevels[k] = nextLevels[n];
            nextLevels[n] = value;
        }
    }

    public static void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void UnlockAllLevels()
    {
        PlayerPrefs.SetInt("LevelsCompleted", 50);
    }

}
