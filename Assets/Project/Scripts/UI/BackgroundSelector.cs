using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundSelector : MonoBehaviour
{
    [SerializeField]
    private List<Texture> backgrounds;

    private Canvas canvas;
    private RawImage bg;
    private int indexDiff = 1;
    private Volume postProcess;
    private Color wallColor;

    // Start is called before the first frame update
    void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;

        bg = GetComponentInChildren<RawImage>();
        
        if(bg.color.a == 0 )
            bg.color = Color.white;

        SelectBackground();
    }

    private void SelectBackground()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex <= indexDiff)
        {
            bg.texture = backgrounds[0];
        }
        else if (sceneIndex <= 9 + indexDiff)
        {
            bg.texture = backgrounds[1];
            wallColor = new Color(255, 44, 0, 0);
        }
        else if (sceneIndex <= 18 + indexDiff)
        {
            bg.texture = backgrounds[2];
            wallColor = new Color(0, 144, 191);
        }
        else if (sceneIndex <= 30 + indexDiff)
        {
            bg.texture = backgrounds[3];
            wallColor = new Color(40, 191, 0);
        }
        else if (sceneIndex <= 37 + indexDiff)
        {
            bg.texture = backgrounds[4];
            wallColor = new Color(0, 62, 191);
        }
    }

    public Color GetWallColor()
    {
        return wallColor;
    }
}
