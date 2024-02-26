using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    public string NextLevelName;

    private Animator transition;
    GameObject transitionGameObject;
    private Rigidbody2D player;

    void Start()
    {
        transitionGameObject = GameObject.FindGameObjectWithTag("Transition");
        transition = transitionGameObject.GetComponent<Animator>();

        StartCoroutine(TransitionFadeOut());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Rigidbody2D>();
            StartCoroutine(TransitionFadeIn());
        }
    }

    private void LoadNextLevel()
    {
        if (!LevelManager.Instance.random)
            SceneManager.LoadScene(NextLevelName);
        else
            LevelManager.Instance.LoadRandomNextLevel();
    }

    private IEnumerator TransitionFadeIn()
    {
        Debug.Log("Fade In");
        player.velocity = Vector3.zero;
        transitionGameObject.SetActive(true);
        transition.SetTrigger("Fade In");
        yield return new WaitForSeconds(1);
        LoadNextLevel();
    }

    private IEnumerator TransitionFadeOut()
    {
        Debug.Log("Fade Out");
        transition.SetTrigger("Fade Out");
        yield return new WaitForSeconds(1);
        transitionGameObject.SetActive(false);
    }
}
