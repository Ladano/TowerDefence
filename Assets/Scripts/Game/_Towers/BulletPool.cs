using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class BulletPool
	{
		private static GenericPool<TowerBullet> _bulletPool;

		public static void InitPool(GameObject bulletPrefab)
		{
			_bulletPool = new GenericPool<TowerBullet>(bulletPrefab, 10);
		}

		public static TowerBullet GetBullet()
		{
			return _bulletPool.GetObjectFromPool();
		}

		public static void ReleaseBullet(TowerBullet bullet)
		{
			_bulletPool.ReleaseObject(bullet);
		}
	}
}
