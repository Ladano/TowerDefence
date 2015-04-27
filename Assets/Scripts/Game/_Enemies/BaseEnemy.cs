using UnityEngine;
using System;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class BaseEnemy : MonoBehaviour
	{
		public event Action OnDeath;

		[SerializeField] private float _startHP;
		[SerializeField] private float _startSpeed;
		[SerializeField] private Transform _hpBar;
		private float _hp;
		private float _speed;
		private Transform _cachedTransform;
		private EnemySpawnChance _releaseObject;

		private void Awake()
		{
			_cachedTransform = transform;
		}

		/// <summary>
		/// Init with specified moveLine and releaseObject.
		/// </summary>
		/// <param name="moveLine">Move line.</param>
		/// <param name="releaseObject">Release object.</param>
		public void Init(MoveLine moveLine, EnemySpawnChance releaseObject)
		{
			_hp = _startHP;
			_speed = _startSpeed;
			_cachedTransform.position = moveLine.StartLineWp.position;
			_releaseObject = releaseObject;
			StartMove(moveLine.EndLineWp);
			UpdateHpBar(1.0f);
		}

		/// <summary>
		/// Starts the move.
		/// </summary>
		/// <param name="endMoveWP">End move Wp</param>
		private void StartMove(Transform endMoveWP)
		{
			float moveTime = Mathf.Abs(endMoveWP.position.x - _cachedTransform.position.x) / _speed;
			LeanTween.moveX(gameObject, endMoveWP.position.x, moveTime)
				.setEase(LeanTweenType.linear)
				.setOnComplete(OnMoveEnd);
		}

		/// <summary>
		/// Gettings the damage.
		/// </summary>
		/// <param name="damage">Damage.</param>
		public void GettingDamage(float damage)
		{
			_hp = Mathf.Clamp((_hp - damage), 0.0f, _startHP);
			if(_hp==0.0f)
			{
				Death();
			}
			else
			{
				UpdateHpBar(_hp / _startHP);
			}
		}

		/// <summary>
		/// Death this enemy.
		/// </summary>
		private void Death()
		{
			if(OnDeath!=null)
			{
				OnDeath();
			}

			LeanTween.cancel(gameObject);
			_releaseObject.ReleaseEnemy(this);
		}

		/// <summary>
		/// Raises the move end event.
		/// </summary>
		private void OnMoveEnd()
		{
			ProtectedObject.MinusOneHp();
			Death();
		}

		/// <summary>
		/// Updates the hp bar.
		/// </summary>
		private void UpdateHpBar(float percentHp)
		{
			_hpBar.localScale = new Vector3(percentHp, _hpBar.localScale.y, _hpBar.localScale.z);
		}
	}
}
