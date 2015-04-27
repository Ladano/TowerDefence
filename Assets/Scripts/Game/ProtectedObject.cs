using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class ProtectedObject : MonoBehaviour
	{
		private static ProtectedObject _instance;
		[SerializeField] private int _hp = 5;

		private void Awake()
		{
			_instance = this;
		}

		public static void MinusOneHp()
		{
			_instance._hp -= 1;
			if(_instance._hp==0)
			{
				GameManager.LooseGame();
			}
		}
	}
}
