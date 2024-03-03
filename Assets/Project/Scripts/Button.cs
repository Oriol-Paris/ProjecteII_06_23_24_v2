using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    [SerializeField]
    public bool sticky = false;
    private bool hit = false;
    [SerializeField]
    public GameObject unlockable;

    private GameObject player;
    private Rigidbody2D playerRb;
    private Throwable playerScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        playerScript = player.GetComponent<Throwable>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(sticky)
            {
                playerRb.velocity = Vector3.zero;
                playerRb.freezeRotation = true;
                playerRb.freezeRotation = false;
                unlockable.SetActive(false);
                playerScript.ToggleShoot();
            }

            if(!hit)
            {
                unlockable.SetActive(false);

                hit = true;
            }
        }
    }

    public void ToggleHit()
    {
        hit = !hit;
    }

}
