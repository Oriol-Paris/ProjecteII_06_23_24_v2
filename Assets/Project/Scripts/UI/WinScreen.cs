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
            trophy.texture = trophies[2];
        else if (playerBounces <= twoStarBounces)
            trophy.texture = trophies[1];
        else
            trophy.texture = trophies[0];

        levelText.SetText(SceneManager.GetActiveScene().name);
        bounces.SetText("You used " + playerBounces + " bounces");
    }
}
