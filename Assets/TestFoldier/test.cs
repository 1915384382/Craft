using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Burst;
*/
public class test : MonoBehaviour
{
    [SerializeField]
    Mesh mesh;
    [SerializeField]
    Material material;
    [SerializeField]
    bool  usejob;
    List<Transform> transforms = new List<Transform>();
    float speed = 50;
    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject obj = new GameObject();
            MeshRenderer meshRenderer =obj.AddComponent<MeshRenderer>();
            meshRenderer.material = material;
            MeshFilter meshf =obj.AddComponent<MeshFilter>();
            meshf.mesh = mesh;
            Vector3 pos = Vector3.zero;
            pos.x = UnityEngine.Random.Range(-20, 20);
            pos.z = UnityEngine.Random.Range(-30, 30);
            obj.transform.position = pos;
            transforms.Add(obj.transform);
        }
    }
    public void TransMove() 
    {
        for (int i = 0; i < transforms.Count; i++)
        {
            Vector3 pos = Vector3.zero;
            pos.z += Time.deltaTime * speed;
            transforms[i].position = pos;
            /*
            if (transforms[i].position.z >= 30)
            {
                speed = -math.abs(speed);
            }
            if (transforms[i].position.z <= -30)
            {
                speed = math.abs(speed);
            }
            */
        }
        calcuLate();
    }
    private void Update()
    {
        float starttime = Time.realtimeSinceStartup;
        if (usejob)
        {

        Debug.Log(((Time.realtimeSinceStartup - starttime) * 1000) + "ms");
        }
        else
        {
            TransMove();
        Debug.Log(((Time.realtimeSinceStartup - starttime) * 1000) + "ms");
        }
        /*
        NativeList<JobHandle> handles = new NativeList<JobHandle>(Allocator.Temp);
        for (int i = 0; i < 10; i++)
        {
            JobHandle jobHandle = GetToughJob(mesh, material);
            handles.Add(jobHandle);
        }

        JobHandle.CompleteAll(handles);
        handles.Dispose();
        */
        /*
        for (int i = 0; i < 10; i++)
        {
            calcuLate();
        }
        */
    }
    public void calcuLate() 
    {
        float value = 0;
        for (int i = 0; i < 10000; i++)
        {
            //value = math.exp10(math.sqrt(value));
        }
    }
    //public void NormalToughJob() 
    //{
    //    EntityManager manager = World.Active.EntityManager;
    //    EntityArchetype entityArchetype = manager.CreateArchetype(
    //        typeof(LevelComponent),
    //        typeof(Translation),
    //        typeof(RenderMesh),
    //        typeof(MoveSpeedComponent),
    //        typeof(LocalToWorld)
    //        );

    //    NativeArray<Entity> array = new NativeArray<Entity>(100, Allocator.Temp);
    //    manager.CreateEntity(entityArchetype, array);
    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        Entity entity = array[i];
    //        manager.SetComponentData(entity, new LevelComponent() { level = 100 });
    //        manager.SetComponentData(entity, new Translation() { Value = new float3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-30, 30)) });

    //        manager.SetComponentData(entity, new MoveSpeedComponent() { speed = UnityEngine.Random.Range(50, 150) });

    //       // manager.SetSharedComponentData(entity, new RenderMesh() { mesh = mesh, material = material });

    //    }
    //}
    /*
    public JobHandle GetToughJob(Mesh mesh, Material material) 
    {
        ToughJob job = new ToughJob();
        return job.Schedule();
    }
    */
}
/*
[BurstCompile]
public struct ToughJob : IJob
{
    public void Execute()
    {
        float value = 0;
        for (int i = 0; i < 10000; i++)
        {
            value = math.exp10(math.sqrt(value));
        }
    }
}
public struct ToughJobParallel : IJobParallelFor
{
    public NativeArray<float3> transforms;
    public NativeArray<float> moveSpeed;
    public void Execute(int index)
    {
        transforms[index] += new float3(0, 0, moveSpeed[index] * Time.deltaTime);
        if (transforms[index].z >= 30)
        {
            moveSpeed[index] = -math.abs(moveSpeed[index]);
        }
        if (transforms[index].z <= 30)
        {
            moveSpeed[index] = math.abs(moveSpeed[index]);
        }
        float value = 0;
        for (int i = 0; i < 10000; i++)
        {
            value = math.exp10(math.sqrt(value));
        }
    }
}*/
