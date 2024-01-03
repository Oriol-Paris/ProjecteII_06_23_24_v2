using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public bool random;

    private int counter;


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

    private void Awake()
    {
        random = false;
        counter = 0;
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
        int nextSceneID = nextLevels[counter];

        SceneManager.LoadScene(nextSceneID);

        counter++;
    }

    public void ChangeRandom()
    {
        random = !random;
        int highestSceneID = SceneManager.sceneCountInBuildSettings - 1; ;

        levels.Clear();
        levels = new HashSet<int>(Enumerable.Range(1,highestSceneID));
        nextLevels = levels.ToList();
        nextLevels = nextLevels.OrderBy(x => Random.value).ToList();
        
        ShuffleLevels();

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
}
