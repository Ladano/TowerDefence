using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class StartGameButton : AbstractInputObject
	{
		public override void OnClick()
		{
			GameManager.StartGame();
			ScreenManager.HideScreen();
		}
	}
}
