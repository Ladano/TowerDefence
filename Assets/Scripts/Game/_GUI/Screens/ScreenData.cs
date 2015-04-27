using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.GUI
{
	[System.Serializable]
	public class ScreenData
	{
		public ScreenType Type;
		public GameObject ScreenGO;

		public void Show()
		{
			ScreenGO.SetActive(true);
		}

		public void Hide()
		{
			ScreenGO.SetActive(false);
		}
	}
}