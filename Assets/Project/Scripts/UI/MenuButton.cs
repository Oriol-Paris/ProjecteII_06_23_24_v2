using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    Player player;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject winScreen;

    [SerializeField]
    GameObject levelText;

    [SerializeField]
    GameObject pauseButton;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        pauseMenu.SetActive(false);
    }

    public void EnterWinScreen()
    {
        int bounces = FindAnyObjectByType<Player>().GetBounces();

        GameObject.FindGameObjectWithTag("GameObjects").SetActive(false);

        GameObject.Find("LevelNumText").SetActive(false);
        GameObject.Find("EnterButton").SetActive(false);

        winScreen.SetActive(true);

        winScreen.GetComponent<WinScreen>().playerBounces = bounces;
        winScreen.GetComponent<WinScreen>().SetUpWinScreen();

        StartCoroutine(FindAnyObjectByType<Fade>().TransitionFadeOut());
    }

    public void ToggleInMenu()
    {
        if(!player.GetInMenu())
        {
            pauseMenu.SetActive(true);
            levelText.SetActive(false);
            pauseButton.SetActive(false);
        }
            
        else
        {
            pauseMenu.SetActive(false);
            levelText.SetActive(true);
            pauseButton.SetActive(true);
        }
            
        player.ToggleInMenu();
    }

    public void ToMainMenu()
    {
        FindAnyObjectByType<DataSaver>().Save();
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 35)
            SceneManager.LoadScene("Level Selector");
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToggleSFXMute()
    {
        player.ToggleMute();
    }

    public void ToggleMusicMute()
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.ToggleMute();
    }
}
