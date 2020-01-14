using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public BoxCollider2D fall;
    public Rigidbody2D fallrig;
    public AudioSource buttonsound;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            fall.isTrigger = true;
            fallrig.bodyType = RigidbodyType2D.Dynamic;
            buttonsound.Play();
        }
    }
}
