using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com
{
	[RequireComponent (typeof (BoxCollider))]
	public abstract class AbstractInputObject : MonoBehaviour
	{
		public abstract void OnClick();
	}
}
