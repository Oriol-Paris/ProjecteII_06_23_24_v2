using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    Vector3 throwVector;
    Rigidbody2D _rb;

    [SerializeField]
    float multiplyer = 3.0f;


    [SerializeField]
    Material lineMaterial;
    private LineRenderer lineRenderer;

    void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    private void Start()
    {
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    //onmouse events possible thanks to monobehaviour + collider2d
    void OnMouseDown()
    {
        CalculateThrowVector();
        lineRenderer.enabled = true;
    }
    void OnMouseDrag()
    {
        CalculateThrowVector();
    }
    void CalculateThrowVector()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //doing vector2 math to ignore the z values in our distance.
        Vector2 distance = mousePos - this.transform.position;
        //dont normalize the ditance if you want the throw strength to vary
        throwVector = -distance ;
        DrawThrowPath();
    }
    void OnMouseUp()
    {
        Throw();
        lineRenderer.enabled=false;
    }
    public void Throw()
    {
        _rb.AddForce(throwVector * multiplyer);
    }

    void DrawThrowPath()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + throwVector;
        lineRenderer.SetPosition(0, startPos); 
        lineRenderer.SetPosition(1, endPos);
    }
}
