using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using Unity.Entities;
//using Unity.Transforms;
public class AirrCraftController : CraftCtrl
{
    [Header("飞机速度  上下 左右")]
    [SerializeField]
    float UpDownSpeed;
    [SerializeField]
    float LeftRightSpeed;

    [Header("子弹位置")]
    public LineBullet LineBullet;
    [SerializeField]
    bool hitTargetMove = false;
    bool ForbitShootMove = false;
    
    [Header("子弹预制体")]
    public GameObject bulletPrefab;
    [Header("子弹速度")]
    public float bulletSpeed;

    float bulletCDTimer;

    //Entity bulletEntityPrefab;
    //EntityManager manager;
    List<GameObject> shoots = new List<GameObject>();
    public BulletType bulletType;
    public void Init(Vector3 pos) 
    {
        ForbitShootMove = true;
        transform.position = pos;
        Vector3 position = Vector3.zero;
        position.x = 7;
        position.z = -60;
        transform.DOMove(position, 1).OnComplete<Tweener>(MoveEnd);


        HP = MaxHP;
        LineBullet = GetComponentInChildren<LineBullet>();
        SetLevel(1);
        //manager = World.Active.EntityManager;
        //bulletEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(bulletPrefab, World.Active);
    }
    public void MoveEnd() 
    {
        ForbitShootMove = false;
    }
    public override void SetLevel(int addLevel)
    {
        if (LineBullet != null)
        {
            LineBullet.GetShootPos(addLevel, out shoots);
        }
    }
    void Update()
    {
        if (!IsDie && !ForbitShootMove)
        {
            MouseMove();
            Move();
            Shoot();
            if (Input.GetKeyDown(KeyCode.E))
                SetLevel(1);
        }
    }
    Transform target;
    Vector3 NowPosition;
    Vector3 LastPosition;
    void MouseMove() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, int.MaxValue))
            {
                //Debug.Log("检测到物体");
                if (hit.transform != null && hit.transform.IsChildOf(transform))
                {
                    target = transform;
                }
            }
            NowPosition = Input.mousePosition;
            LastPosition = NowPosition;
            if (!hitTargetMove)
            {
                target = GameManager.Instance.player.transform;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("GetMouseButtonUp");
            target = null;
            NowPosition = Vector3.zero;
            LastPosition = Vector3.zero;
        }
    }
    private void LateUpdate()
    {
        if (target!=null)
        {
            if (hitTargetMove)
            {
                NowPosition = Input.mousePosition;
                Vector3 now = Camera.main.ScreenToWorldPoint(NowPosition);
                now.y = 0;
                now.x = Mathf.Clamp(now.x, -38, 38);
                now.z = Mathf.Clamp(now.z, -65, 65);
                target.transform.position = now;
                LastPosition = NowPosition;
            }
            else
            {
                NowPosition = Input.mousePosition;
                if (NowPosition != LastPosition)
                {
                    Vector3 now = Camera.main.ScreenToWorldPoint(NowPosition);
                    Vector3 last = Camera.main.ScreenToWorldPoint(LastPosition);
                    Vector3 difrent = now - last;
                    difrent.y = 0;
                    difrent = target.transform.position + difrent;
                    difrent.x = Mathf.Clamp(difrent.x, -38, 38);
                    difrent.z = Mathf.Clamp(difrent.z, -65, 65);
                    target.transform.position = difrent;
                }
                LastPosition = NowPosition;
            }
        }
    }
    void Move()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir.z = UpDownSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.z = -UpDownSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -LeftRightSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = LeftRightSpeed;
        }

        transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -38, 38);
        position.z = Mathf.Clamp(position.z, -65, 65);
        transform.position = position;
    }
    public override void BeHit(int value)
    {
        if (IsDie)
        {
            ParticleCtrl particle = ParticlePool.Instance.GetParticleObj(GameConst.Instance.AirCraftBombEffect);
            if (particle != null)
            {
                particle.TurnOn = true;
                particle.transform.position = transform.position;
            }
            AirCraftPool.Instance.RevertCraft(gameObject);
        }
    }
    void Shoot()
    {
        if (bulletCDTimer <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetBullet();
            }
            else if (Input.GetMouseButton(0))
            {
                GetBullet();
            }
        }
        else
        {
            bulletCDTimer -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Break();
        }
    }
    void GetBullet()
    {
        for (int i = 0; i < shoots.Count; i++)
        {
            Vector3 pos = shoots[i].transform.position;
            Vector3 rot = shoots[i].transform.eulerAngles;
            Bullet bullet = BulletPool.Instance.GetBulletObj(bulletType.ToString());
            if (bullet != null)
            {
                bullet.Init(pos, rot, TargetLayer.Enemy);
                AudioManager.Instance.Play("Bullet");
            }
        }
        bulletCDTimer = ShootCd;
    }
    //public void SpawnBulletEcs(Vector3 position, Vector3 rotation)
    //{
    //    Entity bullet = manager.Instantiate(bulletEntityPrefab);

    //    manager.SetComponentData(bullet, new Translation { Value = position });
    //    manager.SetComponentData(bullet, new Rotation { Value = Quaternion.Euler(rotation) });
    //    manager.AddComponentData(bullet, new SpeedComponent { speed = bulletSpeed });
    //    //manager.AddComponentData(bullet, new AttackTargetComponent { targetLayer = TargetLayer.Enemy });
    //    //manager.AddComponentData(bullet, new DamageValueComponent { damageValue = damage });
    //}
    public override void OnReset()
    {
        Init(Vector3.zero);
        SetLevel(-10);
        ForbitShootMove = true;
        target = null;
        NowPosition = Vector3.zero;
        LastPosition = Vector3.zero;
    }
}
