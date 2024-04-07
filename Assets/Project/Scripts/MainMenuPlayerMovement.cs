using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
    }

    private void FixedUpdate()
    {
        if(rb.velocity.x < 4f && rb.velocity.x > -4f && rb.velocity.y < 4f && rb.velocity.y > -4f)
            rb.velocity += new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        else
            rb.velocity = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
    }
}
