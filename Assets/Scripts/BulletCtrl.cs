using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl
{
    private static BulletCtrl ins;
    public static BulletCtrl Instance
    {
        get
        {
            if (ins == null)
            {
                ins = new BulletCtrl();
            }
            return ins;
        } 
    }
    public List<GameObject> bullets = new List<GameObject>();
}
