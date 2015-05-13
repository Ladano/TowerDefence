using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class GamePanelButton : AbstractGUIButton
	{
		private const string InfoString = "Fire rate = {0}\n Fire damage = {1}\n Fire distance = {2}";

		[SerializeField] private TowerType _towerType;
		[SerializeField] private Text _infoLabel;
		private TowerData _towerData;

		private void Start()
		{
			_towerData = TowersController.GetTowerData(_towerType);

			_infoLabel.text = string.Format(InfoString, _towerData.FireSpeed, _towerData.FireDamage, _towerData.FireDistance);
		}

		public override void OnClick()
		{
			GamePanel.Build(_towerData);
		}
	}
}
