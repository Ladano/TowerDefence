using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Com.Game
{
	public class DefaultGetTargetToFire : AbstractGetTargetToFire
	{
		public override BaseEnemy GetTargetToFire(List<RaycastHit> hits)
		{
			RaycastHit hit = hits[0];
			for(int i = 1; i<hits.Count; i++)
			{
				if(hit.transform.position.x>hits[i].transform.position.x)
				{
					hit = hits[i];
				}
			}
			
			return hit.transform.GetComponent<BaseEnemy>();
		}
	}
}
