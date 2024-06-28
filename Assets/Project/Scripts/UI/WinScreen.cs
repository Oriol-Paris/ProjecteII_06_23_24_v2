using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    int twoStarBounces;
    [SerializeField]
    int threeStarBounces;

    public int stars;

    [SerializeField]
    TextMeshProUGUI levelText;
    [SerializeField]
    TextMeshProUGUI bounces;
    [SerializeField]
    RawImage trophy;
    

    [SerializeField]
    Texture2D[] trophies;

    [NonSerialized]
    public int playerBounces;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetUpWinScreen()
    {
        if (playerBounces <= threeStarBounces)
        {
            trophy.texture = trophies[2];
            stars = 3;
        }
            
        else if (playerBounces <= twoStarBounces)
        {
            trophy.texture = trophies[1];
            stars = 2;
        }
        else
        {
            trophy.texture = trophies[0];
            stars = 1;
        }

        levelText.SetText(SceneManager.GetActiveScene().name);
        bounces.SetText("You used " + playerBounces + " bounces");

        FindAnyObjectByType<DataSaver>().SaveLevel(stars);
    }


}
