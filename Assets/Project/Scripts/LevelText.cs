using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = SceneManager.GetActiveScene().name;
    }
}
