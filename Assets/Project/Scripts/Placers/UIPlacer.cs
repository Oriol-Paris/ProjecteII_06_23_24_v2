using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlacer : MonoBehaviour
{
    void Start()
    {
        Button button = this.GetComponent<Button>();
        Image image = this.GetComponent<Image>();

        button.transform.position = new Vector3(175, 395, 124);
        image.transform.position = new Vector3(-170, 390, -34);
    }

}
