using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    public GameObject brokenobj;
    public BoxCollider2D broken;
    public Rigidbody2D brokenrig;
    public Rigidbody2D brokenjoint;
    public AudioSource brokensound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("brokenact",0.1f);
            Invoke("fall",1f);
        }
    }
    void brokenact()
    {
        broken.isTrigger = true;
        brokenrig.bodyType = RigidbodyType2D.Dynamic;
        brokenobj.layer = 0;
        brokensound.Play();
    }
    void fall()
    {
        brokenjoint.bodyType = RigidbodyType2D.Dynamic;
    }
}
