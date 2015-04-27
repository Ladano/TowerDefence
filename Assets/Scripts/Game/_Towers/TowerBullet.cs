using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class TowerBullet : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _bulletSprite;
		[SerializeField] private Color _matDedaultColor;
		[SerializeField] private Color _matOnKillTargetColor;
		private const float BulletSpeed = 3.0f;

		private BaseTower _tower;
		private BaseEnemy _enemy;
		private Transform _target;
		private bool _isFired;
		private bool _isTargetAlive;
		private Vector3 _targetLastPosition;

		//выстрел по противнику
		public void FireToEnemy(BaseTower tower, BaseEnemy enemy)
		{
			_bulletSprite.color = _matDedaultColor;

			_isFired = true;
			_isTargetAlive = true;

			_tower = tower;
			_enemy = enemy;
			_target = enemy.transform;
			_enemy.OnDeath += DeathTarget;

			transform.position = _tower.transform.position;
		}

		//ивент сробатывает при смерти цели если снаряд еще до нее не достиг
		//кеширует последнее место положение цели и летит к нему после чего освобождается
		//изменение цвета сделано для наглядности
		private void DeathTarget()
		{
			_bulletSprite.color = _matOnKillTargetColor;
			_targetLastPosition = _target.position;
			_isTargetAlive = false;
			_enemy.OnDeath -= DeathTarget;
		}

		//обработка полета снаряад
		private void Update()
		{
			if(_isFired)
			{
				float step = BulletSpeed * Time.deltaTime;
				Vector3 _to = (_isTargetAlive) ? _target.position : _targetLastPosition;
				transform.position = Vector3.MoveTowards(transform.position, _to, step);
				if(transform.position==_to)
				{
					HitTarget();
				}
			}
		}

		//попадание в цель
		private void HitTarget()
		{
			if(_isTargetAlive)
			{
				_tower.DealDamage(_enemy);
				_enemy.OnDeath -= DeathTarget;
			}
			_isFired = false;
			BulletPool.ReleaseBullet(this);
		}
	}
}
