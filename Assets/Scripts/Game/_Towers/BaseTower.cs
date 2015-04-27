using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Com.Game
{
	public class BaseTower : MonoBehaviour
	{
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

		private void Update()
		{
			if(_enableToFire)
			{
				List<RaycastHit> hits = Physics.SphereCastAll(transform.position, _fireDistance, Vector3.forward)
					.Where( a => a.collider.CompareTag(GameTags.EnemyTag) )
					.ToList();

				//если в радиусе есть противники ищем находящегося в зоне стрельбы
				//и при этом ближайшего к обороняемой зоне и стреляем по нему
				if(hits.Count>0)
				{

					RaycastHit hit = hits[0];
					for(int i = 1; i<hits.Count; i++)
					{
						if(hit.transform.position.x>hits[i].transform.position.x)
						{
							hit = hits[i];
						}
					}

					BaseEnemy enemy = hit.transform.GetComponent<BaseEnemy>();
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
	}
}
