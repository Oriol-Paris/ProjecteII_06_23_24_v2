using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public int firstLevel = 1;
    public int lastLevel = 20;
    public Transform content;
    public TMP_FontAsset font;
    public float fontSize;


    private void Start()
    {
        if (PlayerPrefs.GetInt("LevelsCompleted") == 0)
        {
            PlayerPrefs.SetInt("LevelsCompleted", 1);
        }
        else if (PlayerPrefs.GetInt("LevelsCompleted") > lastLevel)
        {
            PlayerPrefs.SetInt("LevelsCompleted", lastLevel);
        }
        GenerateButtons();
    }

    private void GenerateButtons()
    {
        GridLayoutGroup gridLayout = content.GetComponent<GridLayoutGroup>();
        int maxUnlockedLevel = PlayerPrefs.GetInt("LevelsCompleted");

        for(int i = firstLevel; i <= lastLevel; i++)
        {
            GameObject buttonGo = Instantiate(buttonPrefab, content);
            Button button = buttonGo.GetComponent<Button>();
            button.image.color = new Color(0, 0, 0, 0.45f);

            if (button != null)
            {
                if(i > maxUnlockedLevel)
                {
                    button.interactable = false;
                }

                TextMeshProUGUI buttonText = buttonGo.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.color = Color.white;
                buttonText.font = font;
                buttonText.fontSize = fontSize;

                if(buttonText != null)
                    buttonText.text = i.ToString();

                button.onClick.AddListener(() => FindObjectOfType<LevelManager>().LoadLevel());

                buttonGo.name = "ButtonLevel" + i;
            }
        }
        //recargar la grid
        gridLayout.enabled = false;
        gridLayout.enabled = true;
    }
}
