using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com
{
	public class TestInputObject : AbstractInputObject
	{
		public override void OnClick()
		{
			Debug.Log("Click " + gameObject.name);
		}
	}
}
