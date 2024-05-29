using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField]
    public ParticleSystem bounceParticles;
    [SerializeField]
    public ParticleSystem hitParticles;
    [SerializeField]
    public ParticleSystem moveParticles;

    private void Update()
    {
        if(this.GetComponent<Rigidbody2D>().velocity.magnitude > 0.0f)
        {
            moveParticles.Play();
        }
        else
            moveParticles.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("wall"))
        {
            bounceParticles.Play();
        }
        else if(collision.gameObject.CompareTag("spike"))
        {
            hitParticles.Play();
        }
    }
}
