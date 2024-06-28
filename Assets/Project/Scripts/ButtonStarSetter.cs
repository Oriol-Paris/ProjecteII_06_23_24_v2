using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStarSetter : MonoBehaviour
{
    [SerializeField] public Image one;
    [SerializeField] public Image two;
    [SerializeField] public Image three;
    private List<Image> stars;

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
            two.color = Color.black;
            break;

        case 3:
            three.color = Color.black;
            break;
        }
    }

    public void SetStarsActive()
    {
        foreach (Image star in stars)
        {
            star.gameObject.SetActive(true);
        }
    }

    public void SetStarsInactive()
    {
        foreach (Image star in stars)
        {
            star.gameObject.SetActive(false);
        }
    }
}
