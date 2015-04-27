using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Com.GUI;

namespace Assets.Scripts.Com
{
	public class ScreenManager : MonoBehaviour
	{
		private static ScreenManager _instance;
		private static ScreenData _currentActiveScreen;
		[SerializeField] private List<ScreenData> _screens;

		private void Awake()
		{
			_instance = this;
		}

		private ScreenData GetScreen(ScreenType type)
		{
			ScreenData screen = _screens.FirstOrDefault( a => a.Type==type );
			if(screen==null)
			{
				screen = _screens[0];
				Debug.LogException(new System.Exception("Missing screen, set to _screens[0] element"));
			}
			return screen;
		}

		public static void ShowScreen(ScreenType type)
		{
			Time.timeScale = 0.0f;
			_currentActiveScreen = _instance.GetScreen(type);
			_currentActiveScreen.Show();
			BlackScreen.Show();
		}

		public static void HideScreen()
		{
			if(_currentActiveScreen!=null)
			{
				Time.timeScale = 1.0f;
				_currentActiveScreen.Hide();
				BlackScreen.Hide();
			}
			else
			{
				Debug.LogException(new System.Exception("Вызов функции скрытия Screen, когда ни один из них не показан"));
			}
		}
	}
}
