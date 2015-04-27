using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class PauseGameButton : AbstractInputObject
	{
		public override void OnClick()
		{
			ScreenManager.ShowScreen(ScreenType.PauseGame);
		}
	}
}