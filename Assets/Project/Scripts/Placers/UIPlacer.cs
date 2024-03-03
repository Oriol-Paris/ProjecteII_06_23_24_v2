using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlacer : MonoBehaviour
{
    [SerializeField]
    RectTransform buttonTransform;
    [SerializeField]
    RectTransform imageTransform;

    void Awake()
    {
        buttonTransform.localPosition = new Vector3(175, 395, 100);
        imageTransform.localPosition = new Vector3(-170, 390, 100);
    }

}
