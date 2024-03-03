using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    public void Appear()
    {
        StartCoroutine(AppearCoroutine());
    }

    private IEnumerator AppearCoroutine()
    {
        anim.Play("MenuAppear");
        yield return new WaitForSeconds(1f);
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
