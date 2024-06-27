using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    [SerializeField]
    public bool sticky = false;
    private bool hit = false;

    [SerializeField]
    public GameObject door;
    private Player player;

    //para botones mobiles
    public bool mobile;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        GetComponent<SpriteRenderer>().material.color = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(sticky)
            {
                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                player.GetComponent<Rigidbody2D>().freezeRotation = true;
                player.ToggleShoot();

                if(mobile)
                {
                    player.inMobilePlatform = true;
                    player.platform = this.GetComponentInParent<PlatformMovement>();
                }
                
            }

            if (!hit)
            {
                door.SetActive(false);
                GetComponent<SpriteRenderer>().material.color = Color.green;
                hit = true;
            }

        }
    }

    public void ResetHit()
    {
        hit = false;
        GetComponent<SpriteRenderer>().material.color = Color.red;
        door.SetActive(true);
    }
}
