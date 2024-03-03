using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    List<Sprite> textures;

    private Animator transition;
    GameObject transitionGameObject;
    private Rigidbody2D player;

    void Start()
    {
        transitionGameObject = GameObject.FindGameObjectWithTag("Transition");
        transition = transitionGameObject.GetComponent<Animator>();

        GetComponent<SpriteRenderer>().sprite = textures[Random.Range(0, textures.Count - 1)];

        StartCoroutine(TransitionFadeOut());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckIfNewMaxLevel();

            player = collision.GetComponent<Rigidbody2D>();
            StartCoroutine(TransitionFadeIn());
        }
    }

    private void LoadNextLevel()
    {
        if (!LevelManager.Instance.random)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            LevelManager.Instance.LoadRandomNextLevel();
    }

    private IEnumerator TransitionFadeIn()
    {
        player.drag = 10;
        transitionGameObject.SetActive(true);
        transition.SetTrigger("Fade In");
        yield return new WaitForSeconds(1);
        LoadNextLevel();
    }

    private IEnumerator TransitionFadeOut()
    {
        transition.SetTrigger("Fade Out");
        yield return new WaitForSeconds(1);
        transitionGameObject.SetActive(false);
    }

    private void CheckIfNewMaxLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex - 1 > PlayerPrefs.GetInt("LevelsCompleted"))
            PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted") + 1);
    }
}
