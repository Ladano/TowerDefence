using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Com.Game
{
	public abstract class AbstractGetAllTargets : MonoBehaviour
	{
		public abstract List<RaycastHit> GetAllHits(float fireDistance);
	}
}
