using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundSelector : MonoBehaviour
{
    [SerializeField]
    private List<Texture> backgrounds;

    private Canvas canvas;
    private RawImage bg;
    private int indexDiff = 3;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;

        bg = GetComponentInChildren<RawImage>();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(sceneIndex <= 7 + indexDiff)
        {
            bg.texture = backgrounds[0];
        }
        else if (sceneIndex <= 12 + indexDiff)
        {
            bg.texture = backgrounds[1];
        }
        else if (sceneIndex <= 20 + indexDiff)
        {
            bg.texture = backgrounds[2];
        }
    }
}
