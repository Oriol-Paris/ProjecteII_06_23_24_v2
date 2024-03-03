using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallColor : MonoBehaviour
{
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = this.gameObject.GetComponent<Renderer>().material;
        material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
