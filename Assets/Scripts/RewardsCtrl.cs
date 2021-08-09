using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RewardType
{
    LvUp,
    LifeUp,
}
public class RewardsCtrl : MonoBehaviour
{
    public string path;
    public PoolPathType pooltype;
    public float lifetime = 5f;
    public RewardType type;
    int lifeHp = 20;
    int addLevel = 1;
    //左右范围
    float LeftRange;
    float RightRange;
    //飞行速度
    int speed = 10;
    //x轴速度
    float XSpeed;
    public void InitReward(Vector3 pos) 
    {
        transform.position = pos;
        LeftRange = pos.x - 10;
        RightRange = pos.x + 10;
        XSpeed = 1.5f;
        speed = 10;
    }
    private void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.x = XSpeed;
        if (transform.position.x >= RightRange)
            XSpeed = -Mathf.Abs(XSpeed);
        else if (transform.position.x <= LeftRange)
            XSpeed = Mathf.Abs(XSpeed);
        dir.z = -1;
        transform.Translate(dir * Time.deltaTime * speed, Space.World);

        Vector3 pos = transform.position;
        if (pos.x <= -75 || pos.x >= 75 || pos.z <= -105 || pos.z >= 105)
        {
            BulletPool.Instance.RevertBullet(gameObject);
        }
        Trigger();
    }
    Collider[] target;
    void Trigger()
    {
        target = Physics.OverlapSphere(transform.position, 0.1f);
        for (int i = 0; i < target.Length; i++)
        {
            Collider collision = target[i];
            if (collision.gameObject.CompareTag("Player"))
            {
                CraftCtrl craftCtrl = GameManager.Instance.GetComponent<CraftCtrl>(collision.gameObject);
                if (craftCtrl != null)
                {
                    if (type == RewardType.LifeUp)
                    {
                        craftCtrl.OnDamage(-lifeHp);
                    }
                    else if (type == RewardType.LvUp)
                    {
                        craftCtrl.SetLevel(addLevel);
                    }
                }
                RewardPool.Instance.RevertReward(gameObject);
                OnTrigEnter(collision);
                return;
            }
        }
    }
    public virtual void OnTrigEnter(Collider collision) { }
    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        CraftCtrl craftCtrl = GameManager.Instance.GetComponent<CraftCtrl>(collision.gameObject);
    //        if (craftCtrl != null)
    //        {
    //            if (type == RewardType.LifeUp)
    //            {
    //                craftCtrl.OnDamage(-lifeHp);
    //            }
    //            else if (type == RewardType.LvUp)
    //            {
    //                craftCtrl.SetLevel(addLevel);
    //            }
    //        }
    //        RewardPool.Instance.RevertReward(gameObject);
    //    }
    //}
    public void Setaction()
    {
        GameManager.Instance.actionResetGame += OnGameReset;
    }
    public void OnGameReset(int a)
    {
        RewardPool.Instance.RevertReward(this.gameObject);
        GameManager.Instance.actionResetGame -= OnGameReset;
    }
}