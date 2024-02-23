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

    private bool ShootDone;

    Transform playerTransform;
    Vector2 originalPos;


    [SerializeField]
    AudioSource hitSource;
    [SerializeField]
    AudioSource bounceSource;

    Camera cam;
    Vector3 startPoint;
    Vector3 endPoint;



    void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        ShootDone = false;
        playerTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        cam = Camera.main; 
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
        originalPos = transform.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 0;
            Debug.Log(startPoint);
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 0;
        }
    }

    //onmouse events possible thanks to monobehaviour + collider2d
    void OnMouseDown()
    {
        if(!ShootDone)
        {
            CalculateThrowVector();
            lineRenderer.enabled = true;
        }
       
    }
    void OnMouseDrag()
    {
        if(!ShootDone)
        CalculateThrowVector();
    }
    void CalculateThrowVector()
    {
        Vector2 distance = startPoint - endPoint;
        //dont normalize the ditance if you want the throw strength to vary
        throwVector = -distance ;
        DrawThrowPath();
    }
    void OnMouseUp()
    {
        Throw();
        lineRenderer.enabled=false;
        ShootDone=true;
    }
    public void Throw()
    {
        if(!ShootDone)
        _rb.AddForce(throwVector * multiplyer);
    }

    void DrawThrowPath()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + throwVector;
        lineRenderer.SetPosition(0, startPos); 
        lineRenderer.SetPosition(1, endPos);
    }


    public void ReturnOriginalPos()
    {
        ShootDone = false;
        this.transform.position = originalPos;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = 0;
        _rb.Sleep();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("wall"))
        {
            bounceSource.Play();
        }
        else if(collision.gameObject.CompareTag("spike"))
        {
            hitSource.Play();
        }

    }

    public void ToggleShoot()
    {
        ShootDone = !ShootDone;
    }
}
