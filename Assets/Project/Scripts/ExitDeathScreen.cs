using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDeathScreen : MonoBehaviour
{
    [SerializeField]
    public string SceneDestination;
    [SerializeField]
    public float timeForExit = 5f;

    public float time = 0f;

    [SerializeField]
    public AudioSource deathSource;

    private void Start()
    {
        deathSource.Play();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time > timeForExit )
        {
            SceneManager.LoadScene( SceneDestination );
        }
    }
}
