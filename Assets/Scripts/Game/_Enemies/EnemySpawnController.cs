using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Com.Game
{
	public class EnemySpawnController : AbstractController
	{
		[SerializeField] private List<MoveLine> _lines;
		[SerializeField] private List<EnemySpawnChance> _spawnChanceTable;
		[SerializeField] private float _spawnRate = 2.0f;

		protected override void Init()
		{
			_spawnChanceTable.ForEach( a => a.Init() );
		}

		protected override void StartGame()
		{
			InvokeRepeating("SpawnEnemy", 1.0f, _spawnRate);
		}

		protected override void EndGame()
		{
			CancelInvoke("SpawnEnemy");
		}


		//спав проихожит по таблице вероятности заложенной в _spawnChanceTable
		private void SpawnEnemy()
		{
			int chance = Random.Range(0, 100);
			EnemySpawnChance enemyToSpawn = _spawnChanceTable.FirstOrDefault( a => a.MinChance<=chance && a.MaxChance>chance);
			if(enemyToSpawn==null)
			{
				Debug.LogException(new System.Exception("Missing enemy spawn chance zone, set to _spawnChanceTable[0] element"));
				enemyToSpawn = _spawnChanceTable[0];
			}

			int lineId = Random.Range(0, _lines.Count);
			BaseEnemy newEnemy = enemyToSpawn.GetNewEnemy();
			newEnemy.Init(_lines[lineId], enemyToSpawn);
		}
	}
}
