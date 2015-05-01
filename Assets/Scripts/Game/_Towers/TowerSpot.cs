using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class TowerSpot : AbstractInputObject
	{
		[SerializeField] private Transform _buildSpot;
		private GameObject _tower;

		public override void OnClick()
		{
			GamePanel.Show(BuildTower);
		}

		public void BuildTower(TowerData towerData)
		{
			_tower = Instantiate(TowersController.GetTowerPrefab(towerData.Type)) as GameObject;
			_tower.transform.parent = _buildSpot;
			_tower.transform.localPosition = Vector3.zero;
			_tower.transform.localScale = Vector3.one;
			_tower.GetComponent<BaseTower>().Init(towerData.FireDamage, towerData.FireDistance, towerData.FireDistance);
			GamePanel.Hide();
		}
	}
}
