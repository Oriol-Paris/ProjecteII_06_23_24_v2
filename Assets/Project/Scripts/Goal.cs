using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField]
    public string NextLevelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        if (!LevelManager.Instance.random)
            SceneManager.LoadScene(NextLevelName);
        else
            LevelManager.Instance.LoadRandomNextLevel();
    }
}
