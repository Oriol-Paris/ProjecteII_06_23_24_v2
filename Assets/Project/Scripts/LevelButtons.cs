using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class LevelButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public int firstLevel = 1;
    public int lastLevel;
    public Transform content;
    public TMP_FontAsset font;
    public float fontSize;

    public TrophyList trophies;


    private void Awake()
    {
        lastLevel = SceneManager.sceneCountInBuildSettings - 3;

        FindAnyObjectByType<DataSaver>().FirstLoad();
        trophies = FindAnyObjectByType<DataSaver>().GetTrophies();

        GenerateButtons();
    }

    private void GenerateButtons()
    {
        GridLayoutGroup gridLayout = content.GetComponent<GridLayoutGroup>();
        
        for(int i = 1; i < trophies.list.Count + 1; i++)
        {
            GameObject buttonGo = Instantiate(buttonPrefab, content);
            Button button = buttonGo.GetComponent<Button>();
            button.image.color = new Color(1, 1, 1, 1f);

            if (button != null)
            {
                TextMeshProUGUI buttonText = buttonGo.GetComponentInChildren<TextMeshProUGUI>();

                button.interactable = true;
                buttonText.color = Color.black;

                buttonText.font = font;
                buttonText.fontSize = fontSize;

                if (buttonText != null)
                    buttonText.text = i.ToString();

                button.onClick.AddListener(() => FindObjectOfType<LevelManager>().LoadLevel());

                buttonGo.name = "ButtonLevel" + i;
            }

            button.GetComponent<ButtonStarSetter>().SetStars(trophies.list[i - 1]);
        }
        if(trophies.list.Count < lastLevel)
        {
            for(int i = trophies.list.Count + 1; i < lastLevel; i++)
            {
                GameObject buttonGo = Instantiate(buttonPrefab, content);
                Button button = buttonGo.GetComponent<Button>();
                button.image.color = new Color(1, 1, 1, 1f);

                if (button != null)
                {
                    TextMeshProUGUI buttonText = buttonGo.GetComponentInChildren<TextMeshProUGUI>();

                    button.interactable = false;
                    buttonText.color = Color.white;

                    if (i == trophies.list.Count + 1 && trophies.list[0] != 0)
                    {
                        button.interactable = true;
                        buttonText.color = Color.black;
                        button.GetComponent<ButtonStarSetter>().SetStars(0);
                    }

                    buttonText.font = font;
                    buttonText.fontSize = fontSize;

                    if (buttonText != null)
                        buttonText.text = i.ToString();

                    button.onClick.AddListener(() => FindObjectOfType<LevelManager>().LoadLevel());

                    buttonGo.name = "ButtonLevel" + i;
                }
            }
        }

        //recargar la grid
        gridLayout.enabled = false;
        gridLayout.enabled = true;
    }
}
