using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateplat2 : MonoBehaviour
{
    public GameObject plattemplate_2;
    GameObject plat2;
    public void Spawn()
    {
        plat2 = Instantiate(plattemplate_2);
    }
    public void Insplat()
    {
        Destroy(plat2);
        plat2 = Instantiate(plattemplate_2);
    }
}
