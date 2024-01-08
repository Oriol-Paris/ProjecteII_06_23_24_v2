using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObject : MonoBehaviour
{
    [field: SerializeField]
    public Throwable m_throwable { get; set; }

    [field: SerializeField]
    public LifeManagement m_lifeManagement { get; set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        { 
            if(m_lifeManagement != null)
                m_lifeManagement.LifeLost();
            if (m_throwable != null)
                m_throwable.ReturnOriginalPos();
        }
    }


}
