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

    //[SerializeField]
    Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void EnterButtonPressed()
    {
        player.ToggleInMenu();
        enterButton.gameObject.SetActive(false);
        menu.Appear();
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
