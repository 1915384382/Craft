using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletPool.Instance.RevertBullet(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            AirCraftPool.Instance.RevertCraft(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AirCraftPool.Instance.RevertCraft(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Reward"))
        {
            RewardPool.Instance.RevertReward(collision.gameObject);
        }
    }
}
