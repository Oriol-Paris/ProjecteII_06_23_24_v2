using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    void Awake()
    {
        text.SetText(SceneManager.GetActiveScene().name);
    }
}
