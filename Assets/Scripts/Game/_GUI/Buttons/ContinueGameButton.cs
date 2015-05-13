using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class ContinueGameButton : AbstractGUIButton
	{
		public override void OnClick()
		{
			ScreenManager.HideScreen();
		}
	}
}