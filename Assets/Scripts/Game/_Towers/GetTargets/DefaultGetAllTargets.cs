using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Com.Game
{
	public class DefaultGetAllTargets : AbstractGetAllTargets
	{
		public override List<RaycastHit> GetAllHits(float fireDistance)
		{
			List<RaycastHit> result = Physics.SphereCastAll(transform.position, fireDistance, Vector3.forward)
				.Where( a => a.collider.CompareTag(GameTags.EnemyTag) )
				.ToList();
			return result;
		}
	}
}
