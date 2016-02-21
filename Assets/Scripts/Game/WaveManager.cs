using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
/// <summary>
/// ウェーブを管理する人
/// </summary>
public class WaveManager : SingletonMonoBehaviour<WaveManager> {

	/// <summary>
	/// エミッター情報
	/// </summary>
	[Serializable]
	public class EmitterInfo {
		public EnemyEmitter emitter;	//エミッター
		public int unlockLevel;			//解放レベル
	}
	//エミッター
	public EmitterInfo[] emitters;
	//UI
	public Text waveCountText;

#region Function
	/// <summary>
	/// ウェーブの開始
	/// </summary>
	public void WaveStart(int level) {
		//エミッター解放
		for (int i = 0; i < emitters.Length; i++) {
			if (emitters[i].unlockLevel <= level) {
				emitters[i].emitter.emitLevel = level;
				emitters[i].emitter.enabled = true;
			} else {
				emitters[i].emitter.enabled = false;
			}
		}
		//UI
		waveCountText.text = level.ToString();
	}
	/// <summary>
	/// ウェーブの終了
	/// </summary>
	public void WaveEnd() {
		//エミッターの停止
		for(int i = 0; i < emitters.Length; i++) {
			emitters[i].emitter.EmitObjectDestroy();
			emitters[i].emitter.enabled = false;
		}
	}
#endregion
}
