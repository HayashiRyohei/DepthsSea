using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPController : MonoBehaviour {
	
	GameManager gm;
	[SerializeField]
	Image hpBar;
	[SerializeField]
	Text hpValue;

	void OnEnable() {
		if(!gm) gm = GameManager.Instance;
	}

	void Update() {
		hpBar.fillAmount = gm.HP / 100.0f;
		hpValue.text = gm.HP + "/" + 100;
	}
}
