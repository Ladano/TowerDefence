using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class TowerSpot : AbstractInputObject
	{
		[SerializeField] private Transform _buildSpot;
		private BaseTower _tower;
		private Transform _towerTransform;

		public override void OnClick()
		{
			GamePanel.Show(BuildTower);
		}

		public void BuildTower(TowerData towerData)
		{
			collider.enabled = false;

			_tower = TowersController.GetTowerToBuild(towerData.Type);
			_towerTransform = _tower.transform;
			_towerTransform.parent = _buildSpot;
			_towerTransform.localPosition = Vector3.zero;
			_towerTransform.localScale = Vector3.one;
			_tower.Init(towerData.FireSpeed, towerData.FireDamage, towerData.FireDistance);
			GamePanel.Hide();
		}
	}
}
