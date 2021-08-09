using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalBullet : Bullet
{
    public override void Init(Vector3 pos, Vector3 rot, TargetLayer layer)
    {
        base.Init(pos, rot, layer);
        targetLayer = TargetLayer.Player;
    }
}
