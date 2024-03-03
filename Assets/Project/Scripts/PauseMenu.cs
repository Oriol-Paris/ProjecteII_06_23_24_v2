using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    public void Appear(GameObject buttonsToSpawn)
    {
        StartCoroutine(AppearCoroutine(buttonsToSpawn));
    }

    private IEnumerator AppearCoroutine(GameObject buttonsToSpawn)
    {
        anim.Play("MenuAppear");
        yield return new WaitForSeconds(1f);
        buttonsToSpawn.SetActive(true);
    }

    public void Dissappear()
    {
        StartCoroutine(DissappearCoroutine());
    }

    private IEnumerator DissappearCoroutine()
    {
        anim.Play("MenuDissappear");
        yield return new WaitForSeconds(1f);
    }
}
