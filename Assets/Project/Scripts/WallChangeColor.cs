using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        BackgroundSelector backgroundSelector = FindAnyObjectByType<BackgroundSelector>();

        renderer.material.color = backgroundSelector.GetWallColor();
    }
}
