using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCtrl : MonoBehaviour
{
    [SerializeField]
    Transform bg1;
    [SerializeField]
    Transform bg2;
    [SerializeField]
    float speed;
    void Update()
    {
        if (bg1.transform.position.z <= -150)
        {
            float z = bg1.transform.position.z + 150;
            Vector3 pos = Vector3.zero;
            pos.y = bg1.transform.position.y;
            pos.z = 150+ z;
            bg1.transform.position = pos;
        }
        if (bg2.transform.position.z <= -150)
        {
            float z = bg2.transform.position.z + 150;
            Vector3 pos = Vector3.zero;
            pos.y = bg2.transform.position.y;
            pos.z = 150+ z;
            bg2.transform.position = pos;
        }
        bg1.transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        bg2.transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
    }
}
