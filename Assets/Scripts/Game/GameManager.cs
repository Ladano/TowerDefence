using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Com.Game
{
	public class GameManager : MonoBehaviour
	{
		public static event Action OnGameStart;
		public static event Action OnGameEnd;

		private static GameManager _instance;
		[SerializeField] private GameObject _bulletPrefab;
		[SerializeField] private float _gameTime;
		[SerializeField] private Text _timerLabel;
		private float _gameTimer;
		private bool _isGameInProgress = false;

		private void Awake()
		{
			_instance = this;
			BulletPool.InitPool(_bulletPrefab);
		}

		private void Start()
		{
			ScreenManager.ShowScreen(ScreenType.StartGame);
		}

		public static void StartGame()
		{
			_instance.StartGameEvent();
		}

		public static void LooseGame()
		{
			ScreenManager.ShowScreen(ScreenType.LooseGame);
			_instance.EndGameEvent();
		}

		private void WinGame()
		{
			ScreenManager.ShowScreen(ScreenType.WinGame);
			EndGameEvent();
		}

		private void StartGameEvent()
		{
			_isGameInProgress = true;
			_gameTimer = 0.0f;
			if(OnGameStart!=null)
			{
				OnGameStart();
			}
		}

		private void EndGameEvent()
		{
			_isGameInProgress = false;
			if(OnGameEnd!=null)
			{
				OnGameEnd();
			}
		}

		private void Update()
		{
			if(_isGameInProgress)
			{
				_gameTimer += Time.deltaTime;
				_timerLabel.text = string.Format("Осталось времени: {0}",  (Mathf.Round(_gameTime - _gameTimer)).ToString());
				if(_gameTimer>_gameTime)
				{
					WinGame();
				}
			}

		}
	}
}
