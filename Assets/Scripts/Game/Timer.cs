using UnityEngine;
using System.Collections;

/// <summary>
/// Timer.
/// 背景とか変える人.
/// </summary>

public class Timer : MonoBehaviour {
	static int time = 0;
	[SerializeField]
	int lapTime;
	[SerializeField]
	Animator backgroundAnimator;


	IEnumerator Start () {
		while (true) {
			switch (GameManager.Instance.state) {
			case GameManager.State.WAIT:  // 配置中.
				// とりあえず、ソッコーでPlayへ.
				PlayGame();
				break;
			case GameManager.State.PLAY: // タワーディフェンス中.

				if (time >= lapTime) { // ラップタイムを超えたら.
					time = lapTime;
					GameManager.Instance.state = GameManager.State.RESULT;
					backgroundAnimator.SetBool ("play", false);
					Application.LoadLevelAdditive ("_SubResult");
				}

				// 時間を進める.
				time++;
				Debug.Log (time);

				yield return new WaitForSeconds (1.0f);
				break;
			case GameManager.State.RESULT: // 小リザルト中.
				break;
			}
			yield return 0;
		}
	}


	public void PlayGame() {
		backgroundAnimator.SetBool ("play", true);
		GameManager.Instance.waveCount++;
		GameManager.Instance.state = GameManager.State.PLAY;
	}


	/// <summary>
	/// タイマーを戻す.
	/// </summary>
	public void TimerReset() {
		time = 0;
		GameManager.Instance.state = GameManager.State.WAIT;
		Application.UnloadLevel ("_SubResult");
	}
}
