using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    public PauseMenu menu;

    [SerializeField]
    public MenuButton enterButton;
    [SerializeField]
    public MenuButton exitButton;
    [SerializeField]
    public GameObject pauseButtons;

    //[SerializeField]
    Throwable player;

    void Start()
    {
        player = FindAnyObjectByType<Throwable>();
        pauseButtons.SetActive(false);
    }

    public void EnterButtonPressed()
    {
        player.ToggleInMenu();
        enterButton.gameObject.SetActive(false);
        menu.Appear(pauseButtons);
        exitButton.gameObject.SetActive(true);
    }

    public void ExitButtonPressed()
    {
        player.ToggleInMenu();
        exitButton.gameObject.SetActive(false);
        menu.Dissappear();
        enterButton.gameObject.SetActive(true);
    }
}
