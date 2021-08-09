/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using DG.Tweening;
public class MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        //EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);
        //Entities.WithAll<Entity>().ForEach((Entity entity)=> {
        //    entityCommandBuffer.DestroyEntity(entity);
        //});
        Entities.ForEach((Entity entity, ref Translation trans, ref SpeedComponent speed) =>//,ref DamageValueComponent damageValueComponent,ref AttackTargetComponent attackTargetComponent) => 
        {
            trans.Value.z += speed.speed * Time.deltaTime;
            /*
            List<CraftCtrl> craftCtrls = new List<CraftCtrl>();
            Collider[] colliders = Physics.OverlapSphere(trans.Value, 0.1f);
            for (int i = 0; i < colliders.Length; i++)
            {
                GameObject obje = colliders[i].gameObject;
                if (obje != null && obje.layer == LayerMask.NameToLayer(attackTargetComponent.targetLayer.ToString()))
                {
                    ParticleCtrl obj = ParticlePool.Instance.GetParticleObj(GameConst.BulletHitEffect);
                    if (obj != null)
                    {
                        obj.TurnOn = true;
                        obj.transform.position = trans.Value;
                    }
                    Camera.main.transform.DOShakePosition(0.015f).OnComplete(() => { Vector3 vec = Vector3.zero; vec.y = 50; Camera.main.transform.position = vec; });

                    CraftCtrl craft = GameManager.Instance.GetCraftComponent(obje);
                    if (craft!= null)
                    {
                        if (craftCtrls.Contains(craft))
                            continue;
                        craftCtrls.Add(craft);
                        craft.OnDamage(damageValueComponent.damageValue);
                        World.Active.EntityManager.DestroyEntity(entity);
                        break;
                    }
                }
                
                if (obje != null && GameManager.Instance.GetComponent<DeadZone>(obje) != null)
                {
                    World.Active.EntityManager.DestroyEntity(entity);
                }
            }
        });
    }
}
            */
