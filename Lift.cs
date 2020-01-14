using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var target = collision.gameObject.transform;
            target.SetParent(this.transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var target = collision.gameObject.transform;
            var original = target.GetComponent<TransformState>().OriginalParent;
            target.SetParent(original);
        }
    }
}
