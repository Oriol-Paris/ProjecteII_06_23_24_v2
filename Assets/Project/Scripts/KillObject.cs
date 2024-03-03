using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObject : MonoBehaviour
{

    Throwable player;

    private void Start()
    {
        player = FindAnyObjectByType<Throwable>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        { 
            if (player != null)
                player.ReturnOriginalPos();
        }
    }


}
