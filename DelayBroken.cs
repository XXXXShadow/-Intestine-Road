using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayBroken : MonoBehaviour
{

    public GameObject delaybrokenobj;
    public PolygonCollider2D broken;
    public Rigidbody2D brokenrig;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("fall", 2f);
        }
    }
    void fall()
    {
        broken.isTrigger = true;
        brokenrig.bodyType = RigidbodyType2D.Dynamic;
        delaybrokenobj.layer = 0;
    }
}
