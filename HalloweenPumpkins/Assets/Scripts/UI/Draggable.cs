using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private Vector3 startPos;

	public GameObject BombPrefab;

	public void OnBeginDrag (PointerEventData eventData)
	{
		Debug.Log ("OnBeginDrag");
		startPos = transform.position;
	}

	public void OnDrag (PointerEventData eventData)
	{
		Debug.Log ("OnDrag");
		Debug.Log (eventData.position);
		this.transform.position = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		Debug.Log ("OnEndDrag");

		if (BombManger.BombsCount > 0)
		{
			transform.position = startPos;

			Vector3 offset = new Vector3 (0f, 0f, 10f);
			Vector3 pos = Camera.main.ScreenToWorldPoint (eventData.position) + offset;

			GameObject Bomd = Instantiate (BombPrefab, pos, Quaternion.identity) as GameObject;

			BombManger.RemoveBombs (1);

			if(BombManger.BombsCount == 0)
			{
				GameManager.Instance.GameViewUI.HideBombContainer ();
			}
		} 
	}
}
