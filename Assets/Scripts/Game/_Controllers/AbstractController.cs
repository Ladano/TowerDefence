using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public abstract class AbstractController : MonoBehaviour
	{
		protected bool _isGameActive = false;

		private void OnEnable()
		{
			GameManager.OnGameStart += StartGameEvent;
			GameManager.OnGameEnd += EndGameEvent;
		}

		private void OnDisable()
		{
			GameManager.OnGameStart -= StartGameEvent;
			GameManager.OnGameEnd -= EndGameEvent;
		}

		private void Awake()
		{
			Init();
		}

		private void StartGameEvent()
		{
			_isGameActive = true;
			StartGame();
		}

		private void EndGameEvent()
		{
			_isGameActive = false;
			EndGame();
		}

		protected abstract void Init();

		protected abstract void StartGame();

		protected abstract void EndGame();
	}
}
