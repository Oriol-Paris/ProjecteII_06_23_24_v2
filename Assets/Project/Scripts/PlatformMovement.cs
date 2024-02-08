using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] 
    private bool firstLeft; // Dirección inicial hacia la izquierda
    [SerializeField] 
    private bool firstUp; //Direccionj inicial hacia arriba
    [SerializeField] 
    private bool centered; 
    [SerializeField] 
    private bool bounce; // Rebotar con ciertos elementos
    [SerializeField] 
    private bool allBounce; // Rebotar con todo
    [SerializeField] 
    private bool upDown; 

    [SerializeField] 
    private float range; 
    [SerializeField] 
    private float velocity;

    private Vector2 initialPosition;
    private Vector2 targetPosition;

    void Start()
    {
        if (bounce || allBounce)
            return;
        initialPosition = transform.position;
        CalculateTargetPosition();
    }

    
    void Update()
    {
        if (bounce || allBounce)
        {
            BounceMovement();
            return;
        }
        float t = Mathf.PingPong(Time.time * velocity, 1.0f);
        transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
    }

    private void BounceMovement()
    {
        switch(bounce)
        {
            case true:
                break;
            case false:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(allBounce)
        {
            case true:
                //loogic
                return;
                break;
            case false:
                switch(bounce)
                { 
                    case true:
                        //if (collision.gameObject.CompareTag("")
                        //    return;
                        return;
                        break;
                    case false:
                        return;
                        break;
                }
                break;
        }
    }

    private void CalculateTargetPosition()
    {
        float halfRange = centered ? range / 2.0f : 0.0f;
        float directionX = firstLeft ? -1.0f : 1.0f;
        float directionY = firstUp ? 1.0f : -1.0f;

        if (upDown)
        {
            initialPosition = new Vector2(initialPosition.x, initialPosition.y - halfRange);
            targetPosition = new Vector2(initialPosition.x, initialPosition.y + range * directionY);
        }
        else
        {
            initialPosition = new Vector2(initialPosition.x - halfRange * directionX, initialPosition.y);
            targetPosition = new Vector2(initialPosition.x + range * directionX, initialPosition.y);
        }
    }
}
