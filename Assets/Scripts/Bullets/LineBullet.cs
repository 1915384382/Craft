using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.Entities;
//using Unity.Mathematics;
//using Unity.Transforms;
public class LineBullet : MonoBehaviour
{
    public List<GameObject> BulletShooters;

    [SerializeField]
    int level = 0;
    List<int> index = new List<int>();
    public void GetShootPos(int level, out List<GameObject> Shoots) 
    {
        ChangeLevel(level);
        Shoots = new List<GameObject>();
        for (int i = 0; i < index.Count; i++)
        {
            if (i < BulletShooters.Count)
            {
                Shoots.Add(BulletShooters[i]);
            }
        }
    }
    public void ChangeLevel(int value)
    {
        level += value;
        level = Mathf.Clamp(level, 1, 4);
        index.Clear();
        if (level >= 1)
            index.Add(0);
        if (level >= 2)
        {
            index.Add(1);
            index.Add(2);
        }
        if (level >= 3)
        {
            index.Add(3);
            index.Add(4);
        }
        if (level >= 4)
        {
            index.Add(5);
            index.Add(6);
        }
    }
}
