using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.GUI
{
	public class BlackScreen : MonoBehaviour
	{
		private const float ShowAlpha = 0.75f;
		private const float HideAlpha = 0.0f;

		private static BlackScreen _instance;
		[SerializeField] private float _showTime = 0.2f;

		private void Awake()
		{
			_instance = this;
		}

		public static void Show()
		{
			TweenAlpha(ShowAlpha);
			_instance.collider.enabled = true;
		}

		public static void Hide()
		{
			TweenAlpha(HideAlpha);
			_instance.collider.enabled = false;
		}

		public static void TweenAlpha(float alpha)
		{
			LeanTween.alpha(_instance.gameObject, alpha, _instance._showTime)
				.setUseEstimatedTime(true);
		}
	}
}
