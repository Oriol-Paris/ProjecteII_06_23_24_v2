using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private void Awake()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            this.gameObject.SetActive(false);
        }
    }
}
