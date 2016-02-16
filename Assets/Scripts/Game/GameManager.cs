using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {
	// ゲームのスコア(初期状態は0).
	private  int score;
	public int Score{
		get{return this.score;}
	}
	// デプシー神殿のHP(初期状態は100).
	private int hp;
	public int HP{
		get{return this.hp;}
	}
	// Wave数(初期状態は0).
	private int waveCount;
	public int WaveCount {
		get{return this.waveCount;} 
	}
	// ゲームのステータス.
	public enum State{WAIT,PLAY,RESULT,};
	public State state = State.PLAY;
	// これがtrueなら、ノーダメージ(初期状態はtrue).
	private bool isNoDamage;

	void Awake() {
		InitManager ();
	}

	/// <summary>
	/// 初期化用.
	/// </summary>
	private void InitManager() {
		this.score = 0;
		this.hp = 100;
		this.waveCount = 0;
		isNoDamage = true;
	}

	/// <summary>
	/// HPを1削る.
	/// </summary>
	public void Damage() {
		this.hp--;
		// ノーダメージではなくなる.
		isNoDamage = false;
	}

	/// <summary>
	/// Wave数を増やす.
	/// </summary>
	public void AddWave() { 
		waveCount++;
	}

	void Update() {
		Debug.Log (this.hp);
	}
}