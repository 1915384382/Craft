using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool<T> where T : Object
{
    private static ObjPool<T> ins;
    public static ObjPool<T> Instance
    {
        get
        {
            if (ins == null)
            {
                ins = new ObjPool<T>();
            }
            return ins;
        }
    }
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    protected List<PoolNode<T>> objects = new List<PoolNode<T>>();
    PoolNode<T> GetPoolNode(string _name)
    {
        PoolNode<T> node = objects.Find(x => { return x.path == _name; });
        if (node == null)
        {
            node = new PoolNode<T>(_name);
            objects.Add(node);
        }
        return node;
    }
}
