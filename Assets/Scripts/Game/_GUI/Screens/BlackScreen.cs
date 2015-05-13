using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Com.MyInput;

namespace Assets.Scripts.Com.GUI
{
	public class BlackScreen : MonoBehaviour
	{
		private static BlackScreen _instance;
		[SerializeField] private Color _showColor;
		[SerializeField] private Color _hideColor;
		[SerializeField] private Image _blackScreen;
		[SerializeField] private float _showTime = 0.2f;
		[SerializeField] private SceneCamera _sceneCamera;

		private void Awake()
		{
			_instance = this;
		}

		public static void Show()
		{
			_instance.TweenAlpha (_instance._showColor, false);
			_instance.SetImageState(true);
			_instance._sceneCamera.SetState(false);
		}

		public static void Hide()
		{
			_instance.TweenAlpha(_instance._hideColor, true);
			_instance._sceneCamera.SetState(true);
		}

		private void TweenAlpha(Color newColor, bool changeImageState)
		{
			if(changeImageState)
			{
				LeanTween.value (gameObject, _blackScreen.color, newColor, _showTime)
					.setOnUpdate ((color) => _blackScreen.color = color)
					.setOnComplete (SetImageState, false)
					.setUseEstimatedTime (true);
			}
			else
			{
				LeanTween.value (gameObject, _blackScreen.color, newColor, _showTime)
					.setOnUpdate ((color) => _blackScreen.color = color)
					.setUseEstimatedTime (true);
			}
		}

		private void SetImageState(object state)
		{
			_blackScreen.enabled = (bool)state;
		}
	}
}

