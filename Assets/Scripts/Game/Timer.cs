using UnityEngine;
using System.Collections;
/// <summary>
/// タイマー.
/// </summary>
public class Timer : MonoBehaviour {
	
	public float time = 60;
	private float measureTime;
	public GameObject eventHandler;
	public string eventName;
	public bool isPlay = false;

	[SerializeField]
	int lapTime;
	[SerializeField]
	Animator backgroundAnimator;
	
#region MonoBehaviourEvent
	private void OnEnable() {
		measureTime = 0f;
	}
	private void Update() {
		if(isPlay) {
			if(measureTime >= time) {
				Stop();
			}
			measureTime += Time.deltaTime;
		}
	}
#endregion
#region Function
	/// <summary>
	/// 計測開始.
	/// </summary>
	public void Play(float time) {
		this.time = time;
		measureTime = 0f;
		isPlay = true;
	}
	/// <summary>
	/// 計測開始
	/// </summary>
	public void Play(float time, GameObject eventHandler, string eventName) {
		this.eventHandler = eventHandler;
		this.eventName = eventName;
		Play(time);
	}
	/// <summary>
	/// 計測開始.
	/// </summary>
	public void Play() {
		Play(time);
	}
	/// <summary>
	/// 計測停止.
	/// </summary>
	private void Stop() {
		measureTime = 0f;
		isPlay = false;
		//イベント送信
		Notify(eventHandler, eventName, null);

		//GameManager.Instance.state = GameManager.State.WAIT;
		//Application.UnloadLevel("_SubResult");
	}
	/// <summary>
	/// イベント送信.
	/// </summary>
	private void Notify(GameObject eventHandler, string eventName, object item) {
		if(eventHandler) {
			eventHandler.SendMessage(eventName, item, SendMessageOptions.DontRequireReceiver);
		}
	}
#endregion

	/*
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

				yield return new WaitForSeconds (1.0f);
				break;
			case GameManager.State.RESULT: // 小リザルト中.
				break;
			}
			yield return 0;
		}
	}
	*/

	/// <summary>
	/// これが呼ばれると,ゲームを開始する.
	/// </summary>
	public void PlayGame() {
		backgroundAnimator.SetBool ("play", true);
		GameManager.Instance.AddWave();
		GameManager.Instance.state = GameManager.State.PLAY;
	}
}