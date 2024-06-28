using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    List<Sprite> textures;

    [SerializeField, ColorUsage(true, true)]
    public List<Color> colors;

    void Start()
    {

        GetComponent<SpriteRenderer>().sprite = textures[Random.Range(0, textures.Count - 1)];

        GetComponent<SpriteRenderer>().material.color = colors[Random.Range(0, colors.Count - 1)];

        StartCoroutine(FindAnyObjectByType<Fade>().TransitionFadeOut());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindAnyObjectByType<Player>().GetComponent<Rigidbody2D>().drag = 25;

            CheckIfNewMaxLevel();
            StartCoroutine(FindAnyObjectByType<Fade>().TransitionFadeIn());
            FindAnyObjectByType<MenuButton>().EnterWinScreen();
        }
    }

    private void CheckIfNewMaxLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex - 1 >= PlayerPrefs.GetInt("LevelsCompleted"))
            PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted") + 1);
    }
}
