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

    public void NextScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void NextScene(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }

    public void Return()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex-1);
    }

    public void LoadLevel()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        if (button != null)
        {
            GameObject audioManagerMenu = GameObject.FindGameObjectWithTag("audio");
            Destroy(audioManagerMenu);
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

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
