using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_bullet : MonoBehaviour
{
    public GameObject spit_particlex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Destroy(gameObject);

            GameObject spit_particle = Instantiate(spit_particlex);
            spit_particle.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0,0,0));//粒子效果位置和旋轉方向
            Destroy(spit_particle,0.5f);
        }
    }
}