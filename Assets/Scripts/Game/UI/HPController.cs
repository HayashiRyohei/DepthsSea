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
		hpBar.fillAmount = gm.HP / (float)gm.MaxHP;
		hpValue.text = gm.HP + "/" + gm.MaxHP;
	}
}
