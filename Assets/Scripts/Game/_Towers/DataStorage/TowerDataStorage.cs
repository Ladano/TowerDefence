using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Com.Game
{
	public class TowerDataStorage : ScriptableObject
	{
		[SerializeField] private List<TowerData> _towersDictionary;

		public TowerData GetTowerData(TowerType towerType)
		{
			TowerData towerData = _towersDictionary.FirstOrDefault( a => a.Type==towerType );
			if(towerData==null)
			{
				towerData = _towersDictionary[0];
				Debug.LogException(new System.Exception("В справочнике нет элемента с типом " + towerType.ToString() + ", установлено значение _towersDictionary[0]"));
			}
			return towerData;
		}
	}
}
