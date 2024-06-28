using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ButtonStarSetter : MonoBehaviour
{
    [SerializeField] public Image one;
    [SerializeField] public Image two;
    [SerializeField] public Image three;

    private List<Image> stars = new List<Image>();

    public void Awake()
    {
        stars.Add(one);
        stars.Add(two);
        stars.Add(three);
    }

    public void SetStars(int value)
    {
        foreach (Image star in stars)
        {
            star.color = Color.white;
        }

        switch (value)
        {
        case 0:
            break;

        case 1:
            one.color = Color.black;
            break;

        case 2:
            one.color = Color.black;
            two.color = Color.black;
            break;

        case 3:
            one.color = Color.black;
            two.color = Color.black;
            three.color = Color.black;
            break;
        }
    }
}
