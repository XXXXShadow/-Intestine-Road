using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateplat3 : MonoBehaviour
{
    public GameObject plattemplate_3;
    GameObject plat3;
    public void Spawn()
    {
        plat3 = Instantiate(plattemplate_3);
    }
    public void Insplat()
    {
        Destroy(plat3);
        plat3 = Instantiate(plattemplate_3);
    }
}
