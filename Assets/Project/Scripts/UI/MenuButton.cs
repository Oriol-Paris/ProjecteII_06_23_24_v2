using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    Player player;

    [SerializeField]
    GameObject pauseMenu;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        pauseMenu.SetActive(false);
    }

    public void ToggleInMenu()
    {
        if(!player.GetInMenu())
            pauseMenu.SetActive(true);
        else 
            pauseMenu.SetActive(false);
        player.ToggleInMenu();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ToggleMute()
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.ToggleMute();
    }
}
