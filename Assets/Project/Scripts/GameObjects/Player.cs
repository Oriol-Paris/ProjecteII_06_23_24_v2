using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 throwVector;
    Rigidbody2D _rb;

    [SerializeField]
    float multiplyer = 3.0f;

    [SerializeField]
    Material lineMaterial;
    private LineRenderer lineRenderer;
    private TrailRenderer trailRenderer;

    private bool ShootDone = false;
    private bool ShootStarted = false;
    private bool inMenu = false;

    Vector2 originalPos;
    Vector2 mouseOriginalPos;

    GameButton button;

    int bounces;
    [SerializeField]
    AudioSource hitSource;
    [SerializeField]
    AudioSource bounceSource;

    //para plataforma movil y sticky button (user case)
    public bool inMobilePlatform = false;
    public PlatformMovement platform;
    //esto

    //Particle system
    [SerializeField] private GameObject bounceParticles;

    [SerializeField] private GameObject deathEffectPrefab;

    void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        trailRenderer = gameObject.GetComponent <TrailRenderer>();
        ShootDone = false;
        button = FindAnyObjectByType<GameButton>();
        bounces = 0;
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
        if (inMenu)
        {
            return;
        }
        if (inMobilePlatform && platform != null)
        {
            this.transform.position += new Vector3(platform.transform.position.x - this.transform.position.x, 0,0);
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
        inMobilePlatform = false;
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
        GameButton gameButton = GameObject.FindObjectOfType<GameButton>();
        if (gameButton != null)
        {
            gameButton.unlockable.SetActive(true);
        }
        ShootDone = false;
        ShootStarted = false;
        this.transform.position = originalPos;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = 0;
        this.transform.rotation = Quaternion.identity;
        bounces = 0;
        _rb.Sleep();

        trailRenderer.Clear();

        if(button != null)
        {
            button.ToggleHit();
        }
        inMobilePlatform = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounces++;

        if(collision.gameObject.CompareTag("wall"))
        {
            bounceSource.Play();

            GameObject bounceEffect = Instantiate(bounceParticles, collision.contacts[0].point, Quaternion.identity, null);
            bounceEffect.transform.right = collision.contacts[0].normal;
            Destroy(bounceEffect, 1.5f);
        }
        else if(collision.gameObject.CompareTag("spike"))
        {
            StartCoroutine(SpikeHit());
        }
        else if(collision.gameObject.CompareTag("Teleport"))
        {
            Teleport(collision.gameObject.GetComponent<Teleporter>());
        }
    }

    private IEnumerator SpikeHit()
    {
        hitSource.Play();
        Vector3 deathPosition = transform.position;

        GameObject deathEffect = Instantiate(deathEffectPrefab, deathPosition, Quaternion.identity);

        ParticleSystem particleSystem = deathEffect.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
        Destroy(deathEffect, 1.5f);

        yield return new WaitForSeconds(0.1f);

        ReturnOriginalPos();
    }

    public void Teleport(Teleporter tp)
    {
        hitSource.Play();
        Vector3 tpPosition = transform.position;

        GameObject deathEffect = Instantiate(deathEffectPrefab, tpPosition, Quaternion.identity);

        ParticleSystem particleSystem = deathEffect.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
        Destroy(deathEffect, 1.5f);

        this.transform.position = tp.GetDestination().position;
        _rb.velocity = _rb.velocity.magnitude * tp.GetDestination().up;
    }

    public void ToggleShoot()
    {
        ShootStarted = !ShootStarted;
        ShootDone = !ShootDone;
        inMobilePlatform = false;
    }

    public void ToggleInMenu()
    {
        inMenu = !inMenu;
    }

    public void ToggleMute()
    {
        hitSource.mute = !hitSource.mute;
        bounceSource.mute = !bounceSource.mute;
    }

    public bool GetInMenu()
    {
        return inMenu;
    }

    public int GetBounces()
    {
        return bounces;
    }

}
