using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public enum ScreenSide { Left, Right, Top, Bottom, None }
public class SnapToScreen : MonoBehaviour
{
    public float offset;
    public ScreenSide side;
    // Start is called before the first frame update
    void Awake()
    {
        float yPos = Camera.main.orthographicSize;
        float xPos = yPos * ((float)Screen.width / (float)Screen.height);

        Vector2 center = Camera.main.transform.position;
        
        switch (side)
        {
            case ScreenSide.Left:
                transform.position = new Vector2 (center.x - xPos, transform.position.y);
                transform.position += offset * Vector3.right;
                break;
            case ScreenSide.Right:
                transform.position = new Vector2(center.x + xPos, transform.position.y);
                transform.position += offset * Vector3.left;
                break;
            case ScreenSide.Top:
                transform.position = new Vector2(transform.position.x, center.y + yPos);
                transform.position += offset * Vector3.down;
                break;
            case ScreenSide.Bottom:
                transform.position = new Vector2(transform.position.x, center.y - yPos);
                transform.position += offset * Vector3.up;
                break;
        }

    }

}
