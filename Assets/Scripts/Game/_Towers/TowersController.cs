using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class TowersController : AbstractController
	{
		private static TowersController _instance;
		[SerializeField] private TowerDataStorage _towersData;

		protected override void Init()
		{
			_instance = this;
		}
		
		protected override void StartGame()
		{

		}
		
		protected override void EndGame()
		{
			
		}

		public static GameObject GetTowerPrefab(TowerType towerType)
		{
			return _instance._towersData.GetTowerData(towerType).TowerPrefab;
		}

		public static TowerData GetTowerData(TowerType towerType)
		{
			return _instance._towersData.GetTowerData(towerType);
		}
	}
}
