using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spit : MonoBehaviour
{
    public GameObject bullettemplate;
    public float force = 3000;

    //float lastSpawn;
    //public float timeInterval = 1;
    // Start is called before the first frame update
    void Start()
    {
        force = 1000;
        //timeInterval = 1;
        //lastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Time.time - lastSpawn >= timeInterval)
        {
            GameObject bullet = Instantiate(bullettemplate);

            bullet.SetActive(true);
            bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);//子彈位置和旋轉方向
            Vector3 v = new Vector3(-45,-90,0);//施力方向
            bullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * force);
            lastSpawn = Time.time;
        }
        */
    }
    void BulletSpawn()
    {
        GameObject bullet = Instantiate(bullettemplate);
        bullet.SetActive(true);
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);//子彈位置和旋轉方向
        Vector3 v = new Vector3(-45, -90, 0);//施力方向
        bullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * force);
    }
}
