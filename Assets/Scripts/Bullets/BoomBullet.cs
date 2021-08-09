using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BoomBullet : Bullet
{
    bool hasMove = false;
    Vector3 startPosition;
    [SerializeField]
    float moveLength;
    [SerializeField]
    int SpawnCount;
    public override void OnRevert()
    {
        base.OnRevert();
        hasMove = false;
        startPosition = Vector3.zero;
    }
    public override void Init(Vector3 pos, Vector3 rot, TargetLayer layer)
    {
        base.Init(pos, rot, layer);
        startPosition = pos;
    }
    public override void Move()
    {
        if (!hasMove)
        {
            transform.DOMoveZ(transform.position.z + moveLength, 2).OnComplete<Tweener>(Boom);
            hasMove = true;
        }
    }
    void Boom() 
    {
        Vector3 pos = transform.position;
        for (int i = 0; i < SpawnCount; i++)
        {
            Bullet bullet = BulletPool.Instance.GetBulletObj("");
            bullet.Init(pos, Vector3.zero, TargetLayer.Enemy);
        }
    }
}
