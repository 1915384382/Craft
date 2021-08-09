using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolNode<T> where T : Object
{
    public string path;
    Queue<T> queue = new Queue<T>();
    public PoolNode(string _path)
    {
        path = _path;
    }
    public T Dequeue()
    {
        T ret = null;
        while (queue.Count > 0 && ret == null)
        {
            ret = queue.Dequeue();
        }
        return ret;
    }
    public void Enqueue(T data)
    {
        queue.Enqueue(data);
    }
    public T Peak()
    {
        T ret = null;
        while (queue.Count > 0)
        {
            ret = queue.Peek();
            if (ret != null)
            {
                return ret;
            }
            else
            {
                queue.Dequeue();
            }
        }
        return ret;
    }
    public bool Contains(T obj)
    {
        return queue.Contains(obj);
    }

}

public abstract class ObjectPool<T> where T : Object
{
    
    public int limitNum = 20;
    public int nowNum = 0;
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
    protected abstract T OnCreateObject(string _name);
    protected abstract void OnRevertObject(T _object);

    protected virtual T GetObject(string _path)
    {
        PoolNode<T> node = GetPoolNode(_path);
        T ret = node.Dequeue();
        if (ret == null)
        {
            ret = OnCreateObject(_path);
            if (ret == null)
            {
                Debug.LogError(" can not create name =" + _path);
            }
        }
        else
        {
            nowNum--;
        }
        return ret;
    }
    public virtual void RevertObject(string path, T obj)
    {
        if (obj != null)
        {
            OnRevertObject(obj);
            PoolNode<T> node = GetPoolNode(path);
            if (!node.Contains(obj))
            {
                node.Enqueue(obj);
                nowNum++;
            }
        }
    }
}
public class BulletPool : ObjectPool<Bullet>
{
    private static BulletPool ins;
    public static BulletPool Instance
    {
        get
        {
            if (ins == null)
            {
                ins = new BulletPool();
                GameManager.Instance.InitPool(PoolType.Bullet);
            }
            return ins;
        }
    }
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    protected override Bullet OnCreateObject(string _name)
    {
        Bullet bullet = null;
        GameObject prefab = null;
        if (prefabs.ContainsKey(_name))
        {
            prefab = prefabs[_name];
        }
        else
        {
            prefab = Resources.Load<GameObject>("Prefabs/Bullets/" + _name);
            prefabs.Add(_name, prefab);
        }
        if (prefab != null)
        {
            GameObject go = GameObject.Instantiate(prefab);
            bullet = GameManager.Instance.GetComponent<Bullet>(go);
        }
        return bullet;
    }

    public void RevertBullet(GameObject gameObject)
    {
        Bullet bullet = GameManager.Instance.GetComponent<Bullet>(gameObject);
        if (bullet != null)
        {
            RevertObject(bullet.path, bullet);
            bullet.gameObject.SetActive(false);
            bullet.transform.parent = GameManager.Instance.BulletPool.transform;
        }
        else
        {
            Debug.LogError("obj is not Bullet+" + gameObject.name);
        }
    }
    protected override void OnRevertObject(Bullet _object)
    {
        _object.OnRevert();
    }
    public Bullet GetBulletObj(string path)
    {
        Bullet bullet = base.GetObject(path);
        bullet.path = path;
        bullet.gameObject.SetActive(true);
        bullet.Setaction();
        return bullet;
    }
}
public class ParticlePool : ObjectPool<ParticleCtrl>
{
    private static ParticlePool ins;
    public static ParticlePool Instance
    {
        get
        {
            if (ins == null)
            {
                ins = new ParticlePool();
                GameManager.Instance.InitPool(PoolType.Particle);
            }
            return ins;
        }
    }
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    protected override ParticleCtrl OnCreateObject(string _name)
    {
        ParticleCtrl bullet = null;
        GameObject prefab = null;
        if (prefabs.ContainsKey(_name))
        {
            prefab = prefabs[_name];
        }
        else
        {
            prefab = Resources.Load<GameObject>("Prefabs/Effects/" + _name);
            prefabs.Add(_name, prefab);
        }
        if (prefab != null)
        {
            GameObject go = GameObject.Instantiate(prefab);
            bullet = GameManager.Instance.GetComponent<ParticleCtrl>(go);
        }
        return bullet;
    }

