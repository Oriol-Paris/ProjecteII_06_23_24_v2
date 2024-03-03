using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObject : MonoBehaviour
{
    [field: SerializeField]
    public Throwable m_throwable { get; set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        { 
            if (m_throwable != null)
                m_throwable.ReturnOriginalPos();
        }
    }


}
