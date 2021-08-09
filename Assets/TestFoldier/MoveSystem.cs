using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public class MoveSystem : ComponentSystem
//{
//    protected override void OnUpdate()
//    {
//        Entities.ForEach((ref Translation trans,ref MoveSpeedComponent speedComponent) =>
//        {
//            trans.Value.z += Time.deltaTime * speedComponent.speed;
//            if (trans.Value.z >= 30)
//            {
//                speedComponent.speed = -Mathf.Abs(speedComponent.speed);
//            }
//            if (trans.Value.z <= -30)
//            {
//                speedComponent.speed = Mathf.Abs(speedComponent.speed);
//            }
//        });
//    }
//}
