using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	[System.Serializable]
	public class TowerData
	{
		public TowerType Type;
		public GameObject TowerPrefab;
		public float FireSpeed;
		public float FireDamage;
		public float FireDistance;
	}
}
