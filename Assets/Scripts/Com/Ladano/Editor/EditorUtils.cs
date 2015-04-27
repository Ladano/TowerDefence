using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Com;
using Assets.Scripts.Com.Utils;
using Assets.Scripts.Com.Game;

namespace Assets.Scripts.Editor
{
    public class CustomMenu
    {
		[MenuItem("Utils/Kill Player Prefs")]
		private static void KillPrefs()
		{
			PlayerPrefs.DeleteAll();
		}

		[MenuItem("Utils/Rounding transform coordinates #&q")]
		private static void RoundingTransformCoordinates()
		{
			Vector3 coords = Selection.activeTransform.localPosition;
			Selection.activeTransform.localPosition = new Vector3((float)System.Math.Round(coords.x, 2), (float)System.Math.Round(coords.y, 2), (float)System.Math.Round(coords.z, 2));
		}

		[MenuItem("Utils/Zero Transform Local Pos #&w")]
		private static void ZeroTransformCoordinates()
		{
			Selection.activeTransform.localPosition = Vector3.zero;
		}

		[MenuItem("Utils/Set Sprite Alpha 0.0f #&z")]
		private static void SetSpriteAlphaZero()
		{
			if(Selection.activeTransform.GetComponent<SpriteRenderer>()!=null)
			{
				SetSpiteAlpha(Selection.activeTransform.GetComponent<SpriteRenderer>(), 0.0f);
			}
		}

		[MenuItem("Utils/Set Sprite Alpha 0.3f #&x")]
		private static void SetSpriteAlphaHalf()
		{
			if(Selection.activeTransform.GetComponent<SpriteRenderer>()!=null)
			{
				SetSpiteAlpha(Selection.activeTransform.GetComponent<SpriteRenderer>(), 0.3f);
			}
		}

		[MenuItem("Utils/Set Sprite Alpha 1.0f #&c")]
		private static void SetSpriteAlphaOne()
		{
			if(Selection.activeTransform.GetComponent<SpriteRenderer>()!=null)
			{
				SetSpiteAlpha(Selection.activeTransform.GetComponent<SpriteRenderer>(), 1.0f);
			}
		}

		private static void SetSpiteAlpha(SpriteRenderer sprite, float alpha)
		{
			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
		}

		[MenuItem("Utils/Create Tower Data Storage")]
		private static void CreateTowerDataStorage()
		{
			ScriptableObjectUtility.CreateAsset<TowerDataStorage>();
		} 
   }
}