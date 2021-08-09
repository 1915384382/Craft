using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bullet : MonoBehaviour
{
    //子弹速度
    public float Speed;
    //子弹伤害
    public int Damage;
    //诞生时间
    float initTime;
    //销毁时间
    protected float destroyTime = 20;
    //目标阵营
    protected TargetLayer targetLayer;
    [HideInInspector]
    public string path;
    [HideInInspector]
    public PoolPathType pooltype;
    public virtual void Init(Vector3 pos, Vector3 rot,TargetLayer layer) 
    {
        initTime = Time.time;
        transform.position = pos;
        transform.eulerAngles = rot;
        targetLayer = layer;
        SetBulletSpeed();
    }
    public virtual void OnRevert()
    {
        initTime = 0;
        path = "";
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }
    public virtual void SetBulletSpeed()  { }
    void Update()
    {
        if (Time.time - destroyTime <= initTime)
        {
            Move();

            Vector3 pos = transform.position;
            if (pos.x <= -75 || pos.x >= 75 || pos.z <= -105 || pos.z >= 105)
            {
                BulletPool.Instance.RevertBullet(gameObject);
            }
            Trigger();
        }
        else
        {
            BulletPool.Instance.RevertBullet(gameObject);
        }
    }
    public virtual void Move() 
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
    }
    Collider[] targets;
    void Trigger() 
    {
        targets = Physics.OverlapSphere(transform.position, 0.1f);
        for (int i = 0; i < targets.Length; i++)
        {
            Collider collision = targets[i];
            if (collision.gameObject.CompareTag(targetLayer.ToString()))
            {
                OnTrigEnter(collision);
                return;
            }
        }
    }
    public virtual void OnTrigEnter(Collider collision)
    {
        ParticleCtrl obj = ParticlePool.Instance.GetParticleObj(GameConst.Instance.BulletHitEffect);
        if (obj != null)
        {
            obj.TurnOn = true;
            obj.transform.position = collision.transform.position;
        }
        //Camera.main.transform.DOShakePosition(0.015f).OnComplete(() => { Vector3 vec = Vector3.zero; vec.y = 50; Camera.main.transform.position = vec; });

        CraftCtrl craftCtrl = GameManager.Instance.GetComponent<CraftCtrl>(collision.gameObject);
        if (craftCtrl != null)
        {
            craftCtrl.OnDamage(Damage);
        }
        OnDestroyBullet();
    }
    //private void OnTriggerEnter(Collider collision)
    //{
    //    OnTrigEnter(collision);
    //}
    public virtual void OnDestroyBullet() 
    {
        BulletPool.Instance.RevertBullet(gameObject);
    }
    public void Setaction()
    {
        GameManager.Instance.actionResetGame += OnGameReset;
    }
    public void OnGameReset(int a)
    {
        BulletPool.Instance.RevertBullet(this.gameObject);
        GameManager.Instance.actionResetGame -= OnGameReset;
    }
}
