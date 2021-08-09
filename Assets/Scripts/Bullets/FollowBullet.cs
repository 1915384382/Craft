using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FollowBullet : Bullet
{
    public EnemyCraft target;
    float lifeTime = 5f;
    Quaternion eular;
    public float angle;
    public float delayTime;

    float delayTimer;
    public override void SetBulletSpeed()
    {
        Speed = 50f;
        destroyTime = 5f;
        //float angel = 0;
        //int random = Random.Range(0, 2);
        //if (random == 1)
        //{
        //    angel = 10;// Random.Range(30, 60);
        //}
        //else
        //{
        //    angel = -10;// Random.Range(-60, -30);
        //}
        eular = Quaternion.Euler(0, angle, 0);
        delayTimer = delayTime;
    }
    public override void Move()
    {
        if (delayTimer <= 0)
        {
            LookMove();
        }
        else
        {
            delayTimer -= Time.deltaTime;
        }
        transform.position += transform.forward * Time.deltaTime * Speed;
    }
    //public float angel = 60;
    //void CircleMove()
    //{
    //    Vector3 targetDir = (target.transform.position - transform.position).normalized;
    //    float a = Vector3.Angle(transform.forward, targetDir) / angel;
    //    transform.forward = Vector3.Slerp(transform.forward, targetDir, Time.deltaTime / a).normalized;
    //    Vector3 forward = transform.forward;
    //    transform.position += forward * Time.deltaTime * Speed;
    //}
    Collider[] colliders;
    void LookMove() 
    {
        //eular
        //Vector3 eular = transform.eulerAngles;
        //transform.LookAt(target);
        //Vector3 afterLookEular = transform.eulerAngles;
        //transform.eulerAngles = eular;
        //transform.eulerAngles = Vector3.Slerp(eular, afterLookEular, 0.1f);
        //transform.position += transform.forward * Time.deltaTime * speed;
        if (target == null || target.IsDie)
        {
            target = null;
            colliders = Physics.OverlapBox(Vector3.zero, GameManager.Instance.CheckVector3);
            float minLength = 100;
            Vector3 pos = transform.position;
            for (int i = 0; i < colliders.Length; i++)
            {
                EnemyCraft enemyCraft = GameManager.Instance.GetComponent<EnemyCraft>(colliders[i].gameObject);
                if (enemyCraft!=null && enemyCraft.isActiveAndEnabled)
                {
                    float dis = Vector3.Distance(enemyCraft.transform.position, pos);
                    if (dis<minLength)
                    {
                        target = enemyCraft;
                    }
                }
            }
        }
        if (target!=null)
        {
            FollowMove();
            //rotation
            
        }
        //魔鬼的步伐
        //transform.rotation = transform.rotation *  Quaternion.Euler(0, Random.Range(0,2) ==0?Random.Range(30f,60f):Random.Range(-60f,-30f), 0);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawCube(Vector3.zero, new Vector3(150,10,210));
    //    Gizmos.color = Color.red;
    //}
    void QuaternionMove() 
    {
        Vector3 relativePos = target.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(relativePos.normalized);
        if (rot != transform.rotation)
        {
            Quaternion rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos.normalized), 0.1f);
            transform.rotation = rotation;
        }
    }
    void FollowMove() 
    {
        Vector3 direction = target.transform.position - transform.position;

        float angel =  Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, angel, 0 );
        transform.rotation = transform.rotation * eular;
    }
}
//[RequireComponent(typeof(Collider), typeof(AudioSource))]
//public class FollowBullet : MonoBehaviour
//{
//    [SerializeField, Tooltip("最大转弯速度")]
//    private float MaximumRotationSpeed = 120.0f;

//    [SerializeField, Tooltip("加速度")]
//    private float AcceleratedVeocity = 12.8f;

//    [SerializeField, Tooltip("最高速度")]
//    private float MaximumVelocity = 30.0f;

//    [SerializeField, Tooltip("生命周期")]
//    private float MaximumLifeTime = 8.0f;

//    [SerializeField, Tooltip("上升期时间")]
//    private float AccelerationPeriod = 0.5f;

//    [SerializeField, Tooltip("爆炸特效预制体")]
//    private List<ParticleCtrl> ExplosionPrefabs = null;

//    [SerializeField, Tooltip("导弹渲染体组件")]
//    private Renderer MissileRenderer = null;

//    [SerializeField, Tooltip("尾焰及烟雾粒子特效")]
//    private ParticleSystem[] MissileEffects = null;

//    [SerializeField]
//    public Transform Target = null;        // 目标
//    [SerializeField]
//    public float CurrentVelocity = 0.0f;   // 当前速度

//    private AudioSource audioSource = null;   // 音效组件
//    private float lifeTime = 0.0f;            // 生命期

//    private void Start()
//    {
//        //audioSource = GetComponent<AudioSource>();
//        //audioSource.loop = true;
//        //if (!audioSource.isPlaying)
//        //    audioSource.Play();
//    }

//    // 爆炸
//    private void Explode()
//    {
//        // 之所以爆炸时不直接删除物体，而是先禁用一系列组件，
//        // 是因为导弹产生的烟雾等效果不应该立即消失

//        // 禁止所有碰撞器
//        foreach (Collider col in GetComponents<Collider>())
//        {
//            col.enabled = false;
//        }
//        // 禁止所有粒子系统
//        foreach (ParticleSystem ps in MissileEffects)
//        {
//            ps.Stop();
//        }
//        // 停止播放音效
//        //if (audioSource.isPlaying)
//        //    audioSource.Stop();

//        // 停止渲染，停止本脚本，随机实例化爆炸特效，删除本物体
//        MissileRenderer.enabled = false;
//        enabled = false;
//        Instantiate(ExplosionPrefabs[Random.Range(0, ExplosionPrefabs.Count)], transform.position, Random.rotation);

//        // 三秒后删除导弹物体，这时候烟雾已经散去，可以删掉物体了
//        Destroy(gameObject, 3.0f);
//    }

//    private void Update()
//    {
//        float deltaTime = Time.deltaTime;
//        lifeTime += deltaTime;

//        // 如果超出生命周期，则直接爆炸。
//        if (lifeTime > MaximumLifeTime)
//        {
//            Explode();
//            return;
//        }

//        // 计算朝向目标的方向偏移量，如果处于上升期，则忽略目标
//        Vector3 offset =
//            ((lifeTime < AccelerationPeriod) && (Target != null))
//            ? Vector3.up
//            : (Target.position - transform.position).normalized;

//        // 计算当前方向与目标方向的角度差
//        float angle = Vector3.Angle(transform.forward, offset);

//        // 根据最大旋转速度，计算转向目标共计需要的时间
//        float needTime = angle / (MaximumRotationSpeed * (CurrentVelocity / MaximumVelocity));

//        // 如果角度很小，就直接对准目标
//        if (needTime < 0.001f)
//        {
//            transform.forward = offset;
//        }
//        else
//        {
//            // 当前帧间隔时间除以需要的时间，获取本次应该旋转的比例。
//            transform.forward = Vector3.Slerp(transform.forward, offset, deltaTime / needTime).normalized;
//        }

//        // 如果当前速度小于最高速度，则进行加速
//        if (CurrentVelocity < MaximumVelocity)
//            CurrentVelocity += deltaTime * AcceleratedVeocity;
//        Vector3 pos = transform.forward * CurrentVelocity * deltaTime;
//        pos.y = 0;
//        // 朝自己的前方位移
//        transform.position += pos;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        // 当发生碰撞，爆炸
//        Explode();
//    }
//}