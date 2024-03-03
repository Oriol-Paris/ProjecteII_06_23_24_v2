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
    private bool ShootStarted = false;
    private bool inMenu = false;

    Vector2 originalPos;
    Vector2 mouseOriginalPos;


    [SerializeField]
    AudioSource hitSource;
    [SerializeField]
    AudioSource bounceSource;

    [SerializeField]
    private GameObject bg;

    void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        ShootDone = false;
    }

    private void Start()
    {
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
        originalPos = transform.position;
    }

    private void Update()
    {
        if(inMenu)
        {
            return;
        }
        if (!ShootStarted && Input.GetMouseButtonDown(0))
        {
            mouseOriginalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CalculateThrowVector();
            lineRenderer.enabled = true;
            ShootStarted = true;
        }
        else if (!ShootDone && Input.GetMouseButton(0))
        {
            CalculateThrowVector();
        }
        if (ShootStarted && Input.GetMouseButtonUp(0))
        {
            Throw();
            lineRenderer.enabled = false;
            ShootDone = true;
        }

        if (ShootDone && Input.GetMouseButtonDown(0))
        {
            ReturnOriginalPos();
        }
    }


    void CalculateThrowVector()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //doing vector2 math to ignore the z values in our distance.
        Vector2 distance = mousePos - mouseOriginalPos;
        //dont normalize the ditance if you want the throw strength to vary
        throwVector = -distance;
        DrawThrowPath();
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
        ShootStarted = false;
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

    public void ToggleInMenu()
    {
        inMenu = !inMenu;
    }
}
