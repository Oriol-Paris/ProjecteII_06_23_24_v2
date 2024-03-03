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

    // Start is called before the first frame update
    void Start()
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
        else if (sceneIndex <= 7 + indexDiff)
        {
            bg.texture = backgrounds[1];
        }
        else if (sceneIndex <= 12 + indexDiff)
        {
            bg.texture = backgrounds[2];
        }
        else if (sceneIndex <= 20 + indexDiff)
        {
            bg.texture = backgrounds[3];
        }
        else if (sceneIndex <= 27 + indexDiff)
        {
            bg.texture = backgrounds[4];
        }
    }
}
