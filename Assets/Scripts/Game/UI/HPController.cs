using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPController : MonoBehaviour {
	[SerializeField]
	Image hpBar;

	void Update() {
		hpBar.fillAmount = GameManager.Instance.HP / 100.0f;
	}
}
