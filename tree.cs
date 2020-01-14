using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    Animator MainAnimator;

    public AudioSource Tree;
    void Start()
    {
        MainAnimator = this.GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MainAnimator.SetTrigger("ParaTreeUp");
            Tree.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MainAnimator.SetTrigger("ParaTreeDown");
        }
    }
}
