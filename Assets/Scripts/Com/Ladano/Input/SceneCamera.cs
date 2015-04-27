using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Com.MyInput
{
	public class SceneCamera : MonoBehaviour
	{
		private const float RayDistance = 1000.0f;

		[SerializeField] private LayerMask _raycastLayerMask = -1;
		private Camera _camera;

		private void Awake()
		{
			_camera = gameObject.camera;
		}

		private void Update()
		{
			if(Input.GetMouseButtonDown(0))
			{
				Vector3 _currentTouchPos = _camera.ScreenToWorldPoint(Input.mousePosition);

				Ray ray = new Ray(_currentTouchPos, Vector3.forward);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit, RayDistance, _raycastLayerMask))
				{
					AbstractInputObject elem = hit.collider.gameObject.GetComponent<AbstractInputObject>();
					if(elem!=null)
					{
						elem.OnClick();
					}
				}
			}
		}
	}
}
