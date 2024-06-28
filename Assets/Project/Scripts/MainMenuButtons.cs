using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject settingsMenu;

    private bool inSettings;

    private void Awake()
    {
        PlayerPrefs.SetInt("MutedSFX", 1);
        PlayerPrefs.SetInt("MutedMusic", 1);
    }

    public void ToggleInSettings()
    {
        inSettings = !inSettings;

        if(inSettings)
        {
            menu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        else
        {
            menu.SetActive(true);
            settingsMenu.SetActive(false);
        }
    }

    public void ToggleMuteSFX()
    {
        if (PlayerPrefs.GetInt("MutedSFX") == 0)
            PlayerPrefs.SetInt("MutedSFX", 1);
        else
            PlayerPrefs.SetInt("MutedSFX", 0);
    }

    public void ToggleMuteMusic()
    {
        FindAnyObjectByType<AudioManager>().ToggleMute();

        if (PlayerPrefs.GetInt("MutedMusic") == 0)
            PlayerPrefs.SetInt("MutedMusic", 1);
        else
            PlayerPrefs.SetInt("MutedMusic", 0);
    }
}