    public void RevertParticle(GameObject gameObject)
    {
        ParticleCtrl bullet = GameManager.Instance.GetComponent<ParticleCtrl>(gameObject);
        if (bullet != null)
        {
            RevertObject(bullet.path, bullet);
            bullet.gameObject.SetActive(false);
            bullet.transform.parent = GameManager.Instance.ParticlePool.transform;
        }
        else
        {
            Debug.LogError("obj is not Bullet+" + gameObject.name);
        }
    }
    protected override void OnRevertObject(ParticleCtrl _object)
    {
        _object.path = "";
        _object.transform.position = Vector3.zero;
        _object.transform.eulerAngles = Vector3.zero;
    }
    public ParticleCtrl GetParticleObj(string path)
    {
        ParticleCtrl bullet = base.GetObject(path);
        bullet.path = path;
        bullet.gameObject.SetActive(true);
        bullet.Setaction();
        return bullet;
    }
}
public class AirCraftPool : ObjectPool<CraftCtrl>
{
    private static AirCraftPool ins;
    public static AirCraftPool Instance
    {
        get
        {
            if (ins == null)
            {
                ins = new AirCraftPool();
                GameManager.Instance.InitPool(PoolType.Craft);
            }
            return ins;
        }
    }
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    protected override CraftCtrl OnCreateObject(string _name)
    {
        CraftCtrl bullet = null;
        GameObject prefab = null;
        if (prefabs.ContainsKey(_name))
        {
            prefab = prefabs[_name];
        }
        else
        {
            prefab = Resources.Load<GameObject>("Prefabs/AirCrafts/" + _name);
            prefabs.Add(_name, prefab);
        }
        if (prefab != null)
        {
            GameObject go = GameObject.Instantiate(prefab);
            bullet = GameManager.Instance.GetComponent<CraftCtrl>(go);
        }
        return bullet;
    }

    public void RevertCraft(GameObject gameObject)
    {
        CraftCtrl bullet = GameManager.Instance.GetComponent<CraftCtrl>(gameObject);
        if (bullet != null)
        {
            RevertObject(bullet.path, bullet);
            bullet.gameObject.SetActive(false);
            bullet.transform.parent = GameManager.Instance.CraftPool.transform;
        }
        else
        {
            Debug.LogError("obj is not Bullet+" + gameObject.name);
        }
    }
    protected override void OnRevertObject(CraftCtrl _object)
    {
        _object.path = "";
        _object.transform.position = Vector3.zero;
        _object.transform.eulerAngles = Vector3.zero;
    }
    public CraftCtrl GetAirCraft(string path)
    {
        CraftCtrl bullet = base.GetObject(path);
        bullet.path = path;
        bullet.gameObject.SetActive(true);
        bullet.Setaction();
        return bullet;
    }
}

public class RewardPool : ObjectPool<RewardsCtrl>
{
    private static RewardPool ins;
    public static RewardPool Instance
    {
        get
        {
            if (ins == null)
            {
                ins = new RewardPool();
                GameManager.Instance.InitPool(PoolType.Reward);
            }
            return ins;
        }
    }
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    protected override RewardsCtrl OnCreateObject(string _name)
    {
        RewardsCtrl bullet = null;
        GameObject prefab = null;
        if (prefabs.ContainsKey(_name))
        {
            prefab = prefabs[_name];
        }
        else
        {
            prefab = Resources.Load<GameObject>("Prefabs/Rewards/" + _name);
            prefabs.Add(_name, prefab);
        }
        if (prefab != null)
        {
            GameObject go = GameObject.Instantiate(prefab);
            bullet = GameManager.Instance.GetComponent<RewardsCtrl>(go);
        }
        return bullet;
    }

    public void RevertReward(GameObject gameObject)
    {
        RewardsCtrl bullet = GameManager.Instance.GetComponent<RewardsCtrl>(gameObject);
        if (bullet != null)
        {
            RevertObject(bullet.path, bullet);
            bullet.gameObject.SetActive(false);
            bullet.transform.parent = GameManager.Instance.RewardPool.transform;
        }
        else
        {
            Debug.LogError("obj is not Bullet+" + gameObject.name);
        }
    }
    protected override void OnRevertObject(RewardsCtrl _object)
    {
        _object.path = "";
        _object.transform.position = Vector3.zero;
        _object.transform.eulerAngles = Vector3.zero;
    }
    public RewardsCtrl GetReward(string path)
    {
        RewardsCtrl bullet = base.GetObject(path);
        bullet.path = path;
        bullet.gameObject.SetActive(true);
        bullet.Setaction();
        return bullet;
    }
}