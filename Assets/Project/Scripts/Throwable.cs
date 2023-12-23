using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    Vector3 throwVector;
    Rigidbody2D _rb;

    [SerializeField]
    float multiplyer = 3.0f;

    void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }
    //onmouse events possible thanks to monobehaviour + collider2d
    void OnMouseDown()
    {
        CalculateThrowVector();
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
        throwVector = -distance.normalized * 100;
    }
    void OnMouseUp()
    {
        Throw();
    }
    public void Throw()
    {
        _rb.AddForce(throwVector * multiplyer);
    }
}
