using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class GamePanel : MonoBehaviour
	{
		private static GamePanel _instance;
		[SerializeField] private GameObject _panel;
		private System.Action<TowerData> _onChoose;

		private void Awake()
		{
			_instance = this;
		}

		public static void Show(System.Action<TowerData> onChoose)
		{
			_instance._panel.SetActive(true);
			_instance._onChoose = onChoose;
		}

		public static void Hide()
		{
			_instance._panel.SetActive(false);
		}

		public static void Build(TowerData towerData)
		{
			_instance._onChoose(towerData);
		}
	}
}
