using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameObjectPool
{
    private static GameObjectPool ins;
    public static GameObjectPool Instance
    {
        get
        {
            if (ins == null)
                ins = new GameObjectPool();
            return ins;
        }
    }
    private Dictionary<string, List<GameObject>> objects = new Dictionary<string, List<GameObject>>();
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    public T CreateObject<T>(string _name,PoolPathType poolPathType) where T :class
    {
        GameObject gameObject = null;
        GameObject prefab = null;
        if (prefabs.ContainsKey(_name))
        {
            prefab = prefabs[_name];
        }
        else
        {
            prefab =  Resources.Load<GameObject>(GameManager.Instance.AddString("Prefabs/", poolPathType.ToString(),"/",_name));
            prefabs[_name] = prefab;
        }
        if (!objects.ContainsKey(_name))
        {
            objects[_name] = new List<GameObject>();
        }

        List<GameObject> objs = objects[_name];
        if (objs.Count>0)
        {
            gameObject = objs[0];
            objs.RemoveAt(0);
        }
        else
        {
            gameObject = GameObject.Instantiate(prefab);
        }
        T TObj = GameManager.Instance.GetComponent<T>(gameObject);
        switch (poolPathType)
        {
            case PoolPathType.AirCrafts:
                if (TObj is AirrCraftController)
                {
                    AirrCraftController airrCraft = TObj as AirrCraftController;
                    airrCraft.path = _name;
                    airrCraft.pooltype = PoolPathType.AirCrafts;
                    airrCraft.gameObject.SetActive(true);
                }
                break;
            case PoolPathType.Bullets:
                if (TObj is Bullet)
                {
                    Bullet airrCraft = TObj as Bullet;
                    airrCraft.path = _name;
                    airrCraft.pooltype = PoolPathType.Bullets;
                    airrCraft.gameObject.SetActive(true);
                }
                break;
            case PoolPathType.Effects:
                if (TObj is ParticleCtrl)
                {
                    ParticleCtrl airrCraft = TObj as ParticleCtrl;
                    airrCraft.path = _name;
                    airrCraft.pooltype = PoolPathType.Effects;
                    airrCraft.gameObject.SetActive(true);
                }
                break;
            case PoolPathType.Rewards:
                if (TObj is RewardsCtrl)
                {
                    RewardsCtrl airrCraft = TObj as RewardsCtrl;
                    airrCraft.path = _name;
                    airrCraft.pooltype = PoolPathType.Rewards;
                    airrCraft.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
        return TObj;
    }
    public void RevertGameObject(GameObject gameObject, PoolPathType poolPathType)
    {
        string path = "";
        switch (poolPathType)
        {
            case PoolPathType.AirCrafts:
                AirrCraftController airrCraft = GameManager.Instance.GetComponent<AirrCraftController>(gameObject);
                if (airrCraft!=null)
                {
                    path = airrCraft.path;
                    airrCraft.path = "";
                }
                break;
            case PoolPathType.Bullets:
                Bullet bullet = GameManager.Instance.GetComponent<Bullet>(gameObject);
                if (bullet!=null)
                {
                    path = bullet.path;
                    bullet.pooltype = PoolPathType.Bullets;
                }
                break;
            case PoolPathType.Effects:
                ParticleCtrl particle = GameManager.Instance.GetComponent<ParticleCtrl>(gameObject);
                if (particle!=null)
                {
                    path = particle.path;
                    particle.path = "";
                    particle.pooltype = PoolPathType.Effects;
                }
                break;
            case PoolPathType.Rewards:
                RewardsCtrl reward = GameManager.Instance.GetComponent<RewardsCtrl>(gameObject);
                if (reward!= null)
                {
                    path = reward.path;
                    reward.path = "";
                    reward.pooltype = PoolPathType.Rewards;
                }
                break;
            default:
                break;
        }
        if (!prefabs.ContainsKey(path))
        {
            prefabs[path] = gameObject;
        }
        if (objects.ContainsKey(path))
        {
            objects[path].Add(gameObject);
        }
        else
        {
            objects[path] = new List<GameObject>();
            objects[path].Add(gameObject);
        }
        gameObject.transform.parent = GameManager.Instance.CraftPool.transform;
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.eulerAngles = Vector3.zero;
        gameObject.gameObject.SetActive(false);


    }
}
