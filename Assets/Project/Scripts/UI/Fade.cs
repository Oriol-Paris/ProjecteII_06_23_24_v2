using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Animator transition;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
        player = FindAnyObjectByType<Player>();
    }

    public IEnumerator TransitionFadeIn()
    {
        transition.SetTrigger("Fade In");
        yield return new WaitForSeconds(1);
    }

    public IEnumerator TransitionFadeOut()
    {
        transition.SetTrigger("Fade Out");
        yield return new WaitForSeconds(1);
    }
}
