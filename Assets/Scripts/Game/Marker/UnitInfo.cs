using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// ユニットの情報.
/// </summary>

public class UnitInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	// ユニットの情報.
	[SerializeField, Multiline]
	string info;
	// 情報を表示する場所.
	[SerializeField]
	Text textInfo;
	// 選択された時にセットするユニット.
	[SerializeField]
	GameObject unit;

	/// <summary>
	/// ユニットを配置する.
	/// </summary>
	public void SelectUnit() {
		GameManager.Instance.Marker.GetComponent<UnitMarker> ().SetUnit (unit);
	}

	/// <summary>
	/// マウスが乗ると,情報が表示される.
	/// </summary>
	public void OnPointerEnter(PointerEventData eventData) {
		textInfo.text = info;
	}

	/// <summary>
	/// マウスが離れると,情報が消える.
	/// </summary>
	public void OnPointerExit(PointerEventData eventData) {
		textInfo.text = "";
	}

}

