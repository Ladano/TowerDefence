using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;
		public static T Instance
		{
			get
			{
				if(_instance==null)
				{
					GameObject go = new GameObject();
					_instance = go.AddComponent<T>();
				}
				return _instance;
			}
		}
		
		protected virtual void Awake()
		{
			if(_instance!=null && _instance!=this)
			{
				Destroy(gameObject);
				return;
			}
			_instance = this as T;
			DontDestroyOnLoad(gameObject);
		}
	}
}
