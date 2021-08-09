using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCraft : CraftCtrl
{
    float Speed = 10;
    float DeadTimer = 0.5f;
    Collider[] colliders;
    Rigidbody rb;
    RigidbodyConstraints constraints;
    void Awake()
    {
        colliders = GetComponentsInChildren<Collider>();
        rb = GetComponent<Rigidbody>();
        if (rb!=null)
        {
            constraints = rb.constraints;
        }
    }
    public void InitEnemyCraft(Vector3 pos, Vector3 rot) 
    {
        HP = Random.Range(100, 500);
        FixHP();
        transform.position = pos;
        transform.eulerAngles = rot;
        DeadTimer = 0.5f;
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = true;
        }
        rb.constraints = constraints;
        bulletTimer = Random.Range(2.5f, 5f);
    }
    float bulletTimer;
    void Update()
    {
        if (!IsDie)
        {
            if (!GameManager.Instance.ForbitEnemyMoveShoot)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Speed, Space.Self);
            }
            bulletTimer -= Time.deltaTime;
            if (bulletTimer <= 0)
            {
                Shoot();
                bulletTimer = Random.Range(2.5f, 5f);
            }
        }
        else
        {
            DeadTimer -= Time.deltaTime;
            if (DeadTimer <= 0)
            {
                Dead();
            }
        }
    }
    public override void BeHit(int damageValue) 
    {
        if (IsDie)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
    }
    public void Dead()
    {
        ParticleCtrl particle = ParticlePool.Instance.GetParticleObj(GameConst.Instance.AirCraftBombEffect);
        if (particle != null)
        {
            particle.TurnOn = true;
            particle.transform.position = transform.position;
        }
        if (Random.Range(0, 100) <= GameManager.Instance.RewardRate)
        {
            RewardsCtrl reward = RewardPool.Instance.GetReward(GameConst.Instance.rewards[Random.Range(0, GameConst.Instance.rewards.Length)]);
            if (reward != null)
            {
                reward.InitReward(transform.position);
            }
        }
        AirCraftPool.Instance.RevertCraft(gameObject);
    }
    void Shoot() 
    {
        if (GameManager.Instance.ForbitEnemyMoveShoot)
        {
            return;
        }
        if (transform.position.z > GameManager.Instance.player.transform.position.z)
        {
            Bullet bullet = BulletPool.Instance.GetBulletObj(BulletType.EnemyNormalBullet.ToString());// ObjectPool.Instance.GetObject<Bullet>("Bullet");
            if (bullet != null)
            {
                bullet.Init(transform.position, Vector3.zero, TargetLayer.Player);
                bullet.transform.LookAt(GameManager.Instance.player.transform);
            }
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
    //    {
    //        OnDamage(20);
    //    }
    //}
}
