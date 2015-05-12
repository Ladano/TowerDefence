using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Com.Game
{
	public class BaseTower : MonoBehaviour
	{
		[SerializeField] private AbstractGetAllTargets _getAllTargets;
		[SerializeField] private AbstractGetTargetToFire _getTargetToFire;
		private float _fireSpeed;
		private float _fireDamage;
		private float _fireDistance;
		[SerializeField] private TextMesh _cooldownLabel;
		private bool _enableToFire = true;
		private float _currentFireCooldown;

		public void Init(float fireSpeed, float fireDamage, float fireDistance)
		{
			_fireSpeed = fireSpeed;
			_fireDamage = fireDamage;
			_fireDistance = fireDistance;
		}

		private void Fire(BaseEnemy enemy)
		{
			TowerBullet bullet = BulletPool.GetBullet();
			bullet.FireToEnemy(this, enemy);

			_currentFireCooldown = 1 / _fireSpeed;
			_enableToFire = false;
		}

		public void DealDamage(BaseEnemy enemy)
		{
			enemy.GettingDamage(_fireDamage);
		}

		private void FireCooldown()
		{
			if(!_enableToFire)
			{
				_currentFireCooldown -= Time.deltaTime;
				_cooldownLabel.text = string.Format("{0}s", System.Math.Round(_currentFireCooldown, 2));
				if(_currentFireCooldown<=0)
				{
					_cooldownLabel.text = "";
					_enableToFire = true;
				}
			}
		}

		private void Update()
		{
			if(_enableToFire)
			{
				List<RaycastHit> hits = _getAllTargets.GetAllHits(_fireDistance);

				//если в радиусе есть противники
				if(hits.Count>0)
				{
					BaseEnemy enemy = _getTargetToFire.GetTargetToFire(hits);
					if(enemy!=null)
					{
						Fire(enemy);
					}
					else
					{
						Debug.LogException(new System.Exception("Missing BaseEnemy script on Enemy"));
					}
				}
			}

			//обратный отсчет стрельбы
			FireCooldown();
		}
	}
}
