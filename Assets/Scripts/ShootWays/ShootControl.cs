using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public int level;
    BulletType bulletType;
    TargetLayer targetLayer;
    public virtual List<GameObject> GetGameObjects() 
    {
        return gameObjects;
    }
    public virtual void InitShoot(BulletType type,TargetLayer layer)
    {
        bulletType = type;
        targetLayer = layer;
    }
    public void Shoot() 
    {
        List<GameObject> shoots = GetGameObjects();
        for (int i = 0; i < shoots.Count; i++)
        {
            Vector3 pos = shoots[i].transform.position;
            Vector3 rot = shoots[i].transform.eulerAngles;
            Bullet bullet = BulletPool.Instance.GetBulletObj(bulletType.ToString());
            if (bullet != null)
            {
                bullet.Init(pos, rot, targetLayer);
            }
        }
    }
}
