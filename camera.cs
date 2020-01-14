using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [Header ("追隨物件")]
    public Transform target;
    [Header ("攝影機移動緩衝時間")]
    public float f_SmoothTime = 0.3f;
    [Header ("攝影機固定高度")]
    public float f_PosY;
    [Header ("攝影機左邊界")]
    public float f_MinX;
    [Header ("攝影機右邊界")]
    public float f_MaxX = 162;
    [Header ("攝影機下邊界")]
    public float f_MinY;
    [Header ("攝影機上邊界")]
    public float f_MaxY;

    Vector3 velocity = Vector3.zero;//velocity（相對緩衝減速，一個乘載變量，只要默認其值為0即可。）

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, f_PosY, -10));
        Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, f_SmoothTime);
        transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, f_MinX, f_MaxX), Mathf.Clamp(desiredPosition.y, f_MinY, f_MaxY), -10);//因不明原因使用desiredPosition.z會有錯誤，故改成-10
    }
}
