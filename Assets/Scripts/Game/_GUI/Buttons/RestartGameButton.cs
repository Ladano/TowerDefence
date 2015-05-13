using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class RestartGameButton : AbstractGUIButton
	{
		public override void OnClick()
		{
			Application.LoadLevel(0);
		}
	}
}
