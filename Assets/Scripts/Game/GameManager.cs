using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {
	// ゲームのスコア(初期状態は0).
	int score{get;}
	// デプシー神殿のHP(初期状態は100).
	int HP{get; private set;}
	// Wave数(初期状態は0).
	int waveCount{get; private set;}
	// ゲームのステータス.
	public enum State{WAIT,PLAY,RESULT,};
	public State state = State.PLAY;
	// これがtrueなら、ノーダメージ(初期状態はtrue).
	bool isNoDamage{get; private set;}

	void Awake() {
		InitManager ();
	}

	/// <summary>
	/// 初期化用.
	/// </summary>
	private void InitManager() {
		this.score = 0;
		this.HP = 100;
		this.waveCount = 0;
		isNoDamage = true;
	}

	/// <summary>
	/// HPを1削る.
	/// </summary>
	public void Damage() {
		this.HP--;
		// ノーダメージではなくなる.
		isNoDamage = false;
	}

	/// <summary>
	/// Wave数を増やす.
	/// </summary>
	public void AddWave() { 
		waveCount++;
	}
}