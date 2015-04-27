using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	[System.Serializable]
	public class EnemySpawnChance
	{
		public float MinChance;
		public float MaxChance;
		public GameObject EnemyPrefab;
		[HideInInspector] public GenericPool<BaseEnemy> _enemyPool;

		public void Init()
		{
			_enemyPool = new GenericPool<BaseEnemy>(EnemyPrefab, 5);
		}

		public BaseEnemy GetNewEnemy()
		{
			return _enemyPool.GetObjectFromPool();
		}

		public void ReleaseEnemy(BaseEnemy enemy)
		{
			_enemyPool.ReleaseObject(enemy);
		}
	}
}
