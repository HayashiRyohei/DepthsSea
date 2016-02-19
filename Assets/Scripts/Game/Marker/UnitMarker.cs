using UnityEngine;
using System.Collections;

/// <summary>
/// これに触れると、Unit選択となる.
/// </summary>

public class UnitMarker : MonoBehaviour {
	// 配置されるユニットの向き.
	[SerializeField]
	Vector3 dir;
	// 配置されるユニット.
	GameObject unit;
	// ユニットの情報を表示するパネル.
	GameObject unitInfoPanel;
	// ユニットの配置場所.
	private Vector3 setPos;

	void Start() {
		Vector3 pos = transform.position;
		setPos = new Vector3 (pos.x, pos.y, 1.0f);
	}

	/// <summary>
	/// ユニットを配置する.
	/// </summary>
	public void SetUnit(GameObject selectUnit) {
		if (unit != null) {
			DeleteUnit ();
		}
		unit = (GameObject)Instantiate (selectUnit);
		unit.transform.position = setPos;
		unit.transform.Rotate (dir);
		unitInfoPanel.SetActive (false);
	}

	/// <summary>
	/// ユニットを削除する.
	/// </summary>
	public void DeleteUnit () {
		Destroy (unit);
		unitInfoPanel.SetActive (false);
	}
}