using UnityEngine;
using System.Collections;

/// <summary>
/// Rayを飛ばす.
/// </summary>

public class Raycaster : MonoBehaviour {
	[SerializeField]
	LayerMask layerMask;
	[SerializeField]
	GameObject unitInfoPanel;

	void Update() {
		// if (GameManager.Instance.state == GameManager.State.WAIT) {
			if (Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();
				if (Physics.Raycast(ray , out hit, layerMask)) {
					unitInfoPanel.SetActive (true);
					GameManager.Instance.Marker = hit.collider.gameObject;
				}
			}
		// }
	}

}