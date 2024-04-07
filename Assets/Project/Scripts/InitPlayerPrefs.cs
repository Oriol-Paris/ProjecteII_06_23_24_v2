using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("LevelsCompleted") == 50)
            PlayerPrefs.SetInt("LevelsCompleted", 1);
    }
}
