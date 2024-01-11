using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeManagement : MonoBehaviour
{
    [SerializeField]
    private int startingLives = 10;


    private int lives = 10; 

    private TextMeshProUGUI m_TextMeshPro;

    private void Awake()
    {
        m_TextMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        if (m_TextMeshPro != null )
        {
            Button button = GetComponent<Button>();

            if ( button != null )
            {
                m_TextMeshPro = button.GetComponentInChildren<TextMeshProUGUI>();
            }
        }

        lives = PlayerPrefs.GetInt("PlayerLives", startingLives);
    }

    private void Start()
    {
        UpdateLifeText();
    }

    public void LifeLost()
    {
        lives--;

        if (lives < 0)
            lives = 0;

        UpdateLifeText(); 
        SavePlayersLives();
    }

    private void UpdateLifeText()
    {
        if (m_TextMeshPro != null)
        {
            m_TextMeshPro.text = lives.ToString();
        }
    }

    private void SavePlayersLives()
    {
        PlayerPrefs.SetInt("PlayerLives", lives);
        PlayerPrefs.Save();
    }

    public void InitializePlayerLives()
    {
        PlayerPrefs.SetInt("PlayerLives", startingLives);
    }

    private void Update()
    {
        if(lives <= 0 && SceneManager.GetActiveScene().name != "Main Menu")
        {
            SceneManager.LoadScene("Death Screen");
        }
    }
}
