using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class TowersController : AbstractController
	{
		private static TowersController _instance;
		[SerializeField] private TowerDataStorage _towersData;

		private static GenericPool<BaseTower> _tower1Pool;
		private static GenericPool<BaseTower> _tower2Pool;
		private static GenericPool<BaseTower> _tower3Pool;

		protected override void Init()
		{
			_instance = this;
			_tower1Pool = new GenericPool<BaseTower>(GetTowerPrefab(TowerType.Tower1), 5);
			_tower2Pool = new GenericPool<BaseTower>(GetTowerPrefab(TowerType.Tower2), 5);
			_tower3Pool = new GenericPool<BaseTower>(GetTowerPrefab(TowerType.Tower3), 5);
		}
		
		protected override void StartGame()
		{

		}
		
		protected override void EndGame()
		{
			
		}

		private GameObject GetTowerPrefab(TowerType towerType)
		{
			return _towersData.GetTowerData(towerType).TowerPrefab;
		}

		public static BaseTower GetTowerToBuild(TowerType towerType)
		{
			BaseTower result = null;
			switch (towerType)
			{
			case TowerType.Tower1:
				result = _tower1Pool.GetObjectFromPool();
				break;
			case TowerType.Tower2:
				result = _tower2Pool.GetObjectFromPool();
				break;
			case TowerType.Tower3:
				result = _tower3Pool.GetObjectFromPool();
				break;
			default:
				result = _tower1Pool.GetObjectFromPool();
				break;
			}
			return result;
		}

		public static TowerData GetTowerData(TowerType towerType)
		{
			return _instance._towersData.GetTowerData(towerType);
		}
	}
}
