using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveController : MonoBehaviour {
	[SerializeField]
	Text waveCountText;

	void Update () {
		waveCountText.text = "Wave" + GameManager.Instance.WaveCount;
	}
}
