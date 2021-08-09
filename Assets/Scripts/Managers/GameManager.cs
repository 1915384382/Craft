using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using UnityEditor;
public class GameManager:MonoBehaviour{
    public const float PlayerBulltSpeed = 150;
    public const float EnemyBulltSpeed = 50;
    public AirrCraftController player;
    public float RewardRate = 5;
    //禁止（敌人移动 射击 spawnmanager'生成敌人）
    public bool ForbitEnemyMoveShoot;
    public static GameManager Instance;

    StringBuilder stringBuilder;
    public Action<CraftCtrl,int> actionHpChange;
    public List<UIController> panels = new List<UIController>();
    public Action<int> actionResetGame;
    public Vector3 CheckVector3;
    private string bgm = "MainGame";
    public string BGM;
    private void Awake()
    {
        Instance = this;
        CheckVector3 = Vector3.zero;
        CheckVector3.x = 150;
        CheckVector3.y = 10;
        CheckVector3.z = 210;
        UIController.Instance.RegistEvent();
        stringBuilder = new StringBuilder();

        InstantiatePlayer();
        AudioManager.Instance.PlayBGM(GameConst.Instance.GameBGM);
    }
    public void InstantiatePlayer() 
    {
        CraftCtrl craftCtrl = AirCraftPool.Instance.GetAirCraft(AirCraftType.AirPlane.ToString());
        if (craftCtrl is AirrCraftController)
        {
            AirrCraftController airrCraftController = craftCtrl as AirrCraftController;
            player = airrCraftController;

            Vector3 pos = Vector3.zero;
            pos.x = 7;
            pos.z = -70;
            airrCraftController.Init(pos);

        }
    }
    public T GetComponent<T>(GameObject obj) 
    {
        T component = obj.GetComponent<T>();
        if (component == null)
        {
            component = obj.GetComponentInParent<T>();
        }
        return component;
    }

    #region 字符拼接
    public string AddString(string a, string b)
    {
        stringBuilder.Clear();
        stringBuilder.Append(a);
        stringBuilder.Append(b);
        return stringBuilder.ToString();
    }
    public string AddString(string a, string b, string c)
    {
        stringBuilder.Clear();
        stringBuilder.Append(a);
        stringBuilder.Append(b);
        stringBuilder.Append(c);
        return stringBuilder.ToString();
    }
    public string AddString(string a, string b, string c, string d)
    {
        stringBuilder.Clear();
        stringBuilder.Append(a);
        stringBuilder.Append(b);
        stringBuilder.Append(c);
        stringBuilder.Append(d);
        return stringBuilder.ToString();
    }
    public string AddString(string a, string b, string c, string d, string e)
    {
        stringBuilder.Clear();
        stringBuilder.Append(a);
        stringBuilder.Append(b);
        stringBuilder.Append(c);
        stringBuilder.Append(d);
        stringBuilder.Append(e);
        return stringBuilder.ToString();
    }
    #endregion

    #region 对象池父物体
    [HideInInspector]
    public GameObject BulletPool;
    [HideInInspector]
    public GameObject CraftPool;
    [HideInInspector]
    public GameObject ParticlePool;
    [HideInInspector]
    public GameObject RewardPool;
    public void InitPool(PoolType type)
    {
        switch (type)
        {
            case PoolType.Bullet:
                BulletPool = new GameObject("BulletPool");
                BulletPool.transform.parent = this.transform;
                break;
            case PoolType.Craft:
                CraftPool = new GameObject("CraftPool");
                CraftPool.transform.parent = this.transform;
                break;
            case PoolType.Reward:
                RewardPool = new GameObject("RewardPool");
                RewardPool.transform.parent = this.transform;
                break;
            case PoolType.Particle:
                ParticlePool = new GameObject("ParticlePool");
                ParticlePool.transform.parent = this.transform;
                break;
            default:
                break;
        }
    }
    #endregion

    public void ResetGame() 
    {
        actionResetGame?.Invoke(0);
        SpawnManager.instance.CanSpawn = false;
        StartCoroutine("ResetGamee");
    }
    IEnumerator ResetGamee() 
    {
        yield return new WaitForSeconds(1);
        InstantiatePlayer();

        SpawnManager.instance.CanSpawn = true;
    }
    public void QuiteGame() 
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

        Debug.Log("编辑状态游戏退出");

#else

            Application.Quit();
#endif
    }
}
