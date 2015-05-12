using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Com.Game
{
	public abstract class AbstractGetTargetToFire : MonoBehaviour
	{
		public abstract BaseEnemy GetTargetToFire(List<RaycastHit> hits);
	}
}
