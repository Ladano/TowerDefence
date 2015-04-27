using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Assets.Scripts.Com.Game
{
	public class SortingRenderLayer : EditorWindow
	{
		[MenuItem("Utils/Sorting Render Layer")]
		private static void Init()
		{
			GetWindow<SortingRenderLayer>("Sorting Render Layer");
		}

		private string _sortingLayer;
		private int _sortingLayerOrder;

		private void OnGUI()
		{
			_sortingLayer = EditorGUILayout.TextField(_sortingLayer);
			_sortingLayerOrder = EditorGUILayout.IntField(_sortingLayerOrder);

			if(GUILayout.Button("Sort"))
			{
				Selection.activeTransform.renderer.sortingLayerName = _sortingLayer;
				Selection.activeTransform.renderer.sortingOrder = _sortingLayerOrder;
			}
		}	
	}
}
