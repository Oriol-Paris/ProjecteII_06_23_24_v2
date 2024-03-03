using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderPlacer : MonoBehaviour
{
    [field: SerializeField]
    public bool upBorder;
    [field: SerializeField]
    public bool downBorder;
    [field: SerializeField]
    public bool leftBorder;
    [field: SerializeField]
    public bool rightBorder;

    void Start()
    {

        float yPos = Camera.main.orthographicSize;
        float xPos = yPos * ((float)Screen.width / (float)Screen.height);

        Transform cam = Camera.main.transform;

        if (upBorder)
            this.transform.position = new Vector2(cam.position.x, cam.position.y + yPos);
        else if (downBorder)
            this.transform.position = new Vector2(cam.position.x, cam.position.y - yPos);
        else if(leftBorder)
            this.transform.position = new Vector2(cam.position.x - xPos, cam.position.y);
        else if(rightBorder)
            this.transform.position = new Vector2(cam.position.x + xPos, cam.position.y);
    }
}
