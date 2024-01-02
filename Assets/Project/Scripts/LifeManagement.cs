using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeManagement : MonoBehaviour
{
    [SerializeField]
    private int lifes = 10; 

    private TextMeshProUGUI m_TextMeshPro;

    private void Awake()
    {
        m_TextMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        if (m_TextMeshPro != null )
        {
            Button button = GetComponent<Button>();

            if ( button != null )
            {
                m_TextMeshPro = button.GetComponentInChildren<TextMeshProUGUI>();
            }
        }
    }

    private void Start()
    {
        UpdateLifeText();
    }

    public void LifeLosed()
    {
        lifes--;

        if (lifes < 0)
            lifes = 0;

        UpdateLifeText(); 
    }

    private void UpdateLifeText()
    {
        if (m_TextMeshPro != null)
        {
            m_TextMeshPro.text = lifes.ToString();
        }
    }
}
