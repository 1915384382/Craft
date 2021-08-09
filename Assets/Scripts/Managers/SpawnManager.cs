using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	const string EnemyPath = "Obstacles/";
	[SerializeField]
	float SpawnCD;

	[SerializeField]
	float SpawnCount;

	public List<GameObject> enemys;
	Vector3 rot = new Vector3(0, 180, 0);
	public static SpawnManager instance;
	public bool CanSpawn = false;
    private void Awake()
    {
		instance = this;
		CanSpawn = true;
	}
    float SpawnTimer;
	void Update () {
        if (!CanSpawn)
        {
			return;
        }
        if (SpawnTimer<=0)
        {
			SpawnEnemy();
			SpawnTimer = SpawnCD;
        }
        else
        {
			SpawnTimer -= Time.deltaTime;
        }
	}
	void SpawnEnemy() 
	{
        if (GameManager.Instance.ForbitEnemyMoveShoot)
        {
			return;
        }
		SpawnCount = Random.Range(0, 5);

		for (int i = 0; i < SpawnCount; i++)
		{
			Vector3 position = Vector3.zero;
			position.x = Random.Range(-35, 35);
			position.z = 80;

			GameObject enemy = enemys[Random.Range(0, enemys.Count)];
			CraftCtrl enemyCraft = AirCraftPool.Instance.GetAirCraft(enemy.name);
			if (enemyCraft != null && enemyCraft is EnemyCraft)
			{
				(enemyCraft as EnemyCraft).InitEnemyCraft(position, rot);
			}
		}
	}
}
